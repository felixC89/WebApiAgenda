namespace Agenda.Aplicacion.Dtos
{
    public class UsuarioDto
    {
        public long Iduser { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
