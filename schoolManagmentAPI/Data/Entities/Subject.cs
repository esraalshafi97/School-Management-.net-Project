namespace schoolManagmentAPI.Data.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public ICollection<Teacher> Teachers { get; set; }
    }
}
