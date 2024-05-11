using Agenda.Aplicacion.Dtos;
using Agenda.Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioAplicacion _usuario;

        public UsuarioController(IUsuarioAplicacion usuario)
        {
            _usuario = usuario;
        }

        // GET: api/<UsuarioController>
        [HttpGet("GetAllUsuarios")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var response = await _usuario.GetAllUsers();
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

        // GET api/<UsuarioController>/5
        [HttpGet("GetUsuarioByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var response = await _usuario.GetUsuarioById(id);
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

        // POST api/<UsuarioController>
        [HttpPost("isUserValidAsync")]
        public async Task<IActionResult> isUserValidAsync([FromBody] UsuarioDto user)
        {
            try
            {
                var response = await _usuario.isValidUser(user);
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

        // POST api/<UsuarioController>
        [HttpPost("AgregarUserAsync")]
        public async Task<IActionResult> AgregarUserAsync([FromBody] UsuarioDto user)
        {
            try
            {
                var response = await _usuario.AddUser(user);
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

        // PUT api/<UsuarioController>/5
        [HttpPut("UpdateUsuarioAsync/{id}")]
        public async Task<IActionResult> ActualizarUserAsync([FromBody] UsuarioDto user)
        {
            try
            {
                var response = await _usuario.UpdateUser(user);
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

        // DELETE api/<UsuarioController>/5
        [HttpDelete("DeleteUserAsync/{id}")]
        public async Task<IActionResult> EliminarUserAsync(int id)
        {
            try
            {
                var response = await _usuario.DeleteUser(id);
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
