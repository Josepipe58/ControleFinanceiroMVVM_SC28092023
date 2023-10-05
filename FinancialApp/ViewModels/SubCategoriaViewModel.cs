#nullable disable
using Domain.DataAccess;
using FinancialApp.Commands;

namespace FinancialApp.ViewModels
{
    public class SubCategoriaViewModel : SubCategoriaCommand
    {
        public SubCategoria_DA _subCategoriaDeDespesa_DA;

        public SubCategoriaViewModel()
        {
            //DataGrid Dados
            _subCategoriaDeDespesa_DA = new SubCategoria_DA();
            ListaDeSubCategorias = _subCategoriaDeDespesa_DA.ConsultarSubCategorias();
        }
    }
}
