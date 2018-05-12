# Setting Up Game Tracker
More details coming.

## Building and updating Local Database
We are using SQL LocalDb for the database for the project, which means you'll need to check the connection string in the `appsettings.json` file and confirm that it will work on your machine before running the application.

## Adding a new migration
In order to update the schema you'll need to add a new migration using EF Core migrations.

[Read about EF Core Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/)

### Be sure to install the EF Core Tools
Using NuGet's Package Manager Console, run the following command:

#### PowerShell
```
Install-Package Microsoft.EntityFrameworkCore.Tools
```

If everything worked correctly, you should be able to run this command:

#### PowerShell
```
Get-Help about_EntityFrameworkCore
```

### Tips
 - You can check in the SQL Server Object Explorer in Visual Studio to see your localdb.
 - The migration will pull the connection string from the `appsettings.json` file that gets copied on build.
 - The easiest place to run the EF Core Tools is in the Package Manager Console. Find it in Visual Studio under `Tools` -> `NuGet Package Manager` -> `Package Manager Console`.
 
