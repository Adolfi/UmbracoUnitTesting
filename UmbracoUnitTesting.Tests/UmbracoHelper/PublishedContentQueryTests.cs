using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using UmbracoUnitTesting.Core.Features.Member;
using UmbracoUnitTesting.Tests.Shared;

namespace UmbracoUnitTesting.Tests.UmbracoHelper {
    public class PublishedContentQueryTests : UmbracoBaseTest {
        /// <summary>
        /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-ipublishedcontentquery-using-the-umbracohelper
        /// </summary>
        private MemberProfileController controller;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.controller = new MemberProfileController(Mock.Of<IGlobalSettings>(), Mock.Of<IUmbracoContextAccessor>(), base.ServiceContext, AppCaches.NoCache, Mock.Of<IProfilingLogger>(), base.UmbracoHelper);
        }

        [Test]
        public void GivenContentQueryReturnsOtherContent_WhenIndexAction_ThenReturnViewModelWithOtherContent()
        {
            var currentContent = new Umbraco.Web.Models.ContentModel(new Mock<IPublishedContent>().Object);
            var otherContent = Mock.Of<IPublishedContent>();
            base.PublishedContentQuery.Setup(x => x.Content(1062)).Returns(otherContent);

            var result = (MemberProfileViewModel)((ViewResult)this.controller.Index(currentContent)).Model;

            Assert.AreEqual(otherContent, result.OtherContent);
        }

        [Test]
        public void GivenContentQueryReturnsContentAtRoot_WhenIndexAction_ThenReturnViewModelWithContentAtRoot()
        {
            var currentContent = new Umbraco.Web.Models.ContentModel(new Mock<IPublishedContent>().Object);
            var contentAtRoot = new List<IPublishedContent>()
            {
                Mock.Of<IPublishedContent>()
            };
            base.PublishedContentQuery.Setup(x => x.ContentAtRoot()).Returns(contentAtRoot);

            var result = (MemberProfileViewModel)((ViewResult)this.controller.Index(currentContent)).Model;

            Assert.AreEqual(contentAtRoot, result.ContentAtRoot);
        }
    }
}
