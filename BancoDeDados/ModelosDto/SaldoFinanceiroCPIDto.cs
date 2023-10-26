namespace BancoDeDados.ModelosDto
{
     
    public class SaldoFinanceiroCPIDto
    {
        //CPI = Carteira, Poupança e Investimento.        
        
        public double SaldoDaCarteira { get; set; }
      
        public double SaldoDaPoupanca { get; set; }
       
        public double SaldoDeInvestimento { get; set; }
       
        public double SaldoTotalDaPoupancaEInvestimento { get; set; }
      

        public SaldoFinanceiroCPIDto(){ }

        public SaldoFinanceiroCPIDto(SaldoFinanceiroCPIDto saldoFinanceiroCPIDto)
        {
            SaldoDaCarteira = saldoFinanceiroCPIDto.SaldoDaCarteira;
            SaldoDaPoupanca = saldoFinanceiroCPIDto.SaldoDaPoupanca;
            SaldoDeInvestimento = saldoFinanceiroCPIDto.SaldoDeInvestimento;
            SaldoTotalDaPoupancaEInvestimento = saldoFinanceiroCPIDto.SaldoTotalDaPoupancaEInvestimento;
        }
    }
}
