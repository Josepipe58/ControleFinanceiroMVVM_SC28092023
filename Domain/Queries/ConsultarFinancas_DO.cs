using Domain.Reports;

namespace Domain.Queries
{
    public class ConsultarFinancas_DO : ConsultarCentralDeDados_DO//Não mudar essa herança senão vai dar erros.
    {
        public RelatorioDePoupanca RelatorioDePoupanca_AD { get; set; }
        public ConsultarFinancas_DO()
        {
            RelatorioDePoupanca_AD = new RelatorioDePoupanca();
        }
    }
}
