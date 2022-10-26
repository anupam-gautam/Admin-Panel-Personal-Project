using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminPanelProjectContext _context;
        public AdminController(AdminPanelProjectContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult RegisterAdmin(string name, string username, int mobile_number, string email, string pincode)
        {
            try
            {
                _context.AdminInformations.Add(new AdminInformation
                {
                    
                    Name = name,
                    Username = username,
                    MobileNumber = mobile_number,
                    Email = email,
                    Pincode = pincode
                }); ;
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = StatusCode(200),
                    //Model = model,
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult AdminLogin(string username, string pincode)
        {
            try { }
            catch(Exception ex)
            {
                return BadRequest(ex.Message)
            }
        }
    }
}
