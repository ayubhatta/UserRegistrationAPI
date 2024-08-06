### User and ToDo API

## Overview
- This API provides endpoints for user registration, login, and managing ToDo tasks. It uses ASP.NET Core and Entity Framework Core with SQL Server as the database. Passwords are hashed using BCrypt for security.

## Table of Contents
* Base URL
* Endpoints
    * User Endpoints
        -  Register
        -  Login
    * ToDo Endpoints
        - Create ToDo
        - Get ToDo
        - Update ToDo
        - Delete ToDo
        - Delete All ToDos for a User
        - Delete All Users

* Request and Response Formats
* Error Handling
* Testing the API

  
## Base URL
The base URL for the API is:

https://localhost:5284/api

## Endpoints

# User Endpoints
* Register
  - URL: /Users/Register
  - Method: POST
  - Description: Registers a new user.
* Request
  - Content-Type: application/json
  - Body:

        {
          "fullName": "John Doe",
          "email": "johndoe@example.com",
          "phoneNumber": "+1234567890",
          "password": "securepassword123"
        }
    
* Response
  - Status Code: 201 Created
  - Body:
        {
          "success": true,
          "message": "User registered successfully",
          "user": {
            "id": 1,
            "fullName": "John Doe",
            "email": "johndoe@example.com",
            "phoneNumber": "+1234567890",
            "totalTaskCount": 0
          }
        }
    
# Errors:
* 400 Bad Request: If the email or phone number already exists.
  - Body: {"success": false, "message": "Email or PhoneNumber already exists."}
 
# Login
  * URL: /Users/Login
  * Method: POST
  * Description: Authenticates a user.

# Request
  * Content-Type: application/json
  * Body:
        {
          "email": "johndoe@example.com",
          "password": "securepassword123"
        }
    
# Response
  * Status Code: 200 OK
  * Body:
        {
          "success": true,
          "message": "User logged in successfully",
          "token": "your-jwt-token",
          "user": {
            "id": 1,
            "fullName": "John Doe",
            "phoneNumber": "+1234567890",
            "email": "johndoe@example.com",
            "totalTaskCount": 0
          }
        }

# Errors:

  * 401 Unauthorized: If the email or password is invalid.
  * Body: {"success": false, "message": "Invalid email or password."}


## ToDo Endpoints

# Create ToDo
  * URL: /ToDo
  * Method: POST
  * Description: Creates a new ToDo item.

# Request
  * Content-Type: application/json
  * Body:
        {
          "title": "New Task",
          "description": "Task description",
          "date": "2024-08-06T00:00:00Z",
          "status": "Pending",
          "userId": 1
        }
    
# Response
  * Status Code: 201 Created
  * Body:
        {
          "success": true,
          "message": "ToDo created successfully",
          "toDo": {
            "id": 1,
            "title": "New Task",
            "description": "Task description",
            "date": "2024-08-06T00:00:00Z",
            "status": "Pending",
            "userId": 1
          }
        }
    
# Get ToDo
  * URL: /ToDo/{id}
  * Method: GET
  * Description: Retrieves a ToDo item by its ID.
    
# Request
  * Content-Type: application/json
  * Parameters:
      - id (int): The ID of the ToDo item.

# Response
  * Status Code: 200 OK
  * Body:
        {
          "success": true,
          "message": "ToDo fetched successfully",
          "toDo": {
            "id": 1,
            "title": "New Task",
            "description": "Task description",
            "date": "2024-08-06T00:00:00Z",
            "status": "Pending",
            "userId": 1
          }
        }
    
# Errors:

  * 404 Not Found: If the ToDo item is not found.
  * Body: {"success": false, "message": "ToDo not found."}

# Update ToDo
  * URL: /ToDo/{id}
  * Method: PUT
  * Description: Updates a ToDo item by its ID.
    
# Request
  * Content-Type: application/json
  * Parameters:
      - id (int): The ID of the ToDo item.
  * Body:
        {
          "title": "Updated Task",
          "description": "Updated description",
          "date": "2024-08-07T00:00:00Z",
          "status": "Completed",
          "userId": 1
        }

