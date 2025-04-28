# epht-admin-portal
This application is a test for a web-based admin portal for the EPHT project using .NET 8 and Razor pages.  
The key goal is to create a means for MDH to import, update, delete and edit portal data, and to ensure helpful  
and relevant data validation information is provided to the user throughout the update process. It is also to  
demonstrate the use of Razor pages and gain a better understanding of that workflow and possible validation options.  
The key goals of this project are to:
1. Demonstrate the use of Razor pages for building a web-based admin portal.
2. Implement data validation with form-based input.
3. Demonstrate a drag and drop interface for uploading Excel workbooks.
4. Test reverse engineering of an existing database with Entity Framework and scaffolding.

## Requirements
- .NET 8.0
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- EPPLus: nuget package for reading Excel files. Note this does have licensing requirements.

## Getting Started
You will need to ask a developer for a copy of the `appsettings.json` and `appsettings.Development.json` files since those  
contain connection string information. **Note: the files checked into source control are just examples that exclude the sensitive information!**  
You will need copies of both files from a developer  in order to connect to the database and run the application. 