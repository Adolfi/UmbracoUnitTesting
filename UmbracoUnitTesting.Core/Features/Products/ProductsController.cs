using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Mapping;
using Umbraco.Core.Persistence;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.WebApi;

namespace UmbracoUnitTesting.Core.Features.Products {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-an-umbracoapicontroller
    /// </summary>
    public class ProductsController : UmbracoApiController 
    {
        public ProductsController(IGlobalSettings globalSettings, IUmbracoContextAccessor umbracoContextAccessor, ISqlContext sqlContext, ServiceContext serviceContext, AppCaches appCaches, IProfilingLogger profilingLogger, IRuntimeState runtimeState, UmbracoHelper umbracoHelper, UmbracoMapper umbracoMapper) : base(globalSettings, umbracoContextAccessor, sqlContext, serviceContext, appCaches, profilingLogger, runtimeState, umbracoHelper, umbracoMapper) { }

        public IEnumerable<string> GetAllProducts()
        {
            return new[] { "Table", "Chair", "Desk", "Computer", "Beer fridge" };
        }

        [HttpGet]
        public JsonResult GetAllProductsJson()
        {
            return new JsonResult
            {
                Data = this.GetAllProducts(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            };
        }
    }
}
