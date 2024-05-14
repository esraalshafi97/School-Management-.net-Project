using AutoMapper;
using cityInfo.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using school.Services;
using schoolManagmentAPI.Data.Entities;
using XAct.Security;

namespace schoolManagmentAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        readonly ILogger<TeacherController> _logger;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;


        public TeacherController(ILogger<TeacherController> logger,
            ISchoolRepository schoolRepository,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        //[Authorize]
        [HttpGet("{SubjctId}")]
        public async Task<ActionResult<List<TeacherDto>>> getTeachers(int SubjctId)
        {
            var result = await _schoolRepository.GetTeachersForSubjectAsync(SubjctId);


            if (result == null)
            {
                _logger.LogInformation($"not Found the Teacher id of {SubjctId}");

                return NotFound();

            }
            return Ok(_mapper.Map<IEnumerable<TeacherDto>>(result));

        }
        [HttpGet()]
        public async Task<ActionResult<List<TeacherDto>>> getAllTeachers()
        {
            var result = await _schoolRepository.GetTeachersAsync();


            if (result == null)
            {
                _logger.LogInformation($"no data");

                return NotFound();

            }
            return Ok(_mapper.Map<IEnumerable<TeacherDto>>(result));

        }
        
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> AddTeacher(TeacherCreation data)
        {

            var finalTeacher = _mapper.Map<Teacher>(data);

            _schoolRepository.AddTeacher(
               finalTeacher);
            await _schoolRepository.SaveChangesAsync();

            return NoContent();

        }


        //[Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialyUpdateTeacher(
            int id,
            JsonPatchDocument<TeacherCreation> patchDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var teacherEntity = await _schoolRepository.GetTeacher(id);

            if (teacherEntity == null)
            {
                return BadRequest(ModelState);
            }
            var teacherToPatch = _mapper.Map<TeacherCreation>(
               teacherEntity);

            patchDocument.ApplyTo(teacherToPatch);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(teacherToPatch))
            {
                return BadRequest(ModelState);
            }


            _mapper.Map(teacherToPatch, teacherEntity);


            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacher(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _schoolRepository.GetTeacher(id);

            _schoolRepository.DeleteTeacher(data);

            _schoolRepository.SaveChangesAsync();




            return NoContent();
        }



    }
}
