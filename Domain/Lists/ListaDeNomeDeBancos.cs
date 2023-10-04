using System.Collections.Generic;

namespace Domain.Lists
{
    public class ListaDeNomeDeBancos
    {
        public static List<string> CarregarComboBoxDeNomeDeBancos()
        {
            var listaDeNomeDeBancos = new List<string>()
            {
                "BancoDeTestes",
                "Financeiro_2020_2025",
                "Financeiro_2013_2019",
            };
            return listaDeNomeDeBancos;
        }
    }
}
