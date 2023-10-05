using Database.DatabaseContext;
using Domain.Lists;
using System;
using System.Data;

namespace Domain.Reports
{
    public class RelatorioDePoupanca : Context
    {
        //============================================| Saldo Total da Poupança, Receitas e Investimentos |=============================================================//
        public ListaDeValoresMeses ConsultarSaldoTotalDaPoupancaReceitasEInvestimentos(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Declare @Janeiro decimal(18, 2)" +
                "Set @Janeiro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Saldo Anterior' And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Janeiro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Janeiro')))" +

                "Declare @Fevereiro decimal(18, 2)" +
                "Set @Fevereiro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Fevereiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Fevereiro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Fevereiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Fevereiro')))" +

                "Declare @Marco decimal(18, 2)" +
                "Set @Marco = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Março') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Março')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Março') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Março')))" +

                "Declare @Abril decimal(18, 2)" +
                "Set @Abril = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Abril') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Abril')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Abril') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Abril')))" +

                "Declare @Maio decimal(18, 2)" +
                "Set @Maio = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Maio') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Maio')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Maio') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Maio')))" +

                "Declare @Junho decimal(18, 2)" +
                "Set @Junho = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Junho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Junho')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Junho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Junho')))" +

                "Declare @Julho decimal(18, 2)" +
                "Set @Julho = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Julho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Julho')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Julho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Julho')))" +

                "Declare @Agosto decimal(18, 2)" +
                "Set @Agosto = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Agôsto') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Agôsto')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Agôsto') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Agôsto')))" +

                "Declare @Setembro decimal(18, 2)" +
                "Set @Setembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Setembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Setembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Setembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Setembro')))" +

                "Declare @Outubro decimal(18, 2)" +
                "Set @Outubro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Outubro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Outubro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Outubro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Outubro')))" +

                "Declare @Novembro decimal(18, 2)" +
                "Set @Novembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Novembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria In ('Depósito', 'Depósito Inicial') And Mes = 'Novembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Novembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Novembro')))" +

                "Declare @Dezembro decimal(18, 2)" +
                "Set @Dezembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Dezembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Dezembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Dezembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Débito' And Mes = 'Dezembro')))" +

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
                Meses meses = new()
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
                ListaDeValoresMeses.Add(meses);
            }
            return ListaDeValoresMeses;
        }
        //============================================| Saldo Total da Poupanca |=======================================================================================//
        public ListaDeValoresMeses ConsultarSaldoTotalDaPoupanca(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Declare @Janeiro decimal (18, 2)" +
                "Set @Janeiro = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Saldo Anterior' And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Janeiro')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Janeiro'))" +

                "Declare @Fevereiro decimal(18, 2)" +
                "Set @Fevereiro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Fevereiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Fevereiro')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Fevereiro'))" +

                "Declare @Marco decimal(18, 2)" +
                "Set @Marco = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Março') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Março')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Março'))" +

                "Declare @Abril decimal(18, 2)" +
                "Set @Abril = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Abril') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Abril')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Abril'))" +

                "Declare @Maio decimal(18, 2)" +
                "Set @Maio = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Maio') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Maio')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Maio'))" +

                "Declare @Junho decimal(18, 2)" +
                "Set @Junho = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Junho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Junho')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Junho'))" +

                "Declare @Julho decimal(18, 2)" +
                "Set @Julho = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Julho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Julho')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Julho'))" +

                "Declare @Agosto decimal(18, 2)" +
                "Set @Agosto = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Agôsto') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Agôsto')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Agôsto'))" +

                "Declare @Setembro decimal(18, 2)" +
                "Set @Setembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Setembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Setembro')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Setembro'))" +

                "Declare @Outubro decimal(18, 2)" +
                "Set @Outubro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Outubro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Outubro')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Outubro'))" +

                "Declare @Novembro decimal(18, 2)" +
                "Set @Novembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Novembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Novembro')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Novembro'))" +

                "Declare @Dezembro decimal(18, 2)" +
                "Set @Dezembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaCategoria = 'Renda' And Mes = 'Dezembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Dezembro')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') And Mes = 'Dezembro'))" +

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
                Meses meses = new()
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
                ListaDeValoresMeses.Add(meses);
            }
            return ListaDeValoresMeses;
        }
        //============================================| Juros da Poupança |=============================================================================================//
        public ListaDeValoresMeses ConsultarJurosDaPoupanca(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Janeiro') as Janeiro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Fevereiro') as Fevereiro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Março') as Marco," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Abril') as Abril," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Maio') as Maio," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Junho') as Junho," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Julho') as Julho," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Agôsto') as Agosto," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Setembro') as Setembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Outubro') as Outubro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Novembro') as Novembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança' And Mes = 'Dezembro') as Dezembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaSubCategoria = 'Juros da Poupança') as TotalAno");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new()
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
                ListaDeValoresMeses.Add(meses);
            }
            return ListaDeValoresMeses;
        }
        //===========================================| Rendimentos Entre Depositos, Juros e Saques da Poupança e Investimentos |=========================================//
        public ListaDeValoresMeses ConsultarRendimentosEntreDepositosJurosESaques(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Janeiro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Janeiro') as Janeiro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Fevereiro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Fevereiro') as Fevereiro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Março') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Março') as Marco," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Abril') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Abril') as Abril," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Maio') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Maio') as Maio," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Junho') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Junho') as Junho," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Julho') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Julho') as Julho," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Agôsto') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Agôsto') as Agosto," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Setembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Setembro') as Setembro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Outubro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Outubro') as Outubro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Novembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Novembro') as Novembro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita') And Mes = 'Dezembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito') " +
                "And Mes = 'Dezembro') as Dezembro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo In ('Crédito', 'Receita')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo In ('Despesas Gerais', 'Débito')) as TotalAno");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new()
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
                ListaDeValoresMeses.Add(meses);
            }
            return ListaDeValoresMeses;
        }
        //============================================| Pagamentos e Transferências |===================================================================================//
        public ListaDeValoresMeses ConsultarPagamentosETranferencias(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Janeiro') as Janeiro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Fevereiro') as Fevereiro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Março') as Marco," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Abril') as Abril," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Maio') as Maio," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Junho') as Junho," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Julho') as Julho," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Agôsto') as Agosto," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Setembro') as Setembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Outubro') as Outubro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Novembro') as Novembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais' And Mes = 'Dezembro') as Dezembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Poupança' And Ano = @Ano And Tipo = 'Despesas Gerais') as TotalAno");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new()
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
                ListaDeValoresMeses.Add(meses);
            }
            return ListaDeValoresMeses;
        }
    }
}
