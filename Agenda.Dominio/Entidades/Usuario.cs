namespace Agenda.Dominio.Entidades;

public partial class Usuario
{
    public long Iduser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
