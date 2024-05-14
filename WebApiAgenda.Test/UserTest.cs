using Agenda.Aplicacion.Definiciones;
using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using AutoMapper;
using Moq;

namespace WebApiAgenda.Test
{
    public class UserTest
    {
        private readonly Mock<IUsuarioDominio> _mockUserDomain;
        private readonly Mock<IMapper> _mapper;
        private UsuarioAplicacion _usuarioApl;

        public UserTest()
        {
            _mockUserDomain = new Mock<IUsuarioDominio>();
            _mapper = new Mock<IMapper>();
            _usuarioApl = new UsuarioAplicacion(_mockUserDomain.Object, _mapper.Object);
        }

        [Fact]
        public async void GetAllUserTest()
        {
            ////Arrange
            Task<Response<IEnumerable<Usuario>>> usuarios = Task.Run(() =>
            {
                // Your code to retrieve the list of usuarios
                List<Usuario> users = new List<Usuario>() { new Usuario { Iduser = 1, Username = "felix.calderon89@hotmail.com", Password = "12345" } };

                Response<IEnumerable<Usuario>> res = new Response<IEnumerable<Usuario>>();

                res.Data = users.ToList();
                res.IsSuccessfullRequest = true;
                res.Message = "";
                return res;
            });

            await usuarios;

            _mockUserDomain.Setup(service => service.GetAllUsers()).Returns(usuarios);


            ////Act

            var result = Task.FromResult(await _usuarioApl.GetAllUsers());

            ////Assert

            Assert.NotNull(result);

        }
    }
}