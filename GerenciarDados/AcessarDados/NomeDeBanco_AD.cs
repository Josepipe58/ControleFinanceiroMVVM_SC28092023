#nullable disable
using BancoDeDados;
using BancoDeDados.ModelosDto;
using System;
using System.Data;

namespace GerenciarDados.AcessarDados
{
    public class NomeDeBanco_AD
    {
        public string _consulta = string.Empty;
        public ContextoNomeDeBancos _contextoNomeDeBancos;

        public NomeDeBanco_AD() 
        {
            _contextoNomeDeBancos = new ContextoNomeDeBancos();
        }

        public string Cadastrar(NomeDeBancoDto cadastrar)
        {
            _contextoNomeDeBancos.LimparParametros();
            _contextoNomeDeBancos.AdicionarParametros("@Id", cadastrar.Id + 1);
            _contextoNomeDeBancos.AdicionarParametros("@NomeDoBanco", cadastrar.NomeDoBanco);
            _consulta = _contextoNomeDeBancos.ExecutarManipulacaoDeDados(CommandType.Text,
                "Select @Id = Id +1 From NomeDeBancos; Insert Into NomeDeBancos (Id, NomeDoBanco) " +
                "Values (@Id, @NomeDoBanco ); Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Alterar(NomeDeBancoDto alterar)
        {
            _contextoNomeDeBancos.LimparParametros();
            _contextoNomeDeBancos.AdicionarParametros("@Id", alterar.Id);
            _contextoNomeDeBancos.AdicionarParametros("@NomeDoBanco", alterar.NomeDoBanco);
            _consulta = _contextoNomeDeBancos.ExecutarManipulacaoDeDados(CommandType.Text,
                "Update NomeDeBancos Set NomeDoBanco = @NomeDoBanco Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Excluir(NomeDeBancoDto excluir)
        {
            _contextoNomeDeBancos.LimparParametros();
            _contextoNomeDeBancos.AdicionarParametros("@Id", excluir.Id);
            _consulta = _contextoNomeDeBancos.ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From NomeDeBancos Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public ListaDeNomeDeBancos ConsultarNomeDeBancos()
        {
            ListaDeNomeDeBancos listaNomeDeBancos = new();
            DataTable dataTable = _contextoNomeDeBancos.ExecutarConsulta(CommandType.Text,
                "Select * From NomeDeBancos;");

            foreach (DataRow dataRow in dataTable.Rows)
            {
                NomeDeBancoDto nomeDeBancoDto = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    NomeDoBanco = Convert.ToString(dataRow["NomeDoBanco"])
                };
                listaNomeDeBancos.Add(nomeDeBancoDto);
            }
            return listaNomeDeBancos;
        }
    }
}
