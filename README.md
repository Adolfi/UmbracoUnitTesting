# Umbraco Unit Testing
All example tests from the official Umbraco Documentation section on Unit Testing: https://our.umbraco.com/documentation/Implementation/Unit-Testing/

## Tests included:
- [Testing a ContentModel](UmbracoUnitTesting.Tests/ContentModel/ContentModelTests.cs)


## How to use this project:
This solution contains two projects: A Core project and a Tests project. You'll notice that this solution does not contain any Umbraco website.
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
