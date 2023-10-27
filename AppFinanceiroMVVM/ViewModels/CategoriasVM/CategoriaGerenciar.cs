#nullable disable
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Windows;

namespace AppFinanceiroMVVM.ViewModels.CategoriasVM
{
    public partial class CategoriaViewModel//Gerenciar
    {
        //Cadastrar
        public void Cadastrar(Categoria categoria)
        {            
            if (categoria.Id == 0 && categoria.NomeDaCategoria != null && categoria.NomeDaCategoria != "")
            {
                try
                {
                    Categoria_AD categoria_AD = new();
                    CategoriaDto.NomeDaCategoria = categoria.NomeDaCategoria;
                    CategoriaDto.FiltroDeControleId = categoria.FiltroDeControleId;

                    string retorno = categoria_AD.Cadastrar(CategoriaDto);
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
            else if (categoria.Id > 0 && categoria.NomeDaCategoria != null)
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
        public void Alterar(Categoria categoria)
        {
            if (categoria.Id > 0 && categoria.NomeDaCategoria != null && categoria.NomeDaCategoria != "")
            {
                try
                {
                    Categoria_AD categoria_DA = new();
                    CategoriaDto.Id = categoria.Id;
                    CategoriaDto.NomeDaCategoria = categoria.NomeDaCategoria;
                    CategoriaDto.FiltroDeControleId = categoria.FiltroDeControleId;

                    categoria_DA.Alterar(CategoriaDto);

                    GerenciarMensagens.SucessoAoAlterar(CategoriaDto.Id);
                    LimparDados();
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Alterar";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (categoria.Id == 0 && categoria.NomeDaCategoria != null)
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
        public void Excluir(Categoria categoria)
        {
            if (categoria.Id > 0 && categoria.NomeDaCategoria != null && categoria.NomeDaCategoria != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(categoria.Id);
                if (resultado == MessageBoxResult.No)
                {
                    LimparDados();
                    return;
                }
                try
                {
                    Categoria_AD categoria_DA = new();
                    CategoriaDto.Id = categoria.Id;
                    
                    string retorno = categoria_DA.Excluir(CategoriaDto);
                    int id = Convert.ToInt32(retorno);

                    //Esse if é exclusivo para tabelas que tem relacionamentos.
                    if (id > 0)
                    {
                        GerenciarMensagens.SucessoAoExcluir(CategoriaDto.Id);
                        LimparDados();
                        return;
                    }
                }
                catch (Exception erro)
                {
                    _nomeDoMetodo = "Excluir";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                    return;
                }
            }
            else if (categoria.Id == 0 && categoria.NomeDaCategoria != null)
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

        //Limpar
        public void LimparDados()
        {
            Categoria_AD categoria_AD = new();            
            Categoria.Id = 0;
            Categoria.NomeDaCategoria = null;
            ListaDeCategorias = categoria_AD.ConsultarCategoriasPorNomeDoFiltro(Categoria.NomeDoFiltro);
        }

        //Atualizar
        public void AtualizarDados()
        {
            Categoria.NomeDoFiltro = "Despesas";
            LimparDados();
        }
    }
}
