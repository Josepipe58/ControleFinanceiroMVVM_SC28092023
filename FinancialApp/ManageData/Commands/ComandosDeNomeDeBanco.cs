#nullable disable
using System.Windows.Input;

namespace FinancialApp.ManageData.Commands
{
    public class ComandosDeNomeDeBanco : NomeDoBancoDeDados_MD
    {
        #region |=================================| Comandos |==================================================|
        //|=================================| Comando Cadastrar |==================================================|

        private ICommand _comandoDeCadastrarNomeDeBanco;
        public ICommand ComandoDeCadastrarNomeDeBanco
        {
            get
            {
                _comandoDeCadastrarNomeDeBanco ??=
                    new RelayCommand(param => Cadastrar(NomeDeBanco));
                return _comandoDeCadastrarNomeDeBanco;
            }
        }

        //|=================================| Comando Alterar |====================================================|

        private ICommand _comandoDeAlterarNomeDeBanco;
        public ICommand ComandoDeDeAlterarNomeDeBanco
        {
            get
            {
                _comandoDeAlterarNomeDeBanco ??= new RelayCommand(param =>
                    Alterar(NomeDeBanco));
                return _comandoDeAlterarNomeDeBanco;
            }
        }

        //|=================================| Comando Excluir |====================================================|

        private ICommand _comandoDeExcluirNomeDeBanco;
        public ICommand ComandoDeDeExcluirNomeDeBanco
        {
            get
            {
                _comandoDeExcluirNomeDeBanco ??= new RelayCommand(param =>
                    Excluir(NomeDeBanco));
                return _comandoDeExcluirNomeDeBanco;
            }
        }

        //|=================================| Comando Atualizar |==================================================|

        private ICommand _comandoDeAtualizarNomeDeBanco;
        public ICommand ComandoDeDeAtualizarNomeDeBanco
        {
            get
            {
                _comandoDeAtualizarNomeDeBanco ??= new RelayCommand(param =>
                LimparEAtualizarDados());
                return _comandoDeAtualizarNomeDeBanco;
            }
        }
        #endregion
    }
}
