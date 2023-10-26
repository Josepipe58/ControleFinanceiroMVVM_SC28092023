#nullable disable
using BancoDeDados.ModelosDto;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroMVVM.Views.NomeDeBancosVW
{
    public partial class NomeDeBancoView : UserControl
    {
        public NomeDeBancoView()
        {
            InitializeComponent();
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(NomeDeBancoDto))
                    {
                        NomeDeBancoDto nomeDeBancoDto = (NomeDeBancoDto)DtgDados.SelectedItems[0];

                        TxtId.Text = nomeDeBancoDto.Id.ToString();
                        TxtNomeDeBanco.Text = nomeDeBancoDto.NomeDoBanco.ToString();
                        TxtNomeDeBanco.Focus();
                    }
                }
            }
        }
    }
}
