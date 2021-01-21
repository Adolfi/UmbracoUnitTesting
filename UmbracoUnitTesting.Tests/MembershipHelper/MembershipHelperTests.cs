using System.Security.Principal;
using System.Threading;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using UmbracoUnitTesting.Core.Features.Member;
using UmbracoUnitTesting.Tests.Shared;

namespace UmbracoUnitTesting.Tests.MembershipHelper
{
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-getcurrentmember-using-the-membershiphelper
    /// </summary>
    [TestFixture]
    public class MembershipHelperTests : UmbracoBaseTest
    {
        private MemberProfileController controller;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.controller = new MemberProfileController(Mock.Of<IGlobalSettings>(), Mock.Of<IUmbracoContextAccessor>(), base.ServiceContext, AppCaches.NoCache, Mock.Of<IProfilingLogger>(), base.UmbracoHelper);
        }

        [Test]
        [TestCase("member1")]
        [TestCase("member2")]
        public void GivenExistingMemberIsAuthenticated_WhenIndexAction_ThenReturnViewModelWithCurrentMember(string username)
        {
            var member = new Mock<IMember>();
            member.Setup(x => x.Username).Returns(username);
            base.memberService.Setup(x => x.GetByUsername(username)).Returns(member.Object);

            var expected = Mock.Of<IPublishedContent>();
            base.memberCache.Setup(x => x.GetByMember(member.Object)).Returns(expected);

            var identity = new Mock<IIdentity>();
            identity.Setup(user => user.IsAuthenticated).Returns(true);
            identity.Setup(user => user.Name).Returns(username);

            var principal = new Mock<IPrincipal>();
            principal.Setup(user => user.Identity).Returns(identity.Object);

            this.HttpContext.Setup(ctx => ctx.User).Returns(principal.Object);
            Thread.CurrentPrincipal = principal.Object;

            var actual = (MemberProfileViewModel) ((ViewResult) this.controller.Index(new Umbraco.Web.Models.ContentModel(Mock.Of<IPublishedContent>()))).Model;

            Assert.AreEqual(expected, actual.Member);
        }

        [Test]
        [TestCase("member1")]
        [TestCase("member2")]
        public void GivenExistingMemberIsNotAuthenticated_WhenIndexAction_ThenReturnViewModelWithNullMember(string username)
        {
            var member = new Mock<IMember>();
            member.Setup(x => x.Username).Returns(username);
            base.memberService.Setup(x => x.GetByUsername(username)).Returns(member.Object);
            base.memberCache.Setup(x => x.GetByMember(member.Object)).Returns(Mock.Of<IPublishedContent>());

            var actual = (MemberProfileViewModel)((ViewResult)this.controller.Index(new Umbraco.Web.Models.ContentModel(Mock.Of<IPublishedContent>()))).Model;

            Assert.Null(actual.Member);
        }
    }
}
