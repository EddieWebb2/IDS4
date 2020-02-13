# IDS4

# Introduction 
This document will act as a toolset for the project from testing links to EntityFramework migration and management
Dumm API adress on port 44303 will be required to prove the token flow.


# 1 Useful URL's

## 1.1 User-api
For user authorisation for the group api:
https://localhost:44383/connect/authorize?client_id=useraccess&scope=user-api&redirect_uri=https%3A%2F%2Flocalhost:44303&state=1234&response_type=token

This is making use of the 'connect/authorize?' endpoint making use of OpenID Connect. Construction of this url is as follows and will return a bearer token for authorisation use:
https://localhost:44383/connect/authorize?
client_id       =   useraccess
scope           =   user-api
redirect_uri    =   https%3A%2F%2Flocalhost:44303   
state           =   1234
response_type   =   token
The flow described above is an 'Implicit' Flow/GrantType and in our case is used for testing only. Other user GrantTypes for user interaction are 'ClientCredential' type

For testing the user clients:
* Some website client - https://localhost:44383/connect/authorize?client_id=<ClIENT ID FROM IDS4 - USER CLIENT>&response_type=code&scope=user-api%20openid%20offline_access&redirect_uri=https%3A//localhost:44303


Construction of the url is as follows:
https://localhost:44383/connect/authorize?
client_id       =   <ClIENT ID FROM IDS4 - USER CLIENT>
response_type   =   code
scope           =   user-api%20openid%20offline_access
redirect_uri    =   https%3A//localhost:44303
This will return a client code

## 1.2 Client-api
For testing website client to IDS Core - REST Client needed:

Setup:
Client string:
In order to generate a client token you will need to use the REST client and pass in the given brand environment information (Identity server client & Test Key).

In the REST Client:- "POST"
You will need to add the environment domain with the ID server endpoints to return a token:
	https://<ID Server Domain>/connect/token
	Example:
https://localhost:44383/connect/token

Example: (Body)
client_id=<ClIENT ID FROM IDS4 - WEBSITE CLIENT>&
client_secret=<ClIENT SECRET FROM IDS4 - WEBSITE CLIENT SECRET>&
grant_type=client_credentials&
scope=client-api

Required Headers:
Content-Type = "application/x-www-form-urlencoded�s
This is required to generate a Client-api token

# 2 EntityFramework

Create Migration package:
This will need to be done for all environments

## 2.1 Notes
Check that the project directory is correctly specified to the Project folder �IDS4� and not the solution folder, as the migration packages need to be added in preparation for the �HardCodedInitialiser� class can pick up the configuration and apply to the SQL environment appropriately. (Hardcode initialiser will need to be built out. It may be best to stor this in source)
�cd IDS4�

## 2.2 Handles Tokens & Consent
dotnet ef migrations add InitialIdentityServerPersistedGrantDbMigration -c PersistedGrantDbContext -o Migrations/PersistedGrantDb

## 2.3 Handles Clients and Scopes
dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c ConfigurationDbContext -o Migrations/ConfigurationDb

## 2.4 Optional
Run the database update from the migration package created - Only if you are running it locally from your machine! EF should take care of this so it shouldn�t require running:
dotnet ef database update

Useful link: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-2.2













