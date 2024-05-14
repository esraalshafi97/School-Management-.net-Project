using schoolManagmentAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace schoolManagmentAPI.Models
{
    public class UserDto
    {
        
            [Required]
            [StringLength(50)]
            public String UserName { get; set; }

            [Required]
            [StringLength(100)] 
            public string? Password { get; set; }


        
    }
}
