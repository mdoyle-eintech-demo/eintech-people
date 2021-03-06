# Solution for Eintech's Coding Task
## by Michael Doyle <mdoyle@mdoyle.org>, 30-Aug-2020

This web app uses an Angular UI, an MVC api and an SQLLite database to create an editable list of names.

### How to run
1) Open the solution in Visual Studio (I used 2019)
2) Edit database file location in people-lib\PeopleModel.cs (line 14  the section `options.UseSqlite`) - this is currently hard-coded :/
3) Run/debug both API and WEB projects (hopefull all dependencies will install automatically)
* API will start at http://localhost:52655/api/people
* WEB will start at http://localhost:55258/


### Files

#### people-lib - library
The database and "business logic" for the application.
* people.db a SQLLite database file
* [PeopleModel.cs](/people-lib/PeopleModel.cs) an entify-framwork adapater for the database
* [People.cs](/people-lib/People.cs) simple functions to access the data.

#### api - a RESTful api for accessing people
This uses the people-lib to provide access to the people database over http.
* [Controller/PeopleController.cs](/api/Controllers/PeopleController.cs) - implments the API

#### web - an Angular UI that uses the API to Create, Read and Delete names in the people database.
* [web/ClientApp/src/app/home/home.component.html](web/ClientApp/src/app/home/home.component.html)
* [web/ClientApp/src/app/home/home.component.ts](web/ClientApp/src/app/home/home.component.ts)

(I created this from a VS angular template that i don't have much experience with  - there are a quite a few extra files in here.)

#### tests
Some basic tests I used while coding the application.

