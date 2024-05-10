namespace Agenda.Dominio.Entidades;

public partial class Agendum
{
    public long IdAgenda { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public string? Direccion { get; set; }

    public int Telefono { get; set; }

    public string Correo { get; set; } = null!;

    public string FechaNacimiento { get; set; } = null!;

    public int Edad { get; set; }

    public long IdUser { get; set; }
}
