using Autokuca.Model;
using Autokuca.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autokuca.Server.Controllers
{
    [ApiController, Route("api/saloni")]
    public class SalonController : Controller
    {
        private IService _service { get; set; }
        public SalonController(IService service)
        {
            _service = service;
        }
        [HttpGet("")]
        public async Task<IActionResult> DohvatiSalone(string? naziv = "")
        {
            try
            {
                var result = await _service.GetAll(naziv);
                return (result != null) ? Ok(result) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> DohvatiSalon(int id)
        {
            try
            {

                var result = await _service.DohvatiSalon(id);

                return result is null ? NotFound() : Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize]
        [HttpPut("update")]
        public async Task<ActionResult> AzurirajSalon([FromBody] Salon Salon)
        {
            try
            {

                if (Salon == null)
                {
                    return NotFound();
                }

                var success = await _service.AzurirajSalon(Salon);
                return Ok(success);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> NapraviSalon([FromBody] Salon Salon)
        {
            try
            {
                if (Salon is null)
                {
                    return NotFound(Salon);
                }

                var success = await _service.NapraviSalon(Salon);
                return Ok(success);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> IzbrisiSalon(int SalonId)
        {
            try
            {
                //if (!SalonId.HasValue)
                //{
                //    return NotFound();
                //}

                var success = await _service.IzbrisiSalon(SalonId);
                return Ok(success);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
