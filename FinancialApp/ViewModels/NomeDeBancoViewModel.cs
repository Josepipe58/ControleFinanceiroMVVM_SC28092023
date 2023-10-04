using Domain.DataAccess;
using FinancialApp.Commands;

namespace FinancialApp.ViewModels
{
    public class NomeDeBancoViewModel : NomeDeBancoCommand
    {
        public NomeDoBancoDeDados_DA _nomeDeBanco_DA;

        public NomeDeBancoViewModel()
        {
            NomeDeBanco = new();
            _nomeDeBanco_DA = new();

            ListaDeNomeDeBancos = _nomeDeBanco_DA.ConsultarNomeDeBancos();
        }
    }
}