# Response
  * Status Code: 200 OK
  * Body:
        {
          "success": true,
          "message": "ToDo updated successfully",
          "toDo": {
            "id": 1,
            "title": "Updated Task",
            "description": "Updated description",
            "date": "2024-08-07T00:00:00Z",
            "status": "Completed",
            "userId": 1
          }
        }
    
# Errors:
  * 404 Not Found: If the ToDo item is not found.
      - Body: {"success": false, "message": "ToDo not found."}
  * Delete ToDo
      - URL: /ToDo/{id}
      - Method: DELETE
      - Description: Deletes a ToDo item by its ID.
# Request
  * Content-Type: application/json
  * Parameters:
      - id (int): The ID of the ToDo item.

# Response

  * Status Code: 204 No Content

# Errors:

  * 404 Not Found: If the ToDo item is not found.
      - Body: {"success": false, "message": "ToDo not found."}

## Delete All ToDos for a User

  * URL: /ToDo/DeleteAll/{userId}
  * Method: DELETE
  * Description: Deletes all ToDo items for a specific user.

# Request
  * Content-Type: application/json
  * Parameters:
      - userId (int): The ID of the user.

# Response
  * Status Code: 204 No Content

# Errors:
  * 404 Not Found: If no ToDo items are found for the user.
      - Body: {"success": false, "message": "No ToDo items found for the user."}


## Delete All Users

  * URL: /Users/DeleteAll
  * Method: DELETE
  * Description: Deletes all users and their associated ToDos.

# Request
  * Content-Type: application/json

#Response
  * Status Code: 204 No Content

## Request and Response Formats
  * All requests and responses are in JSON format.

# Request Example

  * POST /Users/Register

      - POST /Users/Register HTTP/1.1
      - Host: localhost:5284
      - Content-Type: application/json

        {
            "fullName": "John Doe",
            "email": "johndoe@example.com",
            "phoneNumber": "+1234567890",
            "password": "securepassword123"
        }

# Response Example
  * 201 Created
      - HTTP/1.1 201 Created
      - Content-Type: application/json

        {
            "success": true,
            "message": "User registered successfully",
            "user": {
              "id": 1,
              "fullName": "John Doe",
              "email": "johndoe@example.com",
              "phoneNumber": "+1234567890",
              "totalTaskCount": 0
            }
        }

# Error Handling

  * 400 Bad Request: The request is invalid or malformed.
  * 401 Unauthorized: Authentication failed.
  * 404 Not Found: The requested resource could not be found.
  * 500 Internal Server Error: An unexpected error occurred on the server.

# Testing the API

  * You can test the API using tools like Postman or curl.

# Example using Postman

  * Register a User:

      - Method: POST
      - URL: https://localhost:5284/api/Users/Register
      - Body: Raw JSON (as shown in the Request section)

        {
          "fullName": "John Doe",
          "email": "johndoe@example.com",
          "phoneNumber": "+1234567890",
          "password": "securepassword123"
        }
        
# Login a User:

  * Method: POST
  * URL: https://localhost:5284/api/Users/Login
  * Body: Raw JSON
        {
          "email": "johndoe@example.com",
          "password": "securepassword123"
        }


# Create a ToDo:

  * Method: POST
  * URL: https://localhost:5284/api/ToDo
  * Body: Raw JSON
        {
          "title": "New Task",
          "description": "Task description",
          "date": "2024-08-06T00:00:00Z",
          "status": "Pending",
          "userId": 1
        }

# Get a ToDo:

  * Method: GET
  * URL: https://localhost:5284/api/ToDo/1
  * Body: None

# Update a ToDo:

  * Method: PUT
  * URL: https://localhost:5284/api/ToDo/1
  * Body: Raw JSON
        {
          "title": "Updated Task",
          "description": "Updated description",
          "date": "2024-08-07T00:00:00Z",
          "status": "Completed",
          "userId": 1
        }
    
# Delete a ToDo:

  * Method: DELETE
  * URL: https://localhost:5284/api/ToDo/1
  * Body: None


