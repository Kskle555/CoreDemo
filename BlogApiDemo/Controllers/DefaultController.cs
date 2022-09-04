using BlogApiDemo.DataAccesLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        Context ct = new Context();
        [HttpGet]
        public IActionResult GetList()
        {
            var getlist = ct.Employess.ToList();
            return Ok(getlist);
           
        }
      
      
        [HttpPost]
        public IActionResult EmployeAdd(Employe employe)
        {
            var addemploye = ct.Employess.Add(employe);
            ct.SaveChanges();
            return Ok(addemploye);

        }
        [HttpGet("{id}")]
        public IActionResult FindEmploye(int id)
        {
             var emp = ct.Employess.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmploye(int id)
        {
           var employes = ct.Employess.Find(id);
            ct.Remove(employes);
            ct.SaveChanges();
            return Ok();

        }

        [HttpPut]
        public IActionResult EmployeUpdate(Employe employee)
        {
            var emp = ct.Find<Employe>(employee.ID);
            if (emp==null)
            {
                return NotFound();

            }
            else
            {
                emp.Name = employee.Name;
                ct.Update(emp);
                ct.SaveChanges();
                return Ok();

            }
        }
       
    }
}
