using Database.DatabaseContext;
using Domain.Lists;
using System;
using System.Data;
using System.Windows;

namespace Domain.Reports
{
    public class RelatorioDeDespesa_DO : Context
    {
        //========================================================| Relatório de Despesas Totais |======================================================================//        
        public ListaDeValoresMeses RelatorioDeDespesasTotais(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Janeiro' And Tipo = 'Despesa') +	" +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro')) as Janeiro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro')) as Fevereiro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Março' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março')) as [Marco]," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Abril' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril')) as Abril," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Maio' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio')) as Maio," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Junho' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho')) as Junho," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Julho' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho')) as Julho," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Agôsto' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto')) as [Agosto]," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Setembro' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro')) as Setembro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Outubro' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro')) as Outubro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Novembro' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro')) as Novembro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Dezembro' And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro')) as Dezembro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Tipo = 'Despesa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno)) as TotalAno");

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
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDeDespesasTotais()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
        //============================================================| Relatório de Despesas Normais |===================================================================//
        public ListaDeValoresMeses RelatorioDeDespesasNormais(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Despesas da Neusa'))) as Janeiro," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Despesas da Neusa')) as Fevereiro," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Despesas da Neusa')) as Marco," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Despesas da Neusa')) as Abril," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Despesas da Neusa')) as Maio," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Despesas da Neusa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Reforma do Apto Novo')) as Junho," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Despesas da Neusa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Reforma do Apto Novo')) as Julho," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Despesas da Neusa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Reforma do Apto Novo')) as Agosto," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Despesas da Neusa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Reforma do Apto Novo')) as Setembro," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Despesas da Neusa')) as Outubro," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Despesas da Neusa')) as Novembro," +

                    "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Tipo = 'Despesa') - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Despesas da Neusa')) as Dezembro," +

                    "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Contas Básicas') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Tipo = 'Despesa')) - " +
                    "((Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Caridade') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Despesas Extras') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Informática e Hardware') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Despesas da Neusa') + " +
                    "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Reforma do Apto Novo')) as TotalAno");

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
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDeDespesaNormal()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
        //============================================================| Relatório de Despesas Extras |===============================================================//
        public ListaDeValoresMeses RelatorioDeDespesasExtras(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select ((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Despesas Extras')) as Janeiro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Despesas Extras')) as Fevereiro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Despesas Extras')) as Marco," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Despesas Extras')) as Abril," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Despesas Extras')) as Maio, " +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Reforma do Apto Novo') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Despesas Extras')) as Junho," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Reforma do Apto Novo') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Despesas Extras')) as Julho," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Reforma do Apto Novo') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Despesas Extras')) as Agosto," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Stembro' And Categoria = 'Reforma do Apto Novo') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Despesas Extras')) as Setembro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Despesas Extras')) as Outubro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Despesas Extras')) as Novembro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Despesas Extras')) as Dezembro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Despesas Extras') + " +
                "(Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Informática e Hardware') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Reforma do Apto Novo') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Despesas Extras')) as TotalAno");

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
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDeDespesasExtras()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
        //=========================================================| Relatório de Despesas com a Neusa |===============================================================//
        public ListaDeValoresMeses RelatorioDeDespesasComANeusa(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select (Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Despesas da Neusa') as Janeiro," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Despesas da Neusa') as Fevereiro," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Despesas da Neusa') as Marco," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Despesas da Neusa') as Abril," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Despesas da Neusa') as Maio," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Despesas da Neusa') as Junho," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Despesas da Neusa') as Julho," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Despesas da Neusa') as Agosto," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Despesas da Neusa') as Setembro," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Despesas da Neusa') as Outubro," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Despesas da Neusa') as Novembro," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Despesas da Neusa') as Dezembro," +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Despesas da Neusa') as TotalAno");

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
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDeDespesasComANeusa()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
        //=========================================================| Relatório de Despesas com Caridades |=============================================================//
        public ListaDeValoresMeses RelatorioDeDespesasComCaridades(int selecionarAno)
        {
            try
            {
                ListaDeValoresMeses listaDeValoresMeses = new();
                LimparParametros();
                AdicionarParametros("@selecionarAno", selecionarAno);
                DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select ((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Janeiro' And Categoria = 'Caridade')) as Janeiro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Fevereiro' And Categoria = 'Caridade')) as Fevereiro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Março' And Categoria = 'Caridade')) as Marco," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Abril' And Categoria = 'Caridade')) as Abril," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Maio' And Categoria = 'Caridade')) as Maio," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Junho' And Categoria = 'Caridade')) as Junho," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Julho' And Categoria = 'Caridade')) as Julho," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Agôsto' And Categoria = 'Caridade')) as Agosto," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Setembro' And Categoria = 'Caridade')) as Setembro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Outubro' And Categoria = 'Caridade')) as Outubro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Novembro' And Categoria = 'Caridade')) as Novembro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Mes = 'Dezembro' And Categoria = 'Caridade')) as Dezembro," +

                "((Select coalesce(Sum(Valor), 0) From Poupancas Where Ano = @selecionarAno And Categoria = 'Caridade') + " +
                "(Select coalesce(Sum(Valor), 0) From Despesas Where Ano = @selecionarAno And Categoria = 'Caridade')) as TotalAno");

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
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: RelatorioDeDespesasComCaridades()." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ListaDeValoresMeses();
            }
        }
    }
}
