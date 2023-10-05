#nullable disable
using Database.Models;
using Domain.DataAccess;
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
        #region |=================================| Gerenciar Dados(CRUD) |=====================================|

        public static string _nomeDoMetodo = string.Empty;

        private static SaldoFinanceiroCPI _saldoFinanceiroCPI;
        private static SaldoDaCarteiraPoupancaEInvestimento _saldoDaCarteiraPoupancaEInvestimento;

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

        public CentralDeDados_MD()
        {
            ListaDaCentralDeDados = new ListaDaCentralDeDados();                       
            _saldoFinanceiroCPI = new SaldoFinanceiroCPI();
            _saldoDaCarteiraPoupancaEInvestimento = new SaldoDaCarteiraPoupancaEInvestimento();
        }

        //Cadastrar
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

        //Alterar
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

        //Limpar Dados
        public void LimparDados()
        {
            //Atenção! Não juntar esse método com AtualizarDados() para não limpar ComboBoxes ao fazer CRUD.
            CentralDeDados_DA centralDeDados_DA = new();
            CentralDeDados.Id = 0;
            CentralDeDados.Valor = 0;
            ListaDaCentralDeDados = centralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(CentralDeDados.Ano);
        }

        //Atualizar Dados 
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
              
        #region |==========| Propriedades Saldo da Carteira, Poupança e Investimentos |=========================|

        private string _saldoDaCarteira;
        public string SaldoDaCarteira
        {
            get { return _saldoDaCarteira; }
            set
            {
                _saldoDaCarteira = value;
                OnPropertyChanged(nameof(SaldoDaCarteira));
            }
        }

        private string _saldoDaPoupanca;
        public string SaldoDaPoupanca
        {
            get { return _saldoDaPoupanca; }
            set
            {
                _saldoDaPoupanca = value;
                OnPropertyChanged(nameof(SaldoDaPoupanca));
            }
        }

        private string _saldoDeInvestimentos;
        public string SaldoDeInvestimentos
        {
            get { return _saldoDeInvestimentos; }
            set
            {
                _saldoDeInvestimentos = value;
                OnPropertyChanged(nameof(SaldoDeInvestimentos));
            }
        }

        private string _saldoTotalPoupancaEInvestimentos;
        public string SaldoTotalPoupancaEInvestimentos
        {
            get { return _saldoTotalPoupancaEInvestimentos; }
            set
            {
                _saldoTotalPoupancaEInvestimentos = value;
                OnPropertyChanged(nameof(SaldoTotalPoupancaEInvestimentos));
            }
        }
        #endregion
    }
}
