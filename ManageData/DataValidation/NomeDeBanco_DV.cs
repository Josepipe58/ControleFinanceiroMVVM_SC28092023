#nullable disable
using Database.Models;
using System.Windows;

namespace ManageData.DataValidation
{
    public class NomeDeBanco_DV : DataValidationBase
    {
        #region |=================================| Propriedades |==================================================|

        private NomeDeBanco _nomeDeBanco;
        public NomeDeBanco NomeDeBanco
        {
            get { return _nomeDeBanco; }
            set
            {
                _nomeDeBanco = value;
                OnPropertyChanged(nameof(NomeDeBanco));
            }
        }
        #endregion

        #region |=================================| Construtor |====================================================|

        public NomeDeBanco_DV()
        {
            NomeDeBanco = new NomeDeBanco();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        public static void Mensagem()
        {
            MessageBox.Show("Atenção! Existe um campo que está vazio.\nPreencha-o(s) para continuar.",
                "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //|=================================| Validar Cadastrar |==================================================|

        public bool ValidarCadastrar(NomeDeBanco nomeDeBanco)
        {
            NomeDeBanco = nomeDeBanco;
            if ((NomeDeBanco.Id >= 0 || NomeDeBanco.Id <= 0) && NomeDeBanco.NomeDoBanco == null)
            {
                Mensagem();
                return false;
            }
            else if ((NomeDeBanco.Id >= 0 || NomeDeBanco.Id <= 0) && NomeDeBanco.NomeDoBanco == "")
            {
                Mensagem();
                return false;
            }
            else if ((NomeDeBanco.Id > 0 || NomeDeBanco.Id < 0) && NomeDeBanco.NomeDoBanco != null)
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser igual a 0 ou vazio.\nOutra opção é clicar no botão Alterar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if ((NomeDeBanco.Id > 0 || NomeDeBanco.Id < 0) && NomeDeBanco.NomeDoBanco != "")
            {
                Mensagem();
                return false;
            }
            else if (NomeDeBanco.Id == 0 && NomeDeBanco.NomeDoBanco != null)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        //|=================================| Validar Alterar e Excluir |==========================================|

        public bool ValidarAlterarExcluir(NomeDeBanco nomeDeBanco)
        {
            NomeDeBanco = nomeDeBanco;
            if ((NomeDeBanco.Id >= 0 || NomeDeBanco.Id <= 0) && NomeDeBanco.NomeDoBanco == null)
            {
                Mensagem();
                return false;
            }
            else if ((NomeDeBanco.Id >= 0 || NomeDeBanco.Id <= 0) && NomeDeBanco.NomeDoBanco == "")
            {
                Mensagem();
                return false;
            }
            else if (NomeDeBanco.Id <= 0 && NomeDeBanco.NomeDoBanco != null)
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser maior que 0.\nOutra opção é clicar no botão Cadastrar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (NomeDeBanco.Id <= 0 && NomeDeBanco.NomeDoBanco != "")
            {
                Mensagem();
                return false;
            }
            else if (NomeDeBanco.Id > 0 && NomeDeBanco.NomeDoBanco != null)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
