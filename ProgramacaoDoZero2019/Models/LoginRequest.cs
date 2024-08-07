using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoDoZero2019.Models
{
    public class LoginRequest
    {
        public string email { get; set; }

        public string senha { get; set; }
    }
}

