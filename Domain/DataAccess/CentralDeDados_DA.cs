#nullable disable
using Database.DatabaseContext;
using Database.Models;
using System;
using System.Data;

namespace Domain.DataAccess
{
    public class CentralDeDados_DA : Context
    {
        public string consulta = string.Empty;

        public string Cadastrar(CentralDeDados cadastrar)
        {
            LimparParametros();
            AdicionarParametros("@Id", cadastrar.Id + 1);
            AdicionarParametros("@NomeDaCategoria", cadastrar.NomeDaCategoria);
            AdicionarParametros("@NomeDaSubCategoria", cadastrar.NomeDaSubCategoria);
            AdicionarParametros("@Valor", cadastrar.Valor);
            AdicionarParametros("@Filtros", cadastrar.Filtros);
            AdicionarParametros("@Tipo", cadastrar.Tipo);
            AdicionarParametros("@Data", cadastrar.Data);
            AdicionarParametros("@Mes", cadastrar.Mes);
            AdicionarParametros("@Ano", cadastrar.Ano);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
            "Select @Id = Id +1 From CentralDeDados; Insert Into CentralDeDados (Id, NomeDaCategoria, NomeDaSubCategoria, Valor, Filtros, " +
            "Tipo, Data, Mes, Ano) Values (@Id, @NomeDaCategoria, @NomeDaSubCategoria, @Valor, " +
            "@Filtros, @Tipo, @Data, @Mes, @Ano); Select @Id as Retorno;").ToString();
            return consulta;
        }

        public string Alterar(CentralDeDados alterar)
        {
            LimparParametros();
            AdicionarParametros("@Id", alterar.Id);
            AdicionarParametros("@NomeDaCategoria", alterar.NomeDaCategoria);
            AdicionarParametros("@NomeDaSubCategoria", alterar.NomeDaSubCategoria);
            AdicionarParametros("@Valor", alterar.Valor);
            AdicionarParametros("@Filtros", alterar.Filtros);
            AdicionarParametros("@Tipo", alterar.Tipo);
            AdicionarParametros("@Data", alterar.Data);
            AdicionarParametros("@Mes", alterar.Mes);
            AdicionarParametros("@Ano", alterar.Ano);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Update CentralDeDados Set NomeDaCategoria = @NomeDaCategoria, NomeDaSubCategoria = @NomeDaSubCategoria, Valor = @Valor, " +
                "Filtros = @Filtros, Tipo = @Tipo, Data = @Data, Mes = @Mes, Ano = @Ano Where Id = @Id; Select @Id as Retorno;").ToString();
            return consulta;
        }

        public string Excluir(int id)
        {
            LimparParametros();
            AdicionarParametros("@Id", id);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From CentralDeDados Where Id = @Id; Select @Id as Retorno;").ToString();
            return consulta;
        }

        //Consulta Geral da Central de Dados.
        public ListaDaCentralDeDados ConsultaGeralDaCentralDeDados(int ano)
        {
            ListaDaCentralDeDados listaDaCentralDeDados = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select * From CentralDeDados Where Ano = @Ano Order By Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CentralDeDados centralDeDados = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubCategoria"]),
                    Valor = Convert.ToDecimal(dataRow["Valor"]),
                    Filtros = Convert.ToString(dataRow["Filtros"]),
                    Tipo = Convert.ToString(dataRow["Tipo"]),
                    Data = Convert.ToDateTime(dataRow["Data"]),
                    Mes = Convert.ToString(dataRow["Mes"]),
                    Ano = Convert.ToInt32(dataRow["Ano"])
                };
                listaDaCentralDeDados.Add(centralDeDados);
            }
            return listaDaCentralDeDados;
        }

        //Fazer consulta de acordo com o filtro selecionado no ComboBox.
        public ListaDaCentralDeDados ConsultarFiltroSelecionadoNoComboBox(string filtros, int ano)
        {
            ListaDaCentralDeDados listaDaCentralDeDados = new();
            LimparParametros();
            AdicionarParametros("@Filtros", filtros);
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select * From CentralDeDados Where Ano = @Ano And Filtros = @Filtros Order By Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CentralDeDados centralDeDados = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubCategoria"]),
                    Valor = Convert.ToDecimal(dataRow["Valor"]),
                    Filtros = Convert.ToString(dataRow["Filtros"]),
                    Tipo = Convert.ToString(dataRow["Tipo"]),
                    Data = Convert.ToDateTime(dataRow["Data"]),
                    Mes = Convert.ToString(dataRow["Mes"]),
                    Ano = Convert.ToInt32(dataRow["Ano"])
                };
                listaDaCentralDeDados.Add(centralDeDados);
            }
            return listaDaCentralDeDados;
        }

        //Consultar tabela de Receitas, com filtros no Nome da Categoria.
        public ListaDaCentralDeDados ConsultarReceitas(int ano)
        {
            ListaDaCentralDeDados listaDaCentralDeDados = new();
            LimparParametros();
            AdicionarParametros("@Ano", ano);
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
                "Select * From CentralDeDados Where Ano = @Ano " +
                "And NomeDaCategoria In ('Renda', 'Venda') Order By Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CentralDeDados centralDeDados = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDaCategoria = Convert.ToString(dataRow["NomeDaCategoria"]),
                    NomeDaSubCategoria = Convert.ToString(dataRow["NomeDaSubCategoria"]),
                    Valor = Convert.ToDecimal(dataRow["Valor"]),
                    Filtros = Convert.ToString(dataRow["Filtros"]),
                    Tipo = Convert.ToString(dataRow["Tipo"]),
                    Data = Convert.ToDateTime(dataRow["Data"]),
                    Mes = Convert.ToString(dataRow["Mes"]),
                    Ano = Convert.ToInt32(dataRow["Ano"])
                };
                listaDaCentralDeDados.Add(centralDeDados);
            }
            return listaDaCentralDeDados;
        }
    }
}
