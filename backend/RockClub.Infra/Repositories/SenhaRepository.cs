

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
        public bool VerificaSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            // instanciando um objeto temporário(using) hmac
            // que recebe classe que faz encripta hash em 256bits
            // recebendo de parametro a senha salt para linkar com a senha hash
            // e aumentar o nível de seguança da senha
            using (var hmac = new HMACSHA256(senhaSalt))
            {
                /* criando a senha hash baseado na senha passada então por logica
                   essa senha hash teria que já ter no banco uma igual */
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));

                /* retorna se computedHash(senha passa por login hasheada) é igual
                   a senhaHash(senha hasheada que já esta dentro do banco)*/
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

                claims: clainsCriada, // claim criada
                expires: DateTime.Now.AddDays(1), // token expira com 1 ano
                signingCredentials: cred // credencial criada acima

                );

            //
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        
    }
}
