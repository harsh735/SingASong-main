
# SingASong

SingASong is an online music store which enables the user to buy albums from a variety of genre and artists. 
Integrated through MSSQL and based on MVC Architecture , it was supported through several Microservices for admin, cart and user operations.

Project developed by - Anshuman Tiwari,Harshendra Singh,Anuj Singh,Parichay Dawar
// Team name : UP14.net


## Features

- View a plethora of albums 
- Add selected albums to cart
- Delete the items from the cart
- Authenticated Login and Registration
- Admin Mode available for users that have admin access
- Ability to Create,Read,Update and Delete albums via Admin mode, made possible through ADO.NET and LINQ 
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
 - Implemented model validation in MVC controllers to ensure that the data submitted to the server is valid before processing through Action Selectors and Data Annotations and other Tag Helpers

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


## Demo

### Home Page
![image](https://github.com/harsh735/SingASong-main/assets/53695605/1e9e5c25-9b6f-45a4-8b4f-de6204d8a8c2)


### Login Page
![image](https://github.com/harsh735/SingASong-main/assets/53695605/009c57ad-54e0-420a-9785-2989b4f9c08a)


### Product Catalogue Page
![image](https://github.com/harsh735/SingASong-main/assets/53695605/9e25375a-ee84-4b9f-b6de-9d516e166576)


### Carts Page
![image](https://github.com/harsh735/SingASong-main/assets/53695605/a61525a6-2a13-4470-af26-78cda2ad570f)


### Payments Method Page
![image](https://github.com/harsh735/SingASong-main/assets/53695605/0325881e-628c-4613-aa5c-26044f56a1d0)


### Thank You Page
![image](https://github.com/harsh735/SingASong-main/assets/53695605/cbebe504-abf4-40e5-8860-630c104d9d59)



### View User Profile page
![image](https://github.com/harsh735/SingASong-main/assets/53695605/f800c4ac-5668-40c1-8eed-7ea57e0464b5)

### Search Album by Name
![image](https://github.com/harsh735/SingASong-main/assets/53695605/3d22fbcc-6367-4d43-b171-fffbcdf494b5)



### Admin Page
![image](https://github.com/harsh735/SingASong-main/assets/53695605/9318a4a0-0145-40f7-9419-008dc536de92)
### Add Album
![image](https://github.com/harsh735/SingASong-main/assets/53695605/10036cbf-6dd7-45c3-a937-cb535f64946d)
### Update Album
![image](https://github.com/harsh735/SingASong-main/assets/53695605/3dc7cbdf-33d3-4276-a6b0-59c3f2bc4e0b)
### Search Album by ID
![image](https://github.com/harsh735/SingASong-main/assets/53695605/327692f3-e9a4-415e-b03f-60c15f2c3ec0)

### Generate reports
![image](https://github.com/harsh735/SingASong-main/assets/53695605/3e095238-54ef-4e03-bff0-01f64bc5c08a)

