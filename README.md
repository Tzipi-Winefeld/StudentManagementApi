# Student Management API

## Description
A simple API for managing a classroom student list using ASP.NET Core.  
Data is stored locally in a JSON file, allowing basic CRUD operations without the need for a database.

## Features
- Retrieve the list of students
- Add a new student to the list
- Delete a student by ID
- Handles various HTTP status codes to enhance API communication

## How to Use
1. **GET** `/api/students`  
   Retrieves the list of students.

2. **POST** `/api/students`  
   Adds a new student with a unique ID and name.

3. **DELETE** `/api/students/{id}`  
   Deletes the specified student by ID.

## HTTP Status Codes
- **200 OK**  
  Successfully retrieved data.

- **201 Created**  
  Student added successfully.

- **204 No Content**  
  No data to return (e.g., on successful deletion).

- **400 Bad Request**  
  Invalid input data.

- **404 Not Found**  
  Student not found by ID.

- **409 Conflict**  
  Student ID already exists.

## Technologies Used
- C# / .NET Core
- ASP.NET Core Web API

## Installation
1. Clone the repository:  
   ```bash
   git clone https://github.com/Tzipi-Winefeld/student-management-api.git
