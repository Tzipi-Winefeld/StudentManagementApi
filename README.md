Student Management API
A simple ASP.NET Core API to manage a list of students, stored in a local JSON file.

HTTP Status Codes
GET - Retrieve List of Students
URL: /api/students
Method: GET
Status Codes:
200 OK     — Successfully retrieved the list of students.
204 No Content — No students found in the list.
POST - Add a New Student
URL: /api/students
Method: POST
Request Body:
{
  "id": 1,
  "name": "John Doe"
}
Status Codes:
201 Created          — Student added successfully.
400 Bad Request    — Invalid data provided.
409 Conflict          — Student with the same ID already exists.
DELETE - Remove a Student
URL: /api/students/{id}
Method: DELETE
Status Codes:
204 No Content   — Student successfully deleted.
404 Not Found       — Student not found.
