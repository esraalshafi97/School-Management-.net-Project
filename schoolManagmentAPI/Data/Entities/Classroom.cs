namespace schoolManagmentAPI.Data.Entities
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public ICollection<Student> Students { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
