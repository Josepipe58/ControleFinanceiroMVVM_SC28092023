#nullable disable
using System.Collections.ObjectModel;

namespace Database.Models
{
    public class SubCategoria : BaseModelo
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

        private string _nomeSubCategoria;
        public string NomeDaSubCategoria
        {
            get { return _nomeSubCategoria; }
            set
            {
                _nomeSubCategoria = value;
                OnPropertyChanged(nameof(NomeDaSubCategoria));
            }
        }

        private int _categoriaId;
        public int CategoriaId
        {
            get { return _categoriaId; }
            set
            {
                _categoriaId = value;
                OnPropertyChanged(nameof(CategoriaId));
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

        private string _pesquisar;
        public string Pesquisar
        {
            get { return _pesquisar; }
            set
            {
                _pesquisar = value;
                OnPropertyChanged(nameof(Pesquisar));
            }
        }

        public SubCategoria() { }

        public SubCategoria(SubCategoria subCategoria)
        {
            Id = subCategoria.Id;
            NomeDaSubCategoria = subCategoria.NomeDaSubCategoria;
            CategoriaId = subCategoria.CategoriaId;
            NomeDaCategoria = subCategoria.NomeDaCategoria;
            FiltroDeControleId = subCategoria.FiltroDeControleId;
            NomeDoFiltro = subCategoria.NomeDoFiltro;
        }
    } 

    public class ListaDeSubCategorias : ObservableCollection<SubCategoria> { }
}
