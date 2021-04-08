using FirstApi.Models;
using FirstApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetStudents(string sort)
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


            return Ok(list);
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
