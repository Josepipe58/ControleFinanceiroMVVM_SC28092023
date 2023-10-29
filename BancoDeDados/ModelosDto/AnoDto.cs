using System.Collections.ObjectModel;

namespace BancoDeDados.ModelosDto
{
    public class AnoDto
    {        
        public int Id { get; set; }

        public int AnoDoCadastro { get; set; }
       

        public AnoDto(){ }

        public AnoDto(AnoDto anoDto)
        {
            Id = anoDto.Id;
            AnoDoCadastro = anoDto.AnoDoCadastro;
        }       
    }

    public class ListaDeAnos : ObservableCollection<AnoDto> { }
}
