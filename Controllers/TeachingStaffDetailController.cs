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
            var items = _repository.GetAll();
            return items.ToList();
        }  

        [HttpGet("{id}")]
        public ActionResult<TeachingStaffDetail> GetDetails(int id)
        {
            var item = _repository.GetDetails(id);
            if( item==null )
                return NotFound();
            return item;    
        } [HttpPost("tsdaddnew")]
        public ActionResult<TeachingStaffDetail> Create(TeachingStaffDetail tsd)
        {
            if(tsd==null)
                return BadRequest();
            
            _repository.Create(tsd);
            return tsd;
        }
        [HttpPut("tsdupdate/{id}")]
        public ActionResult<TeachingStaffDetail> Update(int id, TeachingStaffDetail tsd)
        {
            if(tsd==null)
                return BadRequest();
            _repository.Update(tsd);
            return tsd;
        }
        [HttpDelete("tsdremove/{id}")]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
        
    }
}