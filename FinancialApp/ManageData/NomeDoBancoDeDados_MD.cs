#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using FinancialApp.DataValidation;
using System;
using System.Windows;

namespace FinancialApp.ManageData
{
    public class NomeDoBancoDeDados_MD : NomeDoBancoDeDados_DV
    {
        #region |=================================| Propriedades |==================================================| 

        public string _nomeDoMetodo = string.Empty;

        //Carregar DataGrid Dados.
        private ListaDeNomeDeBancos _listaDeNomeDeBancos;
        public ListaDeNomeDeBancos ListaDeNomeDeBancos
        {
            get { return _listaDeNomeDeBancos; }
            set
            {
                if (_listaDeNomeDeBancos != value)
                {
                    _listaDeNomeDeBancos = value;
                    OnPropertyChanged(nameof(ListaDeNomeDeBancos));
                }
            }
        }
        #endregion

        #region |=================================| Construtor |====================================================|

        public NomeDoBancoDeDados_MD()
        {
            ListaDeNomeDeBancos = new ListaDeNomeDeBancos();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        //|===================================| Cadastrar |===============================================|

        public void Cadastrar(NomeDoBancoDeDados nomeDeBanco)
        {
            if (ValidarCadastrar(nomeDeBanco) == true)
            {
                try
                {
                    NomeDoBancoDeDados_DA categoria_DA = new();
                    string retorno = categoria_DA.Cadastrar(nomeDeBanco);
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
        //|===================================| Alterar |=================================================|
        public void Alterar(NomeDoBancoDeDados nomeDeBanco)
        {
            if (ValidarAlterarExcluir(nomeDeBanco) == true)
            {
                try
                {
                    NomeDoBancoDeDados_DA categoria_DA = new();
                    categoria_DA.Alterar(nomeDeBanco);
                    GerenciarMensagens.SucessoAoAlterar(nomeDeBanco.Id);
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
        //|===================================| Excluir |=================================================|
        public void Excluir(NomeDoBancoDeDados nomeDeBanco)
        {
            if (ValidarAlterarExcluir(nomeDeBanco) == true)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(nomeDeBanco.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparEAtualizarDados();
                    return;
                }
                try
                {
                    NomeDoBancoDeDados_DA categoria_DA = new();
                    categoria_DA.Excluir(nomeDeBanco);
                    GerenciarMensagens.SucessoAoExcluir(nomeDeBanco.Id);
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
        //|===================================| Limpar e Atualizar Dados |================================|
        public void LimparEAtualizarDados()
        {
            NomeDoBancoDeDados_DA categoria_DA = new();
            NomeDeBanco.Id = 0;
            NomeDeBanco.NomeDoBanco = "";
            ListaDeNomeDeBancos = categoria_DA.ConsultarNomeDeBancos();
        }
        #endregion
    }
}
