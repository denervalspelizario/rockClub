using RockClub.Shared.Enum;


namespace RockClub.Shared.Entity
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public CargoEnum Cargo { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public DateTime TokenDataCriacao { get; set; } = DateTime.Now;
        public bool Status { get; set; }


        public UsuarioModel(
            string email, string usuario, CargoEnum cargo, 
            byte[] senhaHash, byte[] senhaSalt, DateTime tokenDataCriacao, bool status) 
        {
            Email = email;
            Usuario = usuario;
            Cargo = cargo;
            SenhaHash = senhaHash;
            SenhaSalt = senhaSalt;
            TokenDataCriacao = tokenDataCriacao;
            Status = status;
        }
    }
}
