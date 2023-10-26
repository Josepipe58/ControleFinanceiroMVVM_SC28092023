#nullable disable
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroMVVM.Views
{
    public partial class CategoriaView : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public CategoriaView()
        {
            InitializeComponent();
        }

        private void CbxNomeDeFiltros_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Categoria_AD categoria_AD = new();
                FiltroDeControle filtrosDeControle = new();

                if (filtrosDeControle.NomeDoFiltro == "Despesas")
                {
                    DtgDados.ItemsSource = categoria_AD.ConsultarCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
                }
                else if (filtrosDeControle.NomeDoFiltro == "Poupança")
                {
                    DtgDados.ItemsSource = categoria_AD.ConsultarCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
                }
                else
                {
                    DtgDados.ItemsSource = categoria_AD.ConsultarCategoriasPorNomeDoFiltro(CbxNomeDeFiltros.Text);
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
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(CategoriaDto))
                    {
                        CategoriaDto categoriaDto = (CategoriaDto)DtgDados.SelectedItems[0];

                        TxtId.Text = categoriaDto.Id.ToString();
                        TxtCategoria.Text = categoriaDto.NomeDaCategoria;
                        CbxNomeDeFiltros.Text = categoriaDto.NomeDoFiltro;
                        TxtCategoria.Focus();
                    }
                }
            }
        }
    }
}
