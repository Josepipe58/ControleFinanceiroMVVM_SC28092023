#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using ManageData.DataValidation;
using System;
using System.Windows;

namespace ManageData
{
    public class SubCategoria_MD : SubCategoria_DV
    {
        #region |=================================| Propriedades |==================================================|        

        //|=========================| Lista de SubCategorias de Despesas |===================================|

        //Carregar DataGrid Dados.
        private ListaDeSubCategorias _listaDeSubCategorias;
        public ListaDeSubCategorias ListaDeSubCategorias
        {
            get { return _listaDeSubCategorias; }
            set
            {
                if (_listaDeSubCategorias != value)
                {
                    _listaDeSubCategorias = value;
                    OnPropertyChanged(nameof(ListaDeSubCategorias));
                }
            }
        }
        #endregion

        #region |=================================| Construtor |====================================================|

        public SubCategoria_MD()
        {
            ListaDeSubCategorias = new ListaDeSubCategorias();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        //|===================================| Cadastrar |===============================================|

        public void Cadastrar(SubCategoria subCategoria)
        {
            if (ValidarCadastrar(subCategoria) == true)
            {
                try
                {
                    SubCategoria_DA subCategoria_DA = new();
                    string retorno = subCategoria_DA.Cadastrar(subCategoria);
                    int codigoDeRetorno = Convert.ToInt32(retorno);
                    GerenciarMensagens.SucessoAoCadastrar(codigoDeRetorno);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    GerenciarMensagens.ErroDeCadastro(erro);
                }
            }
        }
        //|===================================| Alterar |=================================================|
        public void Alterar(SubCategoria subCategoria)
        {
            if (ValidarAlterarExcluir(subCategoria) == true)
            {
                try
                {
                    SubCategoria_DA subCategoria_DA = new();
                    subCategoria_DA.Alterar(subCategoria);
                    GerenciarMensagens.SucessoAoAlterar(subCategoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    GerenciarMensagens.ErroDeAlterar(erro);
                }
            }
        }
        //|===================================| Excluir |=================================================|
        public void Excluir(SubCategoria subCategoria)
        {
            if (ValidarAlterarExcluir(subCategoria) == true)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(subCategoria.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparEAtualizarDados();
                    return;
                }
                try
                {
                    SubCategoria_DA subCategoria_DA = new();
                    subCategoria_DA.Excluir(subCategoria);
                    GerenciarMensagens.SucessoAoExcluir(subCategoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    GerenciarMensagens.ErroDeExcluir(erro);
                }
            }
        }
        //|===================================| Limpar e Atualizar Dados |================================|
        public void LimparEAtualizarDados()
        {
            SubCategoria_DA subCategoria_DA = new();
            SubCategoria.Id = 0;
            SubCategoria.NomeDaSubCategoria = "";
            ListaDeSubCategorias = subCategoria_DA.ConsultarSubCategorias();
        }
        #endregion
    }
}
