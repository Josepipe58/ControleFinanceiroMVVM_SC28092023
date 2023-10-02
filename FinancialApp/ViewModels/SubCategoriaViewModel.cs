#nullable disable
using Database.Models;
using Domain.DataAccess;
using FinancialApp.ManageData.Commands;

namespace FinancialApp.ViewModels
{
    public class SubCategoriaViewModel : ComandosDeSubCategoria
    {
        public SubCategoria_DA subCategoriaDeDespesa_DA;
        public Categoria_DA categoriaDeDespesa_DA;
        public FiltroDeControle_DA filtroDeControle_DA;

        public SubCategoriaViewModel()
        {
            Categoria = new Categoria();
            SubCategoria = new SubCategoria();
            FiltroDeControle = new FiltroDeControle();

            //Carregar ComboBox do Filtro de Cntrole           
            filtroDeControle_DA = new FiltroDeControle_DA();
            ListaDeFiltrosDeControle = filtroDeControle_DA.ConsultarFiltrosDeControle();

            //Carregar ComboBox de Categorias            
            categoriaDeDespesa_DA = new Categoria_DA();
            ListaDeCategorias = categoriaDeDespesa_DA.ConsultarCategorias();

            //DataGrid Dados            
            subCategoriaDeDespesa_DA = new SubCategoria_DA();
            ListaDeSubCategorias = subCategoriaDeDespesa_DA.ConsultarSubCategorias();
        }
    }
}
