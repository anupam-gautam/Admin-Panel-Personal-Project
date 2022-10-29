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
        [Route("RegisterAdmin")]
        [HttpPost("AdminRegistration")]
        public IActionResult RegisterAdmin([FromBody] AdminInformation model)
        {
            try
            {
                _context.AdminInformations.Add(new AdminInformation
                {

                    Name = model.Name,
                    Username = model.Username,
                    MobileNumber = model.MobileNumber,
                    Email = model.Email,
                    Pincode = model.Pincode
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
        [Route("AdminLogin")]
        [HttpPost]
        public IActionResult AdminLogin([FromBody] AdminInformation model)
        {
            try
            {
                var record = _context.AdminInformations.Where(u => u.Username == model.Username && u.Pincode == model.Pincode).ToList();
                if (record == null)
                {
                    return BadRequest();
                }
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("AddCustomer")]
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
                    //FundAmount = customerInformation.FundAmount,
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
        [Route("EditCustomer")]
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

                //information.Name = customerInformation.Name;
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

        [Route("DeleteCustomer")]
        [HttpDelete]
        public IActionResult DeleteCustomer(CustomerInformation customerInformation)
        {
            try
            {
                CustomerInformation information = _context.CustomerInformations.Where(u => u.Name == customerInformation.Name).FirstOrDefault();
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
