using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using school.Services;
using schoolManagmentAPI.Models;
using schoolManagmentAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace schoolManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly ILogger<AuthController> _logger;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;



        public AuthController(ILogger<AuthController> logger,
            ISchoolRepository schoolRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _schoolRepository = schoolRepository ?? throw new ArgumentNullException(nameof(schoolRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration; 
        }


        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(
            UserDto authenticationRequestBody)
        {

            String password= HashData.HashPassword(authenticationRequestBody.Password);
            // Step 1: validate the username/password
             bool isExists=await _schoolRepository.IsUserValid(
                authenticationRequestBody.UserName,
                password);

            if (!isExists)
            {
                return Unauthorized();
            }

            // Step 2: create a token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("userName", authenticationRequestBody.UserName));
          

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

    }
}
