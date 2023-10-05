#nullable disable
using FinancialApp.ManageData;
using System.Windows.Input;

namespace FinancialApp.Commands
{
    public class CentralDeDadosCommand : CentralDeDados_MD
    {
        #region |=================================| Comandos |==================================================|
        
        //Cadastrar 
        private ICommand _comandoDeCadastrarDespesa;
        public ICommand ComandoDeCadastrarDespesa
        {
            get
            {
                _comandoDeCadastrarDespesa ??= new RelayCommand(param =>
                Cadastrar(CentralDeDados));
                return _comandoDeCadastrarDespesa;
            }
        }
        
        //Alterar 
        private ICommand _comandoDeAlterarDespesa;
        public ICommand ComandoDeDeAlterarDespesa
        {
            get
            {
                _comandoDeAlterarDespesa ??= new RelayCommand(param =>
                    Alterar(CentralDeDados));
                return _comandoDeAlterarDespesa;
            }
        }
        
        //Excluir 
        private ICommand _comandoDeExcluirDespesa;
        public ICommand ComandoDeDeExcluirDespesa
        {
            get
            {
                _comandoDeExcluirDespesa ??= new RelayCommand(param =>
                    Excluir(CentralDeDados));
                return _comandoDeExcluirDespesa;
            }
        }
        
        //Atualizar 
        private ICommand _comandoDeAtualizarDespesa;
        public ICommand ComandoDeDeAtualizarDespesa
        {
            get
            {
                _comandoDeAtualizarDespesa ??= new RelayCommand(param =>
                AtualizarDados());
                return _comandoDeAtualizarDespesa;
            }
        }
        #endregion 
    }
}
