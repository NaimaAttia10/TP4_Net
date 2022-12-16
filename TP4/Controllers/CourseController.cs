using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using TP4.Data;
using TP4.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TP4.Controllers
{

    [Route("Course")]
    public class CourseController : Controller
    {
        private readonly StudentRepository _studentRepo;

        public CourseController(StudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        
        [Route("Index")]
        public ActionResult Index()
        {

            IEnumerable<Student> allStudents = _studentRepo.GetAll();
            return View(allStudents);
        }

        
        [HttpGet("Courses")]
        public ActionResult Courses()
        {
            IQueryable allCourses = (IQueryable)_studentRepo.UniqueCourses();
            Console.WriteLine(allCourses);
            return View(allCourses);
        }

        [HttpGet("{course}")]
        public ActionResult GetStudentsForCourse(string course)
        {
            IEnumerable<Student> students = _studentRepo.GetStudentsByCourse(course);
            ViewData["course"] = course;
            return View(students);
        }
        

        

    }
}