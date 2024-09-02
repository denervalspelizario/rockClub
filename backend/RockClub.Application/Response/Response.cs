namespace RockClub.Application.Response
{
    public class Response<T>
    {
        public T? Dados { get; set; }
        public string? Mensagem { get; set; }
        public bool? Status { get; set; }
    }
}
