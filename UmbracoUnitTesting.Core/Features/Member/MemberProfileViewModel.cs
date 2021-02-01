using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace UmbracoUnitTesting.Core.Features.Member {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-getcurrentmember-using-the-membershiphelper
    /// Also: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-ipublishedcontentquery-using-the-umbracohelper
    /// </summary>
    public class MemberProfileViewModel : ContentModel {
        public MemberProfileViewModel(IPublishedContent content) : base(content) { }
        public IPublishedContent Member { get; set; }
        public IPublishedContent OtherContent { get; set; }
        public IEnumerable<IPublishedContent> ContentAtRoot { get; set; }
    }
}
