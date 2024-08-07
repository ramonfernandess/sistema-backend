using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoDoZero2019.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller2019 : ControllerBase
    {

        [HttpGet]
        [Route("olaMundo")]
        public string OlaMundo()
        {
            var mensagem = "Olá mundo via API";
            return mensagem;
        }


        [Route("olaMundoPersonalizado")]
        [HttpGet]
        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá mundo via API " + nome;
            return mensagem;
        }


        [Route("somar")]
        [HttpGet]
        public string Somar(int number1, int number2)
        {
            var soma = number1 + number2;
            var mensagem = "O valor é " + soma;
            return mensagem;
        }


        [Route("media")]
        [HttpGet]
        public string Media(int valor1, int valor2)
        {
            var soma = valor1 + valor2;
            var calcularMedia = soma / 2;
            var mensagem = "A média é " + calcularMedia;
            return mensagem;
        }

        [Route("terreno")]
        [HttpGet]
        public string Terreno(int valor1, int valor2, int valor3)
        {
            var tamanhoTerreno = valor1 * valor2;
            var calcularValor = tamanhoTerreno * valor3;
            var mensagem = "O valor do terreno é R$" + calcularValor;
            return mensagem;
        }

    }
}
