using MASFlightBooking.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MASFlightBooking.WebAPI.Controllers
{

    //[Route("api/[controller]")]
    // [ApiController]
    //public class AuthenticationController
    //{
    //    //An empty MVC controller

    //    //Controller atrribute

    //    public UserManager<Users> usermanager;
    //    public RoleManager<IdentityRole> rolemanager;
    //    private readonly ILogger<AuthenticationController> logger;
    //    //makes it easy to access appsettings
    //    public readonly IConfiguration configuration;


    //    //constructor
    //    public AuthenticationController(UserManager<Users> usermanager, RoleManager<IdentityRole> rolemanager, IConfiguration configuration, ILogger<AuthenticationController> logger)
    //    {
    //        this.usermanager = usermanager;
    //        this.rolemanager = rolemanager;
    //        this.configuration = configuration;
    //        this.logger = logger;

    //    }
    //    [HttpPost]
    //    [Route("register")]

    //    //Frombody is aclass that implement the ibindingsourcemetadata interface(it specifies a data source for modelbinding)
    //    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = new Users()
    //            {
    //                UserName = registerModel.UserName,
    //                //UserName = registerModel.UserName,
    //                Email = registerModel.Email,
    //                SecurityStamp = Guid.NewGuid().ToString()
    //            };
    //            var result = await usermanager.CreateAsync(user, registerModel.Password);
    //            if (result.Succeeded)
    //            {
    //                await rolemanager.CreateAsync(new IdentityRole(RoleNames.User));
    //                await usermanager.AddToRoleAsync(user, RoleNames.User);

    //                var token = await usermanager.GenerateEmailConfirmationTokenAsync(user);
    //                var confirmationLink = Url.Action("ConfirmEmail", "Account", new { token = token }, Request.Scheme);

    //                logger.Log(LogLevel.Warning, confirmationLink);

    //                return Ok(new ResponseViewModel { Success = true, Error = "User successfully created" });
    //            }



    //            /* if (!result.Succeeded)
    //             {
    //                foreach (var error in result.Errors)
    //                {
    //                   ModelState.AddModelError("User creation unsuccessful,please check details", error.Description);


    //                }
    //                //return BadRequest(new ResponseModel { Success = false, Error = result.Errors.ToString()});
    //             }
    //             else
    //             {
    //                  //checking if user role exist 
    //                 if (!await rolemanager.RoleExistsAsync(RoleNames.User))
    //                 //assigning a new role to a non user

    //             }*/
    //        }
    //        return BadRequest(new ResponseViewModel { Success = false, Error = "User details is invalid" });

    //    }

    //    [HttpPost]
    //    [Route("login")]
    //    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    //    {
    //        var user = await usermanager.FindByNameAsync(loginModel.UserName);
    //        if (user != null && await usermanager.CheckPasswordAsync(user, loginModel.Password))
    //        {
    //            var userRoles = await usermanager.GetRolesAsync(user);

    //            var authClaims = new List<Claim>
    //            {


    //            };

    //            new Claim(ClaimTypes.Name, user.UserName);
    //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());


    //            foreach (var userRole in userRoles)
    //            {
    //                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
    //            }
    //            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));


    //            var token = new JwtSecurityToken(
    //                issuer: configuration["JWT:Issuer"],
    //                audience: configuration["JWT.Audience"],
    //                expires: DateTime.Now.AddMinutes(20),
    //                claims: authClaims,
    //                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

    //            return Ok(new
    //            {
    //                token = new JwtSecurityTokenHandler().WriteToken(token),
    //                expiration = token.ValidTo

    //            });
    //        }
    //        return Unauthorized();
    //    }

    //    [HttpPost("register-admin")]
    //    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel registerModel)
    //    {
    //        //checking if user exist in the admin role

    //        var userExists = await usermanager.FindByNameAsync(registerModel.UserName);
    //        if (userExists != null)
    //            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseViewModel { Success = false, Error = "Admin with the same name exist" });
    //        var adminUser = new Users()
    //        {
    //            UserName = registerModel.UserName,
    //            Email = registerModel.Email,
    //            SecurityStamp = Guid.NewGuid().ToString(),
    //        };

    //        var result = await usermanager.CreateAsync(adminUser, registerModel.Password);
    //        if (!result.Succeeded)
    //        {
    //            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseViewModel { Success = false, Error = "Registration not successful" });

    //        }
    //        if (!await rolemanager.RoleExistsAsync(RoleNames.Admin))
    //            await rolemanager.CreateAsync(new IdentityRole(RoleNames.Admin));

    //        if (await rolemanager.RoleExistsAsync(RoleNames.Admin))
    //        {
    //            await usermanager.AddToRoleAsync(adminUser, RoleNames.Admin);

    //        }
    //        return Ok(new ResponseViewModel { Success = true, Error = "Registration Successful" });

    //    }

    //}




}

