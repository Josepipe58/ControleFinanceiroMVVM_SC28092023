using Database.DatabaseContext;
using Domain.Lists;
using System;
using System.Data;
using System.Windows;

namespace Domain.Reports
{
    public class RelatorioDePoupanca_DO : Context
    {
        //====================================================| Saldo Total da Poupança, Receitas e Investimentos |=========================================================//
        public ListaDeValoresMeses SaldoTotalDaPoupancaReceitasEInvestimentos(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new ListaDeValoresMeses();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                    "Declare @Janeiro decimal(18, 2)" +
                    "Set @Janeiro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Saldo Anterior' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Saldo Anterior' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Janeiro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Janeiro'))) " +

                    "Declare @Fevereiro decimal(18, 2) " +
                    "Set @Fevereiro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Fevereiro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Fevereiro'))) " +

                    "Declare @Marco decimal(18, 2) " +
                    "Set @Marco = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Março')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Março'))) " +

                    "Declare @Abril decimal(18, 2) " +
                    "Set @Abril = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Abril')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Abril'))) " +

                    "Declare @Maio decimal(18, 2) " +
                    "Set @Maio = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Maio')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Maio'))) " +

                    "Declare @Junho decimal(18, 2) " +
                    "Set @Junho = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Junho')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Junho'))) " +

                    "Declare @Julho decimal(18, 2) " +
                    "Set @Julho = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Julho')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Julho'))) " +

                    "Declare @Agosto decimal(18, 2) " +
                    "Set @Agosto = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Agôsto')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Agôsto'))) " +

                    "Declare @Setembro decimal(18, 2) " +
                    "Set @Setembro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Setembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Setembro'))) " +

                    "Declare @Outubro decimal(18, 2) " +
                    "Set @Outubro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Outubro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Outubro'))) " +

                    "Declare @Novembro decimal(18, 2) " +
                    "Set @Novembro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito Inicial' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Novembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Novembro'))) " +

                    "Declare @Dezembro decimal(18, 2) " +
                    "Set @Dezembro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Venda' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Juros de Investimentos' And Mes = 'Dezembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And SubCategoria = 'Saque' And Mes = 'Dezembro'))) " +


                    "Select(Select @Janeiro) as Janeiro," +
                    "(Select @Janeiro + @Fevereiro) as Fevereiro," +
                    "(Select @Janeiro + @Fevereiro + @Marco) as Marco," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril) as Abril," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio) as Maio," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho) as Junho," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho) as Julho," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto) as Agosto," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro) as Setembro," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro + @Outubro) as Outubro," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro + @Outubro + @Novembro) as Novembro," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro + @Outubro + @Novembro + @Dezembro) as Dezembro," +
                    "(Select @Janeiro + @Fevereiro + @Marco + @Abril + @Maio + @Junho + @Julho + @Agosto + @Setembro + @Outubro + @Novembro + @Dezembro) as TotalAno");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Meses meses = new Meses
                    {
                        Janeiro = Convert.ToDecimal(dataRow["Janeiro"]),
                        Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]),
                        Marco = Convert.ToDecimal(dataRow["Marco"]),
                        Abril = Convert.ToDecimal(dataRow["Abril"]),
                        Maio = Convert.ToDecimal(dataRow["Maio"]),
                        Junho = Convert.ToDecimal(dataRow["Junho"]),
                        Julho = Convert.ToDecimal(dataRow["Julho"]),
                        Agosto = Convert.ToDecimal(dataRow["Agosto"]),
                        Setembro = Convert.ToDecimal(dataRow["Setembro"]),
                        Outubro = Convert.ToDecimal(dataRow["Outubro"]),
                        Novembro = Convert.ToDecimal(dataRow["Novembro"]),
                        Dezembro = Convert.ToDecimal(dataRow["Dezembro"]),
                        TotalAno = Convert.ToDecimal(dataRow["TotalAno"])
                    };
                    listaDeValoresMeses.Add(meses);
                }
                return listaDeValoresMeses;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDoSaldoTotalDaPoupancaReceitasEInvestimentos()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
        //============================================================| Saldo Total da Poupanca |=======================================================================//
        public ListaDeValoresMeses SaldoTotalDaPoupanca(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new ListaDeValoresMeses();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                    "Declare @Janeiro decimal (18, 2)" +
                    "Set @Janeiro = (Select((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Saldo Anterior' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Janeiro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Janeiro')))" +

                    "Declare @Fevereiro decimal(18, 2)" +
                    "Set @Fevereiro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Fevereiro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Fevereiro')))" +

                    "Declare @Março decimal(18, 2)" +
                    "Set @Março = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Março')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Março')))" +

                    "Declare @Abril decimal(18, 2)" +
                    "Set @Abril = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Abril')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Abril')))" +

                    "Declare @Maio decimal(18, 2) " +
                    "Set @Maio = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Maio')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Maio')))" +

                    "Declare @Junho decimal(18, 2) " +
                    "Set @Junho = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Junho')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Junho')))" +

                    "Declare @Julho decimal(18, 2)" +
                    "Set @Julho = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Julho')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Julho')))" +

                    "Declare @Agôsto decimal(18, 2)" +
                    "Set @Agôsto = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Agôsto')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Agôsto')))" +

                    "Declare @Setembro decimal(18, 2)" +
                    "Set @Setembro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Setembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Setembro')))" +

                    "Declare @Outubro decimal(18, 2)" +
                    "Set @Outubro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Outubro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Outubro')))" +

                    "Declare @Novembro decimal(18, 2)" +
                    "Set @Novembro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Novembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Novembro')))" +

                    "Declare @Dezembro decimal(18, 2)" +
                    "Set @Dezembro = (((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Renda' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Depósito' And Mes = 'Dezembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Dezembro')))" +

                    "Select(Select @Janeiro) as Janeiro," +
                    "(Select @Janeiro + @Fevereiro) as Fevereiro," +
                    "(Select @Janeiro + @Fevereiro + @Março) as Marco," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril) as Abril," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio) as Maio," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio + @Junho) as Junho," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio + @Junho + @Julho) as Julho," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio + @Junho + @Julho + @Agôsto) as Agosto," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio + @Junho + @Julho + @Agôsto + @Setembro) as Setembro," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio + @Junho + @Julho + @Agôsto + @Setembro + @Outubro) as Outubro," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio + @Junho + @Julho + @Agôsto + @Setembro + @Outubro + @Novembro) as Novembro," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio + @Junho + @Julho + @Agôsto + @Setembro + @Outubro + @Novembro + @Dezembro) as Dezembro," +
                    "(Select @Janeiro + @Fevereiro + @Março + @Abril + @Maio + @Junho + @Julho + @Agôsto + @Setembro + @Outubro + @Novembro + @Dezembro) as TotalAno");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Meses meses = new Meses
                    {
                        Janeiro = Convert.ToDecimal(dataRow["Janeiro"]),
                        Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]),
                        Marco = Convert.ToDecimal(dataRow["Marco"]),
                        Abril = Convert.ToDecimal(dataRow["Abril"]),
                        Maio = Convert.ToDecimal(dataRow["Maio"]),
                        Junho = Convert.ToDecimal(dataRow["Junho"]),
                        Julho = Convert.ToDecimal(dataRow["Julho"]),
                        Agosto = Convert.ToDecimal(dataRow["Agosto"]),
                        Setembro = Convert.ToDecimal(dataRow["Setembro"]),
                        Outubro = Convert.ToDecimal(dataRow["Outubro"]),
                        Novembro = Convert.ToDecimal(dataRow["Novembro"]),
                        Dezembro = Convert.ToDecimal(dataRow["Dezembro"]),
                        TotalAno = Convert.ToDecimal(dataRow["TotalAno"])
                    };
                    listaDeValoresMeses.Add(meses);
                }
                return listaDeValoresMeses;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDoSaldoTotalDaPoupanca()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
        //============================================================| Juros da Poupança |========================================================================//
        public ListaDeValoresMeses JurosDaPoupanca(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new ListaDeValoresMeses();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                    "Select(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Janeiro') as Janeiro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Fevereiro') as Fevereiro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Março') as Marco," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Abril') as Abril," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Maio') as Maio," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Junho') as Junho," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Julho') as Julho," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Agôsto') as Agosto," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Setembro') as Setembro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Outubro') as Outubro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Novembro') as Novembro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança' And Mes = 'Dezembro') as Dezembro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And SubCategoria = 'Juros da Poupança') as TotalAno");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Meses meses = new Meses
                    {
                        Janeiro = Convert.ToDecimal(dataRow["Janeiro"]),
                        Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]),
                        Marco = Convert.ToDecimal(dataRow["Marco"]),
                        Abril = Convert.ToDecimal(dataRow["Abril"]),
                        Maio = Convert.ToDecimal(dataRow["Maio"]),
                        Junho = Convert.ToDecimal(dataRow["Junho"]),
                        Julho = Convert.ToDecimal(dataRow["Julho"]),
                        Agosto = Convert.ToDecimal(dataRow["Agosto"]),
                        Setembro = Convert.ToDecimal(dataRow["Setembro"]),
                        Outubro = Convert.ToDecimal(dataRow["Outubro"]),
                        Novembro = Convert.ToDecimal(dataRow["Novembro"]),
                        Dezembro = Convert.ToDecimal(dataRow["Dezembro"]),
                        TotalAno = Convert.ToDecimal(dataRow["TotalAno"])
                    };
                    listaDeValoresMeses.Add(meses);
                }
                return listaDeValoresMeses;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDosJurosDaPoupanca()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
        //==============================================| Rendimentos Entre Depositos, Juros e Saques da Poupança |========================================================//
        public ListaDeValoresMeses RendimentosEntreDepositosJurosESaques(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new ListaDeValoresMeses();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                    "Select((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Janeiro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Janeiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Janeiro')) as Janeiro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Fevereiro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Fevereiro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Fevereiro')) as Fevereiro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Março')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Março') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Março')) as Marco," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Abril')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Abril') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Abril')) as Abril," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Maio')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Maio') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Maio')) as Maio," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Junho')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Junho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Junho')) as Junho," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Julho')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Julho') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Julho')) as Julho," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Agôsto')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Agôsto') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Agôsto')) as Agosto," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Setembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Setembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Setembro')) as Setembro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Outubro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Outubro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Outubro')) as Outubro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Novembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Novembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Novembro')) as Novembro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito' And Mes = 'Dezembro')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito' And Mes = 'Dezembro') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Dezembro')) as Dezembro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Crédito') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Receita') + " +
                    "(Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Crédito')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Investimentos Where Ano = @selecionarAno And Tipo = 'Débito') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Débito') + " +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa')) as TotalAno");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Meses meses = new Meses
                    {
                        Janeiro = Convert.ToDecimal(dataRow["Janeiro"]),
                        Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]),
                        Marco = Convert.ToDecimal(dataRow["Marco"]),
                        Abril = Convert.ToDecimal(dataRow["Abril"]),
                        Maio = Convert.ToDecimal(dataRow["Maio"]),
                        Junho = Convert.ToDecimal(dataRow["Junho"]),
                        Julho = Convert.ToDecimal(dataRow["Julho"]),
                        Agosto = Convert.ToDecimal(dataRow["Agosto"]),
                        Setembro = Convert.ToDecimal(dataRow["Setembro"]),
                        Outubro = Convert.ToDecimal(dataRow["Outubro"]),
                        Novembro = Convert.ToDecimal(dataRow["Novembro"]),
                        Dezembro = Convert.ToDecimal(dataRow["Dezembro"]),
                        TotalAno = Convert.ToDecimal(dataRow["TotalAno"])
                    };
                    listaDeValoresMeses.Add(meses);
                }
                return listaDeValoresMeses;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDosRendimentosEntreDepositosJurosESaques()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
        //=============================================================| Pagamentos e Transferências |====================================================================//
        public ListaDeValoresMeses PagamentosETranferencias(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new ListaDeValoresMeses();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                    "Select(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Janeiro') as Janeiro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Fevereiro') as Fevereiro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Março') as Marco," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Abril') as Abril," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Maio') as Maio," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Junho') as Junho," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Julho') as Julho," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Agôsto') as Agosto," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Setembro') as Setembro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Outubro') as Outubro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Novembro') as Novembro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa' And Mes = 'Dezembro') as Dezembro," +
                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa') as TotalAno");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Meses meses = new Meses
                    {
                        Janeiro = Convert.ToDecimal(dataRow["Janeiro"]),
                        Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]),
                        Marco = Convert.ToDecimal(dataRow["Marco"]),
                        Abril = Convert.ToDecimal(dataRow["Abril"]),
                        Maio = Convert.ToDecimal(dataRow["Maio"]),
                        Junho = Convert.ToDecimal(dataRow["Junho"]),
                        Julho = Convert.ToDecimal(dataRow["Julho"]),
                        Agosto = Convert.ToDecimal(dataRow["Agosto"]),
                        Setembro = Convert.ToDecimal(dataRow["Setembro"]),
                        Outubro = Convert.ToDecimal(dataRow["Outubro"]),
                        Novembro = Convert.ToDecimal(dataRow["Novembro"]),
                        Dezembro = Convert.ToDecimal(dataRow["Dezembro"]),
                        TotalAno = Convert.ToDecimal(dataRow["TotalAno"])
                    };
                    listaDeValoresMeses.Add(meses);
                }
                return listaDeValoresMeses;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDePagamentosETranferencias()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
    }
}
