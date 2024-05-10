namespace Agenda.Dominio.Utilies
{
    public class Response<T>
    {
        public T? Data {get; set;}
        public bool IsSuccessfullRequest { get; set; }
        public string? Message { get; set; }
    }
}
