using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacaoDoZero2019.Models;

namespace ProgramacaoDoZero2019.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase

    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Branco";
            meuVeiculo.Marca = "Nissan";
            meuVeiculo.Modelo = "Sentra";
            meuVeiculo.Placa = "DEV-2025";

            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();
            meuVeiculo.Acelerar();

            return meuVeiculo;
        }

        [Route("obterCarro")]
        [HttpGet]
        public Carro obterCarro() 
        {
            var meuCarro = new Carro();

            meuCarro.Marca = "Nissan";
            meuCarro.Cor = "Branco";
            meuCarro.Modelo = "Sentra";
            meuCarro.Placa = "DEV-2025";

            meuCarro.Acelerar();

            return meuCarro;
        }

        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Marca = "Yamaha";
            minhaMoto.Cor = "Preta";
            minhaMoto.Modelo = "MT 03";
            minhaMoto.Placa = "DEV-2025";

            minhaMoto.Acelerar();

            return minhaMoto;
        }
    }
}
