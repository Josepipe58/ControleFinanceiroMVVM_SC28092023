#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using ManageData.DataValidation;
using System;
using System.Windows;

namespace ManageData
{
    public class Categoria_MD : Categoria_DV
    {
        #region |=================================| Propriedades |==================================================|        

        //|=========================| Lista de Categorias de Despesas |===================================|

        //Carregar DataGrid Dados.
        private ListaDeCategorias _listaDeCategorias;
        public ListaDeCategorias ListaDeCategorias
        {
            get { return _listaDeCategorias; }
            set
            {
                if (_listaDeCategorias != value)
                {
                    _listaDeCategorias = value;
                    OnPropertyChanged(nameof(ListaDeCategorias));
                }
            }
        }
        #endregion

        #region |=================================| Construtor |====================================================|

        public Categoria_MD()
        {            
            ListaDeCategorias = new ListaDeCategorias();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        //|===================================| Cadastrar |===============================================|

        public void Cadastrar(Categoria categoria)
        {
            if (ValidarCadastrar(categoria) == true)
            {
                try
                {
                    Categoria_DA categoria_DA = new();
                    string retorno = categoria_DA.Cadastrar(categoria);
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
        public void Alterar(Categoria categoria)
        {
            if (ValidarAlterarExcluir(categoria) == true)
            {
                try
                {
                    Categoria_DA categoria_DA = new();
                    categoria_DA.Alterar(categoria);
                    GerenciarMensagens.SucessoAoAlterar(categoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    GerenciarMensagens.ErroDeAlterar(erro);
                }
            }
        }
        //|===================================| Excluir |=================================================|
        public void Excluir(Categoria categoria)
        {
            if (ValidarAlterarExcluir(categoria) == true)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(categoria.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparEAtualizarDados();
                    return;
                }
                try
                {
                    Categoria_DA categoria_DA = new();
                    categoria_DA.Excluir(categoria);
                    GerenciarMensagens.SucessoAoExcluir(categoria.Id);
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
            Categoria_DA categoria_DA = new();
            Categoria.Id = 0;
            Categoria.NomeDaCategoria = "";
            ListaDeCategorias = categoria_DA.ConsultarCategorias();
        }
        #endregion
    }
}
