#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using FinancialApp.ManageData.DataValidation;
using System;
using System.Windows;

namespace FinancialApp.ManageData
{
    public class SubCategoria_MD : SubCategoria_DV
    {
        #region |=================================| Propriedades |==================================================|        

        public string nomeDoMetodo = string.Empty;

        //Propriedade do Filtro de Controle
        private FiltroDeControle _filtroDeControle;
        public FiltroDeControle FiltroDeControle
        {
            get { return _filtroDeControle; }
            set
            {
                _filtroDeControle = value;
                OnPropertyChanged(nameof(FiltroDeControle));
            }
        }

        //Carregar ComboBox do Filtro de Controle.
        private ListaDeFiltrosDeControle _listaDeFiltrosDeControle;
        public ListaDeFiltrosDeControle ListaDeFiltrosDeControle
        {
            get { return _listaDeFiltrosDeControle; }
            set
            {
                if (_listaDeFiltrosDeControle != value)
                {
                    _listaDeFiltrosDeControle = value;
                    OnPropertyChanged(nameof(ListaDeFiltrosDeControle));
                }
            }
        }

        //Propriedade de Categorias
        private Categoria _categoria;
        public Categoria Categoria
        {
            get { return _categoria; }
            set
            {
                _categoria = value;
                OnPropertyChanged(nameof(Categoria));
            }
        }

        //Carregar ComboBox de Categorias.
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
                    nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                    return;
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
                    nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                    return;
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
                    nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, nomeDoMetodo);
                    return;
                }
            }
        }
        //|===================================| Limpar e Atualizar Dados |================================|
        public void LimparEAtualizarDados()
        {
            SubCategoria_DA subCategoria_DA = new();
            SubCategoria.Id = 0;
            SubCategoria.NomeDaSubCategoria = "";
            SubCategoria.CategoriaId = 0;
            SubCategoria.NomeDaCategoria = ListaDeSubCategorias[0].NomeDaCategoria;
            SubCategoria.FiltroDeControleId = 0;
            SubCategoria.NomeDoFiltro = ListaDeSubCategorias[0].NomeDoFiltro;  
            SubCategoria.Pesquisar = "";
            ListaDeSubCategorias = subCategoria_DA.ConsultarSubCategorias();
            
        }
        #endregion
    }
}
