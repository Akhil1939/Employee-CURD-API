using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CURD.Models;
using CURD.Models.dataModels;

namespace CURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly employeeContext _context;

        public EmployeesController(employeeContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            return await _context.Employees.Select(emp => new EmployeeModel()
            {
                EmpId = emp.EmpId,
                EmpName = emp.EmpName,
                EmpEmail = emp.EmpEmail,
                EmpMobile = emp.EmpMobile,
                EmpSalary = emp.EmpSalary,
                department = emp.EmpDept.DeptName

            }).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public  ActionResult<Employee> GetEmployee(int id)
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            var employee =  _context.Employees.Where(emp=> emp.EmpId == id).AsQueryable();

            if (!employee.Any())
            {
                return NotFound();
            }

            return employee.Select(employee => new Employee()
            {
               EmpId= employee.EmpId,
               EmpName = employee.EmpName,
               EmpEmail= employee.EmpEmail,
               EmpMobile= employee.EmpMobile,
               EmpSalary= employee.EmpSalary,
               EmpDeptId = employee.EmpDept.DeptId

            }).First();
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          if (_context.Employees == null)
          {
              return Problem("Entity set 'employeeContext.Employees'  is null.");
          }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmpId == id)).GetValueOrDefault();
        }
    }
}
