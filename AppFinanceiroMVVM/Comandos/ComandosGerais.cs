using AppFinanceiroMVVM.Commandos;
using AppFinanceiroMVVM.Views;
using AppFinanceiroMVVM.Views.Consultas;
using AppFinanceiroMVVM.Views.Relatorios;
using System.Windows.Input;

namespace AppFinanceiroMVVM.Comandos
{
    public partial class ComandosDaTelaPrincipal//Comandos Gerais
    {
        private void VoltarParaMenuDeConsultasERelatorios()
        {
            SelecionarControleDeUsuario = new MenuDeConsultasERelatoriosView();
        }

        private ICommand _comandoVoltarParaMenuDeConsultasERelatorios;
        public ICommand ComandoVoltarParaMenuDeConsultasERelatorios
        {
            get
            {
                if (_comandoVoltarParaMenuDeConsultasERelatorios == null)
                {
                    _comandoVoltarParaMenuDeConsultasERelatorios =
                        new RelayCommand(param => VoltarParaMenuDeConsultasERelatorios());
                }
                return _comandoVoltarParaMenuDeConsultasERelatorios;
            }
        }

        #region | Relatórios de Despesas, Poupanças, Receitas e Investimentos |

        public void RelatorioDeDespesas()
        {
            SelecionarControleDeUsuario = new RelatorioDeDespesasView();
        }

        private ICommand _comandoDoRelatorioDeDespesas;
        public ICommand ComandoDoRelatorioDeDespesas
        {
            get
            {
                if (_comandoDoRelatorioDeDespesas == null)
                {
                    _comandoDoRelatorioDeDespesas = new RelayCommand(param => RelatorioDeDespesas());
                }
                return _comandoDoRelatorioDeDespesas;
            }
        }

        public void RelatorioDaPoupanca()
        {
            SelecionarControleDeUsuario = new RelatorioDePoupancaView();
        }

        private ICommand _comandoDoRelatorioDaPoupanca;
        public ICommand ComandoDoRelatorioDaPoupanca
        {
            get
            {
                if (_comandoDoRelatorioDaPoupanca == null)
                {
                    _comandoDoRelatorioDaPoupanca = new RelayCommand(param => RelatorioDaPoupanca());
                }
                return _comandoDoRelatorioDaPoupanca;
            }
        }

        public void RelatorioDeReceitas()
        {
            SelecionarControleDeUsuario = new RelatorioDeReceitasView();
        }

        private ICommand _comandoDoRelatorioDeReceitas;
        public ICommand ComandoDoRelatorioDeReceitas
        {
            get
            {
                if (_comandoDoRelatorioDeReceitas == null)
                {
                    _comandoDoRelatorioDeReceitas = new RelayCommand(param => RelatorioDeReceitas());
                }
                return _comandoDoRelatorioDeReceitas;
            }
        }

        public void RelatorioDeInvestimentos()
        {
            SelecionarControleDeUsuario = new RelatorioDeInvestimentosView();
        }

        private ICommand _comandoDoRelatorioDeInvestimentos;
        public ICommand ComandoDoRelatorioDeInvestimentos
        {
            get
            {
                if (_comandoDoRelatorioDeInvestimentos == null)
                {
                    _comandoDoRelatorioDeInvestimentos = new RelayCommand(param => RelatorioDeInvestimentos());
                }
                return _comandoDoRelatorioDeInvestimentos;
            }
        }

        #endregion


        #region | Consultas de Despesas, Finanças, Receitas e Aposentadoria |

        public void ConsultarDespesas()
        {
            SelecionarControleDeUsuario = new ConsultarDespesasView();
        }

        private ICommand _comandoDeConsultarDespesas;
        public ICommand ComandoDeConsultarDespesas
        {
            get
            {
                if (_comandoDeConsultarDespesas == null)
                {
                    _comandoDeConsultarDespesas = new RelayCommand(param => ConsultarDespesas());
                }
                return _comandoDeConsultarDespesas;
            }
        }

        public void ConsultarFinancas()
        {
            SelecionarControleDeUsuario = new ConsultarFinancasView();
        }

        private ICommand _comandoDeConsultarFinancas;
        public ICommand ComandoDeConsultarFinancas
        {
            get
            {
                if (_comandoDeConsultarFinancas == null)
                {
                    _comandoDeConsultarFinancas = new RelayCommand(param => ConsultarFinancas());
                }
                return _comandoDeConsultarFinancas;
            }
        }
        #endregion
    }
}
