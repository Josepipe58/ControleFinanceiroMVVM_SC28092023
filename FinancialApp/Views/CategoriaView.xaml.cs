#nullable disable
using Database.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinancialApp.Views
{
    public partial class CategoriaView : UserControl
    {
        public CategoriaView()
        {
            InitializeComponent();            
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Categoria))
                    {
                        Categoria categoriaDeDespesa = (Categoria)DtgDados.SelectedItems[0];

                        TxtId.Text = categoriaDeDespesa.Id.ToString();
                        TxtCategoria.Text = categoriaDeDespesa.NomeDaCategoria;
                        CbxNomeDeFiltros.Text = categoriaDeDespesa.NomeDoFiltro;
                        TxtCategoria.Focus();
                    }
                }
            }
        }
    }
}
