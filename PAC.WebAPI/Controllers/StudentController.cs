using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _StudentService;

        public StudentController(IStudentLogic studentService)
        {
            _StudentService = studentService;
        }

        [HttpPost]

        public IActionResult RegisterStudent([FromBody] Student student)
        {
            try
            {
                
                var createProduct = _StudentService.InsertStudents;

                

                return CreatedAtAction(nameof(GetStudentsByID), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                
                return BadRequest("Error al crear estudiante");
            }
            
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _StudentService.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Error al obtener los estudiantes: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentsByID([FromRoute] int id)
        {
            try
            {
                var student = _StudentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound($"Estudiante con ID {id} no encontrado");


                }
                return Ok(student);
            }
            catch (Exception e)
            {
                
                return BadRequest($"Error al obtener el estudiante: {e.Message}");
            }
        }

        [HttpPost("create")]

        public IActionResult CreateStudent([FromBody] Student student)
        {

            try
            {

                var createStudent = _StudentService.CreateStudent(student);

                

                return CreatedAtAction(nameof(GetStudentsByID), new { id = createStudent.Id }, createStudent);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }

    }
}
