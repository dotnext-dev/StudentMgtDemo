using Microsoft.EntityFrameworkCore;
using Sharada.StudentMgt.Core;
using Sharada.StudentMgt.Core.Entities;
using Sharada.StudentMgt.Core.Helpers;
using System;

namespace TestSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<StudentContext>()
                .UseInMemoryDatabase(databaseName: "MockStudents")
                .Options;

            // Run the test against one instance of the context
            using (var context = new StudentContext(options))
            {
                var studentRepo = new EfRepository<Student>(context);
                var enrollmentRepo = new EfRepository<Enrollment>(context);
                var serviceRepo = new EfRepository<Service>(context);

                StudentContextSeed.Seed(context, null);

                Console.WriteLine($"Students: {studentRepo.ListAllAsync().Result.Count}");
                Console.WriteLine($"Enrollments: {enrollmentRepo.ListAllAsync().Result.Count}");
                Console.WriteLine($"Services: {serviceRepo.ListAllAsync().Result.Count}");
            }
        }
    }
}
