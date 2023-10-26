#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using Domain.Queries;
using Domain.Reports;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinancialApp.Views
{
    public partial class CentralDeDadosView : UserControl
    {
        public string nomeDoMetodo = string.Empty;
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
                FiltroDeControle_DA filtroDeControle_DA = new();
                CbxNomeDeFiltros.ItemsSource = filtroDeControle_DA.ConsultarFiltrosDeControle();
                CbxNomeDeFiltros.DisplayMemberPath = "NomeDoFiltro";
                CbxNomeDeFiltros.SelectedValuePath = "Id";
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: CarregarDiversosComboBoxesDeDespesas." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DataGridDaCentralDeDadosEValores();            
        }

        private void CbxNomeDeFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox das Categorias
            Categoria_DA categoria_DA = new();
            CbxCategoria.ItemsSource = categoria_DA
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
            SubCategoria_DA subCategoria_DA = new();
            CbxSubCategoria.ItemsSource = subCategoria_DA
                .ConsultarSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = 0;
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedItems.Count >= 0)
            {
                if (DtgDados.SelectedItems[0].GetType() == typeof(CentralDeDados))
                {
                    CentralDeDados centralDeDados = (CentralDeDados)DtgDados.SelectedItems[0];

                    TxtId.Text = centralDeDados.Id.ToString();
                    CbxCategoria.Text = centralDeDados.NomeDaCategoria;
                    CbxSubCategoria.Text = centralDeDados.NomeDaSubCategoria;
                    TxtValor.Text = centralDeDados.Valor.ToString();
                    CbxNomeDeFiltros.Text = centralDeDados.Filtros;
                    CbxTipo.Text = centralDeDados.Tipo;
                    DtpData.Text = centralDeDados.Data.ToString();
                    CbxMes.Text = centralDeDados.Mes;
                    CbxAno.Text = centralDeDados.Ano.ToString();                    
                }
            }
        }
        
        public void DataGridDaCentralDeDadosEValores()
        {
            try
            {
                CentralDeDados_DA centralDeDados_DA = new();
                DtgDados.ItemsSource = centralDeDados_DA.ConsultarFiltroSelecionadoNoComboBox
                        (CbxNomeDeFiltros.Text, Convert.ToInt32(CbxAno.Text));

                if (CbxNomeDeFiltros.Text == "Despesas")
                {
                    RelatorioDeDespesas relatorioDeDespesa_AD = new();
                    DtgValores.ItemsSource = relatorioDeDespesa_AD.ConsultarDespesasTotais(Convert.ToInt32(CbxAno.Text));
                    LblTituloDtgValores.Content = "Despesa Geral - Mensal e Anual";
                }
                else if (CbxNomeDeFiltros.Text == "Poupança")
                {
                    RelatorioDePoupanca relatorioDePoupanca_AD = new();
                    DtgValores.ItemsSource = relatorioDePoupanca_AD
                        .ConsultarSaldoTotalDaPoupancaReceitasEInvestimentos(Convert.ToInt32(CbxAno.Text));
                    LblTituloDtgValores.Content = "Saldo Total da Poupança";
                    TxtValor.Focus();                    
                }
                else
                {
                    RelatorioDeInvestimentos relatorioDeInvestimentos_AD = new();
                    DtgValores.ItemsSource = relatorioDeInvestimentos_AD
                        .ConsultarSaldoTotalDeInvestimentos(Convert.ToInt32(CbxAno.Text));
                    LblTituloDtgValores.Content = "Saldo Total de Investimentos.";
                }

            }
            catch (Exception erro)
            {
                nomeDoMetodo = "DataGridDaCentralDeDadosEValores";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                return;
            }
            
            SaldoDaCarteiraPoupancaEInvestimentos();
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            DataGridDaCentralDeDadosEValores();
        }
        
        private void CbxNomeDeFiltros_MouseLeave(object sender, MouseEventArgs e)
        {
            DataGridDaCentralDeDadosEValores();
        }
        
        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
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
            if (CbxAno.Text != "" && CbxMes.Text != "")
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
                    nomeDoMetodo = "SaldoDaCarteiraPoupancaEInvestimentos";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                    return;
                }
            }
            else
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
                    nomeDoMetodo = "SaldoDaCarteiraPoupancaEInvestimentos";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                    return;
                }
            }
        }
    }
}
