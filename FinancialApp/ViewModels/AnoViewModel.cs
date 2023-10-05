#nullable disable
using Domain.DataAccess;
using FinancialApp.Commands;

namespace FinancialApp.ViewModels
{
    public class AnoViewModel : AnoCommand
    {
        public Ano_DA _ano_DA;

        public AnoViewModel()
        {
            //DataGrid Dados
            _ano_DA = new Ano_DA();            
            ListaDeAnos = _ano_DA.ConsultarAnos();
        }
    }
}
