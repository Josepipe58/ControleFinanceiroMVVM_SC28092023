#nullable disable
using AppFinanceiroMVVM.Commandos;
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;
using GerenciarDados.Consultas;
using GerenciarDados.Listas;
using GerenciarDados.Relatorios;
using System;
using System.Collections.Generic;

namespace AppFinanceiroMVVM.ViewModels.CentralDeDadosVM
{
    public partial class CentralDeDadosViewModel : RelayCommand
    {
        public string _nomeDoMetodo = string.Empty;

        public CentralDeDadosDto CentralDeDadosDto { get; set; }
        public CentralDeDados CentralDeDados { get; set; }

        public FiltroDeControle FiltroDeControle { get; set; }

        //Construtor
        public CentralDeDadosViewModel()
        {
            CentralDeDados = new CentralDeDados();
            CentralDeDadosDto = new CentralDeDadosDto();
            FiltroDeControle = new FiltroDeControle();

            ListaDeValoresMeses = new ListaDeValoresMeses();
            ListaDeAnos = new ListaDeAnos();           
            ListaDeFiltrosDeControles = new ListaDeFiltrosDeControle();
            ListaDaCentralDeDados = new ListaDaCentralDeDados();

            ListaDeTiposDaCentralDeDados = new List<string>();
            ListaDeMeses = new List<string>();
            LblTituloDtgValores = "Despesa Geral - Mensal e Anual";

            //Lista estática Genérica de Meses 
            ListaDeMeses = ListaGenericaDeMeses.CarregarComboBoxDeMeses();

            //Lista estática de Tipos da Central de Dados
            ListaDeTiposDaCentralDeDados = ListaDeTipos.ListaDeTodosOsTipos();

            //Carregar ComboBox Anos
            Ano_AD _ano_AD = new();
            ListaDeAnos = _ano_AD.ConsultarAnos();

            //Lista do Filtro de Controle
            FiltroDeControle_AD filtroDeControle_AD = new FiltroDeControle_AD();
            ListaDeFiltrosDeControles = filtroDeControle_AD.ConsultarFiltrosDeControle();

            //DataGrid Valores
            RelatorioDeDespesas relatorioDeDespesas = new();
            ListaDeValoresMeses = relatorioDeDespesas.ConsultarDespesasTotais(ListaDeAnos[0].AnoDoCadastro);

            //DataGrid Dados
            CentralDeDados_AD centralDeDados_AD = new CentralDeDados_AD();
            ListaDaCentralDeDados = centralDeDados_AD.ConsultarFiltroSelecionadoNoComboBox
                       (ListaDeFiltrosDeControles[0].NomeDoFiltro, ListaDeAnos[0].AnoDoCadastro);

            SaldoDaCarteiraPoupancaEInvestimentos();
        }
    }
}
