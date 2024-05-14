using schoolManagmentAPI.Data.Entities;

namespace schoolManagmentAPI.Models
{
    public class StudentOfCreation
    {
        public string Name { get; set; }
        public int? ClassroomId { get; set; }
        public IFormFile Image { get; set; }

    }
}
