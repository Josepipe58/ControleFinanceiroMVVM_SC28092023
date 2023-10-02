#nullable disable
using System.Collections.ObjectModel;

namespace Database.Models
{
    public class Categoria : BaseModelo
    {
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

        private string _nomeDaCategoria;
        public string NomeDaCategoria
        {
            get { return _nomeDaCategoria; }
            set
            {
                _nomeDaCategoria = value;
                OnPropertyChanged(nameof(NomeDaCategoria));
            }
        }

        private int _filtroDeControleId;
        public int FiltroDeControleId
        {
            get { return _filtroDeControleId; }
            set
            {
                _filtroDeControleId = value;
                OnPropertyChanged(nameof(FiltroDeControleId));
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

        public Categoria() { }

        public Categoria(Categoria categoria)
        {
            Id = categoria.Id;            
            NomeDaCategoria = categoria.NomeDaCategoria;
            FiltroDeControleId = categoria.FiltroDeControleId;
            NomeDoFiltro = categoria.NomeDoFiltro;
        }
    }

    public class ListaDeCategorias : ObservableCollection<Categoria> { }
}
