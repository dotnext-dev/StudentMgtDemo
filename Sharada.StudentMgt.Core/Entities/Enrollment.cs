using System.ComponentModel.DataAnnotations;

namespace Sharada.StudentMgt.Core.Entities
{
    public class Enrollment : BaseEntity
    {
        [Key]
        public int EnrollmentId { get; set; }
        
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public int SchoolYear { get; set; }
    }
}
