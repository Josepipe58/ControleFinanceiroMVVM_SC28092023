#nullable disable
using BancoDeDados.ModelosDto;
using System.Collections.ObjectModel;

namespace AppFinanceiroMVVM.Modelos
{
    public class SubCategoria : BaseModelos
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
        
        //Essas propriedades são usadas como objeto de transferência ou variáveis.
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
        
        //Essa propriedade pertence ao TextBox de pesquisar por SubCategorias.
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

        public SubCategoria(SubCategoriaDto subCategoriaDto)
        {
            Id = subCategoriaDto.Id;
            NomeDaSubCategoria = subCategoriaDto.NomeDaSubCategoria;
            CategoriaId = subCategoriaDto.CategoriaId;
            NomeDaCategoria = subCategoriaDto.NomeDaCategoria;
            FiltroDeControleId = subCategoriaDto.FiltroDeControleId;
            NomeDoFiltro = subCategoriaDto.NomeDoFiltro;
        }
    }
}
