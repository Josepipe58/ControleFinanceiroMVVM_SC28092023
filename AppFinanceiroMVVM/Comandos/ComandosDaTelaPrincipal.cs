#nullable disable
using AppFinanceiroMVVM.Commandos;
using AppFinanceiroMVVM.Views;
using AppFinanceiroMVVM.Views.NomeDeBancosVW;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace AppFinanceiroMVVM.Comandos
{
    public class ComandosDaTelaPrincipal : RelayCommand
    {
        private object _selecionarControleDeUsuario;
        public object SelecionarControleDeUsuario
        {
            get => _selecionarControleDeUsuario;
            set
            {
                _selecionarControleDeUsuario = value;
                OnPropertyChanged(nameof(SelecionarControleDeUsuario));
            }
        }

        public string _nomeDoMetodo = string.Empty;

        //public ListaDeNomeDeBancosDoSql ListaDeNomeDeBancosDoSql { get; set; }

        public List<string> CarregarComboBoxDeNomeDeBancos { get; set; }

        private CollectionViewSource MenuItemsCollection { get; set; }

        public ICollectionView SourceCollection => MenuItemsCollection.View;

        public ComandosDaTelaPrincipal()
        {
            ObservableCollection<ListaDeItemsDoMenu> menuItems = new()
            {
                new ListaDeItemsDoMenu{ MenuName = "Página Inicial" },
                new ListaDeItemsDoMenu{ MenuName = "Gerenciar Dados" },
                new ListaDeItemsDoMenu{ MenuName = "Consultas e Relatórios" },
                new ListaDeItemsDoMenu{ MenuName = "Aposentadoria" },
                new ListaDeItemsDoMenu{ MenuName = "Categorias" },
                new ListaDeItemsDoMenu{ MenuName = "SubCategorias" },
                new ListaDeItemsDoMenu{ MenuName = "Cadastrar Anos" },
                 new ListaDeItemsDoMenu{ MenuName = "Nome de Bancos de Dados" },
            };
            MenuItemsCollection = new CollectionViewSource { Source = menuItems };

            // Configura a página de inicialização.
            SelecionarControleDeUsuario = new PaginaInicial();
        }

        private void ExibirPaginaInicial()
        {
            SelecionarControleDeUsuario = new PaginaInicial();
        }

        private ICommand _comandoVoltarPaginaInicial;
        public ICommand ComandoVoltarPaginaInicial
        {
            get
            {
                if (_comandoVoltarPaginaInicial == null)
                {
                    _comandoVoltarPaginaInicial = new RelayCommand(param => ExibirPaginaInicial());
                }
                return _comandoVoltarPaginaInicial;
            }
        }

        private ICommand _comandoDoMenu;
        public ICommand ComandoDoMenu
        {
            get
            {
                _comandoDoMenu = new RelayCommand(param => MenuDoMenuInicial(param));
                return _comandoDoMenu;
            }
        }
        public void MenuDoMenuInicial(object parameter)
        {

            try
            {
                switch (SelecionarControleDeUsuario = parameter)
                {
                    case "Página Inicial":
                        SelecionarControleDeUsuario = new PaginaInicial();
                        break;
                    case "Gerenciar Dados":
                        SelecionarControleDeUsuario = new CentralDeDadosView();
                        break;
                    case "Consultas e Relatórios":
                        //SelecionarControleDeUsuario = new MenuDeConsultasERelatorios();
                        break;
                    case "Aposentadoria":
                        SelecionarControleDeUsuario = new AposentadoriaView();
                        break;
                    case "Categorias":
                        SelecionarControleDeUsuario = new CategoriaView();
                        break;
                    case "SubCategorias":
                        SelecionarControleDeUsuario = new SubCategoriaView();
                        break;
                    case "Cadastrar Anos":
                        SelecionarControleDeUsuario = new AnoView();
                        break;
                    case "Nome de Bancos de Dados":
                        SelecionarControleDeUsuario = new NomeDeBancoView();
                        break;
                    default:
                        SelecionarControleDeUsuario = new PaginaInicial();
                        break;
                }
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "MenuDoMenuInicial";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
        }

        public static void AbrirBancoDeDados()
        {
            Process.Start("C:\\Program Files (x86)\\Microsoft SQL Server Management Studio 19\\Common7\\IDE\\Ssms.exe");
        }

        private ICommand _comandoAbrirBancoDeDados;
        public ICommand ComandoAbrirBancoDeDados
        {
            get
            {
                _comandoAbrirBancoDeDados = new RelayCommand(param => AbrirBancoDeDados());
                return _comandoAbrirBancoDeDados;
            }
        }

        public static void SairDoAplicativo()
        {
            Application.Current.MainWindow.Close();
        }

        private ICommand _comandoSairDoAplicativo;
        public ICommand ComandoSairDoAplicativo
        {
            get
            {
                _comandoSairDoAplicativo = new RelayCommand(param => SairDoAplicativo());
                return _comandoSairDoAplicativo;
            }
        }
    }
}
