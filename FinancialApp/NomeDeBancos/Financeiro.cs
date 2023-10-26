#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace FinancialApp.NomeDeBancos
{
    public class Financeiro
    {
        //Contexto
        private readonly SqlParameterCollection _sqlParameterCollection = new SqlCommand().Parameters;

        public SqlConnection CriarConexao()
        {
            SqlConnection conexao = new();
            try
            {
                conexao.ConnectionString = "Data Source=JOSEPIPE-PC\\FINANCEIRO;Initial Catalog=NomeDosBancoDeDados;User " +
                                           "ID=sa;Password=;Integrated Security=True;TrustServerCertificate=True";
            }
            catch (SqlException erroSqlException)
            {
                MessageBox.Show($"Não foi possível carregar o ComboBox com os nomes dos Banco de Dados.\n" +
                    $"Erro de conexão com o Banco de Dados:{"NomeDosBancoDeDados"}.\nDetalhes: {erroSqlException.Message}",
                    "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception erroException)
            {
                MessageBox.Show($"Não foi possível carregar o ComboBox com os nomes dos Banco de Dados.\n" +
                     $"Erro de conexão com o Banco de Dados:{"NomeDosBancoDeDados"}.\nDetalhes: {erroException.Message}",
                     "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            return conexao;
        }

        public DataTable ExecutarConsulta(CommandType commandType, string consultaDeTexto)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = consultaDeTexto;

                //Adicionar os parâmetros no comando
                foreach (SqlParameter sqlParameter in _sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }

                //Criar um adaptador
                SqlDataAdapter sqlDataAdapter = new(sqlCommand);
                DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Não foi possível fazer a conexão com o Banco de Dados selecionado.\nDetalhes: {erro.Message}",
                    "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new DataTable();
            }
        }

        //Modelo da Tabela Financeiros
        public int Id { get; set; }

        public string Nome { get; set; }

        //Lista da Tabela Financeiros
        public ListaDeNomeDeBancosDoSql ConsultarNomeDeBancos()
        {
            ListaDeNomeDeBancosDoSql listaDeNomeDeBancosDoSql = new();
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select * From Financeiros;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Financeiro nomeDeBancos = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Nome = Convert.ToString(dataRow["Nome"])
                };
                listaDeNomeDeBancosDoSql.Add(nomeDeBancos);
            }
            return listaDeNomeDeBancosDoSql;
        }
    }
    public class ListaDeNomeDeBancosDoSql : List<Financeiro> 
    {}
}
