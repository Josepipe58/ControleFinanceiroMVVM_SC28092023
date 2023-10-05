#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Reports;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinancialApp.Views
{
    public partial class CentralDeDadosView : UserControl
    {
        public CentralDeDados CentralDeDados { get; set; }
        public CentralDeDadosView()
        {
            InitializeComponent();
            CentralDeDados = new CentralDeDados();
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
                CbxNomeDeFiltros.SelectedIndex = 0;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Atenção! Ocorreu um erro no seguinte método: CarregarDiversosComboBoxesDeDespesas." +
                    $"\nDetalhes: {erro.Message}", "Mensagem de Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //SaldoDaCarteiraPoupancaEInvestimentos();
            TxtValor.Focus();
        }

        private void CbxNomeDeFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox das Categorias de Despesas.
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
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(CentralDeDados))
                    {
                        CentralDeDados = (CentralDeDados)DtgDados.SelectedItems[0];
                        TxtId.Text = CentralDeDados.Id.ToString();
                        CbxCategoria.Text = CentralDeDados.NomeDaCategoria.ToString();
                        CbxSubCategoria.Text = CentralDeDados.NomeDaSubCategoria.ToString();
                        TxtValor.Text = CentralDeDados.Valor.ToString();
                        CbxNomeDeFiltros.Text = CentralDeDados.Filtros.ToString();
                        CbxTipo.Text = CentralDeDados.Tipo.ToString();
                        DtpData.Text = CentralDeDados.Data.ToString();
                        CbxMes.Text = CentralDeDados.Mes.ToString();
                        CbxAno.Text = CentralDeDados.Ano.ToString();
                        TxtValor.Focus();
                    }
                }
            }
        }

        private void TxtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                double formatarValor = Convert.ToDouble(TxtValor.Text.ToString().Replace("R$", ""));
                TxtValor.Text = string.Format("{0:c}", formatarValor);
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            CentralDeDados_DA centralDeDados_DA = new();
            DtgDados.ItemsSource = centralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(Convert.ToInt32(CbxAno.Text));

            RelatorioDeDespesa relatorioDeDespesa = new();
            DtgValores.ItemsSource = relatorioDeDespesa.ConsultarDespesasTotais(Convert.ToInt32(CbxAno.Text));

            //SaldoDaCarteiraPoupancaEInvestimentos();
        }
    }
}
