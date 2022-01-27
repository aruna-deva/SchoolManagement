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
    public class StudentDetailsController : ControllerBase
    {
         ICRUDRepository<StudentDetail, int> _repository;
        public StudentDetailsController(
            ICRUDRepository<StudentDetail, int> repository
        ) =>_repository = repository;
        public ActionResult<IEnumerable<StudentDetail>> Get()
        {
           try { var items = _repository.GetAll();
            return items.ToList(); }
            catch(Exception e)
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public ActionResult<StudentDetail> GetDetails(int id)
        {
           try{ var item = _repository.GetDetails(id);
            if(item==null)
               return NotFound();
            return item; }
            catch(Exception e)
            {
                throw;
            }
        }
         [HttpPost("addnew")]
        public ActionResult<StudentDetail> Create(StudentDetail std)
        {
            if(std==null)
                return BadRequest();
            try{
            _repository.Create(std);
            return std; }
            catch(Exception e)
            {
                throw;
            }
        }
        [HttpPut("update/{id}")]
        public ActionResult<StudentDetail> Update(int id, StudentDetail std)
        {
            if(std==null)
                return BadRequest();
           try{ _repository.Update(std);
            return std; }
            catch(Exception e)
            {
                throw;
            }
        }
        [HttpDelete("remove/{id}")]
        public ActionResult Delete(int id)
        {
           try{ _repository.Delete(id);
            return Ok(); }
            catch(Exception e)
            {
                throw;
            }
        }

    }
}