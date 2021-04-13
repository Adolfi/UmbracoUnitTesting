using Moq;
using NUnit.Framework;
using Umbraco.Core.Models;
using Umbraco.Core.Strings;
using UmbracoUnitTesting.Core.Features.Products;

namespace UmbracoUnitTesting.Tests.Routing {
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/reference/routing/request-pipeline/outbound-pipeline#1--create-segments
    /// </summary>
    public class ProductPageUrlSegmentProviderTests {
        private readonly Mock<IUrlSegmentProvider> defaultUrlSegmentProvider;
        private readonly ProductPageUrlSegmentProvider productPageUrlSegmentProvider;

        public ProductPageUrlSegmentProviderTests()
        {
            this.defaultUrlSegmentProvider = new Mock<IUrlSegmentProvider>();
            this.productPageUrlSegmentProvider = new ProductPageUrlSegmentProvider(defaultUrlSegmentProvider.Object);
        }
        
        [Test]
        [TestCase("en", "swibble", "123xyz", "swibble-123xyz")]
        [TestCase("en-US", "dibble", "456abc", "dibble-456abc")]
        public void Given_ProductHasSku_When_GetUrlSegment_Then_ReturnExpectedUrlSegment(string culture, string defaultUrlSegment, string productSku, string expected)
        {
            // Arrange
            var contentType = new Mock<ISimpleContentType>();
            contentType.Setup(x => x.Alias).Returns("productPage");

            var content = new Mock<IContentBase>();
            content.Setup(x => x.ContentType).Returns(contentType.Object);
            content.Setup(x => x.GetValue("productSku", culture, null, true)).Returns(productSku);

            defaultUrlSegmentProvider.Setup(x => x.GetUrlSegment(content.Object, culture)).Returns(defaultUrlSegment);
            
            // Act
            var result = productPageUrlSegmentProvider.GetUrlSegment(content.Object, culture);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
