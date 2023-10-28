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
    public partial class RelatorioDeReceitasView : UserControl
    {
        public string categoria, subcategoria, nomeDoMetodo = string.Empty;
        public RelatorioDeReceitas RelatorioDeReceitas { get; set; }

        //Construtor
        public RelatorioDeReceitasView()
        {
            InitializeComponent();
            RelatorioDeReceitas = new RelatorioDeReceitas();
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
            RelatoriosDeReceitas();
        }

        public void RelatoriosDeReceitas()
        {
            try
            {
                //Benefícios do INSS.
                DtgBeneficiosDoINSS.ItemsSource = RelatorioDeReceitas
                    .ConsultarBenefíciosDoINSS(Convert.ToInt32(CbxAno.Text));

                //Benefícios do INSS, Juros da Poupança e Investimrntos.
                DtgBeneficiosJurosEInvestimentos.ItemsSource = RelatorioDeReceitas
                    .ConsultarReceitasMensalEAnual(Convert.ToInt32(CbxAno.Text));

                //Descontos no Benefício.
                DtgDescontosNoBeneficio.ItemsSource = RelatorioDeReceitas
                    .ConsultarDescontosNoBeneficioDoINSS(Convert.ToInt32(CbxAno.Text));

                //Fluxo de Caixa - Receitas Menos Despesas.
                DtgFluxoDeCaixa.ItemsSource = RelatorioDeReceitas
                    .ConsultarFluxoDeCaixaReceitasMenosDespesas(Convert.ToInt32(CbxAno.Text));

                //Saldo da Carteira.
                DtgSaldoCarteira.ItemsSource = RelatorioDeReceitas
                    .ConsultarSaldoDaCarteiraDeTodosOsMeses(Convert.ToInt32(CbxAno.Text));
            }
            catch (Exception erro)
            {
                nomeDoMetodo = "RelatoriosDeReceitas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                return;
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            RelatoriosDeReceitas();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxAno();
        }
    }
}
