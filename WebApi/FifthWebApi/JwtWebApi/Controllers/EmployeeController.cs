using JwtWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "David", Department = "HR", Salary = 45000 },
            new Employee { Id = 3, Name = "Smith", Department = "Sales", Salary = 40000 }
        };

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(employees);
        }
    }
}