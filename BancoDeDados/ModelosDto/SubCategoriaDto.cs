#nullable disable
using System.Collections.ObjectModel;

namespace BancoDeDados.ModelosDto
{
    public class SubCategoriaDto
    {
        public int Id { get; set; }
       
        public string NomeDaSubCategoria { get; set; }
       
        public int CategoriaId { get; set; }

        //Essas propriedades são usadas como objeto de transferência ou variáveis.       
        public string NomeDaCategoria { get; set; }
       
        public int FiltroDeControleId { get; set; }
       
        public string NomeDoFiltro { get; set; }       
        
        //Essa propriedade pertence ao TextBox de pesquisar por SubCategorias.       
        public string Pesquisar { get; set; }
        

        public SubCategoriaDto() { }

        public SubCategoriaDto(SubCategoriaDto subCategoriaDto)
        {
            Id = subCategoriaDto.Id;
            NomeDaSubCategoria = subCategoriaDto.NomeDaSubCategoria;
            CategoriaId = subCategoriaDto.CategoriaId;
            NomeDaCategoria = subCategoriaDto.NomeDaCategoria;
            FiltroDeControleId = subCategoriaDto.FiltroDeControleId;
            NomeDoFiltro = subCategoriaDto.NomeDoFiltro;
        }
    }

    public class ListaDeSubCategorias : ObservableCollection<SubCategoriaDto>{ }
}
