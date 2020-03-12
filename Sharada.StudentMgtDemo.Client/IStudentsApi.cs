using Refit;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharada.StudentMgtDemo.Client
{
    public interface IStudentsApi
    {
        [Get("/students")]
        Task<List<Student>> GetStudents();

        [Get("/student/{studentId}/enrolls")]
        Task<List<Enrollment>> GetEnrollments(int studentId);

        [Get("/student/{studentId}/services")]
        Task<List<Service>> GetServices(int studentId);
    }

    #region Entities

    public class Student
    {
        public int StudentId { get; set; }
        public int DistrictId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Ssn { get; set; }
    }

    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int SchoolYear { get; set; }
    }

    public class Service
    {
        public int ServiceId { get; set; }
        public int StudentId { get; set; }
        public int SchoolYear { get; set; }

        public string Name { get; set; }
    }

    #endregion
}
