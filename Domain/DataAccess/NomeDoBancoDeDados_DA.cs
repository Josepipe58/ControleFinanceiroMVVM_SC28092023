#nullable disable
using Database.DatabaseContext;
using Database.Models;
using System.Data;
using System;

namespace Domain.DataAccess
{
    public class NomeDoBancoDeDados_DA : DatabaseNameContext
    {
        public string _consulta = string.Empty;

        public string Cadastrar(NomeDoBancoDeDados cadastrar)
        {
            LimparParametros();
            AdicionarParametros("@Id", cadastrar.Id + 1);
            AdicionarParametros("@nomeDoBanco", cadastrar.NomeDoBanco);
            _consulta = ExecutarManipulacaoNomeDeBancos(CommandType.Text,
                "Select @Id = Id +1 From NomeDeBancos; Insert Into NomeDeBancos (Id, NomeDoBanco) " +
                "Values (@Id, @nomedobanco ); Select @id as Retorno;").ToString();
            return _consulta;
        }

        public string Alterar(NomeDoBancoDeDados alterar)
        {
            LimparParametros();
            AdicionarParametros("@id", alterar.Id);
            AdicionarParametros("@nomeDoBanco", alterar.NomeDoBanco);
            _consulta = ExecutarManipulacaoNomeDeBancos(CommandType.Text,
                "Update NomeDeBancos Set NomeDoBanco = @nomeDoBanco Where Id = @id; Select @id as Retorno;").ToString();
            return _consulta;
        }

        public string Excluir(NomeDoBancoDeDados excluir)
        {
            LimparParametros();
            AdicionarParametros("@id", excluir.Id);
            _consulta = ExecutarManipulacaoNomeDeBancos(CommandType.Text,
                "Delete From NomeDeBancos Where Id = @id; Select @id as Retorno;").ToString();
            return _consulta;
        }

        public ListaDeNomeDeBancos ConsultarNomeDeBancos()
        {
            ListaDeNomeDeBancos listaNomeDeBancosColecao = new();
            DataTable dataTable = ConsultarNomeDeBancos(CommandType.Text,
                "Select * From NomeDeBancos;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                NomeDoBancoDeDados oNomeDeBancos = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDoBanco = Convert.ToString(dataRow["NomeDoBanco"])
                };
                listaNomeDeBancosColecao.Add(oNomeDeBancos);
            }
            return listaNomeDeBancosColecao;
        }
    }
}
