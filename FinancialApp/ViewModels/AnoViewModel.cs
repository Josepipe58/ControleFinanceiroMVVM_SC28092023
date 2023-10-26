#nullable disable
using Domain.DataAccess;
using FinancialApp.Commands;

namespace FinancialApp.ViewModels
{
    public partial  class AnoViewModel : AnoCommand
    {
        public AnoViewModel()
        {
            //DataGrid Dados
            Ano_DA ano_DA = new();
            ListaDeAnos = ano_DA.ConsultarAnos();
        }
    }
}
