#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Lists;
using Domain.Messages;
using Domain.Reports;
using FinancialApp.DataValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace FinancialApp.ManageData
{
    public class CentralDeDados_MD : CentralDeDados_DV
    {
        #region |=================================| Gerenciar Dados(CRUD) |=====================================|

        public static string _nomeDoMetodo = string.Empty;

        public ListaDeAnos ListaDeAnos { get; set; }

        public FiltroDeControle FiltroDeControle { get; set; }

        public FiltroDeControle_DA FiltroDeControle_DA { get; set; }

        public CentralDeDados_DA CentralDeDados_DA { get; set; }

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

        public CentralDeDados_MD()
        {
            ListaDeAnos = new ListaDeAnos();
            ListaDaCentralDeDados = new ListaDaCentralDeDados();
            FiltroDeControle_DA = new FiltroDeControle_DA();
            ListaDeValoresMeses = new ListaDeValoresMeses();
            FiltroDeControle = new FiltroDeControle();           
            ListaDeTiposDaCentralDeDados = new List<string>();
            ListaDeMeses = new List<string>();
            CentralDeDados_DA = new CentralDeDados_DA();
            //Ano = new Ano();            
        }

        //Cadastrar
        public void Cadastrar(CentralDeDados centralDeDados)
        {
            if (ValidarCadastrar(centralDeDados) == true)
            {
                try
                {
                    CentralDeDados_DA centralDeDados_DA = new();                   
                    
                    CentralDeDados.NomeDaCategoria = centralDeDados.NomeDaCategoria;
                    CentralDeDados.NomeDaSubCategoria = centralDeDados.NomeDaSubCategoria;
                    CentralDeDados.Valor = Convert.ToDecimal(centralDeDados.Valor);
                    CentralDeDados.Filtros = centralDeDados.Filtros;
                    CentralDeDados.Tipo = centralDeDados.Tipo;
                    CentralDeDados.Data = Convert.ToDateTime(centralDeDados.Data);
                    CentralDeDados.Mes = centralDeDados.Mes;
                    CentralDeDados.Ano = Convert.ToInt32(centralDeDados.Ano);

                    string retorno = centralDeDados_DA.Cadastrar(CentralDeDados);
                    int codigoDeRetorno = Convert.ToInt32(retorno);                    
                    GerenciarMensagens.SucessoAoCadastrar(codigoDeRetorno);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }

        //Alterar
        public void Alterar(CentralDeDados centralDeDados)
        {
            if (ValidarAlterarExcluir(centralDeDados) == true)
            {
                try
                {
                    CentralDeDados_DA centralDeDados_DA = new(); 
                    /*
                    CentralDeDados.Id = centralDeDados.Id;
                    CentralDeDados.NomeDaCategoria = centralDeDados.NomeDaCategoria;
                    CentralDeDados.NomeDaSubCategoria = centralDeDados.NomeDaSubCategoria;
                    CentralDeDados.Valor = Convert.ToDecimal(centralDeDados.Valor);
                    CentralDeDados.Filtros = centralDeDados.Filtros;
                    CentralDeDados.Tipo = centralDeDados.Tipo;
                    CentralDeDados.Data = Convert.ToDateTime(centralDeDados.Data);
                    CentralDeDados.Mes = centralDeDados.Mes;
                    CentralDeDados.Ano = Convert.ToInt32(centralDeDados.Ano);
                    */
                    centralDeDados_DA.Alterar(centralDeDados);

                    GerenciarMensagens.SucessoAoAlterar(centralDeDados.Id);                    
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }

        //Excluir
        public void Excluir(CentralDeDados centralDeDados)
        {
            if (ValidarAlterarExcluir(centralDeDados) == true)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(centralDeDados.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    CentralDeDados_DA centralDeDados_DA = new();
                    //CentralDeDados.Id = centralDeDados.Id;
                    centralDeDados_DA.Excluir(centralDeDados);

                    GerenciarMensagens.SucessoAoExcluir(CentralDeDados.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }

        //Limpar Dados
        public void LimparDados()
        {
            //Atenção! Não juntar esse método com AtualizarDados() para não limpar ComboBoxes ao fazer CRUD.
            //CentralDeDados_DA centralDeDados_DA = new();



            CentralDeDados.Id = 0;
            CentralDeDados.Valor = 0;
            //CentralDeDados.Ano = ListaDeAnos[0].AnoDoCadastro;

            //DataGrid Dados
            //_centralDeDados_DA = new();



            //ListaDaCentralDeDados = CentralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(ListaDeAnos[0].AnoDoCadastro);

            //DataGridDaCentralDeDadosEValores();
            //Lista do Filtro de Controle
            //ListaDeFiltrosDeControles = new ListaDeFiltrosDeControle();
            ListaDeFiltrosDeControles = FiltroDeControle_DA.ConsultarFiltrosDeControle();
            ListaDaCentralDeDados = CentralDeDados_DA.ConsultarFiltroSelecionadoNoComboBox(CentralDeDados.Filtros, ListaDeAnos[0].AnoDoCadastro);

            if (ListaDeFiltrosDeControles[0].NomeDoFiltro == "Despesas")
            {
                //ListaDaCentralDeDados = CentralDeDados_DA.ConsultarFiltroSelecionadoNoComboBox
                //        (ListaDeFiltrosDeControles[0].NomeDoFiltro, Convert.ToInt32(ListaDeAnos[0].AnoDoCadastro));

                RelatorioDeDespesas relatorioDeDespesas = new();
                ListaDeValoresMeses = relatorioDeDespesas.ConsultarDespesasTotais(ListaDeAnos[0].AnoDoCadastro);
                LblTituloDtgValores = "Despesa Geral - Mensal e Anual";
            }
            else if (ListaDeFiltrosDeControles[0].NomeDoFiltro == "Poupança")
            {
                //ListaDaCentralDeDados = CentralDeDados_DA.ConsultarFiltroSelecionadoNoComboBox
                //        (ListaDeFiltrosDeControles[0].NomeDoFiltro, Convert.ToInt32(ListaDeAnos[0].AnoDoCadastro));

                RelatorioDePoupanca relatorioDePoupanca_AD = new();
                ListaDeValoresMeses = relatorioDePoupanca_AD
                    .ConsultarSaldoTotalDaPoupancaReceitasEInvestimentos(ListaDeAnos[0].AnoDoCadastro);
                LblTituloDtgValores = "Saldo Total da Poupança";
            }
            else if (ListaDeFiltrosDeControles[0].NomeDoFiltro == "Investimentos")
            {
                //ListaDaCentralDeDados = CentralDeDados_DA.ConsultarFiltroSelecionadoNoComboBox
                //        (ListaDeFiltrosDeControles[0].NomeDoFiltro, Convert.ToInt32(ListaDeAnos[0].AnoDoCadastro));

                RelatorioDeInvestimentos relatorioDeInvestimentos_AD = new();
                ListaDeValoresMeses = relatorioDeInvestimentos_AD
                    .ConsultarSaldoTotalDeInvestimentos(ListaDeAnos[0].AnoDoCadastro);
                LblTituloDtgValores = "Saldo Total de Investimentos.";
            }
        }

        //Atualizar Dados 
        public void AtualizarDados()
        {
            DateTime mes = DateTime.Now;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var mesAtual = textInfo.ToTitleCase(mes.ToString("MMMM"));
            var dataAtual = textInfo.ToTitleCase(mes.ToString("dd/MM/yyyy"));

            CentralDeDados.Data = Convert.ToDateTime(dataAtual);            
            CentralDeDados.Tipo = ListaDeTipos.ListaDeTodosOsTipos()[0];
            CentralDeDados.Mes = mesAtual.ToString();
            CentralDeDados.Ano = ListaDeAnos[0].AnoDoCadastro;
            CentralDeDados.Filtros = ListaDeFiltrosDeControles[0].NomeDoFiltro;            
            LimparDados();
            
        }
        #endregion
    }
}
