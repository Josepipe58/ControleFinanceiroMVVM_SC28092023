#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Messages;
using ManageData.DataValidation;
using System;
using System.Windows;

namespace ManageData
{
    public class Ano_MD : Ano_DV
    {
        #region |=================================| Propriedades |==================================================|

        private ListaDeAnos _listaDeAnos;
        public ListaDeAnos ListaDeAnos
        {
            get { return _listaDeAnos; }
            set
            {
                if (_listaDeAnos != value)
                {
                    _listaDeAnos = value;
                    OnPropertyChanged(nameof(ListaDeAnos));
                }
            }
        }
        #endregion

        #region |=================================| Construtor |====================================================|

        public Ano_MD()
        {
            ListaDeAnos = new ListaDeAnos();
        }
        #endregion

        #region |=================================| Métodos |=======================================================|

        //|=================================| Cadastrar |==========================================|

        public void Cadastrar(Ano ano)
        {
            if (ValidarCadastrar(ano) == true)
            {
                try
                {
                    Ano_DA ano_DA = new();
                    string retorno = ano_DA.Cadastrar(ano);
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
        //|=================================| Alterar |============================================|

        public void Alterar(Ano ano)
        {
            if (ValidarAlterarExcluir(ano) == true)
            {
                try
                {
                    Ano_DA ano_DA = new();
                    ano_DA.Alterar(ano);
                    GerenciarMensagens.SucessoAoAlterar(ano.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    GerenciarMensagens.ErroDeAlterar(erro);
                }
            }
        }
        //|=================================| Excluir |============================================|

        public void Excluir(Ano ano)
        {
            if (ValidarAlterarExcluir(ano) == true)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(ano.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparEAtualizarDados();
                    return;
                }
                try
                {
                    Ano_DA ano_DA = new();
                    ano_DA.Excluir(ano);
                    GerenciarMensagens.SucessoAoExcluir(ano.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    GerenciarMensagens.ErroDeExcluir(erro);
                }
            }
        }
        //|=================================| Limpar e Atualizar Dados |===========================|

        public void LimparEAtualizarDados()
        {
            Ano_DA ano_DA = new();
            Ano.Id = 0;
            Ano.AnoDoCadastro = 0;
            ListaDeAnos = ano_DA.ConsultarAnos();
        }
        #endregion
    }
}
