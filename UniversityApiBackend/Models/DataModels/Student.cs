using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Student: BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        // DOB = DATE OF BIRTH
        public DateTime DOB { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
