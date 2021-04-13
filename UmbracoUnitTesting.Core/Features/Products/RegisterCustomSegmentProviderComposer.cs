using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Strings;

namespace UmbracoUnitTesting.Core.Features.Products {
    // <inheritdoc />
    // <summary>
    // Docs: https://our.umbraco.com/documentation/reference/routing/request-pipeline/outbound-pipeline#example
    // </summary>
    public class RegisterCustomSegmentProviderComposer : IUserComposer {
        public void Compose(Composition composition)
        {
            composition.Register<IUrlSegmentProvider, DefaultUrlSegmentProvider>();
            composition.UrlSegmentProviders().Insert<ProductPageUrlSegmentProvider>();
        }
    }
}
