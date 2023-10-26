#nullable disable
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AppFinanceiroMVVM.Views
{
    public partial class SubCategoriaView : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public SubCategoriaView()
        {
            InitializeComponent();
           CarregarDiversosComboBoxesDeDespesas();
        }

        private void CarregarDiversosComboBoxesDeDespesas()
        {
            try
            {
                //Carregar ComboBox do Filtro de Controle.
                //Não mudar o ItemsSource daqui senão dá erro.                
                FiltroDeControle_AD filtroDeControle_AD = new();
                CbxNomeDeFiltros.ItemsSource = filtroDeControle_AD.ConsultarFiltrosDeControle();
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
        }

        private void CbxNomeDeFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox das Categorias.
            //Não colocar nenhum tratamento de erros nesse Método porque eles não serão executados e
            //também porque não há necessidade de tratamento de erros.

            Categoria_AD categoria_AD = new();
            CbxCategoria.ItemsSource = categoria_AD
                .ConsultarCategoriasPorId(Convert.ToInt32(CbxNomeDeFiltros.SelectedValue));
            CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
            CbxCategoria.SelectedValuePath = "Id";
            CbxCategoria.SelectedIndex = 0;
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubCategoria_AD subCategoria_AD = new();
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = subCategoria_AD.ConsultarSubCategorias()
                    .Where(sc => sc.NomeDaSubCategoria.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = null;
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = subCategoria_AD.ConsultarSubCategorias();
            }
        }

        private void CbxNomeDeFiltros_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            try
            {
                SubCategoria_AD subCategoria_AD = new();
                FiltroDeControle filtrosDeControle = new();

                if (filtrosDeControle.NomeDoFiltro == "Despesas")
                {
                    DtgDados.ItemsSource = subCategoria_AD.ConsultarSubCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
                }
                else if (filtrosDeControle.NomeDoFiltro == "Poupança")
                {
                    DtgDados.ItemsSource = subCategoria_AD.ConsultarSubCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
                }
                else
                {
                    DtgDados.ItemsSource = subCategoria_AD.ConsultarSubCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
                }
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "DataGridDeCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedItems.Count >= 0)
            {
                if (DtgDados.SelectedItems[0].GetType() == typeof(SubCategoriaDto))
                {
                    SubCategoriaDto subCategoriaDto = (SubCategoriaDto)DtgDados.SelectedItems[0];

                    TxtIdSubCategoria.Text = subCategoriaDto.Id.ToString();
                    TxtSubCategoria.Text = subCategoriaDto.NomeDaSubCategoria;
                    TxtIdCategoria.Text = subCategoriaDto.CategoriaId.ToString();
                    CbxCategoria.Text = subCategoriaDto.NomeDaCategoria;
                    CbxNomeDeFiltros.Text = subCategoriaDto.NomeDoFiltro;
                    TxtSubCategoria.Focus();
                }
            }
        }
    }
}
