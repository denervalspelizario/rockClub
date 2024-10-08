

using MediatR;
using RockClub.Application.ColaboradorCQ.Commands;
using RockClub.Application.UsuarioCQ.Commands;
using RockClub.Infra.Repositories;
using RockClub.Shared.Dtos;
using RockClub.Shared.Entity;
using RockClub.Shared.Interfaces;
using RockClub.Shared.Response;

namespace RockClub.Application.UsuarioCQ.Handlers
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, ResponseBase<UsuarioResponseDTO>>
    {

        // injeções de dependencia
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISenhaRepository _senhaRepository;

        public CreateUsuarioCommandHandler(
            IUsuarioRepository usuarioRepository,
            ISenhaRepository senhaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _senhaRepository = senhaRepository;
        }


        public async Task<ResponseBase<UsuarioResponseDTO>> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {

            // formatação de resposta
            var resposta = new ResponseBase<UsuarioResponseDTO>();

            

            // data de cadastro do usuario
            DateTime dataCriacaousuario = DateTime.Today.Date;

            // status do usuario se iniciam como ativo
            var status = true;




            // validações
            
            var emailExiste = await _usuarioRepository.VerificacaoEmail(request.Email);
            var userExiste = await _usuarioRepository.VerificacaoUser(request.Usuario);
            
            if (emailExiste)
            {
                resposta.Mensagem = "Email já cadastrado";
                return resposta;
            }

            if (userExiste)
            {
                resposta.Mensagem = "Cpf já cadastrado";
                return resposta;
            }

            

            

            // depois de validar criando a criptografia atravez do metodo CriarSenhaHash
            // lembrando que o método CriarSenhaHash retorna a senhaHash e senhaSalt
            _senhaRepository.CriarSenhaHash(request.Senha, out byte[] senhaHash, out byte[] senhaSalt);


            // pegando email, usuario e cargo do parametro, senhaHash e senhaSalt do método CriarSenhaHash
            var usuarioEntity = new UsuarioModel
            (
                request.Email,
                request.Usuario,
                request.Cargo,
                senhaHash,
                senhaSalt,
                dataCriacaousuario,
                status
            );


            // pegando a resposta da criação de usuário
            var respostaCriacaoUsuario = await _usuarioRepository.RegistrarUsuario(usuarioEntity);


            // formatando dados do novo usuario para resposta
            var usuarioResposta = new UsuarioResponseDTO(
                respostaCriacaoUsuario.Dados.Id,
                respostaCriacaoUsuario.Dados.Email,
                respostaCriacaoUsuario.Dados.Usuario,
                respostaCriacaoUsuario.Dados.Cargo.ToString()
                );


            

            resposta.Dados = usuarioResposta;
            resposta.Status = respostaCriacaoUsuario.Dados.Status;
            resposta.Mensagem = respostaCriacaoUsuario.Mensagem;


            return resposta;
        }
    }
}
