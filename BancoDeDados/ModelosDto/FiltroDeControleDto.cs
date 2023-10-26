#nullable disable
using System.Collections.ObjectModel;

namespace BancoDeDados.ModelosDto
{
    public class FiltroDeControleDto
    {
        public int Id { get; set; }
       
        public string NomeDoFiltro { get; set; }

        public FiltroDeControleDto(){ }

        public FiltroDeControleDto(FiltroDeControleDto filtroDeControleDto)
        {
            Id = filtroDeControleDto.Id;
            NomeDoFiltro = filtroDeControleDto.NomeDoFiltro;
        }
    }

    public class ListaDeFiltrosDeControle : ObservableCollection<FiltroDeControleDto> { }
}
