using ProgramacaoDoZero2019.Common;
using ProgramacaoDoZero2019.Entities;
using ProgramacaoDoZero2019.Models;
using ProgramacaoDoZero2019.Repositories;
using System;

namespace ProgramacaoDoZero2019.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();
            var usuarioRepository = new UsuarioRepository(_connectionString);
            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuario existe
               if (usuario.Senha == senha)
                {
                    //senha válida
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha inválida
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos";
                }
            }
            else
            {
                //usuario nao existe
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }
            return result;

        }

        public CadastroResult Cadastro(string nome, 
            string sobrenome, 
            string telefone, 
            string email, 
            string genero, 
            string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                //usuário já existe 
                result.sucesso = false;
                result.mensagem = "Usuário já existe no sistema";
            }
            else
            {
                //Usuário não existe
                usuario = new Usuario();
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Email = email;
                usuario.Telefone = telefone;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var inserirResult = usuarioRepository.Inserir(usuario);

                if (inserirResult > 0)
                {
                    //inseriu com sucesso
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //erro ao inserir
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário. Tente novamente";
                }
            }

            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);
            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                //nao existe
                result.mensagem = "Usuário não existe";
            }
            else
            {
                //usuario existe

                var assunto = "Recuperação de Senha";
                var corpo = "Sua senha é " + usuario.Senha;

                var emailSender = new EmailSender();
                emailSender.Enviar(assunto, corpo, usuario.Email);

                result.sucesso = true;
            }

            return result;
        }
        
        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
