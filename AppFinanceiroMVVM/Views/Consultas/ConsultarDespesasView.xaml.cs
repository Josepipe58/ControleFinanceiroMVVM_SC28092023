#nullable disable
using GerenciarDados.AcessarDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using GerenciarDados.Consultas;
using System.Linq;

namespace AppFinanceiroMVVM.Views.Consultas
{
    public partial class ConsultarDespesasView : UserControl
    {
        public string categoria, subcategoria, nomeDoMetodo = string.Empty;
        public ConsultarDespesas ConsultarDespesas { get; set; }

        //Construtor
        public ConsultarDespesasView()
        {
            InitializeComponent();
            ConsultarDespesas = new ConsultarDespesas();
            CarregarComboBoxesDeConsultarDespesas();
        }

        private void CarregarComboBoxesDeConsultarDespesas()
        {
            try
            {
                //ComboBox de Nome de Filtros.
                FiltroDeControle_AD filtroDeControle_AD = new();
                CbxNomeDeFiltros.ItemsSource = filtroDeControle_AD.ConsultarFiltrosDeControle()
                    .Where(d => d.NomeDoFiltro == "Despesas");
                CbxNomeDeFiltros.DisplayMemberPath = "NomeDoFiltro";
                CbxNomeDeFiltros.SelectedValuePath = "Id";
                CbxNomeDeFiltros.SelectedIndex = -1;

                //Carregar ComboBox Ano.                
                Ano_AD ano_AD = new();
                CbxAno.ItemsSource = ano_AD.ConsultarAnos();
                CbxAno.DisplayMemberPath = "AnoDoCadastro";
                CbxAno.SelectedValuePath = "Id";
                CbxAno.SelectedIndex = -1;

                //Carregar ComboBox Mês
                CbxMes.ItemsSource = ListaGenericaDeMeses.CarregarComboBoxDeMeses();
                CbxMes.SelectedIndex = -1;

            }
            catch (Exception erro)
            {
                nomeDoMetodo = "CarregarComboBoxesDeConsultarDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                return;
            }
            ConsultasDeDespesas();
        }

        private void CbxNomeDeFiltros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox das Categorias.
            //Não colocar nenhum tratamento de erros nesse Método porque eles não serão executados
            //e também porque não há necessidade de tratamento de erros.

            Categoria_AD categoria_AD = new();
            CbxCategoria.ItemsSource = categoria_AD
                .ConsultarCategoriasPorId(Convert.ToInt32(CbxNomeDeFiltros.SelectedValue));
            CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
            CbxCategoria.SelectedValuePath = "Id";
            CbxCategoria.SelectedIndex = -1;

        }

