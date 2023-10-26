#nullable disable
using Database.Models;
using Domain.Messages;

namespace FinancialApp.DataValidation
{
    public class Categoria_DV : DataValidationBase
    {
        public Categoria Categoria { get; set; }

        public Categoria_DV()
        {
            Categoria = new Categoria();
        }

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
