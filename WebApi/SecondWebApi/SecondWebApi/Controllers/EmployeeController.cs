using Microsoft.AspNetCore.Mvc;
using SecondWebApi.Models;

namespace SecondWebApi.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Smith", Department = "HR", Salary = 45000 },
            new Employee { Id = 3, Name = "David", Department = "Finance", Salary = 60000 }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }
    }
}