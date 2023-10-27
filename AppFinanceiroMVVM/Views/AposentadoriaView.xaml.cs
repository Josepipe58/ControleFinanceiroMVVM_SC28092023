#nullable disable
using BancoDeDados.ModelosDto;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroMVVM.Views
{
    public partial class AposentadoriaView : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public AposentadoriaView()
        {
            InitializeComponent();
            DtpData.Text = Convert.ToString(DateTime.Today);
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(AposentadoriaDto))
                    {
                        AposentadoriaDto aposentadoriaDto = (AposentadoriaDto)DtgDados.SelectedItems[0];
                        TxtId.Text = aposentadoriaDto.Id.ToString();                       
                        DtpData.Text = aposentadoriaDto.Data.Date.ToString("g");
                        CbxAnoDoIndice.Text = aposentadoriaDto.AnoDoIndice.ToString();
                        CbxAnoDoReajuste.Text = aposentadoriaDto.AnoDoReajuste.ToString();
                        TxtIndiceDoAumento.Text = aposentadoriaDto.IndiceDoAumento.ToString();
                        TxtValorDoAumento.Text = aposentadoriaDto.ValorDoAumento.ToString();
                        TxtAtualizarValor.Text = aposentadoriaDto.AtualizarValor.ToString();
                        TxtSaldoAtual.Text = aposentadoriaDto.SaldoAtual.ToString();
                        TxtIndiceDoAumento.Focus();
                    }
                }
            }
        }
    }
}
