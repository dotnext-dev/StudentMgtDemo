using Microsoft.Extensions.Logging;
using Sharada.StudentMgt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharada.StudentMgt.Core.Helpers
{
    public class StudentContextSeed
    {
        public static void Seed(StudentContext sContext,
            ILoggerFactory loggerFactory)
        {
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!sContext.Students.Any())
                {
                    var eId = 1;
                    var sId = 1;
                    var ssId = 1;
                    for (var d = 1; d <= 4; d++)
                    {
                        for (var s = 1; s <= 9; s++)
                        {
                            var student = new Student(sId++, d,
                                $"Student{s:D2}",
                                $"Distrct{d:D2}",
                                DateTime.Today.AddYears(-1 * d),
                                $"{s:D2}{d:D4}");
                            sContext.Add(student);

                            for (var e = 1; e <= 3; e++)
                            {
                                var enrollment = new Enrollment { EnrollmentId = eId++, Student = student, SchoolYear = DateTime.Today.AddYears(d).Year };
                                sContext.Add(enrollment);
                            }

                            for (var ss = 1; ss <= 2; ss++)
                            {
                                var service = new Service { ServiceId = ssId++, Student = student, SchoolYear = DateTime.Today.AddYears(d).Year, Name = $"S{ss:D4}{s:D2}{d:D3}" };
                                sContext.Add(service);
                            }
                        }
                    }

                    sContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var log = loggerFactory.CreateLogger<StudentContext>();
                log.LogError(ex.Message);

                throw;
            }
        }
    }
}
