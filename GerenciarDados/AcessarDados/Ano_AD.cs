#nullable disable
using BancoDeDados.ContextoDoBancoDeDados;
using BancoDeDados.ModelosDto;
using System;
using System.Data;

namespace GerenciarDados.AcessarDados
{
    public class Ano_AD
    {
        public string _consulta = string.Empty; 
        public Contexto _contexto;

        public Ano_AD()
        {
            _contexto = new Contexto();        
        }

        public string Cadastrar(AnoDto cadastrar)
        {
            _contexto.LimparParametros();            
            _contexto.AdicionarParametros("@AnoDoCadastro", cadastrar.AnoDoCadastro);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Insert Into Anos (AnoDoCadastro) " +
                "Values (@AnoDoCadastro); Select @@IDENTITY as Retorno;").ToString();
            return _consulta;
        }

        public string Alterar(AnoDto alterar)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", alterar.Id);
            _contexto.AdicionarParametros("@AnoDoCadastro", alterar.AnoDoCadastro);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Update Anos Set Id = @Id, AnoDoCadastro = @AnoDoCadastro " +
                "Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public string Excluir(AnoDto excluir)
        {
            _contexto.LimparParametros();
            _contexto.AdicionarParametros("@Id", excluir.Id);
            _consulta = _contexto.ExecutarManipulacaoDeDados(CommandType.Text,
                "Delete From Anos Where Id = @Id; Select @Id as Retorno;").ToString();
            return _consulta;
        }

        public ListaDeAnos ConsultarAnos()
        {
            ListaDeAnos listaDeAnos = new();
            DataTable dataTableAno = _contexto.ExecutarConsulta(CommandType.Text, "Select * From Anos;");
            foreach (DataRow dataRow in dataTableAno.Rows)
            {
                AnoDto anoDto = new()
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    AnoDoCadastro = Convert.ToInt32(dataRow["AnoDoCadastro"])
                };
                listaDeAnos.Add(anoDto);
            }
            return listaDeAnos;
        }
    }
}
