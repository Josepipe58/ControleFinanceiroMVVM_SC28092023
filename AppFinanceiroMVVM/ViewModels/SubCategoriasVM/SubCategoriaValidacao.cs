#nullable disable
using AppFinanceiroMVVM.Modelos;
using GerenciarDados.Mensagens;

namespace AppFinanceiroMVVM.ViewModels.SubCategoriasVM
{
    public partial class SubCategoriaViewModel//Validação
    {

        //Cadastrar
        public bool ValidarCadastrar(SubCategoria subCategoriaDeDespesa)
        {            
            SubCategoria = subCategoriaDeDespesa;            
            if (SubCategoria.Id == 0 && SubCategoria.NomeDaSubCategoria != null && SubCategoria.NomeDaSubCategoria != "")
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
            if (SubCategoria.Id > 0 && SubCategoria.NomeDaSubCategoria != null && SubCategoria.NomeDaSubCategoria != "")
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
    }
}
