#nullable disable
using BancoDeDados;
using BancoDeDados.ContextoDoBancoDeDados;
using System.Windows;
using System.Windows.Input;

namespace AppFinanceiroMVVM
{
    public partial class MainWindow : Window
    {
        public Contexto Context { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //Context = new Context(CbxBanco.Text);            
        }

        private void CbxBanco_MouseLeave(object sender, MouseEventArgs e)
        {
            //Context = new Context(CbxBanco.Text);
        }
    }
}
