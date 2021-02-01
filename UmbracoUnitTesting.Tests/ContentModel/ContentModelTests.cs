using Moq;
using NUnit.Framework;
using Umbraco.Core.Models.PublishedContent;
using UmbracoUnitTesting.Core.Features.Home;
using UmbracoUnitTesting.Core.Features.StandardPage;
using UmbracoUnitTesting.Tests.Shared;

namespace UmbracoUnitTesting.Tests.ContentModel {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-a-contentmodel
    /// </summary>
    [TestFixture]
    public class ContentModelTests : UmbracoBaseTest 
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        [Test]
        [TestCase("", "")]
        [TestCase("My Heading", "My Heading")]
        [TestCase("Another Heading", "Another Heading")]
        public void GivenPublishedContent_WhenGetHeading_ThenReturnCustomViewModelWithHeadingValue(string value, string expected)
        {
            var publishedContent = new Mock<IPublishedContent>();
            base.SetupPropertyValue(publishedContent, nameof(StandardPageViewModel.Heading), value);

            var model = new StandardPageViewModel(publishedContent.Object);

            Assert.AreEqual(expected, model.Heading);
        }

        [Test]
        [TestCase("/", "/")]
        [TestCase("/umbraco", "/umbraco")]
        [TestCase("https://www.umbraco.com", "https://www.umbraco.com")]
        public void GivenPublishedContent_WhenGetUrl_ThenReturnCustomViewModelWithUrl(string url, string expected)
        {
            var content = new Mock<IPublishedContent>();
            content.Setup(x => x.Url).Returns(url);

            var model = new StandardPageViewModel(content.Object);

            Assert.AreEqual(expected, model.Url);
        }
    }
}
