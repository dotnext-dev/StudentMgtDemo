using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sharada.StudentMgt.Core.Entities;
using Sharada.StudentMgt.Core.Interfaces;

namespace Sharada.StudentMgtDemo.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IAsyncRepository<Student> _studentsRepository;
        private readonly IAsyncRepository<Enrollment> _enrollmentsRepository;
        private readonly IAsyncRepository<Service> _servicesRepository;

        public StudentController(IAsyncRepository<Student> studentRepository,
            IAsyncRepository<Enrollment> enrollmentsRepository,
            IAsyncRepository<Service> servicesRepository)
        {
            _studentsRepository = studentRepository;
            _enrollmentsRepository = enrollmentsRepository;
            _servicesRepository = servicesRepository;
        }

        [HttpGet]
        [Route("{studentId:int}/detail")]
        public async Task<IActionResult> Detail(int? studentId)
        {
            if (studentId == null)
            {
                return base.ValidationProblem("Student id cannot be null");
            }
            else
            {
                var student = await _studentsRepository.GetByIdAsync(studentId.Value);
                if (student != null)
                    return Ok(student);

                return NotFound();
            }
        }

        [HttpGet]
        [Route("{studentId:int}/enrolls")]
        public async Task<IActionResult> Enrollments(int? studentId, int? schoolYear)
        {
            if (studentId == null)
            {
                return base.ValidationProblem("Student id cannot be null");
            }
            else
            {
                var enrollments = await _enrollmentsRepository.ListAsync(
                    e => e.StudentId == studentId.Value 
                     && (schoolYear == null || e.SchoolYear == schoolYear));
                if (enrollments != null)
                    return Ok(enrollments);

                return NotFound();
            }
        }

        [HttpGet]
        [Route("{studentId:int}/services")]
        public async Task<IActionResult> Services(int? studentId, int? schoolYear)
        {
            if (studentId == null)
            {
                return base.ValidationProblem("Student id cannot be null");
            }
            else
            {
                var services = await _servicesRepository.ListAsync(
                    e => e.StudentId == studentId.Value
                     && (schoolYear == null || e.SchoolYear == schoolYear));
                if (services != null)
                    return Ok(services);

                return NotFound();
            }
        }
    }
}