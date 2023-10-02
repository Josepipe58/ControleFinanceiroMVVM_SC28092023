using Domain.DataAccess;
using FinancialApp.ManageData.Commands;

namespace FinancialApp.ViewModels
{
    public class CategoriaViewModel : ComandosDeCategoria
    {
        public Categoria_DA categoria_DA;

        public CategoriaViewModel()
        {
            Categoria = new();
            categoria_DA = new();
            ListaDeCategorias = categoria_DA.ConsultarCategorias();
        }
    }
}
