#nullable disable
using Database.Models;
using Domain.DataAccess;
using Domain.Lists;
using Domain.Reports;
using FinancialApp.Commands;
using System;
using System.Collections.Generic;

namespace FinancialApp.ViewModels
{
    public class CentralDeDadosViewModel : CentralDeDadosCommand
    {
        #region |===============================| Propriedades |======================================================|

        

        #endregion

        #region |===============================| Construtor de Despesa ViewModel |===================================|

        public CentralDeDadosViewModel()
        {

            //Carregar ComboBox Anos
            Ano_DA _ano_DA = new();                       
            ListaDeAnos = _ano_DA.ConsultarAnos();

            //DataGrid Valores
            RelatorioDeDespesas relatorioDeDespesas = new();
            ListaDeValoresMeses = new ListaDeValoresMeses();
            ListaDeValoresMeses = relatorioDeDespesas.ConsultarDespesasTotais(ListaDeAnos[0].AnoDoCadastro);

            //Lista Genérica de Meses            
            ListaDeMeses = new List<string>();
            ListaDeMeses = ListaGenericaDeMeses.CarregarComboBoxDeMeses();

            //Lista de Tipos da Central de Dados
            ListaDeTiposDaCentralDeDados = new List<string>();
            ListaDeTiposDaCentralDeDados = ListaDeTipos.ListaDeTodosOsTipos();            

            //Lista do Filtro de Controle
            ListaDeFiltrosDeControles = new ListaDeFiltrosDeControle();
            ListaDeFiltrosDeControles = FiltroDeControle_DA.ConsultarFiltrosDeControle();

            //DataGrid Dados
            CentralDeDados_DA = new();
            //ListaDaCentralDeDados = CentralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(ListaDeAnos[0].AnoDoCadastro);

            ListaDaCentralDeDados = CentralDeDados_DA.ConsultarFiltroSelecionadoNoComboBox
                       (ListaDeFiltrosDeControles[0].NomeDoFiltro, Convert.ToInt32(ListaDeAnos[0].AnoDoCadastro));
        }
        #endregion
    }
}
