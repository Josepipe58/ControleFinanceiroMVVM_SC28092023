#nullable disable
using BancoDeDados.ContextoDoBancoDeDados;
using BancoDeDados.ModelosDto;
using System;
using System.Data;

namespace GerenciarDados.AcessarDados
{
    public class SubCategoria_AD
    {
        public string _consulta = string.Empty;
        public Contexto _contexto;

        public SubCategoria_AD()
        {
            _contexto = new Contexto();
        }

        public string Cadastrar(SubCategoriaDto cadastrar)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", cadastrar.Id +1);
            _contexto.AdicionarParametros("@NomeDaSubCategoria", cadastrar.NomeDaSubCategoria);
            _contexto.AdicionarParametros("@CategoriaId", cadastrar.CategoriaId);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Select @Id = Id +1 From SubCategorias; Insert Into SubCategorias (Id, NomeDaSubCategoria, CategoriaId) " +
                "Values (@Id, @NomeDaSubCategoria, @CategoriaId); Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Alterar(SubCategoriaDto alterar)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", alterar.Id);
            _contexto.AdicionarParametros("@NomeDaSubCategoria", alterar.NomeDaSubCategoria);
            _contexto.AdicionarParametros("@CategoriaId", alterar.CategoriaId);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Update SubCategorias Set NomeDaSubCategoria = @NomeDaSubCategoria, CategoriaId = @CategoriaId " +
                "Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Excluir(SubCategoriaDto excluir)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", excluir.Id);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From SubCategorias Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        //Preencher DataGrid de SubCategorias.
        public ListaDeSubCategorias ConsultarSubCategorias()
        {
            ListaDeSubCategorias listaDeSubCategorias = new();
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select c.FiltroDeControleId, fc.NomeDoFiltro, sc.CategoriaId, c.NomeDaCategoria, " +
                "sc.Id, sc.NomeDaSubCategoria From SubCategorias sc " +
                "Inner Join Categorias c on sc.CategoriaId = c.Id " +
                "Inner Join FiltrosDeControle fc on c.FiltroDeControleId = fc.Id Order By sc.Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                SubCategoriaDto subCategoriaDto = new()
                {
                    FiltroDeControleId = Convert.ToInt32(dataRow["FiltroDeControleId"]),
                    NomeDoFiltro = Convert.ToString(dataRow["NomeDoFiltro"]),
                    CategoriaId = Convert.ToInt32(dataRow["CategoriaId"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubCategoria"]),
                };
                listaDeSubCategorias.Add(subCategoriaDto);
            }
            return listaDeSubCategorias;
        }

        //Fazer consulta de acordo com o filtro selecionado no ComboBox.
        public ListaDeSubCategorias ConsultarSubCategoriasPorNomeDoFiltro(string nomeDoFiltro)
        {
            ListaDeSubCategorias listaDeSubCategorias = new();
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@NomeDoFiltro", nomeDoFiltro);
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select c.FiltroDeControleId, fc.NomeDoFiltro, sc.CategoriaId, c.NomeDaCategoria, " +
                "sc.Id, sc.NomeDaSubCategoria From SubCategorias sc " +
                "Inner Join Categorias c on sc.CategoriaId = c.Id " +
                "Inner Join FiltrosDeControle fc on c.FiltroDeControleId = fc.Id " +
                "Where NomeDoFiltro = @NomeDoFiltro Order By sc.Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                SubCategoriaDto subCategoriaDto = new()
                {
                    FiltroDeControleId = Convert.ToInt32(dataRow["FiltroDeControleId"]),
                    NomeDoFiltro = Convert.ToString(dataRow["NomeDoFiltro"]),
                    CategoriaId = Convert.ToInt32(dataRow["CategoriaId"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubCategoria"]),
                };
                listaDeSubCategorias.Add(subCategoriaDto);
            }
            return listaDeSubCategorias;
        }

        //Preencher ComboBox de SubCategorias.
        public ListaDeSubCategorias ConsultarSubCategoriasPorId(int id)
        {
            ListaDeSubCategorias listaDeSubCategorias = new();
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", id);
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select * From SubCategorias Where CategoriaId = @Id Order By NomeDaSubCategoria Asc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                SubCategoriaDto subCategoriaDto = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubCategoria"]),
                    CategoriaId = Convert.ToInt32(dataRow["CategoriaId"])
                };
                listaDeSubCategorias.Add(subCategoriaDto);
            }
            return listaDeSubCategorias;
        }
    }
}
