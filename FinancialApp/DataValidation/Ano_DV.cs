#nullable disable
using Database.Models;
using Domain.Messages;
using System;

namespace FinancialApp.DataValidation
{
    public class Ano_DV : DataValidationBase
    {
        public Ano Ano { get; set; }

        public Ano_DV()
        {
            Ano = new Ano();
        }

        //Cadastrar
        public bool ValidarCadastrar(Ano ano)
        {
            Ano = ano;
            if (Ano.Id == 0 && Ano.AnoDoCadastro > 0 && Ano.AnoDoCadastro != 0)
            {
                return true;
            }
            else if (Ano.Id > 0 && Ano.AnoDoCadastro > 0)
            {
                GerenciarMensagens.ErroAoCadastrar();
                return false;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return false;
            }
        }

        //Alterar e Excluir
        public bool ValidarAlterarExcluir(Ano ano)
        {
            Ano = ano;
            if(Ano.Id > 0 && Ano.AnoDoCadastro > 0 && Ano.AnoDoCadastro != 0)
            {
                return true;
            }
            else if (Ano.Id == 0 && Ano.AnoDoCadastro > 0)
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                return false;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return false;
            }
        }
    }
}
