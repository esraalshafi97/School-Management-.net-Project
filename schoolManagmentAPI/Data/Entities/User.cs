using Microsoft.EntityFrameworkCore.ValueGeneration;
using schoolManagmentAPI.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using XSystem.Security.Cryptography;

namespace schoolManagmentAPI.Data.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public String UserName { get; set; }
        
        [Required]
        [StringLength(100)] // Increase the length to accommodate the hashed password
        public string? Password
        {
            get;
             set;
            
         
        }
        public void HashPassword( )
        {
            Password=HashData.HashPassword(Password);
        }



        }
}
