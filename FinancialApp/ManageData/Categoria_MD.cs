#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using FinancialApp.DataValidation;
using System;
using System.Windows;

namespace FinancialApp.ManageData
{
    public class Categoria_MD : Categoria_DV
    {
        #region |=================================| Propriedades |==================================================| 
        
        public string _nomeDoMetodo = string.Empty;

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
            ListaDeFiltrosDeControle = new ListaDeFiltrosDeControle();
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
                    categoria.FiltroDeControleId = Categoria.FiltroDeControleId +1;
                    string retorno = categoria_DA.Cadastrar(categoria);

                    //Ao Cadastrar o FiltroDeControleId, o ComboBox muda para o próximo item por causa do +1.
                    //E esse if faz voltar o nome do item que foi cadastrado.
                    if (categoria.FiltroDeControleId != 0)
                        categoria.FiltroDeControleId = Categoria.FiltroDeControleId - 1;

                    int codigoDeRetorno = Convert.ToInt32(retorno);                    
                    GerenciarMensagens.SucessoAoCadastrar(codigoDeRetorno);
                    LimparDados();
                   
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
        public void Alterar(Categoria categoria)
        {
            if (ValidarAlterarExcluir(categoria) == true)
            {
                try
                {
                    Categoria_DA categoria_DA = new();                    
                    categoria.FiltroDeControleId = Categoria.FiltroDeControleId + 1;

                    categoria_DA.Alterar(categoria);
                    //Ao Alterar o FiltroDeControleId, o ComboBox muda para o próximo item por causa do +1.
                    //E esse if faz voltar o nome do item que foi alterado. 
                    if (categoria.FiltroDeControleId != 0)
                        categoria.FiltroDeControleId = Categoria.FiltroDeControleId - 1;

                    GerenciarMensagens.SucessoAoAlterar(categoria.Id);
                    LimparDados();
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
        public void Excluir(Categoria categoria)
        {
            if (ValidarAlterarExcluir(categoria) == true)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(categoria.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    Categoria_DA categoria_DA = new();
                    categoria_DA.Excluir(categoria);
                    GerenciarMensagens.SucessoAoExcluir(categoria.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }

        //|=================================| Limpar Dados |===========================|            

        public void LimparDados()
        {
            //Atenção! Não juntar esse método com AtualizarDados() para não limpar ComboBoxes ao fazer CRUD.
            Categoria_DA categoria_DA = new();
            Categoria.Id = 0;
            Categoria.NomeDaCategoria = "";
            ListaDeCategorias = categoria_DA.ConsultarCategorias();
        }
        //|===================================| Limpar e Atualizar Dados |================================|
        public void AtualizarDados()//Esse método será executo por um comando na classe: CategoriaCommand.
        {
            Categoria_DA categoria_DA = new(); 

            Categoria.Id = 0;
            Categoria.NomeDaCategoria = "";
            Categoria.NomeDoFiltro = null;            
            ListaDeCategorias = categoria_DA.ConsultarCategorias();
        }
        #endregion
    }
}
