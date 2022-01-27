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
    public class StaffClassificationController : ControllerBase
    {
        ICRUDRepository<Staffclassification, int> _repository;
        public StaffClassificationController(ICRUDRepository<Staffclassification, int>
        repository) => _repository = repository;
        public ActionResult<IEnumerable<Staffclassification>> Get()
        {
            try
            {
                var items = _repository.GetAll();
                return items.ToList();
            }
            catch (Exception e)
            {
                throw;
            }

        }
        [HttpGet("{id}")]
        public ActionResult<Staffclassification> GetDetails(int id)
        {
            try
            {
                var item = _repository.GetDetails(id);
                if (item == null)
                    return NotFound();
                return item;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpPost("scladdnew")]
        public ActionResult<Staffclassification> Create(Staffclassification scl)
        {
            if (scl == null)
                return BadRequest();
            try
            {
                _repository.Create(scl);
                return scl;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpPut("sclupdate/{id}")]
        public ActionResult<Staffclassification> Update(int id, Staffclassification scl)
        {
            if (scl == null)
                return BadRequest();
            try
            {
                _repository.Update(scl);
                return scl;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpDelete("sclremove/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}