using Database.DatabaseContext;
using Domain.Lists;
using System;
using System.Data;

namespace Domain.Reports
{
    public class RelatorioDeInvestimentos : Context
    {
        //============================================| Saldo Total da Poupança, Receitas e Investimentos |=============================================================//
        public ListaDeValoresMeses ConsultarSaldoTotalDaPoupancaReceitasEInvestimentos(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Declare @Janeiro decimal(18, 2)" +
                "Set @Janeiro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Saldo Anterior' And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Janeiro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Janeiro')))" +

                "Declare @Fevereiro decimal(18, 2)" +
                "Set @Fevereiro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Fevereiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Fevereiro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Fevereiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Fevereiro')))" +

                "Declare @Marco decimal(18, 2)" +
                "Set @Marco = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Março') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Março')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Março') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Março')))" +

                "Declare @Abril decimal(18, 2)" +
                "Set @Abril = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Abril') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Abril')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Abril') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Abril')))" +

                "Declare @Maio decimal(18, 2)" +
                "Set @Maio = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Maio') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Maio')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Maio') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Maio')))" +

                "Declare @Junho decimal(18, 2)" +
                "Set @Junho = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Junho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Junho')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Junho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Junho')))" +

                "Declare @Julho decimal(18, 2)" +
                "Set @Julho = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Julho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Julho')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Julho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Julho')))" +

                "Declare @Agosto decimal(18, 2)" +
                "Set @Agosto = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Agôsto') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Agôsto')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Agôsto') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Agôsto')))" +

                "Declare @Setembro decimal(18, 2)" +
                "Set @Setembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Setembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Setembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Setembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Setembro')))" +

                "Declare @Outubro decimal(18, 2)" +
                "Set @Outubro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Outubro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Outubro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Outubro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Outubro')))" +

                "Declare @Novembro decimal(18, 2)" +
                "Set @Novembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Novembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria In ('Depósito', 'Depósito Inicial') And Mes = 'Novembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Novembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Novembro')))" +

                "Declare @Dezembro decimal(18, 2)" +
                "Set @Dezembro = (((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria In ('Renda', 'Venda') And Mes = 'Dezembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Depósito' And Mes = 'Dezembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Filtros = 'Poupança' And Tipo = 'Despesas Gerais' And Mes = 'Dezembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Débito' And Mes = 'Dezembro')))" +

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
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Saldo Total de Investimentos |==================================================================================//
        public ListaDeValoresMeses ConsultarSaldoTotalDeInvestimentos(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Declare @Janeiro decimal (18, 2)" +
                "Set @Janeiro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Saldo do Ano Anterior', 'Juros de Investimentos', 'Depósito') And Mes = 'Janeiro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Janeiro'))" +

                "Declare @Fevereiro decimal(18, 2)" +
                "Set @Fevereiro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Fevereiro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Fevereiro'))" +

                "Declare @Marco decimal(18, 2)" +
                "Set @Marco = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Março') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Março'))" +

                "Declare @Abril decimal(18, 2)" +
                "Set @Abril = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Abril') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Abril'))" +

                "Declare @Maio decimal(18, 2)" +
                "Set @Maio = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Maio') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Maio'))" +

                "Declare @Junho decimal(18, 2)" +
                "Set @Junho = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Junho') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Junho'))" +

                "Declare @Julho decimal(18, 2)" +
                "Set @Julho = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Julho') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Julho'))" +

                "Declare @Agosto decimal(18, 2)" +
                "Set @Agosto = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Agôsto') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Agôsto'))" +

                "Declare @Setembro decimal(18, 2)" +
                "Set @Setembro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Setembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Setembro'))" +

                "Declare @Outubro decimal(18, 2)" +
                "Set @Outubro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Outubro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Outubro'))" +

                "Declare @Novembro decimal(18, 2)" +
                "Set @Novembro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito', 'Depósito Inicial') And Mes = 'Novembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Novembro'))" +

                "Declare @Dezembro decimal(18, 2)" +
                "Set @Dezembro = ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria " +
                "In ('Juros de Investimentos', 'Depósito') And Mes = 'Dezembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' And Mes = 'Dezembro'))" +

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
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Juros de Investimentos |========================================================================================//
        public ListaDeValoresMeses ConsultarJurosDeInvestimentos(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Janeiro') as Janeiro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Fevereiro') as Fevereiro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Março') as Marco," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Abril') as Abril," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Maio') as Maio," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Junho') as Junho," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Julho') as Julho," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Agôsto') as Agosto," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Setembro') as Setembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Outubro') as Outubro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Novembro') as Novembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos' And Mes = 'Dezembro') as Dezembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaSubCategoria = 'Juros de Investimentos') as TotalAno");

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
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Rendimentos Entre Depositos Juros e Saques da Poupança |========================================================//
        public ListaDeValoresMeses ConsultarRendimentosEntreDepositosJurosESaques(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Janeiro')) - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Janeiro') as Janeiro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Fevereiro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Fevereiro')) as Fevereiro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Março') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Março')) as Marco," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Abril') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Abril')) as Abril," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Maio') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Maio')) as Maio," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Junho') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Junho')) as Junho," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Julho') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Julho')) as Julho," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Agôsto') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Agôsto')) as Agosto," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Setembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Setembro')) as Setembro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Outubro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Outubro')) as Outubro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Novembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Novembro')) as Novembro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito' " +
                "And Mes = 'Dezembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque' " +
                "And Mes = 'Dezembro')) as Dezembro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And Tipo = 'Crédito') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Investimentos' And Ano = @ano And NomeDaSubCategoria = 'Saque')) as TotalAno");

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
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
    }
}
