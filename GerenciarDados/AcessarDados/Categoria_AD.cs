#nullable disable
using BancoDeDados.ContextoDoBancoDeDados;
using BancoDeDados.ModelosDto;
using System;
using System.Data;

namespace GerenciarDados.AcessarDados
{
    public class Categoria_AD
    {
        public string _consulta, _nomeDoMetodo = string.Empty;
        public Contexto _contexto;

        public Categoria_AD()
        {
            _contexto = new Contexto();
        }

        public string Cadastrar(CategoriaDto cadastrar)
        {
            _contexto.LimparParametros();            
            _contexto.AdicionarParametros("@NomeDaCategoria", cadastrar.NomeDaCategoria);
            _contexto.AdicionarParametros("@FiltroDeControleId", cadastrar.FiltroDeControleId);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
            "Insert Into Categorias (NomeDaCategoria, FiltroDeControleId) " +
                "Values (@NomeDaCategoria, @FiltroDeControleId); Select @@IDENTITY as Retorno;").ToString();
            return _consulta;
        }

        public string Alterar(CategoriaDto alterar)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", alterar.Id);
            _contexto.AdicionarParametros("@NomeDaCategoria", alterar.NomeDaCategoria);
            _contexto.AdicionarParametros("@FiltroDeControleId", alterar.FiltroDeControleId);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Update Categorias Set NomeDaCategoria = @NomeDaCategoria, FiltroDeControleId = @FiltroDeControleId " +
                "Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Excluir(CategoriaDto excluir)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", excluir.Id);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From Categorias Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        //Preencher DataGrid e ComboBox de Categorias.
        public ListaDeCategorias ConsultarCategorias()
        {
            ListaDeCategorias listaDeCategorias = new();
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select c.FiltroDeControleId, fc.NomeDoFiltro, c.Id, c.NomeDaCategoria From Categorias c " +
                "Inner Join FiltrosDeControle fc on c.FiltroDeControleId = fc.Id Order By c.Id Asc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CategoriaDto categoriaDto = new()
                {
                    FiltroDeControleId = Convert.ToInt32(dataRow["FiltroDeControleId"]),
                    NomeDoFiltro = Convert.ToString(dataRow["NomeDoFiltro"]),
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                };
                listaDeCategorias.Add(categoriaDto);
            }
            return listaDeCategorias;
        }

        //Fazer consulta de acordo com o filtro selecionado no ComboBox.
        public ListaDeCategorias ConsultarCategoriasPorNomeDoFiltro(string nomeDoFiltro)
        {
            ListaDeCategorias listaDeCategorias = new();
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@NomeDoFiltro", nomeDoFiltro);
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select c.FiltroDeControleId, fc.NomeDoFiltro, c.Id, c.NomeDaCategoria From Categorias c " +
                "Inner Join FiltrosDeControle fc on c.FiltroDeControleId = fc.Id " +
                "Where NomeDoFiltro = @NomeDoFiltro Order By c.Id Asc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CategoriaDto categoriaDto = new()
                {
                    FiltroDeControleId = Convert.ToInt32(dataRow["FiltroDeControleId"]),
                    NomeDoFiltro = Convert.ToString(dataRow["NomeDoFiltro"]),
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                };
                listaDeCategorias.Add(categoriaDto);
            }
            return listaDeCategorias;
        }

        //Preencher ComboBox de Categorias com parâmetros.
        public ListaDeCategorias ConsultarCategoriasPorId(int id)
        {
            ListaDeCategorias listaDeCategorias = new();
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", id);
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select * From Categorias Where FiltroDeControleId = @Id Order By NomeDaCategoria Asc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CategoriaDto categoriaDto = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    FiltroDeControleId = Convert.ToInt32(dataRow["FiltroDeControleId"])
                };
                listaDeCategorias.Add(categoriaDto);
            }
            return listaDeCategorias;
        }
    }
}
