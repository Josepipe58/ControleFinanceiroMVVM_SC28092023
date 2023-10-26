using BancoDeDados.ModelosDto;

namespace AppFinanceiroMVVM.Modelos
{
     
    public class SaldoFinanceiroCPI : BaseModelos
    {
        //CPI = Carteira, Poupança e Investimento.
        
        private double _saldoDaCarteira;
        public double SaldoDaCarteira
        {
            get { return _saldoDaCarteira; }
            set
            {
                _saldoDaCarteira = value;
                OnPropertyChanged(nameof(SaldoDaCarteira));
            }
        }

        private double _saldoDaPoupanca;
        public double SaldoDaPoupanca
        {
            get { return _saldoDaPoupanca; }
            set
            {
                _saldoDaPoupanca = value;
                OnPropertyChanged(nameof(SaldoDaPoupanca));
            }
        }

        private double _saldoDeInvestimento;
        public double SaldoDeInvestimento
        {
            get { return _saldoDeInvestimento; }
            set
            {
                _saldoDeInvestimento = value;
                OnPropertyChanged(nameof(SaldoDeInvestimento));
            }
        }

        private double _saldoTotalDaPoupancaEInvestimento;
        public double SaldoTotalDaPoupancaEInvestimento
        {
            get { return _saldoTotalDaPoupancaEInvestimento; }
            set
            {
                _saldoTotalDaPoupancaEInvestimento = value;
                OnPropertyChanged(nameof(SaldoTotalDaPoupancaEInvestimento));
            }
        }

        public SaldoFinanceiroCPI(){ }

        public SaldoFinanceiroCPI(SaldoFinanceiroCPIDto saldoFinanceiroCPIDto)
        {
            SaldoDaCarteira = saldoFinanceiroCPIDto.SaldoDaCarteira;
            SaldoDaPoupanca = saldoFinanceiroCPIDto.SaldoDaPoupanca;
            SaldoDeInvestimento = saldoFinanceiroCPIDto.SaldoDeInvestimento;
            SaldoTotalDaPoupancaEInvestimento = saldoFinanceiroCPIDto.SaldoTotalDaPoupancaEInvestimento;
        }
    }
}
