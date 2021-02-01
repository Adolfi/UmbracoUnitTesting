using System.Web.Mvc;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoUnitTesting.Core.Features.Home {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-a-contentmodel
    /// Also: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-iculturedictionary-using-the-umbracohelper
    /// </summary>
    public class HomeController : RenderMvcController 
    {
        public HomeController(IGlobalSettings globalSettings, IUmbracoContextAccessor umbracoContextAccessor, ServiceContext serviceContext, AppCaches appCaches, IProfilingLogger profilingLogger, UmbracoHelper umbracoHelper) : base(globalSettings, umbracoContextAccessor, serviceContext, appCaches, profilingLogger, umbracoHelper) { }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = new HomeViewModel(model.Content)
            {
                Heading = "Hello World",
                DictionaryTitle = this.Umbraco.GetDictionaryValue("myDictionaryKey"),
                Url = model.Content.Url
            };

            return View(viewModel);
        }
    }
}
