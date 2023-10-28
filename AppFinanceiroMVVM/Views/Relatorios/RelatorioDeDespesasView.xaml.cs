#nullable disable
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using GerenciarDados.Relatorios;

namespace AppFinanceiroMVVM.Views.Relatorios
{
    public partial class RelatorioDeDespesasView : UserControl
    {
        public string categoria, subcategoria, nomeDoMetodo = string.Empty;
        public RelatorioDeDespesas RelatorioDeDespesas { get; set; }

        //Construtor
        public RelatorioDeDespesasView()
        {
            InitializeComponent();
            RelatorioDeDespesas = new RelatorioDeDespesas();
            CarregarComboBoxAno();
        }

        public void CarregarComboBoxAno()
        {
            try
            {
                //Carregar ComboBox Ano.
                Ano_AD ano_AD = new();
                CbxAno.ItemsSource = ano_AD.ConsultarAnos();
                CbxAno.DisplayMemberPath = "AnoDoCadastro";
                CbxAno.SelectedValuePath = "Id";
                CbxAno.SelectedIndex = 0;
            }
            catch (Exception erro)
            {
                nomeDoMetodo = "CarregarComboBoxAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                return;
            }
            RelatoriosDeDespesas();
        }

        public void RelatoriosDeDespesas()
        {
            try
            {
                //Carregar DataGrid das Despesas Gerais.
                DtgDespGeral.ItemsSource = RelatorioDeDespesas.ConsultarDespesasTotais(Convert.ToInt32(CbxAno.Text));

                //Carregar DataGrid das Despesas Normais.
                DtgDespNormal.ItemsSource = RelatorioDeDespesas.ConsultarDespesasNormais(Convert.ToInt32(CbxAno.Text));

                //Carregar DataGrid das Despesas Extras.
                DtgDespExtra.ItemsSource = RelatorioDeDespesas.ConsultarDespesasExtras(Convert.ToInt32(CbxAno.Text));

                //Carregar DataGrid das Despesas da Neusa.
                DtgDespNeusa.ItemsSource = RelatorioDeDespesas.ConsultarDespesasComANeusa(Convert.ToInt32(CbxAno.Text));

                //Carregar DataGrid das Despesas de Caridade.
                DtgDespCaridade.ItemsSource = RelatorioDeDespesas.ConsultarDespesasComCaridades(Convert.ToInt32(CbxAno.Text));
            }
            catch (Exception erro)
            {
                nomeDoMetodo = "RelatoriosDeDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                return;
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            RelatoriosDeDespesas();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxAno();
        }
    }
}
