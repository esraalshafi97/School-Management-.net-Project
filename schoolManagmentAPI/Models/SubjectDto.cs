using System;
namespace cityInfo.api.Models
{
	public class SubjectDto
	{
        public int Id { get; set; }
        public String Name { get; set; }
       
        public ICollection<TeacherDto> Teatcher { get; set; } = new List<TeacherDto>();



    }
}

