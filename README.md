# CardCostApi

## CardCostApi Management Application

In this application, the user can request information about a card number, create/read/update/delete existing records in Clearing Cost Matrix. 
This is an n-tier application about managing card cost details.
Beginning from inner to outer, in the first layer we can see the Core layer. In this layer we have our entities, DTOs and repositories interfaces. 
In the second layer there is the Infrastructure. In this layer we added the DbContext, repository implementation and the external api call (binlist api).
The third layer has the application services interfaces/implementation and our application mappings.   
In the last layer (Presentation) I added the Api because it is used to pass data in the UI. 

## Getting Started

1. Copy/download the project on your PC.
2. Create a database (e.x. CardCostDb). Execute SQL file in order to create the Database scheme and initial data for Clearing Cost Matrix.
3. Set connection strings.
4. Set CardCost.Api as StartUp project.
5. Run the project!

## How to use
When Application starts on Swagger:
1. Check the schema of input/output objects and endpoints.
2. Open Postman (or any other Api client).
3. Register a new user.
4. Authenticate the user you created before and keep the Token value from response.
5. Use the value from token on every request (select Bearer Token authorization) in order to authorize your user to access the Api (there is a limit of 7000 requests/minute)


## Built With
* .NET Core 3.1
* MSSQL
* Swagger 
* JWT authentication
* Automapper
* Docker
* Xunit

## Author
Christos Karounias
