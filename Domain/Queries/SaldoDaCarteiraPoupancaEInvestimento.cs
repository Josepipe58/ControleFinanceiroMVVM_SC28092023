using Database.DatabaseContext;
using System;
using System.Data;
using System.Windows;

namespace Domain.Queries
{
    public class SaldoDaCarteiraPoupancaEInvestimento : Context
    {
        //==============================================================| Saldo da Carteira |======================================================================
        public double SaldoDaCarteira(int ano)
        {
            try
            {
                LimparParametros();
                AdicionarParametros("@ano", ano);
                double saldoDaCarteira = Convert.ToDouble(ExecutarManipulacaoDeDados(CommandType.Text,
                    "Select((Select coalesce(Sum(Valor), 0) From Receitas Where Tipo = 'Carteira' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Receitas Where Categoria = 'Renda' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where SubCategoria = 'Saque' And Ano = @ano) + " +
                     "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Saque' And Ano = @ano)) - " +
                    "(((Select coalesce(Sum(Valor), 0) From Despesas Where Tipo = 'Despesa' And Ano = @ano) - " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Categoria = 'Débitos da Poupança' And Ano = @ano)) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where SubCategoria = 'Depósito' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Depósito Inicial' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Depósito' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Receitas Where Categoria = 'Renda' And Ano = @ano))"));
                return saldoDaCarteira;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: SaldoDaCarteira()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }
        //==============================================================| Saldo da Poupanca |======================================================================
        public double SaldoDaPoupanca(int ano)
        {
            try
            {
                LimparParametros();
                AdicionarParametros("@ano", ano);
                double saldoDaPoupanca = Convert.ToDouble(ExecutarManipulacaoDeDados(CommandType.Text,
                    "Select((Select coalesce(Sum(Valor), 0) From Poupancas Where Tipo = 'Saldo Anterior' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Categoria = 'Renda' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Categoria = 'Venda' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where SubCategoria = 'Depósito' And Ano = @ano)) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Tipo = 'Despesa' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Tipo = 'Débito' And Ano = @ano))"));
                return saldoDaPoupanca;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: SaldoDaPoupanca()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }
        //==============================================================| Saldo de Investimentos |======================================================================
        public double SaldoDeInvestimentos(int ano)
        {
            try
            {
                LimparParametros();
                AdicionarParametros("@ano", ano);
                double saldoDeInvestimentos = Convert.ToDouble(ExecutarManipulacaoDeDados(CommandType.Text,
                    "Select((Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Saldo do Ano Anterior' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Juros de Investimentos' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Depósito Inicial' And Ano = @ano) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Depósito' And Ano = @ano)) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Saque' And Ano = @ano))"));
                return saldoDeInvestimentos;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: SaldoDeInvestimentos().\n" +
                   $"Detalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }
    }
}
