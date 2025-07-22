using Microsoft.AspNetCore.Mvc;
using RestapiInventory.Dto.Common;
using RestapiInventory.Models;
using RestapiInventory.Services;

namespace RestapiInventory.Controllers
{
    [ApiController]
    [Route("user_profile")]
    public class UserProfileController : Controller
    {
        private readonly UserProfileService _userProfileService;
        public UserProfileController(UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
        [HttpGet("get_all")]
        public IActionResult GetAllData()
        {
            FormDto<IList<UserProfile>> result = _userProfileService.GetAllData();
            return Ok(result);
        }
        [HttpGet("get_by_division")]
        public IActionResult GetByDivision(string keyword)
        {
            FormDto<IList<UserProfile>> result = _userProfileService.GetByDivision(keyword);
            return Ok(result);
        }
        [HttpGet("get_by_name")]
        public IActionResult GetByName(string keyword)
        {
            FormDto<IList<UserProfile>> result = _userProfileService.GetByName(keyword);
            return Ok(result);
        }
        [HttpGet("get_by_id")]
        public IActionResult GetById(string id)
        {
            FormDto<UserProfile> result = _userProfileService.GetById(id);
            return Ok(result);
        }
    }
}
