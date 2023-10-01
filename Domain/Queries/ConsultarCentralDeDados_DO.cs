#nullable disable
using Database.DatabaseContext;
using Database.Models;
using Domain.Lists;
using Domain.Messages;
using System;
using System.Data;

namespace Domain.Queries
{
    public class ConsultarCentralDeDados_DO : Context
    {
        //============================================| Carregar DataGrid de Consultas |================================================================================//
        public ListaDaCentralDeDados ConsultarCentralDeDados()
        {
            ListaDaCentralDeDados listaDaCentralDeDados = new();
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
               "Select * From CentralDeDados Order By Id Desc");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CentralDeDados centralDeDados = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubcategoria"]),
                    Valor = Convert.ToDecimal(dataRow["Valor"]),
                    Filtros = Convert.ToString(dataRow["Filtros"]),
                    Tipo = Convert.ToString(dataRow["Tipo"]),
                    Data = Convert.ToDateTime(dataRow["Data"]),
                    Mes = Convert.ToString(dataRow["Mes"]),
                    Ano = Convert.ToInt32(dataRow["Ano"])
                };
                listaDaCentralDeDados.Add(centralDeDados);
            }
            return listaDaCentralDeDados;
        }
        //============================================| Consultar Por NomeDaCategoria |=================================================================================//
        public ListaDeValoresMeses ConsultarPorNomeDaCategoria(string nomeDaCategoria)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@NomeDaCategoria", nomeDaCategoria);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
            "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Janeiro')) as Janeiro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Fevereiro')) as Fevereiro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Março')) as Marco," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Abril')) as Abril," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Maio')) as Maio," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Junho')) as Junho," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Julho')) as Julho," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Agôsto')) as Agosto," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Setembro')) as Setembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Outubro')) as Outubro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Novembro')) as Novembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = 'Dezembro')) as Dezembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria)) as TotalAno");

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
        //============================================| Consultar Por NomeDaCategoria e NomeDaSubCategoria |============================================================//
        public ListaDeValoresMeses ConsultarPorNomeDaCategoriaENomeDaSubCategoria(string nomeDaCategoria, string nomeDaSubCategoria)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@NomeDaCategoria", nomeDaCategoria);
            AdicionarParametros("@NomeDaSubCategoria", nomeDaSubCategoria);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
            "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Janeiro')) as Janeiro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Fevereiro')) as Fevereiro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Março')) as Marco," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Abril')) as Abril," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Maio')) as Maio," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Junho')) as Junho," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Julho')) as Julho," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Agôsto')) as Agosto," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Setembro')) as Setembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Outubro')) as Outubro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Novembro')) as Novembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Mes = 'Dezembro')) as Dezembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria)) as TotalAno");

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
        //============================================| Consultar Por NomeDaCategoria, NomeDaSubCategoria e Mês |=======================================================//
        public ListaDeValoresMeses ConsultarPorNomeDaCategoriaNomeDaSubCategoriaEMes(string nomeDaCategoria, string nomeDaSubCategoria, string mes)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@NomeDaCategoria", nomeDaCategoria);
            AdicionarParametros("@NomeDaSubCategoria", nomeDaSubCategoria);
            AdicionarParametros("@Mes", mes);
            DataTable dataTable = new();
            switch (mes)
            {
                case "Janeiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Janeiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Fevereiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Fevereiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Março":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Marco, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Abril":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Abril, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Maio":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Maio, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Junho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Junho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Julho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Julho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Agôsto":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Agosto, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Setembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Setembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Outubro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Outubro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Novembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Novembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;

                case "Dezembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as Dezembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes)) as TotalAno");
                    break;
                default:
                    break;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new();
                if (mes == "Janeiro")
                {
                    meses.Janeiro = Convert.ToDecimal(dataRow["Janeiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Fevereiro")
                {
                    meses.Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Março")
                {
                    meses.Marco = Convert.ToDecimal(dataRow["Marco"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Abril")
                {
                    meses.Abril = Convert.ToDecimal(dataRow["Abril"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Maio")
                {
                    meses.Maio = Convert.ToDecimal(dataRow["Maio"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Junho")
                {
                    meses.Junho = Convert.ToDecimal(dataRow["Junho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Julho")
                {
                    meses.Julho = Convert.ToDecimal(dataRow["Julho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Agôsto")
                {
                    meses.Agosto = Convert.ToDecimal(dataRow["Agosto"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Setembro")
                {
                    meses.Setembro = Convert.ToDecimal(dataRow["Setembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Outubro")
                {
                    meses.Outubro = Convert.ToDecimal(dataRow["Outubro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Novembro")
                {
                    meses.Novembro = Convert.ToDecimal(dataRow["Novembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Dezembro")
                {
                    meses.Dezembro = Convert.ToDecimal(dataRow["Dezembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else
                {
                    GerenciarMensagens.MensagemDeErroDeSwitchCase();
                    return new ListaDeValoresMeses();
                }
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Consultar Por NomeDaCategoria, NomeDaSubCategoria, Mês e Ano |==================================================//
        public ListaDeValoresMeses ConsultarPorNomeDaCategoriaNomeDaSubCategoriaMesEAno(string nomeDaCategoria, string nomeDaSubCategoria, string mes, int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@NomeDaCategoria", nomeDaCategoria);
            AdicionarParametros("@NomeDaSubCategoria", nomeDaSubCategoria);
            AdicionarParametros("@Mes", mes);
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = new();
            switch (mes)
            {
                case "Janeiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Janeiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Fevereiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Fevereiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Março":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Marco, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Abril":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Abril, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Maio":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Maio, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Junho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Junho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Julho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Julho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Agôsto":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Agosto, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Setembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Setembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Outubro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Outubro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Novembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Novembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Dezembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as Dezembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria " +
                    "And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;
                default:
                    break;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new();
                if (mes == "Janeiro")
                {
                    meses.Janeiro = Convert.ToDecimal(dataRow["Janeiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Fevereiro")
                {
                    meses.Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Março")
                {
                    meses.Marco = Convert.ToDecimal(dataRow["Marco"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Abril")
                {
                    meses.Abril = Convert.ToDecimal(dataRow["Abril"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Maio")
                {
                    meses.Maio = Convert.ToDecimal(dataRow["Maio"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Junho")
                {
                    meses.Junho = Convert.ToDecimal(dataRow["Junho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Julho")
                {
                    meses.Julho = Convert.ToDecimal(dataRow["Julho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Agôsto")
                {
                    meses.Agosto = Convert.ToDecimal(dataRow["Agosto"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Setembro")
                {
                    meses.Setembro = Convert.ToDecimal(dataRow["Setembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Outubro")
                {
                    meses.Outubro = Convert.ToDecimal(dataRow["Outubro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Novembro")
                {
                    meses.Novembro = Convert.ToDecimal(dataRow["Novembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Dezembro")
                {
                    meses.Dezembro = Convert.ToDecimal(dataRow["Dezembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else
                {
                    GerenciarMensagens.MensagemDeErroDeSwitchCase();
                    return new ListaDeValoresMeses();
                }
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Consultar Por NomeDaCategoria, NomeDaSubCategoria e Ano |=======================================================//
        public ListaDeValoresMeses ConsultarPorNomeDaCategoriaNomeDaSubCategoriaEAno(string nomeDaCategoria, string nomeDaSubCategoria, int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@NomeDaCategoria", nomeDaCategoria);
            AdicionarParametros("@NomeDaSubCategoria", nomeDaSubCategoria);
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
            "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Janeiro')) as Janeiro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Fevereiro')) as Fevereiro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Março')) as Marco," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
             "And Mes = 'Abril')) as Abril," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Maio')) as Maio," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
             "And Mes = 'Junho')) as Junho," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Julho')) as Julho," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Agôsto')) as Agosto," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
             "And Mes = 'Setembro')) as Setembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Outubro')) as Outubro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Novembro')) as Novembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano " +
            "And Mes = 'Dezembro')) as Dezembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And NomeDaSubCategoria = @NomeDaSubCategoria And Ano = @Ano)) as TotalAno");

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
        //============================================| Consultar Por NomeDaCategoria e Mês |===========================================================================//
        public ListaDeValoresMeses ConsultarPorNomeDaCategoriaEMes(string nomeDaCategoria, string mes)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@NomeDaCategoria", nomeDaCategoria);
            AdicionarParametros("@Mes", mes);
            DataTable dataTable = new();
            switch (mes)
            {
                case "Janeiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Janeiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Fevereiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Fevereiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Março":
                    dataTable = ExecutarConsulta(CommandType.Text,
                   "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Marco, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Abril":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Abril, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Maio":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Maio, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Junho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Junho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Julho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Julho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Agôsto":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Agosto, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Setembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Setembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Outubro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Outubro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Novembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Novembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;

                case "Dezembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as Dezembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes)) as TotalAno");
                    break;
                default:
                    break;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new();
                if (mes == "Janeiro")
                {
                    meses.Janeiro = Convert.ToDecimal(dataRow["Janeiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Fevereiro")
                {
                    meses.Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Março")
                {
                    meses.Marco = Convert.ToDecimal(dataRow["Marco"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Abril")
                {
                    meses.Abril = Convert.ToDecimal(dataRow["Abril"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Maio")
                {
                    meses.Maio = Convert.ToDecimal(dataRow["Maio"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Junho")
                {
                    meses.Junho = Convert.ToDecimal(dataRow["Junho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Julho")
                {
                    meses.Julho = Convert.ToDecimal(dataRow["Julho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Agôsto")
                {
                    meses.Agosto = Convert.ToDecimal(dataRow["Agosto"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Setembro")
                {
                    meses.Setembro = Convert.ToDecimal(dataRow["Setembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Outubro")
                {
                    meses.Outubro = Convert.ToDecimal(dataRow["Outubro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Novembro")
                {
                    meses.Novembro = Convert.ToDecimal(dataRow["Novembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Dezembro")
                {
                    meses.Dezembro = Convert.ToDecimal(dataRow["Dezembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else
                {
                    GerenciarMensagens.MensagemDeErroDeSwitchCase();
                    return new ListaDeValoresMeses();
                }
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Consultar Por NomeDaCategoria e Ano |===========================================================================//
        public ListaDeValoresMeses ConsultarPorNomeDaCategoriaEAno(string nomeDaCategoria, int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@NomeDaCategoria", nomeDaCategoria);
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
            "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Janeiro')) as Janeiro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Fevereiro')) as Fevereiro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Março')) as Marco," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Abril')) as Abril," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Maio')) as Maio," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Junho')) as Junho," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Julho')) as Julho," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Agôsto')) as Agosto," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Setembro')) as Setembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Outubro')) as Outubro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Novembro')) as Novembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano And Mes = 'Dezembro')) as Dezembro," +

            "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Ano = @Ano)) as TotalAno");

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
        //============================================| Consultar Por NomeDaCategoria, Mês e Ano |======================================================================//
        public ListaDeValoresMeses ConsultarPorNomeDaCategoriaMesEAno(string nomeDaCategoria, string mes, int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@NomeDaCategoria", nomeDaCategoria);
            AdicionarParametros("@Mes", mes);
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = new();
            switch (mes)
            {
                case "Janeiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Janeiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Fevereiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Fevereiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Março":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Marco, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Abril":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Abril, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Maio":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Maio, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Junho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Junho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Julho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Julho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Agôsto":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And And Mes = @Mes And Ano = @Ano)) as Agosto, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Setembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Setembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Outubro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Outubro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Novembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Novembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Dezembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as Dezembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where NomeDaCategoria = @NomeDaCategoria And Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;
                default:
                    break;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new();
                if (mes == "Janeiro")
                {
                    meses.Janeiro = Convert.ToDecimal(dataRow["Janeiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Fevereiro")
                {
                    meses.Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Março")
                {
                    meses.Marco = Convert.ToDecimal(dataRow["Marco"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Abril")
                {
                    meses.Abril = Convert.ToDecimal(dataRow["Abril"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Maio")
                {
                    meses.Maio = Convert.ToDecimal(dataRow["Maio"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Junho")
                {
                    meses.Junho = Convert.ToDecimal(dataRow["Junho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Julho")
                {
                    meses.Julho = Convert.ToDecimal(dataRow["Julho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Agôsto")
                {
                    meses.Agosto = Convert.ToDecimal(dataRow["Agosto"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Setembro")
                {
                    meses.Setembro = Convert.ToDecimal(dataRow["Setembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Outubro")
                {
                    meses.Outubro = Convert.ToDecimal(dataRow["Outubro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Novembro")
                {
                    meses.Novembro = Convert.ToDecimal(dataRow["Novembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Dezembro")
                {
                    meses.Dezembro = Convert.ToDecimal(dataRow["Dezembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else
                {
                    GerenciarMensagens.MensagemDeErroDeSwitchCase();
                    return new ListaDeValoresMeses();
                }
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Consultar Por Mês e Ano |==================================================================================//
        public ListaDeValoresMeses ConsultarPorMesEAno(string mes, int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Mes", mes);
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = new();
            switch (mes)
            {
                case "Janeiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Janeiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Fevereiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Fevereiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Março":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Marco, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Abril":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Abril, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Maio":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Maio, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Junho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Junho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Julho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Julho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Agôsto":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Agosto, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Setembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Setembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Outubro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Outubro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Novembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Novembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;

                case "Dezembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as Dezembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes And Ano = @Ano)) as TotalAno");
                    break;
                default:
                    break;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new();
                if (mes == "Janeiro")
                {
                    meses.Janeiro = Convert.ToDecimal(dataRow["Janeiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Fevereiro")
                {
                    meses.Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Março")
                {
                    meses.Marco = Convert.ToDecimal(dataRow["Marco"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Abril")
                {
                    meses.Abril = Convert.ToDecimal(dataRow["Abril"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Maio")
                {
                    meses.Maio = Convert.ToDecimal(dataRow["Maio"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Junho")
                {
                    meses.Junho = Convert.ToDecimal(dataRow["Junho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Julho")
                {
                    meses.Julho = Convert.ToDecimal(dataRow["Julho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Agôsto")
                {
                    meses.Agosto = Convert.ToDecimal(dataRow["Agosto"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Setembro")
                {
                    meses.Setembro = Convert.ToDecimal(dataRow["Setembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Outubro")
                {
                    meses.Outubro = Convert.ToDecimal(dataRow["Outubro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Novembro")
                {
                    meses.Novembro = Convert.ToDecimal(dataRow["Novembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Dezembro")
                {
                    meses.Dezembro = Convert.ToDecimal(dataRow["Dezembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else
                {
                    GerenciarMensagens.MensagemDeErroDeSwitchCase();
                    return new ListaDeValoresMeses();
                }
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Consultar Por Mês |=========================================================================================//
        public ListaDeValoresMeses ConsultarPorMes(string mes)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
            LimparParametros();
            AdicionarParametros("@Mes", mes);
            DataTable dataTable = new();
            switch (mes)
            {
                case "Janeiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Janeiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Fevereiro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Fevereiro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Março":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Marco, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Abril":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Abril, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Maio":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Maio, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Junho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Junho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Julho":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Julho, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Agôsto":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Agosto, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Setembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Setembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Outubro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Outubro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Novembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Novembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;

                case "Dezembro":
                    dataTable = ExecutarConsulta(CommandType.Text,
                    "Select ((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as Dezembro, " +

                    "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Mes = @Mes)) as TotalAno");
                    break;
                default:
                    break;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Meses meses = new();
                if (mes == "Janeiro")
                {
                    meses.Janeiro = Convert.ToDecimal(dataRow["Janeiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Fevereiro")
                {
                    meses.Fevereiro = Convert.ToDecimal(dataRow["Fevereiro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Março")
                {
                    meses.Marco = Convert.ToDecimal(dataRow["Marco"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Abril")
                {
                    meses.Abril = Convert.ToDecimal(dataRow["Abril"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Maio")
                {
                    meses.Maio = Convert.ToDecimal(dataRow["Maio"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Junho")
                {
                    meses.Junho = Convert.ToDecimal(dataRow["Junho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Julho")
                {
                    meses.Julho = Convert.ToDecimal(dataRow["Julho"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Agôsto")
                {
                    meses.Agosto = Convert.ToDecimal(dataRow["Agosto"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Setembro")
                {
                    meses.Setembro = Convert.ToDecimal(dataRow["Setembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Outubro")
                {
                    meses.Outubro = Convert.ToDecimal(dataRow["Outubro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Novembro")
                {
                    meses.Novembro = Convert.ToDecimal(dataRow["Novembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else if (mes == "Dezembro")
                {
                    meses.Dezembro = Convert.ToDecimal(dataRow["Dezembro"]);
                    meses.TotalAno = Convert.ToDecimal(dataRow["TotalAno"]);
                }
                else
                {
                    GerenciarMensagens.MensagemDeErroDeSwitchCase();
                    return new ListaDeValoresMeses();
                }
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
        //============================================| Consultar Por Ano |====================================================================================//
        public ListaDeValoresMeses ConsultarPorAno(int ano)
        {
            ListaDeValoresMeses listaDeValoresMeses = new();
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

                "((Select coalesce(Sum(Valor), 0) From CentralDeDados Where Ano = @Ano And Mes = 'Agôsto' And Tipo = 'Despesas Gerais')) as [Agosto]," +

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
                listaDeValoresMeses.Add(meses);
            }
            return listaDeValoresMeses;
        }
    }
}
