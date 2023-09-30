#nullable disable
using Database.Models;
using System.Windows;

namespace ManageData.DataValidation
{
    public class SubCategoria_DV : DataValidationBase
    {
        #region |====================================| Propriedades |============================================|

        private SubCategoria _subCategoria;
        public SubCategoria SubCategoria
        {
            get { return _subCategoria; }
            set
            {
                _subCategoria = value;
                OnPropertyChanged(nameof(SubCategoria));
            }
        }
        #endregion

        #region |====================================| Construtor |==============================================|

        public SubCategoria_DV()
        {
            SubCategoria = new SubCategoria();
        }
        #endregion

        #region |====================================| Métodos |=================================================|
        public static void Mensagem()
        {
            MessageBox.Show("Atenção! Existe um campo que está vazio.\nPreencha-o(s) para continuar.",
                "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //|=================================| Validar Cadastrar |==================================================|

        public bool ValidarCadastrar(SubCategoria subCategoriaDeDespesa)
        {
            //Não colocar para validação o ComboBox de Categorias(CategoriaDeDespesaId) porque ele será sempre maior ou igual a 0.
            SubCategoria = subCategoriaDeDespesa;
            if (SubCategoria.Id == 0 && SubCategoria.NomeDaSubCategoria == null)
            {
                Mensagem();
                return false;
            }
            else if (SubCategoria.Id == 0 && SubCategoria.NomeDaSubCategoria == "")
            {
                Mensagem();
                return false;
            }
            else if (SubCategoria.Id > 0 && SubCategoria.NomeDaSubCategoria != null && SubCategoria.NomeDaSubCategoria != "")
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser maior que 0.\nOutra opção é clicar no botão Alterar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (SubCategoria.Id == 0 && SubCategoria.NomeDaSubCategoria != null)
            {
                return true;
            }
            else
            {
                Mensagem();
                return false;
            }
        }
        //|=================================| Validar Alterar e Excluir |==========================================|

        public bool ValidarAlterarExcluir(SubCategoria subCategoriaDeDespesa)
        {
            //Não colocar para validação o ComboBox de Categorias(CategoriaDeDespesaId) porque ele será sempre maior ou igual a 0.
            SubCategoria = subCategoriaDeDespesa;
            if (SubCategoria.Id > 0 && SubCategoria.NomeDaSubCategoria == null)
            {
                Mensagem();
                return false;
            }
            else if (SubCategoria.Id > 0 && SubCategoria.NomeDaSubCategoria == "")
            {
                Mensagem();
                return false;
            }
            else if (SubCategoria.Id == 0 && SubCategoria.NomeDaSubCategoria != null && SubCategoria.NomeDaSubCategoria != "")
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser maior que 0.\nOutra opção é clicar no botão Cadastrar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (SubCategoria.Id > 0 && SubCategoria.NomeDaSubCategoria != null)
            {
                return true;
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
