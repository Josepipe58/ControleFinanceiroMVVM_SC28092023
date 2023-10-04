#nullable disable
using Database.DatabaseContext;
using Database.Models;
using System;
using System.Data;

namespace Domain.DataAccess
{
    public class SubCategoria_DA : Context
    {
        public string _consulta = string.Empty;

        public string Cadastrar(SubCategoria cadastrar)
        {
            LimparParametros();
            AdicionarParametros("@Id", cadastrar.Id +1);
            AdicionarParametros("@NomeDaSubCategoria", cadastrar.NomeDaSubCategoria);
            AdicionarParametros("@CategoriaId", cadastrar.CategoriaId);
            _consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Select @Id = Id +1 From SubCategorias; Insert Into SubCategorias (Id, NomeDaSubCategoria, CategoriaId) " +
                "Values (@Id, @NomeDaSubCategoria, @CategoriaId); Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Alterar(SubCategoria alterar)
        {
            LimparParametros();
            AdicionarParametros("@Id", alterar.Id);
            AdicionarParametros("@NomeDaSubCategoria", alterar.NomeDaSubCategoria);
            AdicionarParametros("@CategoriaId", alterar.CategoriaId);
            _consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Update SubCategorias Set NomeDaSubCategoria = @NomeDaSubCategoria, CategoriaId = @CategoriaId " +
                "Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Excluir(SubCategoria excluir)
        {
            LimparParametros();
            AdicionarParametros("@Id", excluir.Id);
            _consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From SubCategorias Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        //Preencher DataGrid de SubCategorias.
        public ListaDeSubCategorias ConsultarSubCategorias()
        {
            ListaDeSubCategorias listaDeSubCategorias = new();
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select c.FiltroDeControleId, fc.NomeDoFiltro, sc.CategoriaId, c.NomeDaCategoria, " +
                "sc.Id, sc.NomeDaSubCategoria From SubCategorias sc " +
                "Inner Join Categorias c on sc.CategoriaId = c.Id " +
                "Inner Join FiltrosDeControle fc on c.FiltroDeControleId = fc.Id Order By sc.Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                SubCategoria subCategoria = new()
                {
                    FiltroDeControleId = Convert.ToInt32(dataRow["FiltroDeControleId"]),
                    NomeDoFiltro = Convert.ToString(dataRow["NomeDoFiltro"]),
                    CategoriaId = Convert.ToInt32(dataRow["CategoriaId"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubCategoria"]),
                };
                listaDeSubCategorias.Add(subCategoria);
            }
            return listaDeSubCategorias;
        }

        //Preencher ComboBox de SubCategorias.
        public ListaDeSubCategorias ConsultarSubCategoriasPorId(int id)
        {
            ListaDeSubCategorias listaDeSubCategorias = new();
            LimparParametros();
            AdicionarParametros("@Id", id);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select * From SubCategorias Where CategoriaId = @Id Order By NomeDaSubCategoria Asc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                SubCategoria subCategoria = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubCategoria"]),
                    CategoriaId = Convert.ToInt32(dataRow["CategoriaId"])
                };
                listaDeSubCategorias.Add(subCategoria);
            }
            return listaDeSubCategorias;
        }
    }
}
