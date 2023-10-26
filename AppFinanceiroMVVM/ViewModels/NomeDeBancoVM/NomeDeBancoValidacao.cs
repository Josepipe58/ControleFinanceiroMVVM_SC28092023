#nullable disable
using AppFinanceiroMVVM.Modelos;
using GerenciarDados.Mensagens;

namespace AppFinanceiroMVVM.ViewModels.NomeDeBancoVM
{
    public partial class NomeDeBancoViewModel//Validação
    {

        //Cadastrar
        public bool ValidarCadastrar(NomeDeBanco nomeDeBanco)
        {
            NomeDeBanco = nomeDeBanco;
            if (NomeDeBanco.Id == 0 && NomeDeBanco.NomeDoBanco != null && NomeDeBanco.NomeDoBanco != "")
            {
                return true;
            }
            else if (NomeDeBanco.Id > 0 && NomeDeBanco.NomeDoBanco != null)
            {
                GerenciarMensagens.ErroAoCadastrar();
                return false;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return false;
            }
        }

        //Alterar e Excluir
        public bool ValidarAlterarExcluir(NomeDeBanco nomeDeBanco)
        {
            NomeDeBanco = nomeDeBanco;
            if (NomeDeBanco.Id > 0 && NomeDeBanco.NomeDoBanco != null && NomeDeBanco.NomeDoBanco != "")
            {
                return true;
            }
            else if (NomeDeBanco.Id == 0 && NomeDeBanco.NomeDoBanco != null)
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                return false;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return false;
            }
        }
    }
}
