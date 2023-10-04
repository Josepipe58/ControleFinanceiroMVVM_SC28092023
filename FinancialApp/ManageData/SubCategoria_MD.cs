#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using FinancialApp.DataValidation;
using System;
using System.Windows;

namespace FinancialApp.ManageData
{
    public class SubCategoria_MD : SubCategoria_DV
    {
        #region |=================================| Gerenciar Dados(CRUD) |=====================================|        

        public string _nomeDoMetodo = string.Empty;

        //OBS: As Listas dos ComboBoxes, estão no Código Por Trás(Code Behind), por causa do evento SelectionChanged.

        //Lista do DataGrid Dados
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

        public SubCategoria_MD()
        {
            ListaDeSubCategorias = new ListaDeSubCategorias();           
        }

        //Cadastrar
        public void Cadastrar(SubCategoria subCategoria)
        {
            if (ValidarCadastrar(subCategoria) == true)
            {
                try
                {
                    SubCategoria_DA subCategoria_DA = new();
                    subCategoria.Id = SubCategoria.Id;
                    subCategoria.NomeDaSubCategoria = SubCategoria.NomeDaSubCategoria;                    
                    subCategoria.CategoriaId = SubCategoria.CategoriaId;
                    string retorno = subCategoria_DA.Cadastrar(subCategoria);
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
        public void Alterar(SubCategoria subCategoria)
        {
            if (ValidarAlterarExcluir(subCategoria) == true)
            {
                try
                {
                    SubCategoria_DA subCategoria_DA = new();
                    subCategoria.Id = SubCategoria.Id;
                    subCategoria.NomeDaSubCategoria = SubCategoria.NomeDaSubCategoria;
                    subCategoria.CategoriaId = SubCategoria.CategoriaId;
                    subCategoria_DA.Alterar(subCategoria);

                    GerenciarMensagens.SucessoAoAlterar(subCategoria.Id);
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
        public void Excluir(SubCategoria subCategoria)
        {
            if (ValidarAlterarExcluir(subCategoria) == true)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(subCategoria.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    SubCategoria_DA subCategoria_DA = new();
                    subCategoria_DA.Excluir(subCategoria);

                    GerenciarMensagens.SucessoAoExcluir(subCategoria.Id);
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
            SubCategoria_DA subCategoria_DA = new();
            SubCategoria.Id = 0;
            SubCategoria.NomeDaSubCategoria = null;           
            ListaDeSubCategorias = subCategoria_DA.ConsultarSubCategorias();
        }

        //Limpar e Atualizar Dados
        public void AtualizarDados()
        {
            SubCategoria_DA subCategoria_DA = new();
            SubCategoria.Id = 0;
            SubCategoria.NomeDaSubCategoria = null;            
            SubCategoria.NomeDoFiltro = null;
            SubCategoria.CategoriaId = 0;
            SubCategoria.NomeDaCategoria = null;
            SubCategoria.Pesquisar = null;
            ListaDeSubCategorias = subCategoria_DA.ConsultarSubCategorias();            
        }
        #endregion
    }
}
