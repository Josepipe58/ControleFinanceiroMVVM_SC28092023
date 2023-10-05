#nullable disable
using FinancialApp.ManageData;
using System.Windows.Input;

namespace FinancialApp.Commands
{
    public class CategoriaCommand : Categoria_MD
    {        
        #region |=================================| Comandos |==================================================|
        
        //|Cadastrar 
        private ICommand _comandoDeCadastrarCategoria;
        public ICommand ComandoDeCadastrarCategoria
        {
            get
            {
                _comandoDeCadastrarCategoria ??=
                    new RelayCommand(param => Cadastrar(Categoria));
                return _comandoDeCadastrarCategoria;
            }
        }
       
        //Alterar 
        private ICommand _comandoDeAlterarCategoria;
        public ICommand ComandoDeDeAlterarCategoria
        {
            get
            {
                _comandoDeAlterarCategoria ??= new RelayCommand(param =>
                    Alterar(Categoria));
                return _comandoDeAlterarCategoria;
            }
        }
        
        //Excluir 
        private ICommand _comandoDeExcluirCategoria;
        public ICommand ComandoDeDeExcluirCategoria
        {
            get
            {
                _comandoDeExcluirCategoria ??= new RelayCommand(param =>
                    Excluir(Categoria));
                return _comandoDeExcluirCategoria;
            }
        }
        
        //Comando Atualizar 
        private ICommand _comandoDeAtualizarCategoria;
        public ICommand ComandoDeDeAtualizarCategoria
        {
            get
            {
                _comandoDeAtualizarCategoria ??= new RelayCommand(param =>
                AtualizarDados());
                return _comandoDeAtualizarCategoria;
            }
        }
        #endregion
    }
}
