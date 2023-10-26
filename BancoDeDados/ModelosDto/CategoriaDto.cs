#nullable disable
using System.Collections.ObjectModel;

namespace BancoDeDados.ModelosDto
{
    public class CategoriaDto
    {
        public int Id { get; set; }

        public string NomeDaCategoria { get; set; }

        public int FiltroDeControleId { get; set; }

        //Essa propriedade é usada como objeto de transferência ou variável.
        public string NomeDoFiltro { get; set; }

        public CategoriaDto() { }

        public CategoriaDto(CategoriaDto categoriaDto)
        {
            Id = categoriaDto.Id;            
            NomeDaCategoria = categoriaDto.NomeDaCategoria;
            FiltroDeControleId = categoriaDto.FiltroDeControleId;
            NomeDoFiltro = categoriaDto.NomeDoFiltro;
        }
    }

    public class ListaDeCategorias : ObservableCollection<CategoriaDto> { }
}
