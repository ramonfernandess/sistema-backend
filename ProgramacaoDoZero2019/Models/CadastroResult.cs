using Microsoft.AspNetCore.Mvc;
using System;

namespace ProgramacaoDoZero2019.Models
{
    public class CadastroResult : BaseResult
    {
        public Guid usuarioGuid { get; set; }
    }
}
