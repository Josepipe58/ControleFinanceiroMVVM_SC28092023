#nullable disable
using Database.DatabaseContext;
using Database.Models;
using System;
using System.Data;

namespace Domain.DataAccess
{
    public class Categoria_DA : Context
    {
        public string consulta = string.Empty;

        public string Cadastrar(Categoria cadastrar)
        {
            LimparParametros();
            AdicionarParametros("@Id", cadastrar.Id + 1);
            AdicionarParametros("@NomeDaCategoria", cadastrar.NomeDaCategoria);
            AdicionarParametros("@FiltroDeControleId", cadastrar.FiltroDeControleId);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
            "Select @Id = Id + 1 From Categorias; Insert Into Categorias (Id, NomeDaCategoria, FiltroDeControleId) " +
                "Values (@Id, @NomeDaCategoria, @FiltroDeControleId); Select @Id as Retorno;").ToString();
            return consulta;
        }

        public string Alterar(Categoria alterar)
        {
            LimparParametros();
            AdicionarParametros("@Id", alterar.Id);
            AdicionarParametros("@NomeDaCategoria", alterar.NomeDaCategoria);
            AdicionarParametros("@FiltroDeControleId", alterar.FiltroDeControleId);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Update Categorias Set NomeDaCategoria = @NomeDaCategoria, FiltroDeControleId = @FiltroDeControleId " +
                "Where Id = @Id; Select @Id as Retorno;").ToString();
            return consulta;
        }

        public string Excluir(Categoria excluir)
        {
            LimparParametros();
            AdicionarParametros("@Id", excluir.Id);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From Categorias Where Id = @Id; Select @Id as Retorno;").ToString();
            return consulta;
        }

        //Preencher DataGrid e ComboBox de Categorias.
        public ListaDeCategorias ConsultarCategorias()
        {
            ListaDeCategorias listaDeCategorias = new();
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select c.FiltroDeControleId, fc.NomeDoFiltro, c.Id, c.NomeDaCategoria From Categorias c " +
                "Inner Join FiltrosDeControle fc on c.FiltroDeControleId = fc.Id Order By c.Id Asc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Categoria Categoria = new()
                {
                    FiltroDeControleId = Convert.ToInt32(dataRow["FiltroDeControleId"]),
                    NomeDoFiltro = Convert.ToString(dataRow["NomeDoFiltro"]),
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                };
                listaDeCategorias.Add(Categoria);
            }
            return listaDeCategorias;
        }


        //Preencher ComboBox de Categorias com parâmetros.
        public ListaDeCategorias ConsultarCategoriasPorId(int id)
        {
            ListaDeCategorias listaDeCategorias = new();
            LimparParametros();
            AdicionarParametros("@Id", id);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select * From Categorias Where FiltroDeControleId = @Id Order By NomeDaCategoria Asc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Categoria categoria = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    FiltroDeControleId = Convert.ToInt32(dataRow["FiltroDeControleId"])
                };
                listaDeCategorias.Add(categoria);
            }
            return listaDeCategorias;
        }
    }
}
