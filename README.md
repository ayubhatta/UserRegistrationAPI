### User Registration API

## Overview

This API provides endpoints for user registration and login. It uses ASP.NET Core and Entity Framework Core with SQL Server as the database. Passwords are hashed using BCrypt for security.

## Table of Contents
- Base URL
- Endpoints
- Register
- Login
- Request and Response Formats
- Error Handling
- Testing the API

  # Base URL
The base URL for the API is:
https://localhost:5284/api/Users/Register

## Endpoints
# Register
- URL: /Users/Register
- Method: POST
- Description: Registers a new user.

# Request
- Content-Type: application/json

- Body:

{
  "fullName": "John Doe",
  "email": "johndoe@example.com",
  "phoneNumber": "+1234567890",
  "password": "securepassword123"
}

# Response
- Status Code: 201 Created

- Body:

{
  "id": 1,
  "fullName": "John Doe",
  "email": "johndoe@example.com",
  "phoneNumber": "+1234567890",
  "password": "$2a$12$..."
}

# Errors:

- 400 Bad Request: If the email or phone number already exists.
- Body: "Email or PhoneNumber already exists."

# Login

- URL: /Users/Login
- Method: POST
- Description: Authenticates a user.

# Request

- Content-Type: application/json

- Body:

{
  "Email": "johndoe@example.com",
  "Password": "securepassword123"
}

# Response
- Status Code: 200 OK

- Body: "Login successful."

# Errors:

- 401 Unauthorized: If the email or password is invalid.
- Body: "Invalid email or password."

# Request and Response Formats
All requests and responses are in JSON format.

# Request Example
# POST /Users/Register

POST /Users/Register HTTP/1.1
Host: localhost:5284
Content-Type: application/json

{
    "fullName": "John Doe",
    "email": "johndoe@example.com",
    "phoneNumber": "+1234567890",
    "password": "securepassword123"
}

# Response Example
# 201 Created

http
Copy code
HTTP/1.1 201 Created
Content-Type: application/json

{
    "id": 1,
    "fullName": "John Doe",
    "email": "johndoe@example.com",
    "phoneNumber": "+1234567890",
    "password": "$2a$12$..."
}


## Error Handling

- 400 Bad Request: The request is invalid or malformed.
- 401 Unauthorized: Authentication failed.
- 404 Not Found: The requested resource could not be found.
- 500 Internal Server Error: An unexpected error occurred on the server.

## Testing the API
You can test the API using tools like Postman or curl.

# Example using Postman
1. Register a User:

- Method: POST
- URL: https://localhost:5284/api/Users/Register
- Body: Raw JSON (as shown in the Request section)

