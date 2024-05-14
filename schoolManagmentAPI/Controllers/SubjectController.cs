using AutoMapper;
using cityInfo.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using school.Services;
using schoolManagmentAPI.Data.Entities;
using schoolManagmentAPI.Models;

namespace schoolManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubjectController : ControllerBase
    {
        readonly ILogger<SubjectController> _logger;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        const  String _subjectCashDataValue= "Subjects";


        public SubjectController(ILogger<SubjectController> logger,
            ISchoolRepository schoolRepository,
            IMapper mapper,
            IMemoryCache memoryCache)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(mapper));
        }
         [HttpGet()]
        public async Task<ActionResult<List<SubjectDto>>> getAllSubjects()
        {

            var cacheData = _memoryCache.Get<IEnumerable<Subject>>(_subjectCashDataValue);
            if (cacheData != null)
            {
                return Ok(_mapper.Map<IEnumerable<SubjectDto>>(cacheData));
            }

            var result = await _schoolRepository.GetSubjectsAsync();


            if (result == null)
            {
                _logger.LogInformation($"no data");

                return NotFound();

            }
            _memoryCache.Set(_subjectCashDataValue, result, DateTimeOffset.Now.AddMinutes(1.0));

            return Ok(_mapper.Map<IEnumerable<SubjectDto>>(result));

        }
        
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> AddSubject(SubjectCreation data)
        {

            var finaldata = _mapper.Map<Subject>(data);

            _schoolRepository.AddSubject(
               finaldata);
            await _schoolRepository.SaveChangesAsync();

            return NoContent();

        }

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
