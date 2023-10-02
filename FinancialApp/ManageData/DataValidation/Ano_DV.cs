#nullable disable
using Database.Models;
using System.Windows;

namespace FinancialApp.ManageData.DataValidation
{
    public class Ano_DV : DataValidationBase
    {
        #region |=================================| Propriedades |==================================================|

        private Ano _ano;
        public Ano Ano
        {
            get { return _ano; }
            set
            {
                _ano = value;
                OnPropertyChanged(nameof(Ano));
            }
        }
        #endregion

        #region |=================================| Construtor |====================================================|

        public Ano_DV()
        {
            Ano = new Ano();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        public static void Mensagem()
        {
            MessageBox.Show("Atenção! Existe um campo que está vazio.\nPreencha-o(s) para continuar.",
                "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //|=================================| Validar Cadastrar |==================================================|

        public bool ValidarCadastrar(Ano ano)
        {
            Ano = ano;
            if (Ano.Id == 0 && Ano.AnoDoCadastro > 0)
            {
                return true;
            }
            else if (Ano.Id > 0 && Ano.AnoDoCadastro > 0)
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser igual a 0 ou vazio.\nOutra opção é clicar no botão Alterar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                Mensagem();
                return false;
            }
        }

        //|=================================| Validar Alterar e Excluir |==========================================|

        public bool ValidarAlterarExcluir(Ano ano)
        {
            Ano = ano;
            if (Ano.Id > 0 && Ano.AnoDoCadastro > 0)
            {
                return true;
            }
            else if (Ano.Id == 0 && Ano.AnoDoCadastro > 0)
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser maior do que 0.\nOutra opção é clicar no botão Cadastrar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                Mensagem();
                return false;
            }
        }
        #endregion
    }
}
