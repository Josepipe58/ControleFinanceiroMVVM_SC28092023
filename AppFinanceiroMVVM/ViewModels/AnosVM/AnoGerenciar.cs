using AppFinanceiroMVVM.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Windows;

namespace AppFinanceiroMVVM.ViewModels.AnosVM
{
    public partial class AnoViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(Ano ano)
        {
            if (ValidarCadastrar(ano) == true)
            {
                try
                {
                    Ano_AD ano_AD = new();
                    AnoDto.AnoDoCadastro = ano.AnoDoCadastro;

                    string retorno = ano_AD.Cadastrar(AnoDto);
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
        }

        //Alterar
        public void Alterar(Ano ano)
        {
            if (ValidarAlterarExcluir(ano) == true)
            {
                try
                {
                    Ano_AD ano_AD = new();
                    AnoDto.Id = ano.Id;
                    AnoDto.AnoDoCadastro = ano.AnoDoCadastro;

                    ano_AD.Alterar(AnoDto);

                    GerenciarMensagens.SucessoAoAlterar(AnoDto.Id);
                    LimparEAtualizarDados();
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
                    Ano_AD ano_AD = new();
                    AnoDto.Id = ano.Id;

                    ano_AD.Excluir(AnoDto);

                    GerenciarMensagens.SucessoAoExcluir(AnoDto.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
        }

        //Limpar e Atualizar Dados
        public void LimparEAtualizarDados()
        {
            //AnoDto anoDto = new();
            Ano_AD ano_AD = new();
            Ano.Id = 0;
            Ano.AnoDoCadastro = 0;
            ListaDeAnos = ano_AD.ConsultarAnos();
        }
    }
}
