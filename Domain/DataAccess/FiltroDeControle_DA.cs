#nullable disable
using Database.DatabaseContext;
using Database.Models;
using System;
using System.Data;

namespace Domain.DataAccess
{
    public class FiltroDeControle_DA : Context
    {
        public ListaDeFiltrosDeControle ConsultarFiltrosDeControle()
        {
            ListaDeFiltrosDeControle listaDeFiltrosDeControle = new();
            DataTable dataTableAno = ExecutarConsulta(CommandType.Text,
                "Select * From FiltrosDeControle;");
            foreach (DataRow dataRow in dataTableAno.Rows)
            {
                FiltroDeControle nomeDeTabela = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDoFiltro = Convert.ToString(dataRow["NomeDoFiltro"])
                };
                listaDeFiltrosDeControle.Add(nomeDeTabela);
            }
            return listaDeFiltrosDeControle;
        }
    }
}
