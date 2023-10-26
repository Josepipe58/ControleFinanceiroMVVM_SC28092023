#nullable disable
using AppFinanceiroMVVM.Commandos;
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;

namespace AppFinanceiroMVVM.ViewModels.NomeDeBancoVM
{
    public partial class NomeDeBancoViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;

        public NomeDeBancoDto NomeDeBancoDto { get; set; }

        public NomeDeBanco NomeDeBanco { get; set; }

        //Lista do DataGrid Dados
        private ListaDeNomeDeBancos _listaDeNomeDeBancos;
        public ListaDeNomeDeBancos ListaDeNomeDeBancos
        {
            get { return _listaDeNomeDeBancos; }
            set
            {
                if (_listaDeNomeDeBancos != value)
                {
                    _listaDeNomeDeBancos = value;
                    OnPropertyChanged(nameof(ListaDeNomeDeBancos));
                }
            }
        }

        public NomeDeBancoViewModel()
        {
            NomeDeBancoDto = new NomeDeBancoDto();
            NomeDeBanco = new NomeDeBanco();
            ListaDeNomeDeBancos = new ListaDeNomeDeBancos();

            //DataGrid Dados
            NomeDeBanco_AD nomeDeBanco_AD = new NomeDeBanco_AD();
            ListaDeNomeDeBancos = nomeDeBanco_AD.ConsultarNomeDeBancos();
        }
    }
}
