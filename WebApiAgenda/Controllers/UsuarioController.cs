using Agenda.Dominio.Dtos;
using Agenda.Infraestructura.Commands.AgendaCommands;
using Agenda.Infraestructura.Queries.UserQueries;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsuarioController>
        [HttpGet("GetAllUsuarios")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var response = await _mediator.Send(new GetAllUserTaskQuery());
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
                var response = await _mediator.Send(new GetByIdUserTaskQuery(id));
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
                var response = await _mediator.Send(new IsValidUserTaskQuery(user));
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
                var response = await _mediator.Send(new CreateUserTaskCommand(user));
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
                var response = await _mediator.Send(new UpdateUserTaskCommand(user));
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
                var response = await _mediator.Send(new DeleteUserTaskCommand(id));
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
