using Domain.Reports;

namespace Domain.Queries
{
    public class ConsultarFinancas : ConsultarCentralDeDados//Não mudar essa herança senão vai dar erros.
    {
        public RelatorioDePoupanca RelatorioDePoupanca_AD { get; set; }
        public ConsultarFinancas()
        {
            RelatorioDePoupanca_AD = new RelatorioDePoupanca();
        }
    }
}
