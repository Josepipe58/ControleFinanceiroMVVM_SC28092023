#nullable disable
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Database.DatabaseContext
{
    public class DatabaseNameContext
    {
        private readonly SqlParameterCollection _sqlParameterCollection = new SqlCommand().Parameters;

        public static SqlConnection CriarConexaoNomeDeBancos()
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

        public void LimparParametros()
        {
            _sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            _sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //Persistência - Inserir - Alterar - Excluir
        public object ExecutarManipulacaoNomeDeBancos(CommandType commandType, string consultaDeTexto)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexaoNomeDeBancos();
                sqlConnection.Open();

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
                MessageBox.Show($"Erro ao se conectar no Banco de Dados.\nDetalhes: {erro.Message}",
                     "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return obj;
            }
        }

        public DataTable ConsultarNomeDeBancos(CommandType commandType, string consultaDeTexto)
        {
            try
            {
                SqlConnection sqlConnection = CriarConexaoNomeDeBancos();
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

                //DataTable = Tabela de dados vazia, onde vai ser colocado os dados que vem do Banco de Dados.
                DataTable dataTable = new();

                //Mandar o comando ir até o Banco de Dados buscar os dados para o adaptador peencher o DataTable.
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Não foi possível fazer a conexão com o Banco de Dados que você selecionou.\nDetalhes: {erro.Message}",
                     "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return new DataTable();
            }
        }
    }
}
