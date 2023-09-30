#nullable disable
using Database.Models;
using System.Windows;

namespace ManageData.DataValidation
{
    public class Categoria_DV : DataValidationBase
    {
        #region |=================================| Propriedades |==================================================|

        private Categoria _categoria;
        public Categoria Categoria
        {
            get { return _categoria; }
            set
            {
                _categoria = value;
                OnPropertyChanged(nameof(Categoria));
            }
        }
        #endregion

        #region |=================================| Construtor |====================================================|

        public Categoria_DV()
        {
            Categoria = new Categoria();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        public static void Mensagem()
        {
            MessageBox.Show("Atenção! Existe um campo que está vazio.\nPreencha-o(s) para continuar.",
                "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //|=================================| Validar Cadastrar |==================================================|

        public bool ValidarCadastrar(Categoria categoriaDeDespesa)
        {
            Categoria = categoriaDeDespesa;
            if ((Categoria.Id >= 0 || Categoria.Id <= 0) && Categoria.NomeDaCategoria == null)
            {
                Mensagem();
                return false;
            }
            else if ((Categoria.Id >= 0 || Categoria.Id <= 0) && Categoria.NomeDaCategoria == "")
            {
                Mensagem();
                return false;
            }
            else if ((Categoria.Id > 0 || Categoria.Id < 0) && Categoria.NomeDaCategoria != null)
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser igual a 0 ou vazio.\nOutra opção é clicar no botão Alterar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if ((Categoria.Id > 0 || Categoria.Id < 0) && Categoria.NomeDaCategoria != "")
            {
                Mensagem();
                return false;
            }
            else if (Categoria.Id == 0 && Categoria.NomeDaCategoria != null)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        //|=================================| Validar Alterar e Excluir |==========================================|

        public bool ValidarAlterarExcluir(Categoria categoriaDeDespesa)
        {
            Categoria = categoriaDeDespesa;
            if ((Categoria.Id >= 0 || Categoria.Id <= 0) && Categoria.NomeDaCategoria == null)
            {
                Mensagem();
                return false;
            }
            else if ((Categoria.Id >= 0 || Categoria.Id <= 0) && Categoria.NomeDaCategoria == "")
            {
                Mensagem();
                return false;
            }
            else if (Categoria.Id <= 0 && Categoria.NomeDaCategoria != null)
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser maior que 0.\nOutra opção é clicar no botão Cadastrar." +
                    "\nCorrija esses erros, para continuar.", "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else if (Categoria.Id <= 0 && Categoria.NomeDaCategoria != "")
            {
                Mensagem();
                return false;
            }
            else if (Categoria.Id > 0 && Categoria.NomeDaCategoria != null)
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
