using Domain.DataAccess;
using FinancialApp.Commands;

namespace FinancialApp.ViewModels
{
    public class CategoriaViewModel : CategoriaCommand
    {
        public Categoria_DA _categoria_DA;
        public FiltroDeControle_DA _filtroDeControle_DA;

        public CategoriaViewModel()
        {
            //Carregar ComboBox do Filtro de Cntrole.          
            _filtroDeControle_DA = new FiltroDeControle_DA();
            ListaDeFiltrosDeControle = _filtroDeControle_DA.ConsultarFiltrosDeControle();

            //Carregar ComboBox Categorias.            
            _categoria_DA = new Categoria_DA();
            ListaDeCategorias = _categoria_DA.ConsultarCategorias();

        }
    }
}
