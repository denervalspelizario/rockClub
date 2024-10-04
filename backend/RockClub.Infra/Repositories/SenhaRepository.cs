using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RockClub.Shared.Entity;
using RockClub.Shared.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RockClub.Infra.Repositories
{
    public class SenhaRepository : ISenhaRepository
    {
        public IConfiguration _config;

        // fazendo a injeção de dependencia para acessar o token cadastado la no appsettings.json
        public SenhaRepository(IConfiguration config)
        {
            this._config = config;
        }


        // metodo que cria a senha hash recebi uma senha normal e retorna senhaHash e senhaSalt
        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {

            // instanciando um objeto temporário(using)
            // que recebe classe que faz encripta hash em 256bits 
            using (var hmac = new HMACSHA256())
            {
                // criando a senha salt
                senhaSalt = hmac.Key;

                // criando a senha hash
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));

            }
        }

        // método que verifica se senha hash já existe no banco
        // senha = senha do usuario passado pelo usuário
        // senha salt = criptografia para aumentar a criptografia da senha
        // senhaHash = senha que está no banco(senha + senhaSalt + criptografia)
        public bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            // instanciando um objeto temporário(using) hmac
            // que recebe classe que faz encripta hash em 256bits
            using (var hmac = new HMACSHA256(senhaSalt))
            {
                // criando uma senha hash baseado na senha passada 
                // tem que ter uma igual no banco 
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));

                
                /* verificando se a computedHash() é igual a senhaHash(senha do banco)*/
                return computedHash.SequenceEqual(senhaHash);
            }
        }



        // método que gera o token JWT
        public string CriarToken(UsuarioModel usuario)
        {
            /* lista de Claims que são as informações sobre o usuário 
             que serão incluídas no token,  como cargo, email e nome de usuário. */

            List<Claim> clainsCriada = new List<Claim>();
            {
                new Claim("Cargo", usuario.Cargo.ToString());
                new Claim("Email", usuario.Email);
                new Claim("Username", usuario.Usuario);
            }

            // criando o token baseado na chave adicionada em appsettings.json
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));


            // criando a credencial baseado na key acima que foi baseado no token criptografado
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // agora de fato criando nosso token
            var token = new JwtSecurityToken(

                claims: clainsCriada, // claim criada(infos usuários)
                expires: DateTime.Now.AddDays(1), // token expira com 1 dia
                signingCredentials: cred // credencial criada acima

                );

            // gerando o jwt baseado nas informações do token acima
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            // retornando jwt
            return jwt;
        }

        
    }
}
