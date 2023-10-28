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
    public partial class RelatorioDePoupancaView : UserControl
    {
        public string categoria, subcategoria, nomeDoMetodo = string.Empty;
        public RelatorioDePoupanca RelatorioDePoupanca { get; set; }

        //Construtor
        public RelatorioDePoupancaView()
        {
            InitializeComponent();
            RelatorioDePoupanca = new RelatorioDePoupanca();
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
            RelatoriosDaPoupanca();
        }

        public void RelatoriosDaPoupanca()
        {
            try
            {
                //Saldo Total da Poupança, Receitas e Investimentos.                
                DtgSaldoTotalDaPoupancaReceitasEInvestimentos.ItemsSource = RelatorioDePoupanca
                    .ConsultarSaldoTotalDaPoupancaReceitasEInvestimentos(Convert.ToInt32(CbxAno.Text));

                //Saldo Total da Poupança.
                DtgSaldoTotalDaPoupanca.ItemsSource = RelatorioDePoupanca.ConsultarSaldoTotalDaPoupanca(Convert.ToInt32(CbxAno.Text));

                //Juros da Poupança
                DtgJurosDaPoupanca.ItemsSource = RelatorioDePoupanca.ConsultarJurosDaPoupanca(Convert.ToInt32(CbxAno.Text));

                //Rendimentos entre Depósitos, Juros e Saques.
                DtgRendimentosDepositoJurosSaques.ItemsSource = RelatorioDePoupanca
                    .ConsultarRendimentosEntreDepositosJurosESaques(Convert.ToInt32(CbxAno.Text));

                //Pagamentos e Tranferências.
                DtgPagamentosETransferencia.ItemsSource = RelatorioDePoupanca
                    .ConsultarPagamentosETranferencias(Convert.ToInt32(CbxAno.Text));
            }
            catch (Exception erro)
            {
                nomeDoMetodo = "RelatoriosDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                return;
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            RelatoriosDaPoupanca();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxAno();
        }
    }
}
