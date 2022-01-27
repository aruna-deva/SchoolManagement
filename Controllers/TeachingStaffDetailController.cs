using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Infrastructure;
using SchoolManagementSystem.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachingStaffDetailController : ControllerBase
    {
        ICRUDRepository<TeachingStaffDetail, int> _repository;
        public TeachingStaffDetailController(ICRUDRepository<TeachingStaffDetail, int> 
        repository ) => _repository = repository;
        
	public ActionResult<IEnumerable<TeachingStaffDetail>> Get()
        {
            try{
                var items = _repository.GetAll();
            return items.ToList(); }
            catch(Exception e)
            {
                throw;
            }
        }  

        [HttpGet("{id}")]
        public ActionResult<TeachingStaffDetail> GetDetails(int id)
        {
            try{
                var item = _repository.GetDetails(id);
            if( item==null )
                return NotFound();
            return item;   }
            catch(Exception e)
            {
                throw;
            } 
        }
         [HttpPost("tsdaddnew")]
        public ActionResult<TeachingStaffDetail> Create(TeachingStaffDetail tsd)
        {
            if(tsd==null)
                return BadRequest();
            try{
            _repository.Create(tsd);
            return tsd; }
            catch(Exception e)
            {
                throw;
            }
        }
        [HttpPut("tsdupdate/{id}")]
        public ActionResult<TeachingStaffDetail> Update(int id, TeachingStaffDetail tsd)
        {
            if(tsd==null)
                return BadRequest();
           try{ _repository.Update(tsd);
            return tsd; }
            catch(Exception e)
            {
                throw;
            }
        }
        [HttpDelete("tsdremove/{id}")]
        public ActionResult Delete(int id)
        {
           try{  _repository.Delete(id);
            return Ok(); }
            catch(Exception e)
            {
                throw;
            }
        }    
    }
}