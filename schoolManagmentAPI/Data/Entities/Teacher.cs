using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace schoolManagmentAPI.Data.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(12, MinimumLength = 12, ErrorMessage = "The national number must be 12 characters.")]
        public string NationalNumber { get; set; }
        public string Name { get; set; }
        public int? SubjectId { get; set; }
        public string? ImageUrl { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        // Navigation properties
        public Subject? Subject { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
