using Database.Models;
using Domain.DataAccess;
using Domain.Lists;
using Domain.Reports;
using ManageData.Commands;
using System.Collections.Generic;

namespace FinancialApp.ViewModels
{
    public class CentralDeDadosViewModel : ComandosDaCentralDeDados
    {
        #region |===============================| Propriedades |======================================================|

        public CentralDeDados_DA centralDeDados_DA;
        public Ano_DA ano_DA;

        //Lista de Tipos
        public List<string> ListaTipoDeDespesa { get; set; }

        //Lista de Meses
        public List<string> ListaDeMeses { get; set; }

        #endregion

        #region |===============================| Construtor de Despesa ViewModel |===================================|

        public CentralDeDadosViewModel()
        {
            //Não deletar essa instância porque está sendo usada na DespesaView.
            CentralDeDados = new();

            //Carregar ComboBox Anos
            ano_DA = new();
            ListaDeAnos = new ListaDeAnos();
            ListaDeAnos = ano_DA.ConsultarAnos();

            //DataGrid Dados           
            centralDeDados_DA = new();
            ListaDaCentralDeDados = centralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(ListaDeAnos[0].AnoDoCadastro);


            //DataGrid Valores
            RelatorioDeDespesa relatorioDeDespesa = new();
            ListaDeValoresMeses = new ListaDeValoresMeses();
            ListaDeValoresMeses = relatorioDeDespesa.RelatorioDeDespesasTotais(ListaDeAnos[0].AnoDoCadastro);

            //Lista Genérica de Meses            
            ListaDeMeses = new List<string>();
            ListaDeMeses = ListaGenericaDeMeses.CarregarComboBoxDeMeses();

            //Lista de Tipo de Despesa
            ListaTipoDeDespesa = new List<string>();
            ListaTipoDeDespesa = ListaDeTipos.ListaDeTodosOsTipos();
        }
        #endregion
    }
}
