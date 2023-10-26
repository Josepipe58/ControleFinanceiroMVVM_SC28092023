#nullable disable
using AppFinanceiroMVVM.Commandos;
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;

namespace AppFinanceiroMVVM.ViewModels.AnosVM
{
    public partial class AnoViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;

        public AnoDto AnoDto { get; set; }

        public Ano Ano { get; set; }

        //Lista do DataGrid Dados e ComboBox
        private ListaDeAnos _listaDeAnos;
        public ListaDeAnos ListaDeAnos
        {
            get { return _listaDeAnos; }
            set
            {
                if (_listaDeAnos != value)
                {
                    _listaDeAnos = value;
                    OnPropertyChanged(nameof(ListaDeAnos));
                }
            }
        }

        public AnoViewModel()
        {
            ListaDeAnos = new ListaDeAnos();
            AnoDto = new AnoDto();
            Ano = new Ano();

            //DataGrid Dados
            Ano_AD ano_AD = new();
            ListaDeAnos = ano_AD.ConsultarAnos();
        }
    }
}
