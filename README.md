
# SingASong

SingASong is an online music store which enables the user to buy albums from a variety of genre and artists. 
Integrated through MSSQL and based on MVC Architecture , it was supported through several Microservices for admin, cart and user operations.


## Features

- View a plethora of albums 
- Add selected albums to cart
- Delete the items from the cart
- Authenticated Login and Registration
- Admin Mode available for users that have admin access
- Ability to Create,Read,Update and Delete albums through admin access
- Search particular albums either by AlbumID or via AlbumName
- Separate view to display Logged in user details via Session authorization
- Separate functionality to view the albums sold under a certain time period , available only to the admin.
- Route Configuration through Microservice controllers


## Optimizations

#### Dependency Injection: 
- Applied dependency injection to inject database access classes (e.g., DBAccess and UserDataAccess) into the controllers, enhancing modularity and testability.
####  Database Integration:
 - Utilized MSSQL as the backend relational database for both MVC and Web API applications.
- Stored and managed data such as user information, albums, and cart details in a structured manner within MSSQL tables.
####  Microservice Endpoints:
- Defined and implemented Web API endpoints within the AdminController and UserController to expose CRUD (Create, Read, Update, Delete) operations for albums, user registration, login, and cart management.
#### MVC Controller Actions:
- Enhanced MVC controller actions to interact with the MSSQL database through the DBAccess class.
Improved error handling and response messages for actions like adding, updating, and deleting albums.

#### Security Measures:

 - Ensured secure handling of user credentials during registration and login processes.
 - Checked and validated user privileges, such as admin status, before performing certain actions.

 #### Validation:
 - Implemented model validation in MVC controllers to ensure that the data submitted to the server is valid before processing.

#### Exception Handling:

 - Incorporated proper exception handling to gracefully handle errors and provide meaningful error messages to users or developers.
 - Managed exceptions in both MVC and Web API controllers, enhancing robustness.

 #### Clean Code Practices:

 - Followed clean code practices to maintain code readability, reusability, and adherence to best practices in C# and ASP.NET.
## API Reference


```http
  GET /api/Admin/FetchAlbums
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
|       -|  | Retrieves all albums |


```http
  GET /api/Admin/FetchAlbums/${albumID}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `albumID`      | `int` | Retrieves a specific album by its ID.|


```http
  GET /api/Admin/FetchAlbums/${albumName}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `albumName`      | `string` | Retrieves a specific album by its name.|


```http
  POST /api/Admin/AddAlbums
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Expects a JSON payload representing the new album.`      | `Album Model` | Deletes an album by ID.|


```http
  PUT /api/Admin/UpdateAlbums/${albumID}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Expects a JSON payload representing the updated album and the albumID in the route.`      | `int, Album Model` |Updates an existing album by ID.|


```http
 DELETE /api/Admin/DeleteAlbums/${albumID}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `albumID`      | `int` |Deletes an existing album by ID.|



```http
    POST /api/User/Register
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Expects a JSON payload representing the user details`      | `User model` |Registers a new user|




```http
    POST /api/User/Login
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Expects a JSON payload representing login details.`      | `User model` | Validates user login credentials.|



```http
    POST /api/User/AddToCart
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `userID, albumID`      | `int` | Adds an album to the user's cart.|



```http
    GET /api/User/FetchCart
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `userID`      | `int` | Retrieves the user's cart albums.|

## Deployment

To deploy this project run

- Clone this repository
- Right click on your solution and got to properties
- Under the common features, enable multiple startups
- Select your Web API microservice directory as well as your MVC directory and click on start


