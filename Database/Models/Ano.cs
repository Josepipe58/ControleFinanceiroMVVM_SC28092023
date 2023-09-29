using System.Collections.Generic;

namespace Database.Models
{
    public class Ano
    {
        public int Id { get; set; }

        public int AnoDoCadastro { get; set; }
    }
    public class ListaDeAnos : List<Ano> { }
}
