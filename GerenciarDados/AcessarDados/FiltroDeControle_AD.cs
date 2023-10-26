#nullable disable
using BancoDeDados.ContextoDoBancoDeDados;
using BancoDeDados.ModelosDto;
using System;
using System.Data;

namespace GerenciarDados.AcessarDados
{
    public class FiltroDeControle_AD
    {
        public Contexto _contexto;

        public FiltroDeControle_AD()
        {
            _contexto = new Contexto();
        }

        public ListaDeFiltrosDeControle ConsultarFiltrosDeControle()
        {
            ListaDeFiltrosDeControle listaDeFiltrosDeControle = new();
            DataTable dataTableAno = _contexto.ExecutarConsulta(CommandType.Text,
                "Select * From FiltrosDeControle;");
            foreach (DataRow dataRow in dataTableAno.Rows)
            {
                FiltroDeControleDto filtroDeControleDto = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDoFiltro = Convert.ToString(dataRow["NomeDoFiltro"])
                };
                listaDeFiltrosDeControle.Add(filtroDeControleDto);
            }
            return listaDeFiltrosDeControle;
        }
    }
}
