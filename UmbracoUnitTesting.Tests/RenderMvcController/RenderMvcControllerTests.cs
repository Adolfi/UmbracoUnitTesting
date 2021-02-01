using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using UmbracoUnitTesting.Core.Features.Home;
using UmbracoUnitTesting.Tests.Shared;

namespace UmbracoUnitTesting.Tests.RenderMvcController {
    /// <inheritdoc />
    /// <summary>
    /// Documentation: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-a-rendermvccontroller
    /// </summary>
    [TestFixture]
    public class RenderMvcControllerTests : UmbracoBaseTest {
        private HomeController controller;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.controller = new HomeController(Mock.Of<IGlobalSettings>(), Mock.Of<IUmbracoContextAccessor>(), base.ServiceContext, AppCaches.NoCache, Mock.Of<IProfilingLogger>(), base.UmbracoHelper);
        }

        [Test]
        public void WhenIndexAction_ThenResultIsIsAssignableFromContentResult()
        {
            var model = new Umbraco.Web.Models.ContentModel(new Mock<IPublishedContent>().Object);

            var result = this.controller.Index(model);

            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Test]
        public void GivenContentModel_WhenIndex_ThenReturnViewModelWithMyProperty()
        {
            var model = new Umbraco.Web.Models.ContentModel(new Mock<IPublishedContent>().Object);

            var result = (HomeViewModel)((ViewResult)this.controller.Index(model)).Model;

            Assert.AreEqual("Hello World", result.Heading);
        }

        [Test]
        [TestCase("/")]
        [TestCase("https://www.umbraco.com")]
        public void GivenContentModelWithUrl_WhenIndex_ThenReturnViewModelWithUrl(string url)
        {
            var content = new Mock<IPublishedContent>();
            content.Setup(x => x.Url).Returns(url);

            var model = new Umbraco.Web.Models.ContentModel(content.Object);
            
            var result = (HomeViewModel)((ViewResult)this.controller.Index(model)).Model;

            Assert.AreEqual(url, result.Url);
        }
    }
}
