using PontoFuncionarios.Context;
using PontoFuncionarios.Exceptions;
using PontoFuncionarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace PontoFuncionarios.Cores
{
    public class CorePonto
    {
        public static void CriarPonto(BancoContext bd, Ponto ponto)
        {
            if (string.IsNullOrEmpty(ponto.NomeFuncionario))
            {
                throw new ParameterException("Ponto precisa do nome do funcionario para ser criado");
            }
            //verificar se o ponto pode ser registrado
            var ultimoPonto = PegarUltimoPontoDoFuncionario(bd, ponto.NomeFuncionario);
            if (ultimoPonto != null &&
                ultimoPonto.Tipo == ponto.Tipo)
            {
                throw new Exception("Ponto não pode ser registrado porque já foi registrado antes.");
            }
            bd.Ponto.Add(ponto);
            bd.SaveChanges();
        }
        public static List<Ponto> PegarUltimosPontos(BancoContext bd)
        {
            var pontos = bd.Ponto.OrderByDescending(x=>x.Data).Take(20).ToList();
            return pontos;
        }

        public static Ponto PegarUltimoPontoDoFuncionario(BancoContext bd, string funcionario)
        {
            return bd.Ponto.Where(x => x.NomeFuncionario == funcionario).OrderByDescending(x => x.Data).FirstOrDefault();
        }
    }
}
