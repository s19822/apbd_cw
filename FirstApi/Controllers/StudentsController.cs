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
        public List<Student> studentsList = new List<Student>();
        public List<string> dataList = new List<string>();

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [NonAction]
        public void ReadStudents()
        {
            using (var reader = new StreamReader(@"C:\Users\Dzejki\Desktop\abc.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    dataList.Add(values[0]);

                    studentsList.Add(new Student
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        StudentNumber = values[2],
                        BirthDate = values[3],
                        DegreeCourse = values[4],
                        ModeCourse = values[5],
                        EmailAddress = values[6],
                        FatherName = values[7],
                        MotherName = values[8]
                    });

                }


            }
        } 

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            ReadStudents();

            return Ok(studentsList);
        }

        [HttpGet("{studentNumber}")]
        public async Task<IActionResult> GetStudentByStudentNumber([FromRoute] string studentNumber)
        {
            Student student = null;

            ReadStudents();

            foreach (var studentFromList in studentsList)
            {
                if (studentFromList.StudentNumber == studentNumber)
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
