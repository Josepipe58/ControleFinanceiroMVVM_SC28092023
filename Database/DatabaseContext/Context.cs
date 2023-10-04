#nullable disable
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Database.DatabaseContext
{
    public class Context
    {
        public static string Banco { get; set; } = "BancoDeTestes"; //"Financeiro_2020_2025";

        private readonly SqlParameterCollection _sqlParameterCollection = new SqlCommand().Parameters;
        public Context(string banco)
        {
            Banco = banco;            
        }
        public Context() { }

        public static SqlConnection CriarConexao()
        {
            SqlConnection conexao = new();
            try
            {
                conexao.ConnectionString = "Data Source=JOSEPIPE-PC\\FINANCEIRO;Initial Catalog=" + Banco + ";User ID=José Euripedes;" +
                                          "Password=;Integrated Security=True;TrustServerCertificate=True;";
            }
            catch (SqlException erroSqlException)
            {
                MessageBox.Show($"Erro do SqlConnection, ao tentar criar conexão com o Banco de Dados.\nDetalhes: {erroSqlException.Message}",
                     "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception erroException)
            {
                MessageBox.Show($"Erro de exceção, ao tentar criar conexão com o Banco de Dados.\nDetalhes: {erroException.Message}",
                     "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            return conexao;
        }

        public void LimparParametros()
        {
            _sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            _sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //Persistência - Inserir - Alterar - Excluir
        public object ExecutarManipulacaoDeDados(CommandType commandType, string consultaDeTexto)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexao();
                sqlConnection.Open();

                //Criar o comando que vai levar a informação para o Banco de Dados.
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = consultaDeTexto;

                //Adicionar os parâmetros no comando
                foreach (SqlParameter sqlParameter in _sqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));
                }
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception erro)
            {
                object obj = new();
                MessageBox.Show($"Erro ao conectar-se no Banco de Dados.\nDetalhes: {erro.Message}",
                     "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return obj;
            }
        }

        //Consultar registros do Banco de Dados.
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
    }
}
