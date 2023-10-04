#nullable disable
using Database.Models;
using Domain.DataAccess;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinancialApp.Views
{
    public partial class SubCategoriaView : UserControl
    {
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
        }

        private void CbxNomeDeFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox das Categorias.
            //Não colocar nenhum tratamento de erros nesse Método porque eles não serão executados e
            //também porque não há necessidade de tratamento de erros.
            Categoria_DA categoria_DA = new();
            CbxCategoria.ItemsSource = categoria_DA
                .ConsultarCategoriasPorId(Convert.ToInt32(CbxNomeDeFiltros.SelectedValue)).ToList();
            CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
            CbxCategoria.SelectedValuePath = "Id";
            CbxCategoria.SelectedIndex = 0;
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedItems.Count >= 0)
            {
                if (DtgDados.SelectedItems[0].GetType() == typeof(SubCategoria))
                {
                    SubCategoria subCategoria = (SubCategoria)DtgDados.SelectedItems[0];

                    TxtIdSubCategoria.Text = subCategoria.Id.ToString();
                    TxtSubCategoria.Text = subCategoria.NomeDaSubCategoria;
                    TxtIdCategoria.Text = subCategoria.CategoriaId.ToString();
                    CbxCategoria.Text = subCategoria.NomeDaCategoria;
                    CbxNomeDeFiltros.Text = subCategoria.NomeDoFiltro;
                    TxtSubCategoria.Focus();
                }
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SubCategoria_DA subCategoria_DA = new();
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = subCategoria_DA.ConsultarSubCategorias()
                    .Where(sc => sc.NomeDaSubCategoria.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = null;
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = subCategoria_DA.ConsultarSubCategorias();
            }
        }
    }
}
