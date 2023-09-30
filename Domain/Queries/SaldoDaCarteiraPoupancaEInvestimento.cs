using Database.DatabaseContext;
using System;
using System.Data;
using System.Windows;

namespace Domain.Queries
{
    public class SaldoDaCarteiraPoupancaEInvestimento : Context
    {
        //==============================================================| Saldo da Carteira |======================================================================
        public double SaldoDaCarteira(int selecionarAno)
        {
            try
            {
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                double saldoDaCarteira = Convert.ToDouble(ExecutarManipulacaoDeDados(CommandType.Text,
                    "Select((Select coalesce(Sum(Valor), 0) From Receitas Where Tipo = 'Carteira' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Receitas Where Categoria = 'Renda' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where SubCategoria = 'Saque' And Ano = @selecionarAno) + " +
                     "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Saque' And Ano = @selecionarAno)) - " +
                    "(((Select coalesce(Sum(Valor), 0) From Despesas Where Tipo = 'Despesa' And Ano = @selecionarAno) - " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Categoria = 'Débitos da Poupança' And Ano = @selecionarAno)) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where SubCategoria = 'Depósito' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Depósito Inicial' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Depósito' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Receitas Where Categoria = 'Renda' And Ano = @selecionarAno))"));
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
        public double SaldoDaPoupanca(int selecionarAno)
        {
            try
            {
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                double saldoDaPoupanca = Convert.ToDouble(ExecutarManipulacaoDeDados(CommandType.Text,
                    "Select((Select coalesce(Sum(Valor), 0) From Poupancas Where Tipo = 'Saldo Anterior' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Categoria = 'Renda' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Categoria = 'Venda' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where SubCategoria = 'Depósito' And Ano = @selecionarAno)) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Tipo = 'Despesa' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Tipo = 'Débito' And Ano = @selecionarAno))"));
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
        public double SaldoDeInvestimentos(int selecionarAno)
        {
            try
            {
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                double saldoDeInvestimentos = Convert.ToDouble(ExecutarManipulacaoDeDados(CommandType.Text,
                    "Select((Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Saldo do Ano Anterior' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Juros de Investimentos' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Depósito Inicial' And Ano = @selecionarAno) + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Depósito' And Ano = @selecionarAno)) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where SubCategoria = 'Saque' And Ano = @selecionarAno))"));
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
