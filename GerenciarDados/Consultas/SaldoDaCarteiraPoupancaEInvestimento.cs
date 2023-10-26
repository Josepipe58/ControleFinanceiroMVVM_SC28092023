using BancoDeDados.ContextoDoBancoDeDados;
using System;
using System.Data;

namespace GerenciarDados.Consultas
{
    public class SaldoDaCarteiraPoupancaEInvestimento
    {
        public Contexto _contexto;

        public SaldoDaCarteiraPoupancaEInvestimento()
        {
            _contexto = new Contexto();
        }

        //==============================================================| Saldo da Carteira |======================================================================
        public double ConsultarSaldoDaCarteiraPorAno(int ano)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Ano", ano);
            double saldoDaCarteira = Convert.ToDouble(_contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria In ('Renda', 'Saldo da Carteira') And Ano = @Ano) + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @Ano)) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Ano = @Ano) + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria In ('Depósito', 'Depósito Inicial') And Ano = @Ano) + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @Ano))"));
            return saldoDaCarteira;
        }
        //==============================================================| Saldo da Poupança |======================================================================
        public double ConsultarSaldoDaPoupanca(int ano)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Ano", ano);
            double saldoDaPoupanca = Convert.ToDouble(_contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Tipo = 'Saldo Anterior' And Ano = @Ano) + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And NomeDaCategoria = 'Renda' And Ano = @Ano) + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Venda' And Ano = @Ano) + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @Ano)) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Tipo In('Despesas Gerais', 'Débito') And Ano = @Ano))"));

            return saldoDaPoupanca;
        }
        //==============================================================| Saldo de Investimentos |======================================================================
        public double ConsultarSaldoDeInvestimentos(int ano)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Ano", ano);
            double saldoDeInvestimentos = Convert.ToDouble(_contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @Ano) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And NomeDaSubCategoria = 'Saque' And Ano = @Ano))"));
            return saldoDeInvestimentos;
        }
    }
}
