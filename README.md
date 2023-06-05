# PROG7311-POE2

Farmer Central - Prototype Web Application
Welcome to Farmer Central, a prototype web application for managing farmers and their associated products.

Prerequisites:
To build and run this prototype, you need the following tools:

Visual Studio (version 2019 or later)
.NET Core SDK (version 6)
SQL Server (Microsoft)


Getting Started:
Clone the repository to your local machine or download the source code as a ZIP file.
Open the solution file (FarmersCentral2.sln) in Visual Studio.

Configure the database connection:
Open the appsettings.json file located in the FarmersCentral2 project.
Update the DefaultConnection connection string with your SQL Server details (server, database, credentials).

Build the solution:
Build the solution using Visual Studio's build functionality or by running dotnet build command in the terminal.

Run the database migrations:
Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
Set the Default project to FarmersApp.Data.
Run the command Update-Database to apply the database migrations.

Run the application:
Set the FarmersCentral2 project as the startup project.
Press F5 or click on the Start button to run the application.

Access the application:
Once the application is running, open your web browser.
Navigate to https://localhost:7269 to access the Farmer Central web application.

USAGE:

Pre-created Employee account:
The application comes with a pre-created employee account that is able to register new users with assigned roles.
Username: employee1@employee.com
Password: Employee123!

Log in to the application:
Use the login form on the homepage to log in with these credentials.

User Roles:
The prototype website provides two different user roles: "Farmer" and "Employee".
The registration process only allows the "Employee" role to assign roles to newly registered users.

Adding Farmers and Products:
Logged-in employees can add new farmers to the database by clicking on "Register Farmer" in the navigation menu.
Logged-in farmers can add new products to their profile by clicking on "Products" in the navigation menu.

Viewing Products:
Logged-in employees can view the list of farmers by clicking on "Farmers". The Employee can then view a list of all products ever supplied by a specific farmer by clicking on "View Products" next to each farmer's name.
Filter the displayed list of products by using the date range and product type filters.
