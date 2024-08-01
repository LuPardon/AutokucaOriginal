using Autokuca.Model;
using Autokuca.Service.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autokuca.Server.Controllers
{
    [ApiController, Route("api/vozila")]
    public class VoziloController : Controller
    {
            private readonly IService _service;
            public VoziloController(IService service)
            {
                _service = service;
            }
            [HttpGet("")]
            public async Task<IActionResult> DohvatiVozila(
                int? id_salona,
                string? proizvodac,
                string? model,
                string? vin,
                short? godina,
                short? snaga_motora,
                int? id_tipVozila,
                int? id_gorivo,
                int? id_mjenjac,
                int? id_oblik,
                string? opis)
            {
                try
                {
                    var result = await _service.DohvatiVozila(
                    id_salona: id_salona,
                    proizvodac: proizvodac,
                    model: model,
                    vin: vin,
                    godina: godina,
                    snaga_motora: snaga_motora,
                    id_tipVozila: id_tipVozila,
                    id_gorivo: id_gorivo,
                    id_mjenjac: id_mjenjac,
                    id_oblik: id_oblik,
                    opis: opis);

                    return (result != null) ? Ok(result) : NotFound();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult> DohvatiVozilo(int id)
            {
                try
                {
                    var result = await _service.DohvatiVozilo(id);

                    return result is null ? NotFound() : Ok(result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            //[Authorize]
            [HttpPut("update")]
            public async Task<ActionResult> AzurirajVozilo([FromBody] Vozilo vozilo)
            {
                try
                {

                    if (vozilo == null)
                    {
                        return NotFound();
                    }

                    var success = await _service.AzurirajVozilo(vozilo);
                    return Ok(success);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            //[Authorize]
            [HttpPost("create")]
            public async Task<IActionResult> NapraviVozilo([FromBody] Vozilo vozilo)
            {
                try
                {
                    if (vozilo is null)
                    {
                        return NotFound(vozilo);
                    }

                    var success = await _service.NapraviVozilo(vozilo);
                    return Ok(success);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            //[Authorize]
            [HttpDelete("delete")]
            public async Task<IActionResult> IzbrisiVozilo(int VoziloId)
            {
                try
                {
                    //if (VoziloId is null)
                    //{
                    //    return NotFound();
                    //}

                    var success = await _service.IzbrisiVozilo(VoziloId);
                    return Ok(success);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
    }
}

