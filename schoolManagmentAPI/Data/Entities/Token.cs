using System.ComponentModel.DataAnnotations;

namespace schoolManagmentAPI.Data.Entities
{
    public class Token
    {
        [Key]
        public String TokenString { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
