# Umbraco Unit Testing
All example tests from the official Umbraco Documentation section on Unit Testing: https://our.umbraco.com/documentation/Implementation/Unit-Testing/

## Tests included:
- [Mocking Umbraco](UmbracoUnitTesting.Tests/Shared/UmbracoBaseTest.cs)
- [Testing ContentModel](UmbracoUnitTesting.Tests/ContentModel/ContentModelTests.cs)
- [Testing RenderMvcController](UmbracoUnitTesting.Tests/RenderMvcController/RenderMvcControllerTests.cs)
- [Testing SurfaceController](UmbracoUnitTesting.Tests/SurfaceController/SurfaceControllerTests.cs)
- [Testing UmbracoApiController](UmbracoUnitTesting.Tests/UmbracoApiController/UmbracoApiControllerTests.cs)
- [Testing ICultureDictionary using the UmbracoHelper](UmbracoUnitTesting.Tests/UmbracoHelper/CultureDictionaryTests.cs)
- [Testing IPublishedContentQuery using the UmbracoHelper](UmbracoUnitTesting.Tests/UmbracoHelper/PublishedContentQueryTests.cs)
- [Testing GetCurrentMember using the MembershipHelper](UmbracoUnitTesting.Tests/MembershipHelper/MembershipHelperTests.cs)

Note that some tests may have been renamed from the official documentation to reuse some models and controllers and thereby reudece the size of this project. Every class in this solution has a summary with a link to the official documentation, so any renaming should not be a problem.

## How to use this project:
This solution contains two projects: A **.Core** project and a **.Tests** project. You'll notice that this solution does not contain any Umbraco website.
This is intentional. Do not use this solution as a template or a base project. Use it as a reference and a source for inspiration to your own projects.
All necessary assemblies to run each test have been installed such as:

**UmbracoUnitTesting.Tests**
- UmbracoCms.Core
- UmbracoCms.Web
- NUnit
- Moq

**UmbracoUnitTesting.Core**
- UmbracoCms.Core
- UmbracoCms.Web
