#nullable disable
using AppFinanceiroMVVM.Modelos;
using BancoDeDados.ModelosDto;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Windows;

namespace AppFinanceiroMVVM.ViewModels.SubCategoriasVM
{
    public partial class SubCategoriaViewModel//Gerenciar
    {

        //Cadastrar
        public void Cadastrar(SubCategoria subCategoria)
        {
            if (ValidarCadastrar(subCategoria) == true)
            {
                try
                {
                    SubCategoria_AD subCategoria_AD = new(); 
                    SubCategoriaDto.NomeDaSubCategoria = subCategoria.NomeDaSubCategoria;
                    SubCategoriaDto.CategoriaId = subCategoria.CategoriaId;

                    string retorno = subCategoria_AD.Cadastrar(SubCategoriaDto);
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
                    SubCategoria_AD subCategoria_AD = new();
                    SubCategoriaDto.Id = subCategoria.Id;
                    SubCategoriaDto.NomeDaSubCategoria = subCategoria.NomeDaSubCategoria;
                    SubCategoriaDto.CategoriaId = subCategoria.CategoriaId;

                    subCategoria_AD.Alterar(SubCategoriaDto);

                    GerenciarMensagens.SucessoAoAlterar(SubCategoriaDto.Id);
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
                    SubCategoria_AD subCategoria_AD = new();
                    SubCategoriaDto.Id = subCategoria.Id;

                    subCategoria_AD.Excluir(SubCategoriaDto);

                    GerenciarMensagens.SucessoAoExcluir(SubCategoriaDto.Id);
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
            //Também não zerar o SubCategoria.CategoriaId para não apagar o ComboBox de Categorias.
            SubCategoria_AD subCategoria_AD = new();
            SubCategoria.Id = 0;            
            SubCategoria.NomeDaSubCategoria = null;
            ListaDeSubCategorias = subCategoria_AD.ConsultarSubCategoriasPorNomeDoFiltro(SubCategoria.NomeDoFiltro);
        }

        //Limpar e Atualizar Dados
        public void AtualizarDados()
        {
            SubCategoria.NomeDoFiltro ="Despesas";  
            LimparDados();
        }
    }
}
