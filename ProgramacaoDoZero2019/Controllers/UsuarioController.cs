using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgramacaoDoZero2019.Models;
using ProgramacaoDoZero2019.Services;
using System;

namespace ProgramacaoDoZero2019.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {           
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Parãmetro request veio nulo.";
            }
            else if (request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "Campo E-mail obrigatório.";
            }
            else if (request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "Campo Senha obrigatório.";
            }
            else
            {
                //sucesso
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.email, request.senha);
            }
            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.sobrenome) ||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.email) ||
                string.IsNullOrWhiteSpace(request.senha) ||
                string.IsNullOrWhiteSpace(request.genero))
            {
                result.sucesso = false;
                result.mensagem = "É necessário preencher todos os campos acima";
            }
            
            var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

            result = new UsuarioService(connectionString).Cadastro(request.nome, request.sobrenome, request.telefone,
            request.email, request.genero, request.senha);

            return result;
        }

        [Route("esqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Campo E-mail obrigatório.";
            }

            var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");

            result = new UsuarioService(connectionString).EsqueceuSenha(request.email);
            
            return result;
        }

        [Route("obterUsuario")]
        [HttpGet]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Usuário Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");


                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);
                
                if (usuario == null)
                {
                    result.mensagem = "Usuário nao existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.Nome;
                }
            }

            return result;
        }
    }  
}
