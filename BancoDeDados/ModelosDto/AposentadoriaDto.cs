using System;
using System.Collections.ObjectModel;

namespace BancoDeDados.ModelosDto
{
    public class AposentadoriaDto
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int AnoDoIndice { get; set; }

        public int AnoDoReajuste { get; set; }

        public decimal IndiceDoAumento { get; set; }

        public decimal ValorDoAumento { get; set; }

        public decimal AtualizarValor { get; set; }

        public decimal SaldoAtual { get; set; }

        public AposentadoriaDto(){ }

        public AposentadoriaDto(AposentadoriaDto aposentadoriaDto)
        {
            Id = aposentadoriaDto.Id;
            Data = aposentadoriaDto.Data;
            AnoDoIndice = aposentadoriaDto.AnoDoIndice;
            AnoDoReajuste = aposentadoriaDto.AnoDoReajuste;
            IndiceDoAumento = aposentadoriaDto.IndiceDoAumento;
            ValorDoAumento = aposentadoriaDto.ValorDoAumento;
            AtualizarValor = aposentadoriaDto.AtualizarValor;
            SaldoAtual = aposentadoriaDto.SaldoAtual;
        }
    }

    public class ListaDeAposentadoria : ObservableCollection<AposentadoriaDto> { }
}
