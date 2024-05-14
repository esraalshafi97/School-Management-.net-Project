using schoolManagmentAPI.Data.Entities;

namespace schoolManagmentAPI.Models
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int? ClassroomId { get; set; }

        // Navigation properties
        public Classroom? Classroom { get; set; }
    }
}
