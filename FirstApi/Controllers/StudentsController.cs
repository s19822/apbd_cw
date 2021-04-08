using FirstApi.Models;
using FirstApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;


        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var list = new List<Student>();
            List<string> listA = new List<string>();
            List<Student> studentsList = new List<Student>();
            using (var reader = new StreamReader(@"C:\Users\Dzejki\Desktop\abc.csv"))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    Student student = null;

                    student.
                    
                }
            }

            return Ok(listA);
        }

        [HttpGet("{idStudent}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int idStudent)
        {
            var list = new List<Student>();

            list.Add(new Student
            {
                IdStudent = 1,
                FirstName = "Jakub",
                LastName = "Stanuszek"
            });

            list.Add(new Student
            {
                IdStudent = 2,
                FirstName = "Tomasz",
                LastName = "Stanuszek"
            });

            list.Add(new Student
            {
                IdStudent = 3,
                FirstName = "Dzejki",
                LastName = "Krol"
            });

            Student student = null;

            foreach(var studentFromList in list)
            {
                if(studentFromList.IdStudent == idStudent)
                {
                    student = studentFromList; 
                }
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            _dbService.AddStudent();
            return Ok();

        }
    }
}
