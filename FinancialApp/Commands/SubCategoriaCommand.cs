#nullable disable
using System.Windows.Input;
using FinancialApp.ManageData;

namespace FinancialApp.Commands
{
    public class SubCategoriaCommand : SubCategoria_MD
    {
        #region |===========================| Comandos de SubCategoria |========================================|
        
        //Cadastrar 
        private ICommand _comandoDeCadastrarSubCategoria;
        public ICommand ComandoDeCadastrarSubCategoria
        {
            get
            {
                _comandoDeCadastrarSubCategoria ??=
                    new RelayCommand(param => Cadastrar(SubCategoria));
                return _comandoDeCadastrarSubCategoria;
            }
        }
        
        //Alterar 
        private ICommand _comandoDeAlterarSubCategoria;
        public ICommand ComandoDeDeAlterarSubCategoria
        {
            get
            {
                _comandoDeAlterarSubCategoria ??= new RelayCommand(param =>
                    Alterar(SubCategoria));
                return _comandoDeAlterarSubCategoria;
            }
        }
        
        //Excluir 
        private ICommand _comandoDeExcluirSubCategoria;
        public ICommand ComandoDeDeExcluirSubCategoria
        {
            get
            {
                _comandoDeExcluirSubCategoria ??= new RelayCommand(param =>
                    Excluir(SubCategoria));
                return _comandoDeExcluirSubCategoria;
            }
        }
        
        //Atualizar
        private ICommand _comandoDeAtualizarSubCategoria;
        public ICommand ComandoDeDeAtualizarSubCategoria
        {
            get
            {
                _comandoDeAtualizarSubCategoria ??= new RelayCommand(param => 
                AtualizarDados());
                return _comandoDeAtualizarSubCategoria;
            }
        }
        #endregion
    }
}
