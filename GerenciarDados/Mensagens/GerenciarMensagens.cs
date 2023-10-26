using System;
using System.Windows;

namespace GerenciarDados.Mensagens
{
    public static class GerenciarMensagens
    {
        //Mensagens de CRUD com Sucesso
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
        
        //Mensagens de CRUD com Erros
        public static void ErroAoCadastrar()
        {
            MessageBox.Show("Atenção!\nO campo Id tem que ser igual a 0 ou vazio.\nOutra opção é clicar no botão Alterar ou Excluir." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ErroAoAlterarOuExcluir()
        {
            MessageBox.Show("Atenção!\nO campo Id tem que ser maior do que 0.\nOutra opção é clicar no botão Cadastrar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void PreencherCampoVazio()
        {
            MessageBox.Show("Atenção! Existe um ou mais de um campo, que está vazio.\n Corrija esse erro para continuar.",
                "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Erros do Try Catch(Exception)
        public static string ErroDeExcecaoENomeDoMetodo(Exception erro, string _nomeDoMetodo)
        {
            return MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: {_nomeDoMetodo}." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error).ToString();
        }

        //Mensagem de Erro de Switch Case
        public static void MensagemDeErroDeSwitchCase()
        {
            MessageBox.Show($"Atenção! Ocorreu um erro no Switch Case.\nNão foi possível selecionar nenhum mês.",
                            "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
