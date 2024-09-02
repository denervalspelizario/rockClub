namespace RockClub.Shared.Response
{
    public class ResponseBase<T>
    {
        public T? Dados { get; set; }
        public string? Mensagem { get; set; }
        public bool? Status { get; set; }
    }
}
