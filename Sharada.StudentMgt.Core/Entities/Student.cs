
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sharada.StudentMgt.Core.Entities
{
    public class Student : BaseEntity
    {
        [Key]
        public int StudentId { get; private set; }
        public int DistrictId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Dob { get; private set; }
        public string Ssn { get; private set; }

        private readonly List<Enrollment> _enrollments = new List<Enrollment>();
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

        private readonly List<Service> _services = new List<Service>();
        public IReadOnlyCollection<Service> Services => _services.AsReadOnly();

        public Student(int studentId, int districtId, string firstName, string lastName, DateTime dob, string ssn)
        {
            StudentId = studentId;
            DistrictId = districtId;
            FirstName = firstName;
            LastName = lastName;
            Dob = dob;
            Ssn = ssn;
        }

    }
}
