# Umbraco Unit Testing
All example tests from the official Umbraco Documentation section on Unit Testing: https://our.umbraco.com/documentation/Implementation/Unit-Testing/

## Tests included:
Some tests have been renamed or improved compared to the official documentation, mostly to be able to reuse models and controllers and reudece the size of each project. 
Every class in this solution has a summary with a link to the official documentation so any renaming should not be a problem.

- [Mocking Umbraco](UmbracoUnitTesting.Tests/Shared/UmbracoBaseTest.cs)
- [Testing ContentModel](UmbracoUnitTesting.Tests/ContentModel/ContentModelTests.cs)
- [Testing RenderMvcController](UmbracoUnitTesting.Tests/RenderMvcController/RenderMvcControllerTests.cs)
- [Testing SurfaceController](UmbracoUnitTesting.Tests/SurfaceController/SurfaceControllerTests.cs)
- [Testing UmbracoApiController](UmbracoUnitTesting.Tests/UmbracoApiController/UmbracoApiControllerTests.cs)
- [Testing ICultureDictionary using the UmbracoHelper](UmbracoUnitTesting.Tests/UmbracoHelper/CultureDictionaryTests.cs)
- [Testing IPublishedContentQuery using the UmbracoHelper](UmbracoUnitTesting.Tests/UmbracoHelper/PublishedContentQueryTests.cs)
- [Testing GetCurrentMember using the MembershipHelper](UmbracoUnitTesting.Tests/MembershipHelper/MembershipHelperTests.cs)

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

## Read more
Go to [adolfi.dev](https://adolfi.dev) if you want to read more Umbraco and/or Unit Testing articles.
