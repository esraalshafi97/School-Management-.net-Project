using AutoMapper;
using cityInfo.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.Services;
using schoolManagmentAPI.Data.Entities;
using schoolManagmentAPI.Models;

namespace schoolManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        readonly ILogger<StudentController> _logger;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;


        public StudentController(ILogger<StudentController> logger,
            ISchoolRepository schoolRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        public async Task<ActionResult<List<SubjectDto>>> getAllSubjects()
        {
            var result = await _schoolRepository.GetSubjectsAsync();


            if (result == null)
            {
                _logger.LogInformation($"no data");

                return NotFound();

            }
            return Ok(_mapper.Map<IEnumerable<SubjectDto>>(result));

        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> AddSubject(SubjectCreation data)
        {

            var finaldata = _mapper.Map<Subject>(data);

            _schoolRepository.AddSubject(
               finaldata);
            await _schoolRepository.SaveChangesAsync();

            return NoContent();

        }

        [Authorize]
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteSubject(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _schoolRepository.GetSubject(id);

            _schoolRepository.DeleteSubject(data);

            _schoolRepository.SaveChangesAsync();

            return NoContent();
        }


    }
}
