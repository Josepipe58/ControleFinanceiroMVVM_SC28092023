#nullable disable
using AppFinanceiroMVVM.Commandos;
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;

namespace AppFinanceiroMVVM.ViewModels.SubCategoriasVM
{
    public partial class SubCategoriaViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;
        //OBS: As Listas dos ComboBoxes, estão no Código Por Trás(Code Behind), por causa do evento SelectionChanged.

        public SubCategoriaDto SubCategoriaDto { get; set; }

        public SubCategoria SubCategoria { get; set; }

        //Lista do DataGrid Dados
        private ListaDeSubCategorias _listaDeSubCategorias;
        public ListaDeSubCategorias ListaDeSubCategorias
        {
            get { return _listaDeSubCategorias; }
            set
            {
                if (_listaDeSubCategorias != value)
                {
                    _listaDeSubCategorias = value;
                    OnPropertyChanged(nameof(ListaDeSubCategorias));
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

        public SubCategoriaViewModel()
        {
            SubCategoriaDto = new SubCategoriaDto();
            SubCategoria = new SubCategoria();
            ListaDeFiltrosDeControle = new ListaDeFiltrosDeControle();

            //ComboBox do filtro de controle
            FiltroDeControle_AD filtroDeControle_AD = new();
            ListaDeFiltrosDeControle = filtroDeControle_AD.ConsultarFiltrosDeControle();

            //DataGrid Dados
            ListaDeSubCategorias = new ListaDeSubCategorias();
            SubCategoria_AD subCategoria_AD = new();
            ListaDeSubCategorias = subCategoria_AD.ConsultarSubCategoriasPorNomeDoFiltro(ListaDeFiltrosDeControle[0].NomeDoFiltro);
        }
    }
}
