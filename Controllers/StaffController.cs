using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolManagementSystem.Infrastructure;
using SchoolManagementSystem.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        SchoolManagementSystem.Infrastructure.IUserService _userService; 
        public StaffController(IUserService service)=> _userService=service;
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(User model)
        {
            //check whether all the properties are filled with values and
            //sent from the client side.All the required properties should
            //have values.Else throw error;
            if(!ModelState.IsValid)
                return BadRequest();
            //invoke the authenticate method which will hit the DB and return bool status
                var signInStatus=_userService.Authenticate(model);
                if(signInStatus==false) //user does not exist
                {
                    return NotFound();
                }
                //build a claims identity and Sign the User as was done in the Login();
                 var claims=new List<Claim>
                {
                new Claim(ClaimTypes.Name, model.TypeName),
                //new Claim(ClaimTypes.Role, model.StaffTypeId),
                //new Claim("Passcode", users["user12"]),
                new Claim(ClaimTypes.Role, "TypeId")
                };
                var claimsIdentity=new ClaimsIdentity(
                claims: claims,
                authenticationType: CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties=new AuthenticationProperties
                {
                    AllowRefresh=true,
                    IsPersistent=true
                };
                await HttpContext.SignInAsync(
                    scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                    principal: new ClaimsPrincipal(claimsIdentity),
                    properties: authProperties
                );
                return Ok();
        }
        [HttpGet("SignOut")]
        new public async Task<IActionResult> SignOut() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
        // static Dictionary<string, string> users=new Dictionary<string, string>
        // {
        //     {"user12","user12"},{"admin","admin"}
        // };
    }
}