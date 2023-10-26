#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using FinancialApp.Commands;
using FinancialApp.DataValidation;
using System;
using System.Windows;
using System.Windows.Input;

namespace FinancialApp.ViewModels
{
    public class CategoriaViewModel : Categoria_DV
    {

        //|Cadastrar 
        private ICommand _comandoDeCadastrarCategoria;
        public ICommand ComandoDeCadastrarCategoria
        {
            get
            {
                _comandoDeCadastrarCategoria ??=
                    new RelayCommand(param => Cadastrar(Categoria));
                return _comandoDeCadastrarCategoria;
            }
        }

        //Alterar 
        private ICommand _comandoDeAlterarCategoria;
        public ICommand ComandoDeDeAlterarCategoria
        {
            get
            {
                _comandoDeAlterarCategoria ??= new RelayCommand(param =>
                    Alterar(Categoria));
                return _comandoDeAlterarCategoria;
            }
        }

        //Excluir 
        private ICommand _comandoDeExcluirCategoria;
        public ICommand ComandoDeDeExcluirCategoria
        {
            get
            {
                _comandoDeExcluirCategoria ??= new RelayCommand(param =>
                    Excluir(Categoria));
                return _comandoDeExcluirCategoria;
            }
        }

        public CategoriaViewModel()
        {
            ListaDeCategorias = new ListaDeCategorias();
            ListaDeFiltrosDeControle = new ListaDeFiltrosDeControle();
        }


        public string _nomeDoMetodo = string.Empty;

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
            FiltroDeControle_DA filtroDeControle_DA = new();
            Categoria_DA categoria_DA = new();
            Categoria categoria = new();
            Categoria.Id = 0;
            Categoria.NomeDaCategoria = null;

            ListaDeFiltrosDeControle = filtroDeControle_DA.ConsultarFiltrosDeControle();
            ListaDeCategorias = categoria_DA.ConsultarCategoriasPorNomeDoFiltro(ListaDeFiltrosDeControle[0].NomeDoFiltro);
        }
    }
}
