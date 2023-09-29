using System.Collections.Generic;

namespace Database.Models
{
    public class FiltroDeControle
    {
        public int Id { get; set; }

        public string NomeDoFiltro { get; set; } = string.Empty;
    }

    public class ListaDeFiltrosDeControle : List<FiltroDeControle> { }
}
