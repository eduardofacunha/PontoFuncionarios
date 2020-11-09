using PontoFuncionarios.Context;
using PontoFuncionarios.Cores;
using PontoFuncionarios.Enums;
using PontoFuncionarios.Exceptions;
using PontoFuncionarios.Models;
using System;
using Xunit;

namespace PontoTest
{
    public class Test
    {
        [Fact]
        public void CriarPontoCorretamente()
        {
            try
            {
                var bd = new BancoContext();
                var transaction = bd.Database.BeginTransaction();
                var pontoEntrada = new Ponto
                {
                    Data = DateTime.Now,
                    NomeFuncionario = "José",
                    Tipo = TipoPonto.Entrada
                };
                
                CorePonto.CriarPonto(bd, pontoEntrada);
                var pontoSaida = new Ponto
                {
                    Data = DateTime.Now,
                    NomeFuncionario = "José",
                    Tipo = TipoPonto.Saida
                };
                CorePonto.CriarPonto(bd, pontoSaida);
                transaction.Rollback();
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
        }
        [Fact]
        public void NaoDeixarCriarPontoDeFormaErrada()
        {
            Assert.Throws<ParameterException>(() =>
            {
                var bd = new BancoContext();
                var transaction = bd.Database.BeginTransaction();
                var ponto = new Ponto
                {
                    Data = DateTime.Now,
                    NomeFuncionario = null,
                    Tipo = TipoPonto.Entrada
                };
                CorePonto.CriarPonto(bd, ponto);
                transaction.Rollback();
            });
        }

        [Fact]
        public void NaoDeixarPontoDuplicado()
        {
            Assert.Throws<Exception>(() =>
            {
                var bd = new BancoContext();
                var transaction = bd.Database.BeginTransaction();
                var pontoEntrada = new Ponto
                {
                    Data = DateTime.Now,
                    NomeFuncionario = "José",
                    Tipo = TipoPonto.Entrada
                };
                CorePonto.CriarPonto(bd, pontoEntrada);
                var pontoDuplicado = new Ponto
                {
                    Data = DateTime.Now,
                    NomeFuncionario = "José",
                    Tipo = TipoPonto.Entrada
                };
                CorePonto.CriarPonto(bd, pontoDuplicado);
                transaction.Rollback();
            });
        }

        [Fact]
        public void PegarUltimosPontos()
        {
            try
            {
                var bd = new BancoContext();
                var pontos = CorePonto.PegarUltimosPontos(bd);
            }
            catch (Exception e)
            {
                Assert.True(false, e.Message);
            }
        }
    }
}
