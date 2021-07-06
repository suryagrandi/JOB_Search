using JOB_Search.Common.Models;
using JOB_Search.Data.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JOB_Search.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserDetails _userDetails;

        public UserController(UserDetails userDetails)
        {
            _userDetails = userDetails;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var data = _userDetails.GetallUsers();
            if (data != null)
            {
                return Ok(new { status = 200, success = true, response = data });
            }
            else
            {
                return Ok(new { status = 401, success = false, response = "Details not found" });
            }
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(Users users)
        {
            int data = _userDetails.AddUser(users);
            if (data > 0)
            {
                return Ok(new { status = 200, success = true, response = "User added successfully" });
            }
            else
            {
                return Ok(new { status = 401, success = false, response = "Data not registered" });
            }
        }

    }
}
