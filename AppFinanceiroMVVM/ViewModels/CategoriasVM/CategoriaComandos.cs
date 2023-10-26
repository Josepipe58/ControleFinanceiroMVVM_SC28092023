#nullable disable
using AppFinanceiroMVVM.Commandos;
using System.Windows.Input;

namespace AppFinanceiroMVVM.ViewModels.CategoriasVM
{
    public partial class CategoriaViewModel//Comandos
    {
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

        //Atualizar
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
    }
}
