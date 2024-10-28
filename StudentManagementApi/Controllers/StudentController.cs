using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentManagementApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private const string FilePath = "students.json";

        private List<Student> LoadStudents()
        {
            if (!System.IO.File.Exists(FilePath))
            {
                System.IO.File.WriteAllText(FilePath, "[]");
            }
            var json = System.IO.File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Student>>(json);
        }

        private void SaveStudents(List<Student> students)
        {
            var json = JsonConvert.SerializeObject(students, Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, json);
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = LoadStudents();
            if (students.Count == 0)
            {
                return NoContent(); // 204 אם אין תלמידים
            }
            return Ok(students); // 200 אם הרשימה מכילה תלמידים
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            if (newStudent == null || string.IsNullOrWhiteSpace(newStudent.Name))
            {
                return BadRequest("Invalid student data."); // 400 אם הנתונים אינם תקינים
            }

            var students = LoadStudents();
            if (students.Any(s => s.Id == newStudent.Id))
            {
                return Conflict("Student with the same ID already exists."); // 409 אם התלמיד כבר קיים
            }

            students.Add(newStudent);
            SaveStudents(students);
            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Id }, newStudent); // 201 עם פרטי התלמיד שנוסף
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var students = LoadStudents();
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound("Student not found."); // 404 אם התלמיד לא נמצא
            }

            students.Remove(student);
            SaveStudents(students);
            return NoContent(); // 204 כאשר התלמיד נמחק בהצלחה
        }
    }
}
