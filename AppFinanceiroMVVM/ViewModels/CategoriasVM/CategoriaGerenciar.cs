#nullable disable
using AppFinanceiroMVVM.Modelos;
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
            if (ValidarCadastrar(categoria) == true)
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
        }

        //Alterar
        public void Alterar(Categoria categoria)
        {
            if (ValidarAlterarExcluir(categoria) == true)
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
                    Categoria_AD categoria_DA = new();
                    CategoriaDto.Id = categoria.Id;

                    categoria_DA.Excluir(CategoriaDto);

                    GerenciarMensagens.SucessoAoExcluir(CategoriaDto.Id);
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
