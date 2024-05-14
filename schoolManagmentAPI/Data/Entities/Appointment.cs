namespace schoolManagmentAPI.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public int ClassroomId  { get; set; }
        public Classroom Classroom { get; set; }
        TimeOnly TimeOnly { get; set; }
    }
}
