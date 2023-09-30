#nullable disable
using Database.DatabaseContext;
using Database.Models;
using Domain.Messages;
using System;
using System.Data;

namespace Domain.DataAccess
{
    public class Ano_DA : Context
    {
        public string consulta = string.Empty;

        public string Cadastrar(Ano cadastrar)
        {
            LimparParametros();
            AdicionarParametros("@Id", cadastrar.Id + 1);
            AdicionarParametros("@AnoDoCadastro", cadastrar.AnoDoCadastro);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Select @Id = Id +1 From Anos; Insert Into Anos (Id, AnoDoCadastro) " +
                "Values (@Id, @AnoDoCadastro); Select @Id as Retorno;").ToString();
            return consulta;
        }

        public string Alterar(Ano alterar)
        {
            LimparParametros();
            AdicionarParametros("@Id", alterar.Id);
            AdicionarParametros("@AnoDoCadastro", alterar.AnoDoCadastro);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Update Anos Set Id = @Id, AnoDoCadastro = @AnoDoCadastro " +
                "Where Id = @Id; Select @Id as Retorno;").ToString();
            return consulta;
        }

        public string Excluir(Ano excluir)
        {
            LimparParametros();
            AdicionarParametros("@Id", excluir.Id);
            consulta = ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From Anos Where Id = @Id; Select @Id as Retorno;").ToString();
            return consulta;
        }

        public ListaDeAnos ConsultarAnos()
        {
            ListaDeAnos listaDeAnos = new();
            DataTable dataTableAno = ExecutarConsulta(CommandType.Text, "Select * From Anos;");
            foreach (DataRow dataRow in dataTableAno.Rows)
            {
                Ano ano = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    AnoDoCadastro = Convert.ToInt32(dataRow["AnoDoCadastro"])
                };
                listaDeAnos.Add(ano);
            }
            return listaDeAnos;
        }
    }
}
