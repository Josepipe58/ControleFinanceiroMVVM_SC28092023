using Database.DatabaseContext;
using System.Windows;
using System.Windows.Input;

namespace FinancialApp
{
    public partial class MainWindow : Window
    {
        public Context Context { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Context = new Context(CbxBanco.Text);            
        }

        private void CbxBanco_MouseLeave(object sender, MouseEventArgs e)
        {
            Context = new Context(CbxBanco.Text);
        }
    }
}
