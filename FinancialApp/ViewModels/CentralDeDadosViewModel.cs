using Database.Models;
using Domain.DataAccess;
using Domain.Lists;
using Domain.Reports;
using FinancialApp.Commands;
using System.Collections.Generic;

namespace FinancialApp.ViewModels
{
    public class CentralDeDadosViewModel : CentralDeDadosCommand
    {
        #region |===============================| Propriedades |======================================================|

        public CentralDeDados_DA _centralDeDados_DA;
        public Ano_DA _ano_DA;

        //Lista de Tipos
        public List<string> ListaTipoDeDespesa { get; set; }

        //Lista de Meses
        public List<string> ListaDeMeses { get; set; }

        #endregion

        #region |===============================| Construtor de Despesa ViewModel |===================================|

        public CentralDeDadosViewModel()
        {
            //Não deletar essa instância porque está sendo usada na Central de Dados.
            CentralDeDados = new CentralDeDados();

            //Carregar ComboBox Anos
            _ano_DA = new();
            ListaDeAnos = new ListaDeAnos();
            ListaDeAnos = _ano_DA.ConsultarAnos();

            //DataGrid Dados           
            _centralDeDados_DA = new();
            ListaDaCentralDeDados = _centralDeDados_DA.ConsultaGeralDaCentralDeDadosPorAno(ListaDeAnos[0].AnoDoCadastro);


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
