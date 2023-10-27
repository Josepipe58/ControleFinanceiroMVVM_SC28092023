#nullable disable
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;
using GerenciarDados.Consultas;
using GerenciarDados.Mensagens;
using GerenciarDados.Relatorios;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroMVVM.Views
{
    public partial class CentralDeDadosView : UserControl
    {
        public string _nomeDoMetodo = string.Empty;

        public CentralDeDadosView()
        {
            InitializeComponent();
            
            CarregarDiversosComboBoxesDeDespesas();
        }

        private void CarregarDiversosComboBoxesDeDespesas()
        {
            //Atualizar com a Data do Sistema
            if (DtpData.Text == "")
            {
                DtpData.Text = Convert.ToString(DateTime.Today);
            }
            else
            {
                DtpData.Text = Convert.ToString(DateTime.Today);
            }

            try
            {
                //Carregar ComboBox do Filtro de Controle.
                //Não mudar o ItemsSource daqui senão dá erro.
                FiltroDeControle_AD filtroDeControle_AD = new();
                CbxNomeDeFiltros.ItemsSource = filtroDeControle_AD.ConsultarFiltrosDeControle();
                CbxNomeDeFiltros.DisplayMemberPath = "NomeDoFiltro";
                CbxNomeDeFiltros.SelectedValuePath = "Id";
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "CarregarDiversosComboBoxesDeDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
        }

        private void CbxNomeDeFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox das Categorias
            Categoria_AD categoria_AD = new();
            CbxCategoria.ItemsSource = categoria_AD
                .ConsultarCategoriasPorId(Convert.ToInt32(CbxNomeDeFiltros.SelectedValue));
            CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
            CbxCategoria.SelectedValuePath = "Id";
            CbxCategoria.SelectedIndex = 0;
        }

        private void CbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox das SubCategorias.
            //Não colocar nenhum tratamento de erros nesse Método porque eles não serão executados e
            //também porque não há necessidade de tratamento de erros.
            SubCategoria_AD subCategoria_AD = new();
            CbxSubCategoria.ItemsSource = subCategoria_AD
                .ConsultarSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = 0;
        }

        public void DataGridDaCentralDeDadosEValores()
        {
            try
            {
                CentralDeDados_AD centralDeDados_AD = new();
                DtgDados.ItemsSource = centralDeDados_AD.ConsultarFiltroSelecionadoNoComboBox
                        (CbxNomeDeFiltros.Text, Convert.ToInt32(CbxAno.Text));

                if (CbxNomeDeFiltros.Text == "Despesas")
                {
                    RelatorioDeDespesas relatorioDeDespesa = new();
                    DtgValores.ItemsSource = relatorioDeDespesa.ConsultarDespesasTotais(Convert.ToInt32(CbxAno.Text));
                    LblTituloDtgValores.Content = "Despesa Geral - Mensal e Anual";
                }
                else if (CbxNomeDeFiltros.Text == "Poupança")
                {
                    RelatorioDePoupanca relatorioDePoupanca = new();
                    DtgValores.ItemsSource = relatorioDePoupanca
                        .ConsultarSaldoTotalDaPoupancaReceitasEInvestimentos(Convert.ToInt32(CbxAno.Text));
                    LblTituloDtgValores.Content = "Saldo Total da Poupança";
                }
                else
                {
                    RelatorioDeInvestimentos relatorioDeInvestimentos = new();
                    DtgValores.ItemsSource = relatorioDeInvestimentos
                        .ConsultarSaldoTotalDeInvestimentos(Convert.ToInt32(CbxAno.Text));
                    LblTituloDtgValores.Content = "Saldo Total de Investimentos.";
                }

            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "DataGridDaCentralDeDadosEValores";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }

            SaldoDaCarteiraPoupancaEInvestimentos();
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedItems.Count >= 0)
            {
                if (DtgDados.SelectedItems[0].GetType() == typeof(CentralDeDadosDto))
                {
                    CentralDeDadosDto centralDeDadosDto = (CentralDeDadosDto)DtgDados.SelectedItems[0];

                    TxtId.Text = centralDeDadosDto.Id.ToString();
                    CbxCategoria.Text = centralDeDadosDto.NomeDaCategoria;
                    CbxSubCategoria.Text = centralDeDadosDto.NomeDaSubCategoria;
                    TxtValor.Text = centralDeDadosDto.Valor.ToString();
                    CbxNomeDeFiltros.Text = centralDeDadosDto.Filtros;
                    CbxTipo.Text = centralDeDadosDto.Tipo;
                    DtpData.Text = centralDeDadosDto.Data.ToString();
                    CbxMes.Text = centralDeDadosDto.Mes;
                    CbxAno.Text = centralDeDadosDto.Ano.ToString();
                }
            }
            TxtValor.Focus();
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            DataGridDaCentralDeDadosEValores();
        }

        private void CbxNomeDeFiltros_MouseLeave(object sender, MouseEventArgs e)
        {
            DataGridDaCentralDeDadosEValores();
        }

        private void TxtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                double formatarValor = Convert.ToDouble(TxtValor.Text.ToString().Replace("R$", ""));
                TxtValor.Text = string.Format("{0:c}", formatarValor);
            }
        }

        public void SaldoDaCarteiraPoupancaEInvestimentos()
        {
            try
            {
                SaldoDaCarteiraPoupancaEInvestimento saldoDaCarteiraPoupancaEInvestimento = new();
                //====================================| Saldo da Carteira |=======================================================================                    
                TxtCarteira.Text = Convert.ToString(saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDaCarteiraPorAno(Convert.ToInt32(CbxAno.Text)));
                double saldoDaCarteira = Convert.ToDouble(TxtCarteira.Text.ToString().Replace("R$", ""));
                TxtCarteira.Text = string.Format("{0:c}", saldoDaCarteira);
                //====================================| Saldo da Poupança |======================================================================== 
                TxtPoupanca.Text = Convert.ToString(saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDaPoupanca(Convert.ToInt32(CbxAno.Text)));
                double saldoDaPoupanca = Convert.ToDouble(TxtPoupanca.Text.ToString().Replace("R$", ""));
                TxtPoupanca.Text = string.Format("{0:c}", saldoDaPoupanca);
                //====================================| Saldo de Investimentos |=================================================================== 
                TxtInvestimento.Text = Convert.ToString(saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDeInvestimentos(Convert.ToInt32(CbxAno.Text)));
                double saldoDeInvestimento = Convert.ToDouble(TxtInvestimento.Text.ToString().Replace("R$", ""));
                TxtInvestimento.Text = string.Format("{0:c}", saldoDeInvestimento);
                //=====================================| Saldo Total da Poupança e de Investimentos |===============================================  
                double _saldoTotalPoupancaEInvestimentos = Convert.ToDouble((saldoDaPoupanca + saldoDeInvestimento).ToString().Replace("R$", ""));
                TxtPoupancaEInvestimento.Text = string.Format("{0:c}", _saldoTotalPoupancaEInvestimentos);
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoDaCarteiraPoupancaEInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
        }
    }
}
