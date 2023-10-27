#nullable disable
using AppFinanceiroMVVM.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Windows;

namespace AppFinanceiroMVVM.ViewModels.NomeDeBancoVM
{
    public partial class NomeDeBancoViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(NomeDeBanco nomeDeBanco)
        {
            if (nomeDeBanco.Id == 0 && nomeDeBanco.NomeDoBanco != null && nomeDeBanco.NomeDoBanco != "")
            {
                try
                {
                    NomeDeBanco_AD nomeDeBanco_AD = new();
                    NomeDeBancoDto.NomeDoBanco = nomeDeBanco.NomeDoBanco;

                    string retorno = nomeDeBanco_AD.Cadastrar(NomeDeBancoDto);
                    int codigoDeRetorno = Convert.ToInt32(retorno);

                    GerenciarMensagens.SucessoAoCadastrar(codigoDeRetorno);
                    LimparEAtualizarDados();

                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Cadastrar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (nomeDeBanco.Id > 0 && nomeDeBanco.NomeDoBanco != null)
            {
                GerenciarMensagens.ErroAoCadastrar();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }

        //Alterar
        public void Alterar(NomeDeBanco nomeDeBanco)
        {
            if (nomeDeBanco.Id > 0 && nomeDeBanco.NomeDoBanco != null && nomeDeBanco.NomeDoBanco != "")
            {
                try
                {
                    NomeDeBanco_AD nomeDeBanco_AD = new();
                    NomeDeBancoDto.Id = nomeDeBanco.Id;
                    NomeDeBancoDto.NomeDoBanco = nomeDeBanco.NomeDoBanco;

                    nomeDeBanco_AD.Alterar(NomeDeBancoDto);

                    GerenciarMensagens.SucessoAoAlterar(NomeDeBancoDto.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (nomeDeBanco.Id == 0 && nomeDeBanco.NomeDoBanco != null)
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }

        //Excluir
        public void Excluir(NomeDeBanco nomeDeBanco)
        {
            if (nomeDeBanco.Id > 0 && nomeDeBanco.NomeDoBanco != null && nomeDeBanco.NomeDoBanco != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(nomeDeBanco.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparEAtualizarDados();
                    return;
                }
                try
                {
                    NomeDeBanco_AD nomeDeBanco_AD = new();
                    NomeDeBancoDto.Id = nomeDeBanco.Id;

                    nomeDeBanco_AD.Excluir(NomeDeBancoDto);

                    GerenciarMensagens.SucessoAoExcluir(NomeDeBancoDto.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (nomeDeBanco.Id == 0 && nomeDeBanco.NomeDoBanco != null)
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                return;
            }
        }

        //Limpar e Atualizar Dados
        public void LimparEAtualizarDados()
        {
            NomeDeBanco.Id = 0;
            NomeDeBanco.NomeDoBanco = null;

            //DataGrid Dados
            NomeDeBanco_AD nomeDeBanco_AD = new();
            ListaDeNomeDeBancos = nomeDeBanco_AD.ConsultarNomeDeBancos();
        }
    }
}
