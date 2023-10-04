#nullable disable
using System.Collections.ObjectModel;

namespace Database.Models
{
    public class FiltroDeControle :BaseModelo
    {
        #region |=========================| Propriedades da Tabela FiltroDeControles |==========================|
        
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _nomeDoFiltro;
        public string NomeDoFiltro
        {
            get { return _nomeDoFiltro; }
            set
            {
                _nomeDoFiltro = value;
                OnPropertyChanged(nameof(NomeDoFiltro));
            }
        }

        public FiltroDeControle(){ }

        public FiltroDeControle(FiltroDeControle filtroDeControle)
        {
            Id = filtroDeControle.Id;
            NomeDoFiltro = filtroDeControle.NomeDoFiltro;
        }
        #endregion
    }

    public class ListaDeFiltrosDeControle : ObservableCollection<FiltroDeControle> { }
}
