#nullable disable
using System.Windows.Input;

namespace FinancialApp.ManageData.Commands
{
    public class ComandosDeCategoria : Categoria_MD
    {
        #region |=================================| Comandos |==================================================|

        //|=================================| Comando Cadastrar |==================================================|

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

        //|=================================| Comando Alterar |====================================================|

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

        //|=================================| Comando Excluir |====================================================|

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

        //|=================================| Comando Atualizar |==================================================|

        private ICommand _comandoDeAtualizarCategoria;
        public ICommand ComandoDeDeAtualizarCategoria
        {
            get
            {
                _comandoDeAtualizarCategoria ??= new RelayCommand(param =>
                LimparEAtualizarDados());
                return _comandoDeAtualizarCategoria;
            }
        }
        #endregion
    }
}
