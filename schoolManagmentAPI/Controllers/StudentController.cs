using AutoMapper;
using cityInfo.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.Services;
using schoolManagmentAPI.Data.Entities;
using schoolManagmentAPI.Models;
using schoolManagmentAPI.Services;

namespace schoolManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly ILogger<StudentController> _logger;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;


        public StudentController(ILogger<StudentController> logger,
            ISchoolRepository schoolRepository,
            IMapper mapper,
            ImageService imageService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
        }
        [HttpGet()]
        public async Task<ActionResult<List<StudentDto>>> getAllStudents()
        {
            var result = await _schoolRepository.GetStudentsAsync();


            if (result == null)
            {
                _logger.LogInformation($"no data");

                return NotFound();

            }
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(result));

        }
        
        [HttpPost]
        public async Task<ActionResult<StudentDto>> AddStudent(StudentOfCreation data)
        {
           String imagePath= await _imageService.UploadImage(data.Image);

            var finaldata = _mapper.Map<Student>(data);
            finaldata.Image = imagePath;

            _schoolRepository.AddStudent(
               finaldata);
            await _schoolRepository.SaveChangesAsync();

            return NoContent();

        }

        //[Authorize]
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteStudentt(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _schoolRepository.GetStudent(id);

            _schoolRepository.DeleteStudent(data);

            _schoolRepository.SaveChangesAsync();

            return NoContent();
        }


    }
}