        private void CbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Carregar ComboBox das SubCategorias.
            //Não colocar nenhum tratamento de erros nesse Método porque eles não serão executados
            //e também porque não há necessidade de tratamento de erros.
            SubCategoria_AD subCategoria_AD = new();
            CbxSubCategoria.ItemsSource = subCategoria_AD
                .ConsultarSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = -1;
        }

        public void ConsultasDeDespesas()
        {
            try
            {
                if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                        .Where(cd => cd.Filtros == "Despesas");

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarDespesasGeraisDeTodosOsAnos();
                    LblTitulo.Content = "Consulta geral de Despesas, de todos os anos cadastrados, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorNomeDaCategoria(CbxCategoria.Text);
                    categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {categoria}, consulta de todos os anos cadastrados, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text == "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                             .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.NomeDaSubCategoria == CbxSubCategoria.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorNomeDaCategoriaENomeDaSubCategoria(CbxCategoria.Text, CbxSubCategoria.Text);
                    categoria = CbxCategoria.Text;
                    subcategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {categoria} - {subcategoria}, consulta de todos os anos cadastrados, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.NomeDaSubCategoria == CbxSubCategoria.Text && dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorNomeDaCategoriaNomeDaSubCategoriaEMes(CbxCategoria.Text, CbxSubCategoria.Text, CbxMes.Text);
                    categoria = CbxCategoria.Text;
                    subcategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {categoria} - {subcategoria}, consulta de acordo com o mês selecionado, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text == "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.NomeDaSubCategoria == CbxSubCategoria.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorNomeDaCategoriaNomeDaSubCategoriaEAno(CbxCategoria.Text, CbxSubCategoria.Text,
                        Convert.ToInt32(CbxAno.Text));
                    categoria = CbxCategoria.Text;
                    subcategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {categoria} - {subcategoria}, consulta de acordo com o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorNomeDaCategoriaEAno(CbxCategoria.Text, Convert.ToInt32(CbxAno.Text));
                    categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {categoria}, consulta de acordo com o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text != "" && CbxMes.Text != "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.NomeDaSubCategoria == CbxSubCategoria.Text &&
                            dp.Mes == CbxMes.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorNomeDaCategoriaNomeDaSubCategoriaMesEAno(CbxCategoria.Text, CbxSubCategoria.Text,
                        CbxMes.Text, Convert.ToInt32(CbxAno.Text));
                    categoria = CbxCategoria.Text;
                    subcategoria = CbxSubCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {categoria} - {subcategoria}, consulta de acordo com o mês e o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.Mes == CbxMes.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorNomeDaCategoriaMesEAno(CbxCategoria.Text, CbxMes.Text, Convert.ToInt32(CbxAno.Text));
                    categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {categoria}, consulta de acordo com o mês e o ano selecionado.";
                }
                else if (CbxCategoria.Text != "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.NomeDaCategoria == CbxCategoria.Text && dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorNomeDaCategoriaEMes(CbxCategoria.Text, CbxMes.Text);
                    categoria = CbxCategoria.Text;
                    LblTitulo.Content = $"Tipo de Consulta: {categoria}, consulta de acordo com o mês selecionado, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.Mes == CbxMes.Text && dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorMesEAno(CbxMes.Text, Convert.ToInt32(CbxAno.Text));
                    LblTitulo.Content = "Consulta geral de Despesas, de acordo com o mês e o ano selecionado.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text != "" && CbxAno.Text == "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.Mes == CbxMes.Text);

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorMes(CbxMes.Text);
                    LblTitulo.Content = "Consulta geral de Despesas, de acordo com o mês selecionado, desde o ano de 2020.";
                }
                else if (CbxCategoria.Text == "" && CbxSubCategoria.Text == "" && CbxMes.Text == "" && CbxAno.Text != "")
                {
                    DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                            .Where(dp => dp.Ano == Convert.ToInt32(CbxAno.Text));

                    DtgValores.ItemsSource = ConsultarDespesas.ConsultarPorAno(Convert.ToInt32(CbxAno.Text));
                    LblTitulo.Content = "Consulta geral de Despesas, de acordo com o ano selecionado.";
                }
                else
                {
                    MessageBox.Show("Não foi possível fazer nenhum tipo de consulta de Despesas.", "Mensagem de Erro!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception erro)
            {
                nomeDoMetodo = "ConsultasDeDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                return;
            }
        }

        private void TxtPesquisar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var listafiltrada = ConsultarDespesas.ConsultarListaDaCentralDeDados()
                    .Where(sc => sc.NomeDaSubCategoria.ToLower().Contains(textBox.Text.ToLower()));
                DtgDados.ItemsSource = listafiltrada;
            }
            else
            {
                DtgDados.ItemsSource = ConsultarDespesas.ConsultarListaDaCentralDeDados();
            }
        }

        private void CbxNomeDeFiltros_DropDownClosed(object sender, EventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void CbxCategoria_MouseLeave(object sender, EventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void CbxSubCategoria_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void CbxMes_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            ConsultasDeDespesas();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            LimparEAtualizarDados();
        }

        private void LimparEAtualizarDados()
        {
            CbxNomeDeFiltros.Text = "";
            CbxCategoria.Text = "";
            CbxSubCategoria.Text = "";
            CbxMes.Text = "";
            CbxAno.Text = "";
            TxtPesquisar.Text = "";
            ConsultasDeDespesas();
        }
    }
}
