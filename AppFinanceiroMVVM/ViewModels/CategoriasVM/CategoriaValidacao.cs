#nullable disable
using AppFinanceiroMVVM.Modelos;
using GerenciarDados.Mensagens;

namespace AppFinanceiroMVVM.ViewModels.CategoriasVM
{
    public partial class CategoriaViewModel//Validação
    {

        //Cadastrar
        public bool ValidarCadastrar(Categoria categoria)
        {
            Categoria = categoria;
            if (Categoria.Id == 0 && Categoria.NomeDaCategoria != null && Categoria.NomeDaCategoria != "")
            {
                return true;
            }
            else if (Categoria.Id > 0 && Categoria.NomeDaCategoria != null)
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
        public bool ValidarAlterarExcluir(Categoria categoria)
        {
            Categoria = categoria;
            if (Categoria.Id > 0 && Categoria.NomeDaCategoria != null && Categoria.NomeDaCategoria != "")
            {
                return true;
            }
            else if (Categoria.Id == 0 && Categoria.NomeDaCategoria != null)
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
