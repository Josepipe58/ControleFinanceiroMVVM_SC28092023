using Database.Models;
using Domain.DataAccess;
using ManageData.Commands;

namespace FinancialApp.ViewModels
{
    public class AnoViewModel : ComandosDeAno
    {
        public AnoViewModel()
        {
            Ano = new Ano();

            Ano_DA ano_DA = new();
            ListaDeAnos = ano_DA.ConsultarAnos();
        }
    }
}
