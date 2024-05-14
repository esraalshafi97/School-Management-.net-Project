namespace schoolManagmentAPI.Data.Entities
{

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int ClassroomId { get; set; }

        // Navigation properties
        public Classroom Classroom { get; set; }
    }
}
