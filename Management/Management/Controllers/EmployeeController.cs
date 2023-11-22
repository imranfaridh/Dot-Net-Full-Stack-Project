using Management.Database;
using Management.DTO.Employee;
using Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public EmployeeController(SchoolDbContext context)
        {
            this._context = context;
        }

        [HttpGet("getAll")]
        public ActionResult<List<GetEmployee>> getEmployee()
        {
            var employee = _context.Employees.ToList();
            return Ok(employee);
        }

        [HttpGet("get/{id:int}")]
        public ActionResult<GetEmployee> getById(int id)
        {
            var employee = _context.Employees.Find(id);
            if (id != 0)
            {
                if (employee != null)
                {
                    return Ok(employee);
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
        public ActionResult<CreateEmployee> createEmployee([FromBody] CreateEmployee employee)
        {
            Employee employee_ = new Employee();
            employee_.EmployeeName = employee.EmployeeName;
            employee_.Department = employee.Department;
            employee_.DOJ = employee.DOJ;
            _context.Employees.Add(employee_);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("update/{id:int}")]
        public ActionResult<UpdateEmployee> updateEmployee(int id, [FromBody] UpdateEmployee employee)
        {
            var employee_ = _context.Employees.Find(id);
            if (id != 0)
            {
                if (employee != null)
                {
                    employee_.EmployeeName = employee.EmployeeName;
                    employee_.Department = employee.Department;
                    employee.DOJ = employee.DOJ;
                    _context.Employees.Update(employee_);
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
        public ActionResult deleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (id != 0)
            {
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return Ok(employee.EmployeeName);
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
    }
}
