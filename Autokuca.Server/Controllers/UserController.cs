using Autokuca.Model;
using Autokuca.Service.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autokuca.Server.Controllers
{
    [ApiController, Route("api/users")]
    public class UserController : Controller
    {
        private IService _service { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IService service, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIManager)
        {
            _service = service;
            _signInManager = signIManager;
            _userManager = userManager;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetApplicationUsers(string mail = "", string lozinka = "")
        {
            try
            {
                var result = await _service.GetApplicationUsers(mail, lozinka);
                //var userInRole = await _userManager.IsInRoleAsync(user,role);
                if (result == null)
                {
                    return NotFound();
                }
                else if (await _userManager.IsInRoleAsync(result[0], "GlobalAdmin"))
                {
                    return Ok(Tuple.Create(result[0], "GlobalAdmin"));
                }
                else if (await _userManager.IsInRoleAsync(result[0], "Admin"))
                {
                    return Ok(Tuple.Create(result[0], "Admin"));
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpGet("{idUser}")]
        public async Task<ActionResult> DohvatiUser(string idUser)
        {
            try
            {

                var result = await _service.DohvatiUser(idUser);

                return result is null ? NotFound() : Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("logout"), Authorize]
        public async Task<ActionResult> Logout(SignInManager<ApplicationUser> signInManager)
        {
            await _signInManager.SignOutAsync().ConfigureAwait(false);
            return Ok();
        }

    }
}
