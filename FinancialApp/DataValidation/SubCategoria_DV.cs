#nullable disable
using Database.Models;
using Domain.Messages;

namespace FinancialApp.DataValidation
{
    public class SubCategoria_DV : DataValidationBase
    {
        #region |=================================| Validação de Dados |==================================================|

        public SubCategoria SubCategoria { get; set; }

        public SubCategoria_DV()
        {
            SubCategoria = new SubCategoria();
        }

        //Cadastrar
        public bool ValidarCadastrar(SubCategoria subCategoriaDeDespesa)
        {            
            SubCategoria = subCategoriaDeDespesa;            
            if (SubCategoria.Id == 0 && SubCategoria.NomeDaSubCategoria != null)
            {
                return true;
            }
            else if (SubCategoria.Id > 0 && SubCategoria.NomeDaSubCategoria != null)
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
        public bool ValidarAlterarExcluir(SubCategoria subCategoriaDeDespesa)
        {           
            SubCategoria = subCategoriaDeDespesa;
            if (SubCategoria.Id > 0 && SubCategoria.NomeDaSubCategoria != null)
            {
                return true;
            }
            else if (SubCategoria.Id == 0 && SubCategoria.NomeDaSubCategoria != null)
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
