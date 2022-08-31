using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{

    public enum Level
    {
        Basic,
        Intermediate,
        Advanced
    }

    public class Course: BaseEntity
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = String.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string Target { get; set; } = String.Empty;

        public string Objectives { get; set; } = String.Empty;

        public string Requirements { get; set; } = String.Empty;

        [Required]
        public Level Level { get; set; } = Level.Basic;
    }
}
