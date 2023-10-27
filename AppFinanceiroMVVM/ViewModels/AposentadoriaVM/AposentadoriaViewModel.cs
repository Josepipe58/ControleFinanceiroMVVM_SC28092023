#nullable disable
using AppFinanceiroMVVM.Commandos;
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;
using GerenciarDados.Listas;
using System;
using System.Collections.Generic;

namespace AppFinanceiroMVVM.ViewModels.AposentadoriaVM
{
    public partial class AposentadoriaViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;

        public string MensagemCalcularReajusteDaAposentadoria { get; set; }

        public AposentadoriaDto AposentadoriaDto { get; set; }

        public Aposentadoria Aposentadoria { get; set; }

        //Lista do DataGrid Dados
        private ListaDeAposentadoria _listaDeAposentadoria;
        public ListaDeAposentadoria ListaDeAposentadoria
        {
            get { return _listaDeAposentadoria; }
            set
            {
                if (_listaDeAposentadoria != value)
                {
                    _listaDeAposentadoria = value;
                    OnPropertyChanged(nameof(ListaDeAposentadoria));
                }
            }
        }

        //Lista de Anos da Aposentadoria
        private List<int> _listaDeAnosDoReajusteDaAposentadoria;
        public List<int> ListaDeAnosDoReajusteDaAposentadoria
        {
            get { return _listaDeAnosDoReajusteDaAposentadoria; }
            set
            {
                if (_listaDeAnosDoReajusteDaAposentadoria != value)
                {
                    _listaDeAnosDoReajusteDaAposentadoria = value;
                    OnPropertyChanged(nameof(ListaDeAnosDoReajusteDaAposentadoria));
                }
            }
        }

        public AposentadoriaViewModel()
        {
            ListaDeAposentadoria = new ListaDeAposentadoria();
           
            AposentadoriaDto = new AposentadoriaDto();
            Aposentadoria = new Aposentadoria();
            Aposentadoria.Data = DateTime.Today;
            ListaDeAnosDoReajusteDaAposentadoria = new List<int>();
            
            //DataGrid Dados
            Aposentadoria_AD aposentadoria_AD = new();
            ListaDeAposentadoria = aposentadoria_AD.ConsultarAposentadoria();            
            Aposentadoria.SaldoAtual = aposentadoria_AD.ConsultarAposentadoria()[0].SaldoAtual;

            ListaDeAnosDoReajusteDaAposentadoria = ListaDeAnosAposentadoria.ListaDeAnosAPartirDe2011();
            MensagemCalcularReajusteDaAposentadoria = InstrucaoParaCalcularReajusteDaAposentadoria();
          
        }
    }
}
