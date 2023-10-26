#nullable disable
using FinancialApp.ManageData;
using System.Windows.Input;

namespace FinancialApp.Commands
{
    public class CentralDeDadosCommand : CentralDeDados_MD
    {
        //Cadastrar 
        private ICommand _comandoDeCadastrar;
        public ICommand ComandoDeCadastrar
        {
            get
            {
                _comandoDeCadastrar ??= new RelayCommand(param =>
                Cadastrar(CentralDeDados));
                return _comandoDeCadastrar;
            }
        }
        
        //Alterar 
        private ICommand _comandoDeAlterar;
        public ICommand ComandoDeAlterar
        {
            get
            {
                _comandoDeAlterar ??= new RelayCommand(param =>
                    Alterar(CentralDeDados));
                return _comandoDeAlterar;
            }
        }
        
        //Excluir 
        private ICommand _comandoDeExcluir;
        public ICommand ComandoDeExcluir
        {
            get
            {
                _comandoDeExcluir ??= new RelayCommand(param =>
                    Excluir(CentralDeDados));
                return _comandoDeExcluir;
            }
        }
        
        //Atualizar 
        private ICommand _comandoDeAtualizar;
        public ICommand ComandoDeAtualizar
        {
            get
            {
                _comandoDeAtualizar ??= new RelayCommand(param => 
                AtualizarDados());               
                return _comandoDeAtualizar;
            }
        }
    }
}
