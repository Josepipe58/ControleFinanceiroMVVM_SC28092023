#nullable disable
using Database.Models;
using Domain.Messages;

namespace FinancialApp.DataValidation
{
    public class CentralDeDados_DV : DataValidationBase
    {
        private CentralDeDados _centralDeDados;
        public CentralDeDados CentralDeDados
        {
            get { return _centralDeDados; }
            set
            {
                _centralDeDados = value;
                OnPropertyChanged(nameof(CentralDeDados));
            }
        }

        public CentralDeDados_DV()
        {
            CentralDeDados = new CentralDeDados();
        }

        //Cadastrar
        public bool ValidarCadastrar(CentralDeDados centralDeDados)
        {
            CentralDeDados = centralDeDados;
            if (CentralDeDados.Id == 0 && CentralDeDados.Valor > 0 && CentralDeDados.Valor != 0)
            {
                return true;
            }
            else if (CentralDeDados.Id > 0 && CentralDeDados.Valor > 0)
            {
                GerenciarMensagens.ErroAoCadastrar();
                return false;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return false;
            }
        }

        //Alterar e Excluir        
        public bool ValidarAlterarExcluir(CentralDeDados centralDeDados2)
        {
            CentralDeDados = centralDeDados2;            
            if (CentralDeDados.Id > 0 && CentralDeDados.Valor > 0 && CentralDeDados.Valor != 0)
            {
                return true;
            }
            else if (CentralDeDados.Id == 0 && CentralDeDados.Valor > 0)
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                return false;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return false;
            }
        }
    }
}
