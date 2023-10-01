using System;
using System.Windows;

namespace Domain.Messages
{
    public class GerenciarMensagens
    {
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

        public static void SelecionarRegistroDeExcluir()
        {
            MessageBox.Show("Atenção! Existe um ou mais de um campo, que está vazio.\n Corrija esse erro para continuar.",
                "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void PreencherCampoVazio()
        {
            MessageBox.Show("Atenção!\nOcorreu um erro, verifique as seguintes opções:\nSe o campo do Id está vazio ou preenchido.\n" +
                   "Se estiver vazio, clique no botão de Cadastrar.\nSe estiver preenchido, clique no botão de Alterar ou Excluir.\n" +
                   "Ou ainda, verifique se existe algum outro campo, além do campo Id, que esteja vazio.\nCorrija esses erros, para continuar.",
                   "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion

        #region |====================================| Erros do Try Catch(Exception) e Nome de Métodos |====================================|

        public static string ErroDeExcecaoENomeDoMetodo(Exception erro, string nomeDoMetodo)
        {
            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: {nomeDoMetodo}." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        #endregion

        #region |====================================| Mensagem de Erro de Switch Case |======================================|

        public static void MensagemDeErroDeSwitchCase()
        {
            MessageBox.Show($"Atenção! Ocorreu um erro no Switch Case.\nNão foi possível selecionar nenhum mês.",
                            "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion
    }
}
