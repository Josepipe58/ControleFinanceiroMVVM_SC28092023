using GerenciarDados.Relatorios;

namespace GerenciarDados.Consultas
{
    public class ConsultarFinancas : ConsultarCentralDeDados//Não mudar essa herança senão vai dar erros.
    {
        public RelatorioDePoupanca RelatorioDePoupanca { get; set; }
        public ConsultarFinancas()
        {
            RelatorioDePoupanca = new RelatorioDePoupanca();
        }
    }
}
