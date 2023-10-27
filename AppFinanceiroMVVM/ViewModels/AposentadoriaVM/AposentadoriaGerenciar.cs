using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Windows;

namespace AppFinanceiroMVVM.ViewModels.AposentadoriaVM
{
    public partial class AposentadoriaViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(Aposentadoria aposentadoria)
        {
            
            if (aposentadoria.Id == 0 && aposentadoria.AnoDoIndice > 0 && aposentadoria.AnoDoReajuste > 0 
                && aposentadoria.IndiceDoAumento > 0)
            {
                try
                {
                    Aposentadoria_AD aposentadoria_AD = new();
                   
                    AposentadoriaDto.Data = aposentadoria.Data;
                    AposentadoriaDto.AnoDoIndice = aposentadoria.AnoDoIndice;
                    AposentadoriaDto.AnoDoReajuste = aposentadoria.AnoDoReajuste;
                    //INPC
                    AposentadoriaDto.IndiceDoAumento = aposentadoria.IndiceDoAumento;
                    AposentadoriaDto.ValorDoAumento = aposentadoria.ValorDoAumento;
                    AposentadoriaDto.AtualizarValor = aposentadoria.AtualizarValor;
                    AposentadoriaDto.SaldoAtual = aposentadoria.SaldoAtual;

                    string retorno = aposentadoria_AD.Cadastrar(AposentadoriaDto);
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
            else if (aposentadoria.Id > 0 && aposentadoria.AnoDoIndice > 0 && aposentadoria.AnoDoReajuste > 0
                && aposentadoria.IndiceDoAumento > 0)
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
        public void Alterar(Aposentadoria aposentadoria)
        {
            if (aposentadoria.Id > 0 && aposentadoria.AnoDoIndice > 0 && aposentadoria.AnoDoReajuste > 0
                && aposentadoria.IndiceDoAumento > 0)
            {
                try
                {
                    Aposentadoria_AD aposentadoria_AD = new();
                    AposentadoriaDto.Id = aposentadoria.Id;
                    AposentadoriaDto.Data = aposentadoria.Data;
                    AposentadoriaDto.AnoDoIndice = aposentadoria.AnoDoIndice;
                    AposentadoriaDto.AnoDoReajuste = aposentadoria.AnoDoReajuste;
                    //INPC
                    AposentadoriaDto.IndiceDoAumento = aposentadoria.IndiceDoAumento;
                    AposentadoriaDto.ValorDoAumento = aposentadoria.ValorDoAumento;
                    AposentadoriaDto.AtualizarValor = aposentadoria.AtualizarValor;
                    AposentadoriaDto.SaldoAtual = aposentadoria.SaldoAtual;

                    aposentadoria_AD.Alterar(AposentadoriaDto);

                    GerenciarMensagens.SucessoAoAlterar(AposentadoriaDto.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (aposentadoria.Id == 0 && aposentadoria.AnoDoIndice > 0 && aposentadoria.AnoDoReajuste > 0
                && aposentadoria.IndiceDoAumento > 0)
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
        public void Excluir(Aposentadoria aposentadoria)
        {
            if (aposentadoria.Id > 0 && aposentadoria.AnoDoIndice > 0 && aposentadoria.AnoDoReajuste > 0
                && aposentadoria.IndiceDoAumento > 0)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(aposentadoria.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    Aposentadoria_AD aposentadoria_AD = new();
                    AposentadoriaDto.Id = aposentadoria.Id;

                    aposentadoria_AD.Excluir(AposentadoriaDto);

                    GerenciarMensagens.SucessoAoExcluir(AposentadoriaDto.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (aposentadoria.Id == 0 && aposentadoria.AnoDoIndice > 0 && aposentadoria.AnoDoReajuste > 0
                && aposentadoria.IndiceDoAumento > 0)
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

        public void CalcularReajusteDaAposentadoria()
        {
            try
            {
                Aposentadoria.ValorDoAumento = Aposentadoria.SaldoAtual * Aposentadoria.IndiceDoAumento / 100;
                Aposentadoria.SaldoAtual = Aposentadoria.SaldoAtual + Aposentadoria.ValorDoAumento + Aposentadoria.AtualizarValor;                
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "CalcularReajusteDaAposentadoria";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
        }

        public string InstrucaoParaCalcularReajusteDaAposentadoria()
        {
            MensagemCalcularReajusteDaAposentadoria = new string("Atenção! Para calcular o reajuste da aposentadoria, " +
                "insira um valor no campo Índice do Aumento e Clique em Calcular e Cadastrar.\nSe precisar atualizar o valor do reajuste, " +
                "faça um DoubleClick, modifique o valor e clique em Alterar.");

            return MensagemCalcularReajusteDaAposentadoria;
        }

        //Limpar e Atualizar Dados
        public void LimparDados()
        {
            Aposentadoria.Id = 0;
            Aposentadoria.Data = DateTime.Today;

            Aposentadoria_AD aposentadoria_AD = new();
            ListaDeAposentadoria = aposentadoria_AD.ConsultarAposentadoria();
        }

        //Limpar e Atualizar Dados
        public void AtualizarDados()
        {
            Aposentadoria.AnoDoIndice = DateTime.Now.Year;
            Aposentadoria.AnoDoReajuste = DateTime.Now.Year;           
            Aposentadoria.IndiceDoAumento = 0;
            Aposentadoria.ValorDoAumento = 0;
            Aposentadoria.AtualizarValor = 0;

            Aposentadoria_AD aposentadoria_AD = new();            
            Aposentadoria.SaldoAtual = aposentadoria_AD.ConsultarAposentadoria()[0].SaldoAtual;
            LimparDados();
        }
    }
}
