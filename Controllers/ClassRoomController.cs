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
    public class ClassRoomController : ControllerBase
    {
        ICRUDRepository<ClassRoom, string> _repository;
        public ClassRoomController(ICRUDRepository<ClassRoom, string> repository ) => _repository = repository;
        public ActionResult<IEnumerable<ClassRoom>> Get()
        {
            var items = _repository.GetAll();
            return items.ToList();
        }  
        [HttpGet("{Standard}")]
        public ActionResult<ClassRoom> GetDetails(string standard)
        {
            var item = _repository.GetDetails(standard);
            if( item==null)
                return NotFound();
            return item;    
        }
        [HttpPost("clsaddnew")]
        public ActionResult<ClassRoom> Create(ClassRoom cls)
        {
            if(cls==null)
                return BadRequest();
            
            _repository.Create(cls);
            return cls;
        }
        [HttpPut("clsupdate/{id}")]
        public ActionResult<ClassRoom> Update(string standard, ClassRoom cls)
        {
            if(cls==null)
                return BadRequest();
            _repository.Update(cls);
            return cls;
        }
        [HttpDelete("clsremove/{id}")]
        public ActionResult Delete(string standard)
        {
            _repository.Delete(standard);
            return Ok();
        }
    }
}