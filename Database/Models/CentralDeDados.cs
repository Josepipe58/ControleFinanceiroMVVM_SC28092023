using System;
using System.Collections.Generic;

namespace Database.Models
{
    public class CentralDeDados
    {
        public int Id { get; set; }

        public string NomeDaCategoria { get; set; } = string.Empty;

        public string NomeDaSubCategoria { get; set; } = string.Empty;

        public decimal Valor { get; set; }

        public string Filtros { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public DateTime Data { get; set; }

        public string Mes { get; set; } = string.Empty;

        public int Ano { get; set; }
    }

    public class ListaDaCentralDeDados : List<CentralDeDados> { }
}
