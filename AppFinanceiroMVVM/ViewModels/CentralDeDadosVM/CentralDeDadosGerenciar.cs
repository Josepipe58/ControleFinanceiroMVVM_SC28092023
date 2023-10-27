#nullable disable
using AppFinanceiroMVVM.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Consultas;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;
using GerenciarDados.Relatorios;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace AppFinanceiroMVVM.ViewModels.CentralDeDadosVM
{
    public partial class CentralDeDadosViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(CentralDeDados centralDeDados)
        {
            if (centralDeDados.Id == 0 && centralDeDados.Valor > 0)
            {
                try
                {
                    CentralDeDados_AD centralDeDados_AD = new();
                    CentralDeDadosDto.NomeDaCategoria = centralDeDados.NomeDaCategoria;
                    CentralDeDadosDto.NomeDaSubCategoria = centralDeDados.NomeDaSubCategoria;
                    CentralDeDadosDto.Valor = Convert.ToDecimal(centralDeDados.Valor);
                    CentralDeDadosDto.Filtros = centralDeDados.Filtros;
                    CentralDeDadosDto.Tipo = centralDeDados.Tipo;
                    CentralDeDadosDto.Data = Convert.ToDateTime(centralDeDados.Data);
                    CentralDeDadosDto.Mes = centralDeDados.Mes;
                    CentralDeDadosDto.Ano = Convert.ToInt32(centralDeDados.Ano);

                    string retorno = centralDeDados_AD.Cadastrar(CentralDeDadosDto);
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
            else if (centralDeDados.Id > 0 && centralDeDados.Valor > 0)
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
        public void Alterar(CentralDeDados centralDeDados)
        {
            if (centralDeDados.Id > 0 && centralDeDados.Valor > 0)
            {
                try
                {
                    CentralDeDados_AD centralDeDados_AD = new();
                    CentralDeDadosDto.Id = centralDeDados.Id;
                    CentralDeDadosDto.NomeDaCategoria = centralDeDados.NomeDaCategoria;
                    CentralDeDadosDto.NomeDaSubCategoria = centralDeDados.NomeDaSubCategoria;
                    CentralDeDadosDto.Valor = Convert.ToDecimal(centralDeDados.Valor);
                    CentralDeDadosDto.Filtros = centralDeDados.Filtros;
                    CentralDeDadosDto.Tipo = centralDeDados.Tipo;
                    CentralDeDadosDto.Data = Convert.ToDateTime(centralDeDados.Data);
                    CentralDeDadosDto.Mes = centralDeDados.Mes;
                    CentralDeDadosDto.Ano = Convert.ToInt32(centralDeDados.Ano);

                    centralDeDados_AD.Alterar(CentralDeDadosDto);

                    GerenciarMensagens.SucessoAoAlterar(CentralDeDadosDto.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (centralDeDados.Id == 0 && centralDeDados.Valor > 0)
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
        public void Excluir(CentralDeDados centralDeDados)
        {
            if (centralDeDados.Id > 0 && centralDeDados.Valor > 0)
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(centralDeDados.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    CentralDeDados_AD centralDeDados_AD = new();

                    CentralDeDadosDto.Id = centralDeDados.Id;

                    centralDeDados_AD.Excluir(CentralDeDadosDto);

                    GerenciarMensagens.SucessoAoExcluir(CentralDeDadosDto.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (centralDeDados.Id == 0 && centralDeDados.Valor > 0)
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

        public void DataGridDaCentralDeDadosEValores(string filtro, int ano)
        {
            CentralDeDados.Filtros = filtro;
            ListaDeAnos[0].AnoDoCadastro = ano;
            try
            {
                CentralDeDados_AD centralDeDados_AD = new();
                FiltroDeControle_AD filtroDeControle_DA = new();
                ListaDeFiltrosDeControles = filtroDeControle_DA.ConsultarFiltrosDeControle();
                ListaDaCentralDeDados = centralDeDados_AD.ConsultarFiltroSelecionadoNoComboBox(CentralDeDados.Filtros, ListaDeAnos[0].AnoDoCadastro);

                if (ListaDeFiltrosDeControles[0].NomeDoFiltro == "Despesas")
                {
                    RelatorioDeDespesas relatorioDeDespesas = new();
                    ListaDeValoresMeses = relatorioDeDespesas.ConsultarDespesasTotais(ListaDeAnos[0].AnoDoCadastro);
                    LblTituloDtgValores = "Despesa Geral - Mensal e Anual";
                }
                else if (ListaDeFiltrosDeControles[0].NomeDoFiltro == "Poupança")
                {
                    RelatorioDePoupanca relatorioDePoupanca_AD = new();
                    ListaDeValoresMeses = relatorioDePoupanca_AD
                        .ConsultarSaldoTotalDaPoupancaReceitasEInvestimentos(ListaDeAnos[0].AnoDoCadastro);
                    LblTituloDtgValores = "Saldo Total da Poupança";
                }
                else if (ListaDeFiltrosDeControles[0].NomeDoFiltro == "Investimentos")
                {
                    RelatorioDeInvestimentos relatorioDeInvestimentos_AD = new();
                    ListaDeValoresMeses = relatorioDeInvestimentos_AD
                        .ConsultarSaldoTotalDeInvestimentos(ListaDeAnos[0].AnoDoCadastro);
                    LblTituloDtgValores = "Saldo Total de Investimentos.";
                }
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "DataGridDaCentralDeDadosEValores";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
            SaldoDaCarteiraPoupancaEInvestimentos(ListaDeAnos[0].AnoDoCadastro);
        }

        public void SaldoDaCarteiraPoupancaEInvestimentos(int ano)
        {
            ListaDeAnos[0].AnoDoCadastro = ano;
            try
            {
                SaldoDaCarteiraPoupancaEInvestimento saldoDaCarteiraPoupancaEInvestimento = new();

                SaldoDaCarteira = Convert.ToDecimal(saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDaCarteiraPorAno(ListaDeAnos[0].AnoDoCadastro));

                SaldoDaPoupanca = Convert.ToDecimal(saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDaPoupanca(ListaDeAnos[0].AnoDoCadastro));

                SaldoDeInvestimento = Convert.ToDecimal(saldoDaCarteiraPoupancaEInvestimento.ConsultarSaldoDeInvestimentos(ListaDeAnos[0].AnoDoCadastro));

                SaldoPoupancaEInvestimento = SaldoDaPoupanca + SaldoDeInvestimento;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoDaCarteiraPoupancaEInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return;
            }
        }

        //Limpar Dados
        public void LimparDados()
        {
            //Atenção! Não juntar esse método com AtualizarDados() para não limpar ComboBoxes ao fazer CRUD.            
            CentralDeDados.Id = 0;
            CentralDeDados.Valor = 0;

            //SaldoDaCarteiraPoupancaEInvestimentos();
            DataGridDaCentralDeDadosEValores(CentralDeDados.Filtros, ListaDeAnos[0].AnoDoCadastro);
        }

        //Atualizar Dados 
        public void AtualizarDados()
        {
            DateTime mes = DateTime.Now;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var mesAtual = textInfo.ToTitleCase(mes.ToString("MMMM"));
            var dataAtual = textInfo.ToTitleCase(mes.ToString("dd/MM/yyyy"));

            CentralDeDados.Data = Convert.ToDateTime(dataAtual);
            CentralDeDados.Tipo = ListaDeTipos.ListaDeTodosOsTipos()[0];
            CentralDeDados.Mes = mesAtual.ToString();
            CentralDeDados.Ano = ListaDeAnos[0].AnoDoCadastro;
            CentralDeDados.Filtros = ListaDeFiltrosDeControles[0].NomeDoFiltro;
            LblTituloDtgValores = "Despesa Geral - Mensal e Anual";
            LimparDados();
        }
    }
}
