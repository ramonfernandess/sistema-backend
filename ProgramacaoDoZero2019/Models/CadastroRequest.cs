using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;

namespace ProgramacaoDoZero2019.Models
{
    public class CadastroRequest
    {
        public string nome { get; set; }

        public string sobrenome { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string senha { get; set; }

        public string genero { get; set; }
    }
}
