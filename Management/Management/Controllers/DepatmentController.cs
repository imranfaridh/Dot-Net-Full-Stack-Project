using Management.Database;
using Management.DTO.Department;
using Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Management.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepatmentController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public DepatmentController(SchoolDbContext context)
        {
            this._context = context;
        }

        [HttpGet("getAll")]

        public ActionResult<List<GetDepartment>> getAllDepatment()
        {
            var department = _context.Departments.ToList();
            return Ok(department);
        }

        [HttpGet("get/{id:int}")]
        public ActionResult<GetDepartment> getDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if(id != 0)
            {
                if(department != null)
                {
                    return Ok(department);
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("save")]
        public ActionResult<CreateDepartment> createDepartment([FromBody] CreateDepartment department)
        {
            Department department_ = new Department();
            department_.DepartmentName = department.DepartmentName;
            _context.Departments.Add(department_);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("update/{id:int}")]
        public ActionResult<UpdateDepartment> updateDepartment(int id, [FromBody] UpdateDepartment department)
        {
            var department_ = _context.Departments.Find(id);
            if (id != 0)
            {
                if (department != null)
                {
                    department_.DepartmentName = department.DepartmentName;
                    _context.Departments.Update(department_);
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            else 
            { 
                return BadRequest();
            }
           
        }

        [HttpDelete("delete/{id:int}")]
        public ActionResult deleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if(id != 0)
            {
                if(department != null)
                {
                    _context.Departments.Remove(department);
                    _context.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
