using System.ComponentModel.DataAnnotations;

namespace Agenda.Aplicacion.Dtos
{
    public class AgendaDto
    {
        public long IdAgenda { get; set; }

        [Required(ErrorMessage = "El es campo nombre es requerido")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El es campo apellida es requerido")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El es campo nacionalidad es requerido")]
        public string Nacionalidad { get; set; } = null!;

        public string? Direccion { get; set; }

        [Required(ErrorMessage = "El es campo telefono es requerido")]
        public int? Telefono { get; set; }

        [Required(ErrorMessage = "El es campo email es requerido")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Por favor ingrese un email válido")]
        public string Correo { get; set; } = null!;

        [Required(ErrorMessage = "El es campo fecha de nacimienton es requerido")]
        public string FechaNacimiento { get; set; } = null!;

        [Required(ErrorMessage = "El es campo edad es requerido")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El es campo idUsuario es requerido")]
        public long IdUser { get; set; }

    }
}
