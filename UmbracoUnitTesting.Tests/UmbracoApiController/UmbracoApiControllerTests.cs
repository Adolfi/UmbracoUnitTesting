using Moq;
using NUnit.Framework;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Configuration;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence;
using Umbraco.Web;
using UmbracoUnitTesting.Core.Features.Products;
using UmbracoUnitTesting.Tests.Shared;

namespace UmbracoUnitTesting.Tests.UmbracoApiController {
    /// <inheritdoc />
    /// <summary>
    /// Docs: https://our.umbraco.com/documentation/Implementation/Unit-Testing/#testing-an-umbracoapicontroller
    /// </summary>
    [TestFixture]
    public class UmbracoApiControllerTests : UmbracoBaseTest 
    {
        private ProductsController controller;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.controller = new ProductsController(Mock.Of<IGlobalSettings>(), Mock.Of<IUmbracoContextAccessor>(), Mock.Of<ISqlContext>(), this.ServiceContext, AppCaches.NoCache, Mock.Of<IProfilingLogger>(), Mock.Of<IRuntimeState>(), base.UmbracoHelper, base.UmbracoMapper);
        }

        [Test]
        public void WhenGetAllProducts_ThenReturnViewModelWithExpectedProducts()
        {
            var expected = new[] { "Table", "Chair", "Desk", "Computer", "Beer fridge" };

            var result = this.controller.GetAllProducts();

            Assert.AreEqual(expected, result);
        }
    }
}
