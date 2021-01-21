using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace UmbracoUnitTesting.Core.Features.StandardPage {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-a-contentmodel
    /// </summary>
    public class StandardPageViewModel : ContentModel
    {
        public StandardPageViewModel(IPublishedContent content) : base(content){}

        public string Heading => this.Content.Value<string>(nameof(Heading));
    }
}
