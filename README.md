# LMS Inventory

Project Description: 

Created a web app for managing inventory using .net Core 7 Web API,MVC,Ajax and MS-SQL.
User can manage inventory by Create,Update,Delete and Read data from Stores,Racks and Elements table.

Following tools are used in the project:

1. Use EF Core as ORM to map data with sql server. Used code first approach.
3. Used MVC with WEB API.
4. CRUD Operation done using CQRS Pattern with MediatR library for Stores, Racks and Elements tables.
5. Interface validations done with Generic Repository and UnitOfWork pattern. 
6. AutoMapper used for DTO validation. 
7. Business Logic Layer and Data Access Layer are separated projects.
8. Generated a report as per given format.


Instruction to run the project:

1. Please clone the project.
2. Open .sln file using visual studio.
3. Go to presentation folder from solution explorer.
4. Change ConnectionString property in both appsettings.json file from Inventory.WebAPI and Inventory.Web project under the Presentation folder.
5. Go to Package Manager Console and write "update-database" to restore database. Make sure you have selected Inventory.Persistence as Default Project in package manager console.
6. Set Multiple Startup Project as Inventory.WebAPI and Inventory.Web.
7. Hit run button.


PROJECT Screenshot:
I have provided some screenshot's of project below :

<img width="735" alt="00 API" src="https://github.com/Saifulpavel/LMSInventory/assets/44993427/64994d9c-cdcd-4074-bd57-ad734e19ce51">
<img width="947" alt="01 ListPage" src="https://github.com/Saifulpavel/LMSInventory/assets/44993427/9e1e0722-3536-472e-878c-bf846e39ed4a">
<img width="957" alt="02 CreatePage" src="https://github.com/Saifulpavel/LMSInventory/assets/44993427/516c558b-c58b-427c-86f1-8a6e5dc8a5b3">
<img width="950" alt="03 Delete" src="https://github.com/Saifulpavel/LMSInventory/assets/44993427/c892a0cf-59b7-4236-9282-18e51236da56">
<img width="959" alt="04 ValidationsAndEditPage" src="https://github.com/Saifulpavel/LMSInventory/assets/44993427/07fba199-40c8-4084-853f-61c02e2082ec">
<img width="957" alt="05 Report" src="https://github.com/Saifulpavel/LMSInventory/assets/44993427/311c4fa6-e08d-468e-8c71-c721aba8ded4">
<img width="956" alt="06 ProjectStructure" src="https://github.com/Saifulpavel/LMSInventory/assets/44993427/93211f48-f985-4440-8bc1-a10232f6d211">




