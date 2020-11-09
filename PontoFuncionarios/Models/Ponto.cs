using PontoFuncionarios.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoFuncionarios.Models
{
    public class Ponto
    {
        public int IdPonto { get; set; }
        public string NomeFuncionario { get; set; }
        public DateTime Data { get; set; }
        public TipoPonto Tipo { get; set; }
    }
}
