#nullable disable
using System.Collections.ObjectModel;

namespace BancoDeDados.ModelosDto
{
    public class NomeDeBancoDto
    {
        public int Id { get; set; }
     
        public string NomeDoBanco { get; set; }

        public NomeDeBancoDto() { }

        public NomeDeBancoDto(NomeDeBancoDto nomeDeBancoDto)
        {
            Id = nomeDeBancoDto.Id;
            NomeDoBanco = nomeDeBancoDto.NomeDoBanco;           
        }
    }

    public class ListaDeNomeDeBancos : ObservableCollection<NomeDeBancoDto> { }
}
