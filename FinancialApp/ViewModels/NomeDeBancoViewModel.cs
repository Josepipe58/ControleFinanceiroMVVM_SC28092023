using Domain.DataAccess;
using ManageData.Commands;

namespace FinancialApp.ViewModels
{
    public class NomeDeBancoViewModel : ComandosDeNomeDeBanco
    {
        public NomeDeBanco_DA nomeDeBanco_DA;

        public NomeDeBancoViewModel()
        {
            NomeDeBanco = new();
            nomeDeBanco_DA = new();

            ListaDeNomeDeBancos = nomeDeBanco_DA.ConsultarNomeDeBancos();
        }
    }
}
