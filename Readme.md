This is a web app for Eintech's Coding Task
Codede by Micahel Doyle <mdoyle@mdoyle.org>, 30-Aug-2020

### How to run
1) Open the solution in Visual Studio (I used 2019)
2) Edit database file location in people-lib\PeopleModel.cs (line 14  the section `options.UseSqlite`) - this is currently hard-coded :/
3) Two projects need to be run 
* API this will start at http://localhost:52655/api/people
* WEB this will start at http://localhost:55258/


### files
#### people-lib - library
The database and "business logic" for the application.
* people.db a SQLLite database file
* PeopleModel.cs an entify-framwork adapater for the database
* People.cs simple functions to access the data.

#### api - a RESTful api for accessing people
This uses the people-lib to provide access to the people databse over http.
Controller\PeopleController.cs - implments the API

#### web - an Angular UI that uses the API to Create, Read and Delete names in the people database.
web\ClientApp\src\app\home\home.component.html
web\ClientApp\src\app\home\home.component.ts
Note create from a VS angular template that i don't have much expreince with  - there is a lot of extra files in here.

#### tests
Some basic tests I used while coding the application.

