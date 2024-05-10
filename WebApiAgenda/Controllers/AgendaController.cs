using Agenda.Aplicacion.Dtos;
using Agenda.Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaAplicacion _agenda;
        public AgendaController(IAgendaAplicacion agenda)
        {
            _agenda = agenda;
        }
        // GET: api/<AgendaController>
        [HttpGet("GetAllContactos")]
        public async Task<IActionResult> GetAllAgendaAsync(int iduser)
        {
            try
            {
                var response = await _agenda.GetAllAgenda(iduser);
                if (response.IsSuccessfullRequest)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AgendaController>/5
        [HttpGet("GetContactoByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var response = await _agenda.GetAgendaById(id);
                if (response.IsSuccessfullRequest)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AgendaController>
        [HttpPost("NuevoContactoAsync")]
        public async Task<IActionResult> AgregarContactoAsync([FromBody]  AgendaDto contacto)
        {
            try
            {
                var response = await _agenda.Add(contacto);
                if (response.IsSuccessfullRequest)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AgendaController>/5
        [HttpPut("ActualizarContactoAsync/{id}")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] AgendaDto contacto)
        {
            try
            {
                var response = await _agenda.Update(contacto);
                if (response.IsSuccessfullRequest)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AgendaController>/5
        [HttpDelete("EliminarContactoAsync/{id}")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            try
            {
                var response = await _agenda.Delete(id);
                if (response.IsSuccessfullRequest)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
