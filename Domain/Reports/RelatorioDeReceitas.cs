using Database.DatabaseContext;
using Domain.Lists;
using System;
using System.Data;

namespace Domain.Reports
{
    public class RelatorioDeReceitas : Context
    {
        //============================================| Benefícios do INSS |============================================================================================//       
        public ListaDeValoresMeses ConsultarBenefíciosDoINSS(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Janeiro') as Janeiro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Fevereiro') as Fevereiro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Março') as Marco," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Abril') as Abril," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Maio') as Maio," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Junho') as Junho," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Julho') as Julho," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Agôsto') as Agosto," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Setembro') as Setembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Outubro') as Outubro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Novembro') as Novembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita' And Mes = 'Dezembro') as Dezembro," +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Tipo = 'Receita') as TotalAno");

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
        //============================================| Minhas Receitas Mensal e Anual |================================================================================//
        public ListaDeValoresMeses ConsultarReceitasMensalEAnual(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "select(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Janeiro') as Janeiro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Fevereiro') as Fevereiro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Março') as Marco," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Abril') as Abril," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Maio') as Maio," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Junho') as Junho," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Julho') as Julho," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Agôsto') as Agosto," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Setembro') as Setembro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Outubro') as Outubro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Novembro') as Novembro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Dezembro') as Dezembro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' ) as TotalAno");

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
        //============================================| Descontos no Benefício do INSS |================================================================================//
        public ListaDeValoresMeses ConsultarDescontosNoBeneficioDoINSS(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "select (select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Janeiro') as Janeiro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Fevereiro') as Fevereiro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Março') as Marco," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Abril') as Abril," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Maio') as Maio," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Junho') as Junho," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Julho') as Julho," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Agôsto') as Agosto," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Setembro') as Setembro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Outubro') as Outubro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Novembro') as Novembro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS' And Mes = 'Dezembro') as Dezembro," +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Descontos no Benefício do INSS') as TotalAno");

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
        //============================================| Fluxo de Caixa - Receitas Menos Despesas |======================================================================//
        public ListaDeValoresMeses ConsultarFluxoDeCaixaReceitasMenosDespesas(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "select((select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Saldo da Carteira' And Mes = 'Janeiro') + " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Janeiro')) - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Janeiro') as Janeiro," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Fevereiro') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Fevereiro') as Fevereiro," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Março') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Março') as Marco," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Abril') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Abril') as Abril," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Maio') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Maio') as Maio," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Junho') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Junho') as Junho," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Julho') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Julho') as Julho," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Agôsto') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Agôsto') as Agosto," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Setembro') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Setembro') as Setembro," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Outubro') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Outubro') as Outubro," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Novembro') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Novembro') as Novembro," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda' And Mes = 'Dezembro') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais' And Mes = 'Dezembro') as Dezembro," +

                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And NomeDaCategoria = 'Renda') - " +
                "(select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @ano And Tipo = 'Despesas Gerais') as TotalAno");

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
        //============================================| Saldo da Carteira de Todos os Meses |===========================================================================//
        public ListaDeValoresMeses ConsultarSaldoDaCarteiraDeTodosOsMeses(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Declare @Janeiro decimal (18, 2)" +
                "Set @Janeiro = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Tipo = 'Carteira' And Ano = @ano And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Janeiro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Janeiro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Janeiro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Janeiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Janeiro')))" +

                "Declare @Fevereiro decimal (18, 2)" +
                "Set @Fevereiro = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Fevereiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Fevereiro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Fevereiro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Fevereiro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Fevereiro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Fevereiro')))" +

                "Declare @Marco decimal (18, 2)" +
                "Set @Marco = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Março') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Março')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Março') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Março')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Março') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Março')))" +

                "Declare @Abril decimal (18, 2)" +
                "Set @Abril = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Abril') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Abril')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Abril') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Abril')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Abril') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Abril')))" +

                "Declare @Maio decimal (18, 2)" +
                "Set @Maio = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Maio') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Maio')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Maio') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Maio')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Maio') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Maio')))" +

                "Declare @Junho decimal (18, 2)" +
                "Set @Junho = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Junho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Junho')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Junho') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Junho')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Junho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Junho')))" +

                "Declare @Julho decimal (18, 2)" +
                "Set @Julho = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Julho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Julho')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Julho') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Julho')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Julho') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Julho')))" +

                "Declare @Agosto decimal (18, 2)" +
                "Set @Agosto = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Agôsto') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Agôsto')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Agôsto') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Agôsto')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Agôsto') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Agôsto'))) " +

                "Declare @Setembro decimal (18, 2)" +
                "Set @Setembro = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Setembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Setembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Setembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Setembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Setembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Setembro')))" +

                "Declare @Outubro decimal (18, 2)" +
                "Set @Outubro = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Outubro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Outubro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Outubro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Outubro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Outubro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Outubro')))" +

                "Declare @Novembro decimal (18, 2)" +
                "Set @Novembro = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Novembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Novembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Novembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Novembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Novembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Novembro')))" +

                "Declare @Dezembro decimal (18, 2)" +
                "Set @Dezembro = (Select((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Dezembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Saque' And Ano = @ano And Mes = 'Dezembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Filtros = 'Despesas' And Tipo = 'Despesas Gerais' And Ano = @ano And Mes = 'Dezembro') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Tarifas da Poupança' And Ano = @ano And Mes = 'Dezembro')) - " +
                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaSubCategoria = 'Depósito' And Ano = @ano And Mes = 'Dezembro') + " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = 'Renda' And Ano = @ano And Mes = 'Dezembro')))" +

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
    }
}
