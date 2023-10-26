#nullable disable
using BancoDeDados.ContextoDoBancoDeDados;
using BancoDeDados.ModelosDto;
using System;
using System.Data;

namespace GerenciarDados.AcessarDados
{
    public class CentralDeDados_AD
    {
        public string _consulta = string.Empty;
        public Contexto _contexto;

        public CentralDeDados_AD()
        {
            _contexto = new Contexto();
        }

        public string Cadastrar(CentralDeDadosDto cadastrar)
        {
            _contexto.LimparParametros();
            //_contexto.AdicionarParametros("@Id", cadastrar.Id +1);
            _contexto.AdicionarParametros("@NomeDaCategoria", cadastrar.NomeDaCategoria);
            _contexto.AdicionarParametros("@NomeDaSubCategoria", cadastrar.NomeDaSubCategoria);
            _contexto.AdicionarParametros("@Valor", cadastrar.Valor);
            _contexto.AdicionarParametros("@Filtros", cadastrar.Filtros);
            _contexto.AdicionarParametros("@Tipo", cadastrar.Tipo);
            _contexto.AdicionarParametros("@Data", cadastrar.Data);
            _contexto.AdicionarParametros("@Mes", cadastrar.Mes);
            _contexto.AdicionarParametros("@Ano", cadastrar.Ano);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
            "Insert Into CentralDeDados (NomeDaCategoria, NomeDaSubCategoria, Valor, Filtros, " +
            "Tipo, Data, Mes, Ano) Values (@NomeDaCategoria, @NomeDaSubCategoria, @Valor, " +
            "@Filtros, @Tipo, @Data, @Mes, @Ano); Select @@IDENTITY as Retorno;").ToString();//Select @@IDENTITY as Retorno;
            return _consulta;
        }

        public string Alterar(CentralDeDadosDto alterar)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", alterar.Id);
            _contexto.AdicionarParametros("@NomeDaCategoria", alterar.NomeDaCategoria);
            _contexto.AdicionarParametros("@NomeDaSubCategoria", alterar.NomeDaSubCategoria);
            _contexto.AdicionarParametros("@Valor", alterar.Valor);
            _contexto.AdicionarParametros("@Filtros", alterar.Filtros);
            _contexto.AdicionarParametros("@Tipo", alterar.Tipo);
            _contexto.AdicionarParametros("@Data", alterar.Data);
            _contexto.AdicionarParametros("@Mes", alterar.Mes);
            _contexto.AdicionarParametros("@Ano", alterar.Ano);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Update CentralDeDados Set NomeDaCategoria = @NomeDaCategoria, NomeDaSubCategoria = @NomeDaSubCategoria, Valor = @Valor, " +
                "Filtros = @Filtros, Tipo = @Tipo, Data = @Data, Mes = @Mes, Ano = @Ano Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Excluir(CentralDeDadosDto excluir)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", excluir.Id);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From CentralDeDados Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        //Consulta Geral da Central de Dados.
        public ListaDaCentralDeDados ConsultaGeralDaCentralDeDadosPorAno(int ano)
        {
            ListaDaCentralDeDados listaDaCentralDeDados = new();
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Ano", ano);
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select * From CentralDeDados Where Ano = @Ano Order By Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CentralDeDadosDto centralDeDadosDto = new()
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
                listaDaCentralDeDados.Add(centralDeDadosDto);
            }
            return listaDaCentralDeDados;
        }

        //Fazer _consulta de acordo com o filtro selecionado no ComboBox.
        public ListaDaCentralDeDados ConsultarFiltroSelecionadoNoComboBox(string filtros, int ano)
        {
            ListaDaCentralDeDados listaDaCentralDeDados = new();
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Ano", ano);
            _contexto.AdicionarParametros("@Filtros", filtros);            
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select * From CentralDeDados Where Ano = @Ano And Filtros = @Filtros Order By Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CentralDeDadosDto centralDeDadosDto = new()
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
                listaDaCentralDeDados.Add(centralDeDadosDto);
            }
            return listaDaCentralDeDados;
        }

        //Consultar tabela de Receitas, com filtros no Nome da Categoria.
        public ListaDaCentralDeDados ConsultarReceitas(int ano)
        {
            ListaDaCentralDeDados listaDaCentralDeDados = new();
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Ano", ano);
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
                "Select * From CentralDeDados Where Ano = @Ano " +
                "And NomeDaCategoria In ('Renda', 'Venda') Order By Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                CentralDeDadosDto centralDeDadosDto = new()
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
                listaDaCentralDeDados.Add(centralDeDadosDto);
            }
            return listaDaCentralDeDados;
        }
    }
}
