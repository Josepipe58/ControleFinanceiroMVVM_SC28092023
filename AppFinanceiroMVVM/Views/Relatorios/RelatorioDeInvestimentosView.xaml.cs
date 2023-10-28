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
    public partial class RelatorioDeInvestimentosView : UserControl
    {
        public string categoria, subcategoria, nomeDoMetodo = string.Empty;
        public RelatorioDeInvestimentos RelatorioDeInvestimentos { get; set; }

        //Construtor
        public RelatorioDeInvestimentosView()
        {
            InitializeComponent();
            RelatorioDeInvestimentos = new RelatorioDeInvestimentos();
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
            RelatoriosDeInvestimentos();
        }

        public void RelatoriosDeInvestimentos()
        {
            try
            {
                //Saldo Total da Poupança, Receitas e Investimentos.
                DtgSaldoTotalDaPoupancaReceitasEInvestimentos.ItemsSource = RelatorioDeInvestimentos
                    .ConsultarSaldoTotalDaPoupancaReceitasEInvestimentos(Convert.ToInt32(CbxAno.Text));

                //Saldo Total de Investimentos.
                DtgSaldoTotalDeInvestimentos.ItemsSource = RelatorioDeInvestimentos.ConsultarSaldoTotalDeInvestimentos(Convert.ToInt32(CbxAno.Text));

                //Juros de Investimentos.
                DtgJurosDeInvestimentos.ItemsSource = RelatorioDeInvestimentos.ConsultarJurosDeInvestimentos(Convert.ToInt32(CbxAno.Text));

                //Total de Rendimentos Entre Depósitos, Juros e Saques.
                DtgDeRendimentosEntreDepositosJurosESaques.ItemsSource = RelatorioDeInvestimentos
                    .ConsultarRendimentosEntreDepositosJurosESaques(Convert.ToInt32(CbxAno.Text));
            }
            catch (Exception erro)
            {
                nomeDoMetodo = "RelatoriosDeInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                return;
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            RelatoriosDeInvestimentos();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxAno();
        }
    }
}
