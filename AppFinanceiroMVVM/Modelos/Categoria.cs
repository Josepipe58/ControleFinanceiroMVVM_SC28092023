#nullable disable
using BancoDeDados.ModelosDto;
using System.Collections.ObjectModel;

namespace AppFinanceiroMVVM.Modelos
{
    public class Categoria : BaseModelos
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

        //Essa propriedade é usada como objeto de transferência ou variável.
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

        public Categoria(CategoriaDto categoriaDto)
        {
            Id = categoriaDto.Id;            
            NomeDaCategoria = categoriaDto.NomeDaCategoria;
            FiltroDeControleId = categoriaDto.FiltroDeControleId;
            NomeDoFiltro = categoriaDto.NomeDoFiltro;
        }
    }
}
