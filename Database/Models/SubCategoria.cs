using System.Collections.Generic;

namespace Database.Models
{
    public class SubCategoria
    {
        public int Id { get; set; }

        public string NomeDaSubCategoria { get; set; } = string.Empty;

        public int CategoriaId { get; set; }

        public string NomeDaCategoria { get; set; } = string.Empty;

        public int FiltroDeControleId { get; set; }

        public string NomeDoFiltro { get; set; } = string.Empty;
    }

    public class ListaDeSubCategorias : List<SubCategoria> { }
}
