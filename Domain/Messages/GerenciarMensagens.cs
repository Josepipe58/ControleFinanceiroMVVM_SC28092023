using System;
using System.Windows;

namespace Domain.Messages
{
    public class GerenciarMensagens
    {
        #region |====================================| Erros do Try Catch |====================================|
        public static string ErroDeCadastro(Exception erro)
        {

            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: Cadastrar." +
                       $"\nDetalhes: {erro.Message} ", "Mensagem de Erro!",
                       MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        public static string ErroDeAlterar(Exception erro)
        {

            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: Alterar." +
                       $"\nDetalhes: {erro.Message} ", "Mensagem de Erro!",
                       MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        public static string ErroDeExcluir(Exception erro)
        {

            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: Excluir." +
                       $"\nDetalhes: {erro.Message} ", "Mensagem de Erro!",
                       MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        public static string ErroSaldoDaCarteira(Exception erro)
        {

            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: SaldoDaCarteira." +
                       $"\nDetalhes: {erro.Message} ", "Mensagem de Erro!",
                       MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        public static string ErroSaldoDaPoupanca(Exception erro)
        {

            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: SaldoDaPoupanca." +
                       $"\nDetalhes: {erro.Message} ", "Mensagem de Erro!",
                       MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        public static string ErroSaldoDeInvestimentos(Exception erro)
        {

            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: SaldoDeInvestimentos." +
                       $"\nDetalhes: {erro.Message} ", "Mensagem de Erro!",
                       MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        public static string ErroSaldoTotalPoupancaEInvestimentos(Exception erro)
        {

            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: SaldoTotalPoupancaEInvestimentos." +
                       $"\nDetalhes: {erro.Message} ", "Mensagem de Erro!",
                       MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        //|================================| Erros de DataGrid e ComboBox de Anos  |==========================================|
        public static void ErroDeCarregarDataGridEComboBoxDeAnos(Exception erro)
        {

            MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: CarregarDataGridEComboBoxDeAnos." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //|================================| Erros de DataGrid e ComboBox de Categorias  |====================================|
        public static void ErroDeCarregarDataGridEComboBoxDeCategorias(Exception erro)
        {

            MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: CarregarDataGridEComboBoxDeCategorias." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //|================================| Erros de DataGrid e ComboBox de SubCategorias  |=================================|
        public static void ErroDeCarregarDataGridDeSubCategorias(Exception erro)
        {

            MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: CarregarDataGridDeSubCategorias." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ErroDeCarregarComboBoxDeSubCategorias(Exception erro)
        {

            MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: CarregarComboBoxDeSubCategoria." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion

        #region |====================================| Mensagens - CRUD |======================================|
        public static void SucessoAoCadastrar(int id)
        {
            MessageBox.Show($"Registro cadastrado com sucesso.\nCódigo do registro: {id}",
                       "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void SucessoAoAlterar(int id)
        {
            MessageBox.Show($"Registro alterado com sucesso.\nCódigo do registro: {id}",
                         "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void SucessoAoExcluir(int id)
        {
            MessageBox.Show($"Registro excluído com sucesso.\nCódigo do registro: {id}",
                       "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult ConfirmarExcluir(int id)
        {
            return MessageBox.Show($"Você tem certeza que deseja excluir esse registro?" +
            $"\nNúmero do Código: {id}", "Cuidado! Atenção!",
            MessageBoxButton.YesNo, MessageBoxImage.Information);
        }
        #endregion
    }
}
