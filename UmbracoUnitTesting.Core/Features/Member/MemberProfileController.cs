using System.Web.Mvc;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoUnitTesting.Core.Features.Member {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-getcurrentmember-using-the-membershiphelper
    /// Also: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-ipublishedcontentquery-using-the-umbracohelper
    /// </summary>
    public class MemberProfileController : RenderMvcController {
        public MemberProfileController(IGlobalSettings globalSettings, IUmbracoContextAccessor umbracoContextAccessor, ServiceContext serviceContext, AppCaches appCaches, IProfilingLogger profilingLogger, UmbracoHelper umbracoHelper) : base(globalSettings, umbracoContextAccessor, serviceContext, appCaches, profilingLogger, umbracoHelper) { }

        public override ActionResult Index(ContentModel model)
        {
            var viewModel = new MemberProfileViewModel(model.Content)
            {
                Member = this.Umbraco.MembershipHelper.GetCurrentMember(), // TODO: Since writing this the UmbracoHelper.MembershipHelper is now obsolete and should instead inject MembershipHelper in the constructor. Keep this until documentation has been updated.
                OtherContent = this.Umbraco.Content(1062)
            };
            return View(viewModel);
        }
    }
}
