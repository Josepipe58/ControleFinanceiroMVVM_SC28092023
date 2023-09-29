#nullable disable
using Database.DatabaseContext;
using Database.Models;
using System;
using System.Data;

namespace Domain.DataAccess
{
    public class Aposentadoria_DA : Context
    {
        public string consulta = string.Empty;

        public string Cadastrar(Aposentadoria cadastrar)
        {
            LimparParametros();
            AdicionarParametros("@Id", cadastrar.Id + 1);
            AdicionarParametros("@data", cadastrar.Data);
            AdicionarParametros("@anoDoIndice", cadastrar.AnoDoIndice);
            AdicionarParametros("@anoDoReajuste", cadastrar.AnoDoReajuste);
            AdicionarParametros("@indiceDoAumento", cadastrar.IndiceDoAumento);
            AdicionarParametros("@valorDoAumento", cadastrar.ValorDoAumento);
            AdicionarParametros("@atualizarValor", cadastrar.AtualizarValor);
            AdicionarParametros("@saldoAtual", cadastrar.SaldoAtual);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
            "Select @Id = Id +1 From Aposentadorias; Insert Into Aposentadorias (Id, Data, AnoDoIndice, AnoDoReajuste, IndiceDoAumento, ValorDoAumento, AtualizarValor, " +
            "SaldoAtual) Values (@Id, @data, @anoDoIndice, @anoDoReajuste, @indiceDoAumento, @valorDoAumento,  @atualizarValor, @saldoAtual); " +
            "Select @Id as Retorno;").ToString();
            return consulta;
        }

        public string Alterar(Aposentadoria alterar)
        {
            LimparParametros();
            AdicionarParametros("@id", alterar.Id);
            AdicionarParametros("@data", alterar.Data);
            AdicionarParametros("@anoDoIndice", alterar.AnoDoIndice);
            AdicionarParametros("@anoDoReajuste", alterar.AnoDoReajuste);
            AdicionarParametros("@indiceDoAumento", alterar.IndiceDoAumento);
            AdicionarParametros("@valorDoAumento", alterar.ValorDoAumento);
            AdicionarParametros("@atualizarValor", alterar.AtualizarValor);
            AdicionarParametros("@saldoAtual", alterar.SaldoAtual);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Update Aposentadorias Set Data = @data, AnoDoIndice = @anoDoIndice, AnoDoReajuste = @anoDoReajuste, IndiceDoAumento = @indiceDoAumento," +
                "ValorDoAumento = @valorDoAumento, AtualizarValor = @atualizarValor, SaldoAtual = @saldoAtual Where Id = @id;" +
                "Select @id as Retorno;").ToString();
            return consulta;
        }

        public string Excluir(int id)
        {
            LimparParametros();
            AdicionarParametros("@id", id);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From Aposentadorias Where Id = @id; Select @id as Retorno;").ToString();
            return consulta;
        }

        public ListaDeAposentadoria ConsultarAposentadoria()
        {
            ListaDeAposentadoria listaDeAposentadoria = new();
            DataTable dataTable = ExecutarConsulta(CommandType.Text,
               "Select * From Aposentadorias Order By Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Aposentadoria aposentadoria = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Data = Convert.ToDateTime(dataRow["Data"]),
                    AnoDoIndice = Convert.ToInt32(dataRow["AnoDoIndice"]),
                    AnoDoReajuste = Convert.ToInt32(dataRow["AnoDoReajuste"]),
                    IndiceDoAumento = Convert.ToDecimal(dataRow["IndiceDoAumento"]),
                    ValorDoAumento = Convert.ToDecimal(dataRow["ValorDoAumento"]),
                    AtualizarValor = Convert.ToDecimal(dataRow["AtualizarValor"]),
                    SaldoAtual = Convert.ToDecimal(dataRow["SaldoAtual"])
                };
                listaDeAposentadoria.Add(aposentadoria);
            }
            return listaDeAposentadoria;
        }
    }
}
