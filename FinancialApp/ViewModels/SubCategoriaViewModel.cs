using Domain.DataAccess;
using ManageData.Commands;

namespace FinancialApp.ViewModels
{
    public class SubCategoriaViewModel : ComandosDeSubCategoria
    {
        public SubCategoria_DA ad_SubCategoriaDeDespesa;
        public Categoria_DA ad_CategoriaDeDespesa;

        public SubCategoriaViewModel()
        {
            //Carregar ComboBox de Categorias
            Categoria = new();
            ad_CategoriaDeDespesa = new();
            ListaDeCategorias = ad_CategoriaDeDespesa.ConsultarCategorias();

            //DataGrid Dados
            SubCategoria = new();
            ad_SubCategoriaDeDespesa = new();
            ListaDeSubCategorias = ad_SubCategoriaDeDespesa.ConsultarSubCategorias();
        }
    }
}
