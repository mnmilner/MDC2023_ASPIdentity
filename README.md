# MDC2023_ASPIdentity
Example ASP.NET Identity API from MDC conference

Note that this example is for ASP.NET 8 and uses the preview release of Visual Studio 2022. 
When .NET 8 is released in November of 2023, the latest Visual Studio 2022 release will work as well.

Setup steps
1. Open the solution in Visual Studio 2022 (preview or >= 17.8)
1. Use the Package Manager Console to initialize the database.
	1. Run the update-database command making sure the API project is selected as the default project in the dropdown.
1. Run the API project and you can inspect the Swagger for the identity api endpoints
1. While the project is running you can use the identity.http file to execute commands.
	1. Start by setting a username and password variable that works for you.
	1. Invoke the Register call to register your user
	1. Once that succeeds, invoke the Login call.
	1. Copy the Access and Refresh tokens and paste into the variable declarations.
	1. You are now set to invoke the other API calls.