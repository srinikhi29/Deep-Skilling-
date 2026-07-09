using WebApplication4.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>
        {
            new Employee{Id=1,Name="John",Department="IT",Salary=50000},
            new Employee{Id=2,Name="David",Department="HR",Salary=45000},
            new Employee{Id=3,Name="Smith",Department="Sales",Salary=40000}
        };

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(employees);
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            Employee? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound($"Employee with id {id} not found");

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee emp)
        {
            if (emp == null)
                return BadRequest("Employee data is required");

            emp.Id = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            employees.Add(emp);

            return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp);
        }

        // PUT: api/Employee/1
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee emp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            Employee? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound($"Employee with id {id} not found");

            employee.Name = emp.Name;
            employee.Department = emp.Department;
            employee.Salary = emp.Salary;

            return Ok(employee);
        }

        // DELETE: api/Employee/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            Employee? employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound($"Employee with id {id} not found");

            employees.Remove(employee);

            return NoContent();
        }
    }
}