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
            try{
                var items = _repository.GetAll();
            return items.ToList();
            } catch(Exception e)
            {
                throw;
            }
        }  
        [HttpGet("{Standard}")]
        public ActionResult<ClassRoom> GetDetails(string standard)
        {
            try{
                var item = _repository.GetDetails(standard);
            if( item==null)
                return NotFound();
            return item;   }
            catch(Exception e)
            {
                throw;
            } 
        }
        [HttpPost("clsaddnew")]
        public ActionResult<ClassRoom> Create(ClassRoom cls)
        {
            if(cls==null)
                return BadRequest();
            try {
            _repository.Create(cls);
            return cls; }
            catch(Exception e){
            throw ;
            }
        }
        [HttpPut("clsupdate/{Standard}")]
        public ActionResult<ClassRoom> Update(string standard, ClassRoom cls)
        {
            if(cls==null)
                return BadRequest();
            try{
            _repository.Update(cls);
            return cls;}
            catch(Exception e)
            {
                throw;
            }
        }
        [HttpDelete("clsremove/{Standard}")]
        public ActionResult Delete(string standard)
        {
           try { _repository.Delete(standard);
            return Ok(); }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}