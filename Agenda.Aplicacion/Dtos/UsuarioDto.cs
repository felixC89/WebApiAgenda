using System.ComponentModel.DataAnnotations;

namespace Agenda.Aplicacion.Dtos
{
    public class UsuarioDto
    {
        public long Iduser { get; set; }

        [Required(ErrorMessage = "El es campo usuario es requerido")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "El es campo contraseña es requerido")]
        public string Password { get; set; } = null!;
    }
}
