#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using ManageData.DataValidation;
using System;
using System.Windows;

namespace ManageData
{
    public class NomeDeBanco_MD : NomeDeBanco_DV
    {
        #region |=================================| Propriedades |==================================================| 

        public string nomeDoMetodo = string.Empty;

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

        public NomeDeBanco_MD()
        {
            ListaDeNomeDeBancos = new ListaDeNomeDeBancos();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        //|===================================| Cadastrar |===============================================|

        public void Cadastrar(NomeDeBanco nomeDeBanco)
        {
            if (ValidarCadastrar(nomeDeBanco) == true)
            {
                try
                {
                    NomeDeBanco_DA categoria_DA = new();
                    string retorno = categoria_DA.Cadastrar(nomeDeBanco);
                    int codigoDeRetorno = Convert.ToInt32(retorno);
                    GerenciarMensagens.SucessoAoCadastrar(codigoDeRetorno);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                    return;
                }
            }
        }
        //|===================================| Alterar |=================================================|
        public void Alterar(NomeDeBanco nomeDeBanco)
        {
            if (ValidarAlterarExcluir(nomeDeBanco) == true)
            {
                try
                {
                    NomeDeBanco_DA categoria_DA = new();
                    categoria_DA.Alterar(nomeDeBanco);
                    GerenciarMensagens.SucessoAoAlterar(nomeDeBanco.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                    return;
                }
            }
        }
        //|===================================| Excluir |=================================================|
        public void Excluir(NomeDeBanco nomeDeBanco)
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
                    NomeDeBanco_DA categoria_DA = new();
                    categoria_DA.Excluir(nomeDeBanco);
                    GerenciarMensagens.SucessoAoExcluir(nomeDeBanco.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                    return;
                }
            }
        }
        //|===================================| Limpar e Atualizar Dados |================================|
        public void LimparEAtualizarDados()
        {
            NomeDeBanco_DA categoria_DA = new();
            NomeDeBanco.Id = 0;
            NomeDeBanco.NomeDoBanco = "";
            ListaDeNomeDeBancos = categoria_DA.ConsultarNomeDeBancos();
        }
        #endregion
    }
}
