## Book Library

**A sample application that allows users to search for books available in the library.**

This repository has two projects that will be detailed in the sections ahead, you can try to run in your machine this projects following the [Setup](#setup) septs.

The application is simple as you can see in the diagram bellow, is composite by an API that queries data from the database and returns to the UI interface to be showed to user.

![Diagram](docs/architecture-diagram.drawio.png)

### WEB
The user can interact with the application by aa Web interface developed using React.js, the source code is available in the folder `book-library-client`.

The app is composed by simple components to search and display the results. Based on title, author, ISBN or category the user can find the book. 

### API
This repository has an API project located in `book-library-api` that provides an interface that integrates with different devices. The project follows the Clean Architecture and are divided in these libraries:
 * **BookLibrary.API**: RESTful Interface to external devices.
 * **BookLibrary.Domain**: Has the entities and abstractions of the infraestructure.
 * **BookLibrary.Infra**: Implements the infraestructure of the application to access the database.

To run queries in the database was used [Dapper](https://www.learndapper.com) that simplifies the data access from the database. To optimize the performance were created some indexes and applied pagination for the queries. 

### Setup
#### Requirements and Tools
Before begin, you need to have some softwares in your machine that will provide the environment to run the apps.
 * .NET Core 8 SDK (.NET CLI)
 * SQL Server (SQL Server Management Studio - SSMS)
 * Node.js ^16
 
#### Setup API
To begin you have to create the database with their respective tables. Get the script `Setup Database.sql` located in `book-library-api\src\BookLibrary.Infra\Scripts` and execute using SSMS.

Then you have to execute some commands in the folder `book-library-api\src\BookLibrary.API`. It'll restore the packages, execute the build and run the API.
 * `dotnet restore`
 * `dotnet build`
 * `dotnet run`

You can check if the API works accessing the documentation in [http://localhost:5262/swagger/index.html](http://localhost:5262/swagger/index.html).

#### Setup WEB
You can install the dependencies of the projects and start the app executing the commands bellow in the folder `book-library-client`.
 * `npm install`
 * `npm run dev`

Then you can go to the web browser and type [http://127.0.0.1:5173](http://127.0.0.1:5173) to access the app.
