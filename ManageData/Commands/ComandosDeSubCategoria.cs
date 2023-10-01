#nullable disable
using System.Windows.Input;

namespace ManageData.Commands
{
    public class ComandosDeSubCategoria : SubCategoria_MD
    {
        #region |=================================| Comandos |==================================================|

        //|=================================| Comando Cadastrar |==================================================|

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

        //|=================================| Comando Alterar |====================================================|

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

        //|=================================| Comando Excluir |====================================================|

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

        //|=================================| Comando Atualizar |==================================================|

        private ICommand _comandoDeAtualizarSubCategoria;
        public ICommand ComandoDeDeAtualizarSubCategoria
        {
            get
            {
                _comandoDeAtualizarSubCategoria ??= new RelayCommand(param =>
                LimparEAtualizarDados());
                return _comandoDeAtualizarSubCategoria;
            }
        }
        #endregion
    }
}
