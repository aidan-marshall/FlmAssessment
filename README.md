FLM ASSESSMENT

ASSUMPTIONS:

WHEN PARSING DATA FROM CSV, JSON, XML IF A FIELD IS MISSING THAT IS NOT DEEMED CRUCIAL EG. (BRANCH_NAME) THE FIELD WILL BE SET TO NULL, OTHERWISE IT WILL BE SKIPPED.

SETUP:

CONNECTINGSTRING NEEDS TO BE SET TO SQL SERVER DB ON LOCAL IN appsettings.json in BranchProductApp.Core

RUN INIITIAL MIGRATIONS TO CREATE DATABASE AND TABLES.

dotnet ef migrations add InitialCreate
dotnet ef database update

SELECT BranchProductApp.WinForms as startup project
