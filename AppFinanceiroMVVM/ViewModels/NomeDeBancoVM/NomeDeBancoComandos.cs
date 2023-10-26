#nullable disable
using AppFinanceiroMVVM.Commandos;
using System.Windows.Input;

namespace AppFinanceiroMVVM.ViewModels.NomeDeBancoVM
{
    public partial class NomeDeBancoViewModel//Comandos
    {
        //|Cadastrar 
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

        //Alterar 
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

        //Excluir 
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

        //Atualizar
        private ICommand _comandoDeLimparEAtualizarNomeDeBanco;
        public ICommand ComandoDeLimparEAtualizarNomeDeBanco
        {
            get
            {
                _comandoDeLimparEAtualizarNomeDeBanco ??= new RelayCommand(param =>
                LimparEAtualizarDados());
                return _comandoDeLimparEAtualizarNomeDeBanco;
            }
        }
    }
}
