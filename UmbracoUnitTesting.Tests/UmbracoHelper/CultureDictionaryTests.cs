using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Dictionary;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using UmbracoUnitTesting.Core.Features.Home;
using UmbracoUnitTesting.Tests.Shared;

namespace UmbracoUnitTesting.Tests.UmbracoHelper {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-iculturedictionary-using-the-umbracohelper
    /// </summary>
    [TestFixture]
    public class CultureDictionaryTests : UmbracoBaseTest {
        private HomeController controller;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.controller = new HomeController(Mock.Of<IGlobalSettings>(), Mock.Of<IUmbracoContextAccessor>(), base.ServiceContext, AppCaches.NoCache, Mock.Of<IProfilingLogger>(), base.UmbracoHelper);
        }

        [Test]
        [TestCase("myDictionaryKey", "myDictionaryValue")]
        public void GivenMyDictionaryKey_WhenIndexAction_ThenReturnViewModelWithMyPropertyDictionaryValue(string key, string expected)
        {
            var model = new Umbraco.Web.Models.ContentModel(new Mock<IPublishedContent>().Object);
            base.CultureDictionary.Setup(x => x[key]).Returns(expected);

            var result = (HomeViewModel)((ViewResult)this.controller.Index(model)).Model;

            Assert.AreEqual(expected, result.DictionaryTitle);
        }
    }
}
