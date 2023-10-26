#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinancialApp.Views
{
    public partial class CategoriaView : UserControl
    {
        public string _nomeDoMetodo = string.Empty;

        public CategoriaView()
        {
            InitializeComponent();
            
            //Carregar ComboBox do Filtro de Cntrole          
            FiltroDeControle_DA filtroDeControle_DA = new();
            CbxNomeDeFiltros.ItemsSource = filtroDeControle_DA.ConsultarFiltrosDeControle();
            DataGridDeCategorias();
        }

        public void DataGridDeCategorias()
        {
            try
            {
                Categoria_DA categoria_DA = new();
                FiltroDeControle filtrosDeControle = new();

                if (filtrosDeControle.NomeDoFiltro == "Despesas")
                {
                    DtgDados.ItemsSource = categoria_DA.ConsultarCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
                }
                else if (filtrosDeControle.NomeDoFiltro == "Poupança")
                {
                    DtgDados.ItemsSource = categoria_DA.ConsultarCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
                }
                else
                {
                    DtgDados.ItemsSource = categoria_DA.ConsultarCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
                }
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "DataGridDeCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
        }

        private void CbxNomeDeFiltros_MouseLeave(object sender, MouseEventArgs e)
        {
            DataGridDeCategorias();
        }

        private void BtnAtualizar_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TxtId.Text = "0";
            TxtCategoria.Text = null;
            CbxNomeDeFiltros.Text = "Despesas";
            Categoria_DA categoria_DA = new();
            DtgDados.ItemsSource = categoria_DA.ConsultarCategoriasPorNomeDoFiltro("Despesas");
        }
        

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Categoria))
                    {
                        Categoria categoriaDeDespesa = (Categoria)DtgDados.SelectedItems[0];

                        TxtId.Text = categoriaDeDespesa.Id.ToString();
                        TxtCategoria.Text = categoriaDeDespesa.NomeDaCategoria;
                        CbxNomeDeFiltros.Text = categoriaDeDespesa.NomeDoFiltro;
                        TxtCategoria.Focus();
                    }
                }
            }
        }
    }
}
