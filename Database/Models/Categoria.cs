using System.Collections.Generic;

namespace Database.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string NomeDaCategoria { get; set; } = string.Empty;

        public int FiltroDeControleId { get; set; }

        public string NomeDoFiltro { get; set; } = string.Empty;
    }

    public class ListaDeCategorias : List<Categoria> { }
}
