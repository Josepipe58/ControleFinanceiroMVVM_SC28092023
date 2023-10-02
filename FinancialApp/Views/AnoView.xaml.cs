#nullable disable
using Database.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinancialApp.Views
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
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Ano))
                    {
                        Ano ano = (Ano)DtgDados.SelectedItems[0];

                        TxtId.Text = ano.Id.ToString();
                        TxtAno.Text = ano.AnoDoCadastro.ToString();

                        TxtAno.Focus();
                    }
                }
            }
        }
    }
}
