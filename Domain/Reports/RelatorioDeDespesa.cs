using Database.DatabaseContext;
using Domain.Lists;
using System;
using System.Data;
using System.Windows;

namespace Domain.Reports
{
    public class RelatorioDeDespesa : Context
    {
        //============================================| Relatório de Despesas Totais |=================================================================================//        
        public ListaDeValoresMeses ConsultarDespesasTotais(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Janeiro' And Tipo = 'Despesas Gerais')) as Janeiro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Fevereiro' And Tipo = 'Despesas Gerais')) as Fevereiro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Março' And Tipo = 'Despesas Gerais')) as Marco," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Abril' And Tipo = 'Despesas Gerais')) as Abril," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Maio' And Tipo = 'Despesas Gerais')) as Maio," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Junho' And Tipo = 'Despesas Gerais')) as Junho," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Julho' And Tipo = 'Despesas Gerais')) as Julho," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Agôsto' And Tipo = 'Despesas Gerais')) as Agosto," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Setembro' And Tipo = 'Despesas Gerais')) as Setembro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Outubro' And Tipo = 'Despesas Gerais')) as Outubro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Novembro' And Tipo = 'Despesas Gerais')) as Novembro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Dezembro' And Tipo = 'Despesas Gerais')) as Dezembro," +

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Despesas Gerais')) as TotalAno");

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
        //============================================| Relatório de Despesas Normais |=================================================================================//
        public ListaDeValoresMeses ConsultarDespesasNormais(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Janeiro' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Janeiro' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa'))) as Janeiro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Fevereiro' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Fevereiro' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa')) as Fevereiro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Março' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Março' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa')) as Marco," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Abril' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Abril' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa')) as Abril," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Maio' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Maio' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa')) as Maio," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Junho' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Junho' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa', 'Reforma do Apto Novo')) as Junho," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Julho' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Julho' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa', 'Reforma do Apto Novo')) as Julho," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Agôsto' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Agôsto' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa', 'Reforma do Apto Novo')) as Agosto," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Setembro' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Setembro' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa', 'Reforma do Apto Novo')) as Setembro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Outubro' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Outubro' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa', 'Reforma do Apto Novo')) as Outubro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Novembro' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Novembro' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa', 'Reforma do Apto Novo')) as Novembro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Dezembro' And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Dezembro' And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa', 'Reforma do Apto Novo')) as Dezembro," +

                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Tipo = 'Despesas Gerais') - " +
                "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria " +
                "In ('Caridade', 'Despesas Extras', 'Informática e Hardware', 'Despesas da Neusa', 'Reforma do Apto Novo')) as TotalAno");

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
        //============================================| Relatório de Despesas Extras |==================================================================================//
        public ListaDeValoresMeses ConsultarDespesasExtras(int selecionarAno)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@selecionarAno", selecionarAno);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
            "Select (Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Janeiro' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware')) as Janeiro," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Fevereiro' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware')) as Fevereiro," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Março' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware')) as Marco," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Abril' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware')) as Abril," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Maio' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware')) as Maio, " +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Junho' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware', 'Reforma do Apto Novo')) as Junho," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Julho' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware', 'Reforma do Apto Novo')) as Julho," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Agôsto' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware', 'Reforma do Apto Novo')) as Agosto," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Setembro' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware', 'Reforma do Apto Novo')) as Setembro," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Outubro' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware', 'Reforma do Apto Novo')) as Outubro," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Novembro' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware', 'Reforma do Apto Novo')) as Novembro," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And Mes = 'Dezembro' And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware', 'Reforma do Apto Novo')) as Dezembro," +

            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @selecionarAno And NomeDaCategoria " +
            "In ('Despesas Extras', 'Informática e Hardware', 'Reforma do Apto Novo')) as TotalAno");

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
        //============================================| Relatório de Despesas com a Neusa |=============================================================================//
        public ListaDeValoresMeses ConsultarDespesasComANeusa(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
            "Select (Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Janeiro' And NomeDaCategoria = 'Despesas da Neusa') as Janeiro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Fevereiro' And NomeDaCategoria = 'Despesas da Neusa') as Fevereiro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Março' And NomeDaCategoria = 'Despesas da Neusa') as Marco," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Abril' And NomeDaCategoria = 'Despesas da Neusa') as Abril," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Maio' And NomeDaCategoria = 'Despesas da Neusa') as Maio," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Junho' And NomeDaCategoria = 'Despesas da Neusa') as Junho," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Julho' And NomeDaCategoria = 'Despesas da Neusa') as Julho," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Agôsto' And NomeDaCategoria = 'Despesas da Neusa') as Agosto," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Setembro' And NomeDaCategoria = 'Despesas da Neusa') as Setembro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Outubro' And NomeDaCategoria = 'Despesas da Neusa') as Outubro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Novembro' And NomeDaCategoria = 'Despesas da Neusa') as Novembro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Dezembro' And NomeDaCategoria = 'Despesas da Neusa') as Dezembro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria = 'Despesas da Neusa') as TotalAno");

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
        //============================================| Relatório de Despesas com Caridade |===========================================================================//
        public ListaDeValoresMeses ConsultarDespesasComCaridades(int ano)
        {
            ListaDeValoresMeses ListaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
            "Select (Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Janeiro' And NomeDaCategoria = 'Caridade') as Janeiro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Fevereiro' And NomeDaCategoria = 'Caridade') as Fevereiro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Março' And NomeDaCategoria = 'Caridade') as Marco," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Abril' And NomeDaCategoria = 'Caridade') as Abril," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Maio' And NomeDaCategoria = 'Caridade') as Maio," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Junho' And NomeDaCategoria = 'Caridade') as Junho," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Julho' And NomeDaCategoria = 'Caridade') as Julho," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Agôsto' And NomeDaCategoria = 'Caridade') as Agosto," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Setembro' And NomeDaCategoria = 'Caridade') as Setembro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Outubro' And NomeDaCategoria = 'Caridade') as Outubro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Novembro' And NomeDaCategoria = 'Caridade') as Novembro," +
            "(Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Dezembro' And NomeDaCategoria = 'Caridade') as Dezembro," +
            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And NomeDaCategoria = 'Caridade')) as TotalAno");

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
