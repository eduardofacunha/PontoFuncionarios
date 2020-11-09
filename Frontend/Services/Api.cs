using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class Api
    {
        public async static Task CriarPonto(Ponto ponto)
        {
            await Https.Put<object>("CriarPonto", ponto);
        }
        public async static Task<List<Ponto>> CarregarPontos()
        {
            var pontos = await Https.Get<List<Ponto>>("PegarUltimosPontos");
            return pontos;
        }
    }
}
