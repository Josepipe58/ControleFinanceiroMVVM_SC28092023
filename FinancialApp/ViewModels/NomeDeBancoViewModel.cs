using Domain.DataAccess;
using FinancialApp.ManageData.Commands;

namespace FinancialApp.ViewModels
{
    public class NomeDeBancoViewModel : ComandosDeNomeDeBanco
    {
        public NomeDoBancoDeDados_DA nomeDeBanco_DA;

        public NomeDeBancoViewModel()
        {
            NomeDeBanco = new();
            nomeDeBanco_DA = new();

            ListaDeNomeDeBancos = nomeDeBanco_DA.ConsultarNomeDeBancos();
        }
    }
}
