using System;
using System.Collections.Generic;

namespace Database.Models
{
    public class Aposentadoria
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int AnoDoIndice { get; set; }

        public int AnoDoReajuste { get; set; }

        public decimal IndiceDoAumento { get; set; }

        public decimal ValorDoAumento { get; set; }

        public decimal AtualizarValor { get; set; }

        public decimal SaldoAtual { get; set; }
    }

    public class ListaDeAposentadoria : List<Aposentadoria> { }
}
