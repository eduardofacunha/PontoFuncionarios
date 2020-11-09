using Frontend.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{   
    public class Ponto
    {
        public int IdPonto { get; set; }
        public string NomeFuncionario { get; set; }
        public DateTime Data { get; set; }
        public TipoPonto Tipo { get; set; }
    }
}
