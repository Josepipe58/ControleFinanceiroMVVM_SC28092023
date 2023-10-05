#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Lists;
using Domain.Messages;
using Domain.Queries;
using Domain.Reports;
using FinancialApp.Commands;
using System;
using System.Collections.Generic;

namespace FinancialApp.ViewModels
{
    public class CentralDeDadosViewModel : CentralDeDadosCommand
    {
        #region |===============================| Propriedades |======================================================|

        public CentralDeDados_DA _centralDeDados_DA;
        public Ano_DA _ano_DA;
        private static SaldoDaCarteiraPoupancaEInvestimento _saldoDaCarteiraPoupancaEInvestimento;
        public double _saldoTotalDaPoupancaEInvestimento;

        //Lista do ComboBox de Anos 
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
        public List<string> ListaTipoDeDespesa { get; set; }

        //Lista de Meses
        public List<string> ListaDeMeses { get; set; }

        #endregion

        #region |===============================| Construtor de Despesa ViewModel |===================================|

        public CentralDeDadosViewModel()
        {
            //Não deletar essa instância porque está sendo usada na Central de Dados.
            CentralDeDados = new CentralDeDados();

            //Carregar ComboBox Anos
            _ano_DA = new();
            ListaDeAnos = new ListaDeAnos();
            ListaDeAnos = _ano_DA.ConsultarAnos();

            //DataGrid Dados           
            _centralDeDados_DA = new();
            ListaDaCentralDeDados = _centralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(ListaDeAnos[0].AnoDoCadastro);            

            //DataGrid Valores
            RelatorioDeDespesa relatorioDeDespesa = new();
            ListaDeValoresMeses = new ListaDeValoresMeses();
            ListaDeValoresMeses = relatorioDeDespesa.ConsultarDespesasTotais(ListaDeAnos[0].AnoDoCadastro);

            //Lista Genérica de Meses            
            ListaDeMeses = new List<string>();
            ListaDeMeses = ListaGenericaDeMeses.CarregarComboBoxDeMeses();

            //Lista de Tipo de Despesa
            ListaTipoDeDespesa = new List<string>();
            ListaTipoDeDespesa = ListaDeTipos.ListaDeTodosOsTipos();

            
            _saldoDaCarteiraPoupancaEInvestimento = new SaldoDaCarteiraPoupancaEInvestimento();
            SaldoDaCarteiraPoupancaEInvestimentos(ListaDeAnos[0].AnoDoCadastro);            
        }

        public void SaldoDaCarteiraPoupancaEInvestimentos(int ano)
        {
            if (ListaDeAnos[0].AnoDoCadastro != 0 && CentralDeDados.Mes != "")
            {
                try
                {
                    //====================================| Saldo da Carteira |=======================================================================                    
                    SaldoDaCarteira = Convert.ToString(_saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDaCarteiraPorAno(ano));
                    double saldoDaCarteira = Convert.ToDouble(SaldoDaCarteira.ToString().Replace("R$", ""));
                    SaldoDaCarteira = string.Format("{0:c}", saldoDaCarteira);
                    //====================================| Saldo da Poupança |======================================================================== 

                    SaldoDaPoupanca = Convert.ToString(_saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDaPoupanca(ano));
                    double saldoDaPoupanca = Convert.ToDouble(SaldoDaPoupanca.ToString().Replace("R$", ""));
                    SaldoDaPoupanca = string.Format("{0:c}", saldoDaPoupanca);
                    
                    //====================================| Saldo de Investimentos |=================================================================== 
                    SaldoDeInvestimentos = Convert.ToString(_saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDeInvestimentos(ano));
                    double saldoDeInvestimento = Convert.ToDouble(SaldoDeInvestimentos.ToString().Replace("R$", ""));
                    SaldoDeInvestimentos = string.Format("{0:c}", saldoDeInvestimento);



                    //=====================================| Saldo Total da Poupança e de Investimentos |===============================================  
                    double _saldoTotalPoupancaEInvestimentos = Convert.ToDouble((saldoDaPoupanca + saldoDeInvestimento).ToString().Replace("R$", ""));
                    SaldoTotalPoupancaEInvestimentos = string.Format("{0:c}", _saldoTotalPoupancaEInvestimentos);
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "SaldoDaCarteiraPoupancaEInvestimentos";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else
            {
                try
                {
                    //====================================| Saldo da Carteira |=======================================================================                    
                    SaldoDaCarteira = Convert.ToString(_saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDaCarteiraPorAno(ano));
                    double saldoDaCarteira = Convert.ToDouble(SaldoDaCarteira.ToString().Replace("R$", ""));
                    SaldoDaCarteira = string.Format("{0:c}", saldoDaCarteira);
                    //====================================| Saldo da Poupança |======================================================================== 

                    SaldoDaPoupanca = Convert.ToString(_saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDaPoupanca(ano));
                    double saldoDaPoupanca = Convert.ToDouble(SaldoDaPoupanca.ToString().Replace("R$", ""));
                    SaldoDaPoupanca = string.Format("{0:c}", saldoDaPoupanca);
                    
                    //====================================| Saldo de Investimentos |=================================================================== 
                    SaldoDeInvestimentos = Convert.ToString(_saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDeInvestimentos(ano));
                    double saldoDeInvestimento = Convert.ToDouble(SaldoDeInvestimentos.ToString().Replace("R$", ""));
                    SaldoDeInvestimentos = string.Format("{0:c}", saldoDeInvestimento);
                    //=====================================| Saldo Total da Poupança e de Investimentos |===============================================                    
                    double _saldoTotalPoupancaEInvestimentos = Convert.ToDouble((saldoDaPoupanca + saldoDeInvestimento).ToString().Replace("R$", ""));
                    SaldoTotalPoupancaEInvestimentos = string.Format("{0:c}", _saldoTotalPoupancaEInvestimentos);

                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "SaldoDaCarteiraPoupancaEInvestimentos";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }
        #endregion
    }
}
