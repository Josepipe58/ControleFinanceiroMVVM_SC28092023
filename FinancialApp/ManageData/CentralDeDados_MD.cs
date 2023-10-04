#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Lists;
using Domain.Messages;
using Domain.Queries;
using FinancialApp.DataValidation;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace FinancialApp.ManageData
{
    public class CentralDeDados_MD : CentralDeDados_DV
    {
        #region |====================================| Propriedades |====================================|

        public static string _nomeDoMetodo = string.Empty;
        private static SaldoFinanceiroCPI _saldoFinanceiroCPI;
        private static SaldoDaCarteiraPoupancaEInvestimento _saldoDaCarteiraPoupancaEInvestimento;

        //|=======================================| Lista da Central de Dados |=======================================|

        //Carregar DataGrid Dados.
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
        //|=======================================| Lista de Valores Meses |=======================================|

        //Carregar DataGrid Valores.
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
        //|=======================================| Lista de Anos |==================================================|

        //Carregar ComboBox de Anos.
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
        #endregion

        #region |====================================| Construtor |================================================|

        public CentralDeDados_MD()
        {
            ListaDaCentralDeDados = new ListaDaCentralDeDados();
            _saldoFinanceiroCPI = new SaldoFinanceiroCPI();
            _saldoDaCarteiraPoupancaEInvestimento = new SaldoDaCarteiraPoupancaEInvestimento();
        }
        #endregion

        #region |====================================| Métodos |===================================================|

        //|=================================| Cadastrar |==========================================|

        public void Cadastrar(CentralDeDados centralDeDados)
        {
            if (ValidarCadastrar(centralDeDados) == true)
            {
                try
                {
                    CentralDeDados_DA centralDeDados_DA = new();
                    string retorno = centralDeDados_DA.Cadastrar(centralDeDados);
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
        //|=================================| Alterar |============================================|

        public void Alterar(CentralDeDados centralDeDados)
        {
            if (ValidarAlterarExcluir(centralDeDados) == true)
            {
                try
                {
                    CentralDeDados_DA centralDeDados_DA = new();
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
        //|=================================| Excluir |============================================|

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
                    centralDeDados_DA.Excluir(centralDeDados);
                    GerenciarMensagens.SucessoAoExcluir(centralDeDados.Id);
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

        public static double SaldoDaCarteira(int ano)
        {             
            try
            {
                _saldoFinanceiroCPI.SaldoDaCarteira =
                    _saldoDaCarteiraPoupancaEInvestimento.SaldoDaCarteira(ano);
                return _saldoFinanceiroCPI.SaldoDaCarteira;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoDaCarteira";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return 0;
            }
        }

        public static double SaldoDaPoupanca(int ano)
        {
            try
            {
                _saldoFinanceiroCPI.SaldoDaPoupanca =
                    _saldoDaCarteiraPoupancaEInvestimento.SaldoDaPoupanca(ano);
                return _saldoFinanceiroCPI.SaldoDaPoupanca;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return 0;
            }
        }

        public static double SaldoDeInvestimentos(int ano)
        {
            try
            {
                _saldoFinanceiroCPI.SaldoDeInvestimento =
                    _saldoDaCarteiraPoupancaEInvestimento.SaldoDeInvestimentos(ano);
                return _saldoFinanceiroCPI.SaldoDeInvestimento;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoDeInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return 0;
            }
        }

        public static double SaldoTotalPoupancaEInvestimentos()
        {
            try
            {
                _saldoFinanceiroCPI.SaldoTotalDaPoupancaEInvestimento =
                    _saldoFinanceiroCPI.SaldoDaPoupanca + _saldoFinanceiroCPI.SaldoDeInvestimento;
                return _saldoFinanceiroCPI.SaldoTotalDaPoupancaEInvestimento;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoTotalPoupancaEInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return 0;
            }
        }
        //|=================================| Limpar Dados |===========================|            

        public void LimparDados()
        {
            //Atenção! Não juntar esse método com AtualizarDados() para não limpar ComboBoxes ao fazer CRUD.
            CentralDeDados_DA centralDeDados_DA = new();
            CentralDeDados.Id = 0;
            CentralDeDados.Valor = 0;
            ListaDaCentralDeDados = centralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(CentralDeDados.Ano);
        }
        //|=================================| Atualizar Dados |===========================|            

        public void AtualizarDados()
        {
            CentralDeDados_DA centralDeDados_DA = new();

            DateTime mes = DateTime.Now;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var mesAtual = textInfo.ToTitleCase(mes.ToString("MMMM"));
            var dataAtual = textInfo.ToTitleCase(mes.ToString("dd/MM/yyyy"));

            CentralDeDados.Id = 0;
            CentralDeDados.NomeDaCategoria = ListaDaCentralDeDados[1].NomeDaCategoria;
            CentralDeDados.Valor = 0;
            CentralDeDados.Tipo = ListaDaCentralDeDados[0].Tipo;
            CentralDeDados.Mes = mesAtual;
            CentralDeDados.Data = Convert.ToDateTime(dataAtual);
            CentralDeDados.Ano = ListaDaCentralDeDados[0].Ano;
            ListaDaCentralDeDados = centralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(CentralDeDados.Ano);
        }
        #endregion
    }
}
