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
        #region |=================================| Gerenciar Dados(CRUD) |=====================================| 

        public string _nomeDoMetodo = string.Empty;

        //Lista do ComboBox Filtros de Controle
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

        //Lista do DataGrid Dados
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

        public Categoria_MD()
        {
            ListaDeFiltrosDeControle = new ListaDeFiltrosDeControle();
            ListaDeCategorias = new ListaDeCategorias();
        }

        //Cadastrar
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

        //Alterar
        public void Alterar(Categoria categoria)
        {
            if (ValidarAlterarExcluir(categoria) == true)
            {
                try
                {
                    Categoria_DA categoria_DA = new();
                    categoria_DA.Alterar(categoria);

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
        //Excluir
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

        //Limpar Dados
        public void LimparDados()
        {
            //Atenção! Não juntar esse método com AtualizarDados() para não limpar ComboBoxes ao fazer CRUD.
            Categoria_DA categoria_DA = new();
            Categoria.Id = 0;
            Categoria.NomeDaCategoria = null;
            ListaDeCategorias = categoria_DA.ConsultarCategorias();
        }

        //Limpar e Atualizar Dados
        public void AtualizarDados()//Esse método será executo por um comando na classe: CategoriaCommand.
        {
            Categoria_DA categoria_DA = new(); 

            Categoria.Id = 0;
            Categoria.NomeDaCategoria = null;
            Categoria.NomeDoFiltro = ListaDeFiltrosDeControle[0].NomeDoFiltro;                        
            ListaDeCategorias = categoria_DA.ConsultarCategorias();
        }
        #endregion
    }
}
