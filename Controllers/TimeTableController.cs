using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Infrastructure;
using System.Security.Claims;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
        string TypeName;
        int UserId;
          ICRUDRepository<TimeTable, string> _repository;
        public TimeTableController(ICRUDRepository<TimeTable, string> repository ) => _repository = repository;

        /************** CHANGES : ******************************************
        * Add the Authorize attribute to the method 
        * In the method, we are getting the Claim values like Name, NameIdentifier and Role 
        * if the RoleName is not "admin" or any other role as required, 
        *  then we are returning an Unauthorized() response back to the user.
        * else valid response will be sent. 
        ********************************************************************/
        [Microsoft.AspNetCore.Authorization.Authorize()]
        public ActionResult<IEnumerable<TimeTable>> Get()
        {
            TypeName = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            UserId = Convert.ToInt32("0" + HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var role = Convert.ToString(HttpContext.User.FindFirst(ClaimTypes.Role).Value);
            if(role.ToLower()!="principal" &&
            role.ToLower()!="viceprincipal") {
                return Unauthorized();
            }
            //end of the code inclusion. 
            if(UserId==0) return BadRequest();
            var items = _repository.GetAll();
            return items.ToList();
        }  
        [HttpGet("{id}")]
        public ActionResult<TimeTable> GetDetails(string id)
        {
            var item = _repository.GetDetails(id);
            if( item==null )
                return NotFound();
            return item;    
        } 
        [HttpPost("ttaddnew")]
        public ActionResult<TimeTable> Create(TimeTable tt)
        {
            if(tt==null)
                return BadRequest();
            
            _repository.Create(tt);
            return tt;
        }
        [HttpPut("ttupdate/{id}")]
        public ActionResult<TimeTable> Update(string id, TimeTable tt)
        {
            if(tt==null)
                return BadRequest();
            _repository.Update(tt);
            return tt;
        }
        [HttpDelete("ttremove/{id}")]
        public ActionResult Delete(string id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}