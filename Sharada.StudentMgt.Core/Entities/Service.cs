using System.ComponentModel.DataAnnotations;

namespace Sharada.StudentMgt.Core.Entities
{
    public class Service : BaseEntity
    {
        [Key]
        public int ServiceId { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public string Name { get; set; }
        public int SchoolYear { get; set; }
    }
}
