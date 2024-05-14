using schoolManagmentAPI.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
namespace cityInfo.api.Models
{
	public class TeacherDto
	{

        [StringLength(12, MinimumLength = 12, ErrorMessage = "The national number must be 12 characters.")]
        public string NationalNumber { get; set; }
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        // Navigation properties
        public SubjectDto? Subject { get; set; }
        public ICollection<Classroom>? Classrooms { get; set; }
        public String ImageUrl { get; set; }


    }
}

