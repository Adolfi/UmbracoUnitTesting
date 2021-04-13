using Umbraco.Core.Models;
using Umbraco.Core.Strings;

namespace UmbracoUnitTesting.Core.Features.Products {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/reference/routing/request-pipeline/outbound-pipeline#1--create-segments
    /// </summary>
    public class ProductPageUrlSegmentProvider : IUrlSegmentProvider {
        private readonly IUrlSegmentProvider provider;

        public ProductPageUrlSegmentProvider(IUrlSegmentProvider urlSegmentProvider){
            provider = urlSegmentProvider;
        }

        public string GetUrlSegment(IContentBase content, string culture = null)
        {
            if (content.ContentType.Alias != "productPage") return null;
            var segment = provider.GetUrlSegment(content, culture);
            var productSku = content.GetValue(propertyTypeAlias: "productSku", culture: culture, segment: null, published: true);
            return string.Format("{0}-{1}", segment, productSku);
        }
    }
}