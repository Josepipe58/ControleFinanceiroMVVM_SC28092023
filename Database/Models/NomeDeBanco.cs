using System.Collections.Generic;

namespace Database.Models
{
    public class NomeDeBanco
    {
        public int Id { get; set; }

        public string NomeDoBanco { get; set; } = string.Empty;
    }

    public class ListaDeNomeDeBancos : List<NomeDeBanco> { }
}
