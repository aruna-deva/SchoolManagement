using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Infrastructure;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
          ICRUDRepository<TimeTable, string> _repository;
        public TimeTableController(ICRUDRepository<TimeTable, string> repository ) => _repository = repository;
        public ActionResult<IEnumerable<TimeTable>> Get()
        {
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