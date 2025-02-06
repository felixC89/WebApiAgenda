using Agenda.Aplicacion.Handlers.HandlersUsuario;
using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Queries.UsersQueries;
using AutoMapper;
using MediatR;
using Moq;
using WebApiAgenda.Controllers;

namespace WebApiAgenda.Tests
{
    public class UserUnitTest
    {
        private readonly Mock<IMapper> _Imapper;
        private readonly Mock<IUnitofWork> _IunitOfWork;

        public UserUnitTest()
        {
            _IunitOfWork = new Mock<IUnitofWork>();
            _Imapper = new Mock<IMapper>();
        }

        [Fact]
        public async void TestGetAllUsersAsync()
        {
            //Arrange
            var mediatrMock = new Mock<IMediator>();
            var userController = new UsuarioController(mediatrMock.Object);

            //Act
            var Users = await userController.GetAllUsersAsync();


            //Assert
            Assert.NotNull(Users);
            //mediatrMock.Verify(m => m.Send(It.IsAny<GetAllUserTaskQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async void HandlerGetAllUsersAsync()
        {
            //Arrange

            var usersList = new Response<IEnumerable<Usuario>>
            {
                IsSuccessfullRequest = true,
                Message = $"Operación exitosa.",
                Data = new List<Usuario>()
                {
                    new Usuario()
                    {
                      Iduser = 1,
                      Username= "felix.calderon89@hotmail.com",
                      Password = "123456"
                    }
                },
            };

            _IunitOfWork.Setup(x => x.RepositoryUsuarioRead.GetAllUsersAsync()).ReturnsAsync(usersList);

            var _handler = new GetAllUsersTaskHandler(_IunitOfWork.Object, _Imapper.Object);

            //Act
           var result = await _handler.Handle(new GetAllUserTaskQuery(), new CancellationToken());


            // Assert
            _IunitOfWork.Verify(x => x.RepositoryUsuarioRead.GetAllUsersAsync(), Times.Once);

        }
    }
}