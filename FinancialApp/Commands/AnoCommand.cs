#nullable disable
using FinancialApp.ManageData;
using System.Windows.Input;

namespace FinancialApp.Commands
{
    public class AnoCommand : Ano_MD
    {
        #region |=================================| Comandos |==================================================|
        
        //Cadastrar
        private ICommand _comandoDeCadastrarAno;
        public ICommand ComandoDeCadastrarAno
        {
            get
            {
                _comandoDeCadastrarAno ??=
                    new RelayCommand(param => Cadastrar(Ano));
                return _comandoDeCadastrarAno;
            }
        }
        
        //Alterar
        private ICommand _comandoDeAlterarAno;
        public ICommand ComandoDeDeAlterarAno
        {
            get
            {
                _comandoDeAlterarAno ??= new RelayCommand(param =>
                    Alterar(Ano));
                return _comandoDeAlterarAno;
            }
        }
       
        //Comando Excluir
        private ICommand _comandoDeExcluirAno;
        public ICommand ComandoDeDeExcluirAno
        {
            get
            {
                _comandoDeExcluirAno ??= new RelayCommand(param =>
                    Excluir(Ano));
                return _comandoDeExcluirAno;
            }
        }

        //Limpar e atualizar dados
        private ICommand _comandoDeAtualizarAno;
        public ICommand ComandoDeDeAtualizarAno
        {
            get
            {
                _comandoDeAtualizarAno ??= new RelayCommand(param =>
                LimparEAtualizarDados());
                return _comandoDeAtualizarAno;
            }
        }
        #endregion       
    }
}
