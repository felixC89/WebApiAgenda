using Agenda.Dominio.Dtos;
using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Commands.UsersCommands;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersUsuario
{
    public class CreateUserTaskHandler : IRequestHandler<CreateUserTaskCommand, Response<bool>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUserTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
        {
            var newUserDto = new UsuarioDto
            {
                Username = request.UserDto.Username,
                Password = request.UserDto.Password
            };

            var newUser = _mapper.Map<Usuario>(newUserDto);

            var result = await _unitOfWork.RepositoryUsuarioWrite.AddUserAsync(newUser);

            if (result == null)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación",
                    Data = result.Data,
                };
            }

            if (!result.IsSuccessfullRequest)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = result.IsSuccessfullRequest,
                    Message = result.Message,
                    Data = result.Data,
                };
            }

            if (!result.Data)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = result.IsSuccessfullRequest,
                    Message = result.Message,
                    Data = result.Data,
                };
            }

            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
