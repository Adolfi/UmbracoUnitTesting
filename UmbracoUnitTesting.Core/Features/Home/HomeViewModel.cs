using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace UmbracoUnitTesting.Core.Features.Home {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-a-contentmodel
    /// </summary>
    public class HomeViewModel : ContentModel
    {
        public HomeViewModel(IPublishedContent content) : base(content){}

        public string Heading { get; set; }
        public string DictionaryTitle { get; set; }
    }
}
