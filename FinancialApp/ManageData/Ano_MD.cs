#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using FinancialApp.DataValidation;
using System;
using System.Windows;

namespace FinancialApp.ManageData
{
    public class Ano_MD : Ano_DV
    { 
        #region |=================================| Gerenciar Dados(CRUD) |=====================================|

        public string _nomeDoMetodo = string.Empty;    

        //Lista do DataGrid Dados e ComboBox
        private ListaDeAnos _listaDeAnos;
        public ListaDeAnos ListaDeAnos
        {
            get { return _listaDeAnos; }
            set
            {
                if (_listaDeAnos != value)
                {
                    _listaDeAnos = value;
                    OnPropertyChanged(nameof(ListaDeAnos));
                }
            }
        }

        public Ano_MD()
        {
            ListaDeAnos = new ListaDeAnos();
        }

        //Cadastrar
        public void Cadastrar(Ano ano)
        {
            if (ValidarCadastrar(ano) == true)
            {
                try
                {
                    Ano_DA ano_DA = new();                   
                    string retorno = ano_DA.Cadastrar(ano);
                    int codigoDeRetorno = Convert.ToInt32(retorno);

                    GerenciarMensagens.SucessoAoCadastrar(codigoDeRetorno);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }

        //Alterar
        public void Alterar(Ano ano)
        {
            if (ValidarAlterarExcluir(ano) == true)
            {
                try
                {
                    Ano_DA ano_DA = new();                    
                    ano_DA.Alterar(ano);

                    GerenciarMensagens.SucessoAoAlterar(ano.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }

        //Excluir
        public void Excluir(Ano ano)
        {
            if (ValidarAlterarExcluir(ano) == true)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(ano.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparEAtualizarDados();
                    return;
                }
                try
                {
                    Ano_DA ano_DA = new();                    
                    ano_DA.Excluir(ano);
                    GerenciarMensagens.SucessoAoExcluir(ano.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }

        //Limpar e Atualizar Dados
        public void LimparEAtualizarDados()
        {
            Ano_DA ano_DA = new();
            Ano.Id = 0;
            Ano.AnoDoCadastro = 0;
            ListaDeAnos = ano_DA.ConsultarAnos();
        }
        #endregion
    }
}
