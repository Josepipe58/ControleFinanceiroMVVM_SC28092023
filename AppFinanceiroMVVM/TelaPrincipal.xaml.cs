#nullable disable
using BancoDeDados.ContextoDoBancoDeDados;
using System.Windows;
using System.Windows.Input;

namespace AppFinanceiroMVVM
{
    public partial class TelaPrincipal : Window
    {
        public Contexto Context { get; set; }
        public TelaPrincipal()
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
