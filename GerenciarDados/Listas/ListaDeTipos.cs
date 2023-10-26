using System.Collections.Generic;

namespace GerenciarDados.Listas
{
    public class ListaDeTipos
    {
        public static List<string> ListaDeTodosOsTipos()
        {
            var listaDeTodosOsTipos = new List<string>()
            {
                "Despesas Gerais",
                "Crédito",
                "Receita",
                "Débito",
                "Carteira",                
                "Saldo Anterior"
            };
            return listaDeTodosOsTipos;
        }
    }
}
