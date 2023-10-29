#nullable disable
using BancoDeDados.ContextoDoBancoDeDados;
using BancoDeDados.ModelosDto;
using System;
using System.Data;

namespace GerenciarDados.AcessarDados
{
    public class Aposentadoria_AD
    {
        public string _consulta = string.Empty;
        public Contexto _contexto;

        public Aposentadoria_AD()
        {
            _contexto = new Contexto();
        }

        public string Cadastrar(AposentadoriaDto cadastrar)
        {
            _contexto.LimparParametros();            
            _contexto.AdicionarParametros("@Data", cadastrar.Data);
            _contexto.AdicionarParametros("@AnoDoIndice", cadastrar.AnoDoIndice);
            _contexto.AdicionarParametros("@AnoDoReajuste", cadastrar.AnoDoReajuste);
            _contexto.AdicionarParametros("@IndiceDoAumento", cadastrar.IndiceDoAumento);
            _contexto.AdicionarParametros("@ValorDoAumento", cadastrar.ValorDoAumento);
            _contexto.AdicionarParametros("@AtualizarValor", cadastrar.AtualizarValor);
            _contexto.AdicionarParametros("@SaldoAtual", cadastrar.SaldoAtual);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
            "Insert Into Aposentadorias (Data, AnoDoIndice, AnoDoReajuste, IndiceDoAumento, ValorDoAumento, AtualizarValor, " +
            "SaldoAtual) Values (@Data, @AnoDoIndice, @AnoDoReajuste, @IndiceDoAumento, @ValorDoAumento,  @AtualizarValor, @SaldoAtual); " +
            "Select @@IDENTITY as Retorno;").ToString();
            return _consulta;
        }

        public string Alterar(AposentadoriaDto alterar)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", alterar.Id);
            _contexto.AdicionarParametros("@Data", alterar.Data);
            _contexto.AdicionarParametros("@AnoDoIndice", alterar.AnoDoIndice);
            _contexto.AdicionarParametros("@AnoDoReajuste", alterar.AnoDoReajuste);
            _contexto.AdicionarParametros("@IndiceDoAumento", alterar.IndiceDoAumento);
            _contexto.AdicionarParametros("@ValorDoAumento", alterar.ValorDoAumento);
            _contexto.AdicionarParametros("@AtualizarValor", alterar.AtualizarValor);
            _contexto.AdicionarParametros("@SaldoAtual", alterar.SaldoAtual);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Update Aposentadorias Set Data = @Data, AnoDoIndice = @AnoDoIndice, AnoDoReajuste = @AnoDoReajuste, IndiceDoAumento = @IndiceDoAumento," +
                "ValorDoAumento = @ValorDoAumento, AtualizarValor = @AtualizarValor, SaldoAtual = @SaldoAtual Where Id = @Id;" +
                "Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Excluir(AposentadoriaDto excluir)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", excluir.Id);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From Aposentadorias Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        //DataGrid
        public ListaDeAposentadoria ConsultarAposentadoria()
        {
            ListaDeAposentadoria listaDeAposentadoria = new();
            DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
               "Select * From Aposentadorias Order By Id Desc;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                AposentadoriaDto aposentadoriaDto = new()
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
                listaDeAposentadoria.Add(aposentadoriaDto);
            }
            return listaDeAposentadoria;
        }

        ////ComboBox Saldo Atual
        //public ListaDeAposentadoria ConsultarSaldoAtualAposentadoria()
        //{
        //    ListaDeAposentadoria listaDeAposentadoria = new();
        //    DataTable dataTable = _contexto.ExecutarConsulta(CommandType.Text,
        //       "Select SaldoAtual From Aposentadorias Order By SaldoAtual Desc;");

        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        AposentadoriaDto aposentadoriaDto = new()
        //        {                   
        //            SaldoAtual = Convert.ToDecimal(dataRow["SaldoAtual"])
        //        };
        //        listaDeAposentadoria.Add(aposentadoriaDto);
        //    }
        //    return listaDeAposentadoria;
        //}
    }
}
