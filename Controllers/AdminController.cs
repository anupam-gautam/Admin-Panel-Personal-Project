using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdminPanelProject.Models;

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


        //Admin Registration
        [HttpPost("AdminRegistration")]
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
                });
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

        //Admin Login
        [HttpGet]
        public IActionResult AdminLogin(string username, string pincode)
        {
            try
            {
                var record = _context.AdminInformations.Where(u => u.Username == username && u.Pincode == pincode).ToList();
                if (record != null)
                {
                    return Ok(record);
                }
                return BadRequest();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(CustomerInformation customerInformation)
        {
            try
            {
                _context.CustomerInformations.Add(new CustomerInformation
                {

                    Name = customerInformation.Name,
                    Address = customerInformation.Address,
                    MobileNumber = customerInformation.MobileNumber,
                    BusinessType = customerInformation.BusinessType,
                    LoanAmount = customerInformation.LoanAmount,
                    LoanPurpose = customerInformation.LoanPurpose,
                    FundAmount = customerInformation.FundAmount,
                });
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

        [HttpPut]
        public IActionResult EditCustomer(CustomerInformation customerInformation)
        {
            try
            {
                CustomerInformation information = _context.CustomerInformations.Where(u => u.Name == customerInformation.Name || u.MobileNumber == customerInformation.MobileNumber).FirstOrDefault();
                if (information == null)
                {
                    throw new Exception();
                }

                information.Name = customerInformation.Name;
                information.Address = customerInformation.Address;
                information.MobileNumber = customerInformation.MobileNumber;
                information.BusinessType = customerInformation.BusinessType;
                information.LoanAmount = customerInformation.LoanAmount;
                information.LoanPurpose = customerInformation.LoanPurpose;
                information.FundAmount = customerInformation.FundAmount;
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

        [HttpDelete]
        public IActionResult DeleteCustomer(string name, int mobilenumber)
        {
            try
            {
                CustomerInformation information = _context.CustomerInformations.Where(u => u.Name == name || u.MobileNumber == mobilenumber).FirstOrDefault();
                if (information == null)
                {
                    throw new Exception();
                }
                _context.CustomerInformations.Remove(information);
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

    }
}
