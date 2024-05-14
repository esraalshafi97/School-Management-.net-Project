using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace cityInfo.api.Models
{
	public class TeacherCreation
    {
        [Required(ErrorMessage ="you must provide a Name ")]
        [MaxLength(50)]
        public String Name { get; set; }

        /*[Range(10000000000, 29999999999, ErrorMessage = "Error NationalNumber")]*/
        public int NationalNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public IFormFile? TeacherImage { get; set; }

    }
}

