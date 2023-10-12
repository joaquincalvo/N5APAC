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

                

                return CreatedAtAction(nameof(student.Id), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                
                return BadRequest("Error al crear estudiante");
            }
            
        }

    }
}
