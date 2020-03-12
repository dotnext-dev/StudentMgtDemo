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
    public class StudentsController : ControllerBase
    {
        private readonly IAsyncRepository<Student> _studentsRepository; 

        public StudentsController(IAsyncRepository<Student> repository)
        {
            _studentsRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List(int? districtId)
        {
            if(districtId == null)
            {
                var students = await _studentsRepository.ListAllAsync();
                return Ok(students);
            }
            else
            {
                var districtStudents = await _studentsRepository.ListAsync(
                    s => s.DistrictId == districtId);
                return Ok(districtStudents);
            }
        }
    }
}