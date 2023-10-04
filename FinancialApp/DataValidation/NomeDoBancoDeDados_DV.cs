#nullable disable
using Database.Models;
using Domain.Messages;

namespace FinancialApp.DataValidation
{
    public class NomeDoBancoDeDados_DV : DataValidationBase
    {
        #region |=================================| Validação de Dados |==================================================|

        public NomeDoBancoDeDados NomeDeBanco {  get; set; }

        public NomeDoBancoDeDados_DV()
        {
            NomeDeBanco = new NomeDoBancoDeDados();
        }

        //Validar Cadastrar
        public bool ValidarCadastrar(NomeDoBancoDeDados nomeDeBanco)
        {
            NomeDeBanco = nomeDeBanco;
            if (NomeDeBanco.Id == 0 && NomeDeBanco.NomeDoBanco != null)
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
        public bool ValidarAlterarExcluir(NomeDoBancoDeDados nomeDeBanco)
        {
            NomeDeBanco = nomeDeBanco;
            if (NomeDeBanco.Id > 0 && NomeDeBanco.NomeDoBanco != null)
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
        #endregion
    }
}
