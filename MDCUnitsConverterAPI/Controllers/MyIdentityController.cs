using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MDCUnitsConverterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MyIdentityController : ControllerBase
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public MyIdentityController(RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMgr)
        {
            _roleManager = roleMgr;
            _userManager = userMgr;
        }

        [HttpPost(template:"role")]
        public async Task<IActionResult> Role([FromBody] string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            if(result.Succeeded)
            {
                return Ok();  
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost(template:"userrole")]
        public async Task<IActionResult> UserRole([FromBody]UserRoleMapping mapping) {
            var user = await _userManager.FindByNameAsync(mapping.UserName);
            if (user != null)
            {
               var result = await _userManager.AddToRoleAsync(user,mapping.RoleName);
                if (result.Succeeded)
                {
                    return Created();
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();            
        }

        [HttpGet(template:"role")]
        public async Task<List<string>> Get()
        {
            return _roleManager.Roles.Select(r=> r.Name)?.ToList();
        }
    }

    public class UserRoleMapping
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
