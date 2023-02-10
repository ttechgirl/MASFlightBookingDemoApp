using MASFlightBooking.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MASFlightBooking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserInterface _userInterface;
        public RoleManager<IdentityRole> _rolemanager;
        private readonly ILogger<AuthController> _logger;
        public readonly IConfiguration _configuration;
        public AuthController( IUserInterface userInterface,RoleManager<IdentityRole> rolemanager, ILogger<AuthController> logger, IConfiguration configuration)
        {
            _userInterface = userInterface;
            _rolemanager = rolemanager;
            _logger = logger;
            _configuration = configuration;
        }
        
        
    
    }
}
 