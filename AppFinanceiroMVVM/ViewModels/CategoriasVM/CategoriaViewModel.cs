#nullable disable
using AppFinanceiroMVVM.Commandos;
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;

namespace AppFinanceiroMVVM.ViewModels.CategoriasVM
{
    public partial class CategoriaViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;

        public CategoriaDto CategoriaDto { get; set; }

        public Categoria Categoria { get; set; }

        //Lista do DataGrid Dados
        private ListaDeCategorias _listaDeCategorias;
        public ListaDeCategorias ListaDeCategorias
        {
            get { return _listaDeCategorias; }
            set
            {
                if (_listaDeCategorias != value)
                {
                    _listaDeCategorias = value;
                    OnPropertyChanged(nameof(ListaDeCategorias));
                }
            }
        }

        //Lista do ComboBox Filtros de Controle
        private ListaDeFiltrosDeControle _listaDeFiltrosDeControle;
        public ListaDeFiltrosDeControle ListaDeFiltrosDeControle
        {
            get { return _listaDeFiltrosDeControle; }
            set
            {
                if (_listaDeFiltrosDeControle != value)
                {
                    _listaDeFiltrosDeControle = value;
                    OnPropertyChanged(nameof(ListaDeFiltrosDeControle));
                }
            }
        }

        public CategoriaViewModel()
        {
            CategoriaDto = new CategoriaDto();
            Categoria = new Categoria();
            ListaDeCategorias = new ListaDeCategorias();
            ListaDeFiltrosDeControle = new ListaDeFiltrosDeControle();

            //ComboBox do filtro de controle
            FiltroDeControle_AD filtroDeControle_AD = new();            
            ListaDeFiltrosDeControle = filtroDeControle_AD.ConsultarFiltrosDeControle();

            //DataGrid Dados
            Categoria_AD categoria_AD = new();
            ListaDeCategorias = categoria_AD.ConsultarCategoriasPorNomeDoFiltro(ListaDeFiltrosDeControle[0].NomeDoFiltro);
        }
    }
}
