using AppFinanceiroMVVM.Commandos;
using BancoDeDados.ModelosDto;
using GerenciarDados.Listas;
using System.Collections.Generic;

namespace AppFinanceiroMVVM.ViewModels.CentralDeDadosVM
{
    public partial class CentralDeDadosViewModel//Propriedades Alteradas
    {
        //Lista do ComboBox da Lista de Filtros de Controle
        private ListaDeFiltrosDeControle _listaDeFiltrosDeControles;
        public ListaDeFiltrosDeControle ListaDeFiltrosDeControles
        {
            get { return _listaDeFiltrosDeControles; }
            set
            {
                if (_listaDeFiltrosDeControles != value)
                {
                    _listaDeFiltrosDeControles = value;
                    OnPropertyChanged(nameof(ListaDeFiltrosDeControles));

                }
            }
        }

        //Lista do ComboBox da Lista de Filtros de Controle
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

        //Lista do DataGrid Dados.       
        private ListaDaCentralDeDados _listaDaCentralDeDados;
        public ListaDaCentralDeDados ListaDaCentralDeDados
        {
            get { return _listaDaCentralDeDados; }
            set
            {
                if (_listaDaCentralDeDados != value)
                {
                    _listaDaCentralDeDados = value;
                    OnPropertyChanged(nameof(ListaDaCentralDeDados));
                }
            }
        }

        //Lista do DataGrid de Valores e Meses
        private ListaDeValoresMeses _listaDeValoresMeses;
        public ListaDeValoresMeses ListaDeValoresMeses
        {
            get { return _listaDeValoresMeses; }
            set
            {
                if (_listaDeValoresMeses != value)
                {
                    _listaDeValoresMeses = value;
                    OnPropertyChanged(nameof(ListaDeValoresMeses));
                }
            }
        }

        //Lista de Tipos
        private List<string> _listaDeTiposDaCentralDeDados;
        public List<string> ListaDeTiposDaCentralDeDados
        {
            get { return _listaDeTiposDaCentralDeDados; }
            set
            {
                if (_listaDeTiposDaCentralDeDados != value)
                {
                    _listaDeTiposDaCentralDeDados = value;
                    OnPropertyChanged(nameof(ListaDeTiposDaCentralDeDados));
                }
            }
        }

        //Lista de Meses
        private List<string> _listaDeMeses;
        public List<string> ListaDeMeses
        {
            get { return _listaDeMeses; }
            set
            {
                if (_listaDeMeses != value)
                {
                    _listaDeMeses = value;
                    OnPropertyChanged(nameof(ListaDeMeses));
                }
            }
        }

        //Propriedade da Label: LblTituloDtgValores
        private string _lblTituloDtgValores;
        public string LblTituloDtgValores
        {
            get { return _lblTituloDtgValores; }
            set
            {
                if (_lblTituloDtgValores != value)
                {
                    _lblTituloDtgValores = value;
                    OnPropertyChanged(nameof(LblTituloDtgValores));
                }
            }
        }

        //Saldo da Carteira
        private decimal _saldoDaCarteira;
        public decimal SaldoDaCarteira
        {
            get { return _saldoDaCarteira; }
            set
            {
                if (_saldoDaCarteira != value)
                {
                    _saldoDaCarteira = value;
                    OnPropertyChanged(nameof(SaldoDaCarteira));
                }
            }
        }

        //Saldo da Poupança
        private decimal _saldoDaPoupanca;
        public decimal SaldoDaPoupanca
        {
            get { return _saldoDaPoupanca; }
            set
            {
                if (_saldoDaPoupanca != value)
                {
                    _saldoDaPoupanca = value;
                    OnPropertyChanged(nameof(SaldoDaPoupanca));
                }
            }
        }

        //Saldo de Investimento(LCI)
        private decimal _saldoDeInvestimento;
        public decimal SaldoDeInvestimento
        {
            get { return _saldoDeInvestimento; }
            set
            {
                if (_saldoDeInvestimento != value)
                {
                    _saldoDeInvestimento = value;
                    OnPropertyChanged(nameof(SaldoDeInvestimento));
                }
            }
        }

        //Saldo da Poupança e Investimento(LCI)
        private decimal _saldoPoupancaEInvestimento;
        public decimal SaldoPoupancaEInvestimento
        {
            get { return _saldoPoupancaEInvestimento; }
            set
            {
                if (_saldoPoupancaEInvestimento != value)
                {
                    _saldoPoupancaEInvestimento = value;
                    OnPropertyChanged(nameof(SaldoPoupancaEInvestimento));
                }
            }
        }
    }
}
