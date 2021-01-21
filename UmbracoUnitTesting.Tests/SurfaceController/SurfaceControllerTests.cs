using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Umbraco.Core.Cache;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence;
using Umbraco.Web;
using UmbracoUnitTesting.Core.Features.Hero;
using UmbracoUnitTesting.Tests.Shared;

namespace UmbracoUnitTesting.Tests.SurfaceController {
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-a-surfacecontroller
    /// </summary>
    public class SurfaceControllerTests {
        [TestFixture]
        public class MySurfaceControllerTests : UmbracoBaseTest {
            private HeroController controller;

            [SetUp]
            public override void SetUp()
            {
                base.SetUp();
                this.controller = new HeroController(Mock.Of<IUmbracoContextAccessor>(), Mock.Of<IUmbracoDatabaseFactory>(), base.ServiceContext, AppCaches.NoCache, Mock.Of<ILogger>(), Mock.Of<IProfilingLogger>(), base.UmbracoHelper);
            }

            [Test]
            public void WhenIndexAction_ThenResultIsIsAssignableFromContentResult()
            {
                var result = this.controller.Index();

                Assert.IsAssignableFrom<ContentResult>(result);
            }

            [Test]
            public void GivenResultIsAssignableFromContentResult_WhenIndexAction_ThenContentIsExpected()
            {
                var result = (ContentResult)this.controller.Index();

                Assert.AreEqual("Hello World", result.Content);
            }
        }
    }
}
