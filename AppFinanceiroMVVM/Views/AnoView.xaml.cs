#nullable disable
using BancoDeDados.ModelosDto;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroMVVM.Views
{
    public partial class AnoView : UserControl
    {
        public AnoView()
        {
            InitializeComponent();
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(AnoDto))
                    {
                        AnoDto ano = (AnoDto)DtgDados.SelectedItems[0];

                        TxtId.Text = ano.Id.ToString();
                        TxtAno.Text = ano.AnoDoCadastro.ToString();

                        TxtAno.Focus();
                    }
                }
            }
        }
    }
}
