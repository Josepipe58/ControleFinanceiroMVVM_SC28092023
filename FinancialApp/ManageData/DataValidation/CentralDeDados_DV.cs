#nullable disable
using Database.Models;
using System.Windows;

namespace FinancialApp.ManageData.DataValidation
{
    public class CentralDeDados_DV : DataValidationBase
    {
        #region |=================================| Propriedades |==================================================|

        private CentralDeDados _centralDeDados;
        public CentralDeDados CentralDeDados
        {
            get { return _centralDeDados; }
            set
            {
                _centralDeDados = value;
                OnPropertyChanged(nameof(CentralDeDados));
            }
        }
        #endregion

        #region |=================================| Construtor |====================================================|

        public CentralDeDados_DV()
        {
            CentralDeDados = new CentralDeDados();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        public static void Mensagem()
        {
            MessageBox.Show("Atenção! Existe um campo que está vazio.\nPreencha-o(s) para continuar.",
                "Atenção!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //|=================================| Validar Cadastrar |==================================================|

        public bool ValidarCadastrar(CentralDeDados despesa)
        {
            CentralDeDados = despesa;
            if (CentralDeDados.Id <= 0 && CentralDeDados.NomeDaCategoria != null && CentralDeDados.NomeDaSubCategoria != null && CentralDeDados.Valor > 0
                && CentralDeDados.Tipo != null && !CentralDeDados.Data.Equals(true) && CentralDeDados.Mes != null && CentralDeDados.Ano > 0)
            {
                return true;
            }
            else if (CentralDeDados.Id > 0 && CentralDeDados.NomeDaCategoria != null && CentralDeDados.NomeDaSubCategoria != null && CentralDeDados.Valor > 0
                && CentralDeDados.Tipo != null && !CentralDeDados.Data.Equals(true) && CentralDeDados.Mes != null && CentralDeDados.Ano > 0)
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

        public bool ValidarAlterarExcluir(CentralDeDados despesa)
        {
            CentralDeDados = despesa;
            if (CentralDeDados.Id > 0 && CentralDeDados.NomeDaCategoria != null && CentralDeDados.NomeDaSubCategoria != null && CentralDeDados.Valor > 0
                && CentralDeDados.Tipo != null && !CentralDeDados.Data.Equals(true) && CentralDeDados.Mes != null && CentralDeDados.Ano > 0)
            {

                return true;
            }
            else if (CentralDeDados.Id <= 0 && CentralDeDados.NomeDaCategoria != null && CentralDeDados.NomeDaSubCategoria != null && CentralDeDados.Valor > 0
                && CentralDeDados.Tipo != null && !CentralDeDados.Data.Equals(true) && CentralDeDados.Mes != null && CentralDeDados.Ano > 0)
            {
                MessageBox.Show("Atenção!\nO campo Id tem que ser maior que 0.\nOutra opção é clicar no botão Cadastrar." +
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
