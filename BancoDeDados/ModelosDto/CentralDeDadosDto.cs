#nullable disable
using System;
using System.Collections.ObjectModel;

namespace BancoDeDados.ModelosDto
{
    public class CentralDeDadosDto
    {
        public int Id { get; set; }
       
        public string NomeDaCategoria { get; set; }
        
        public string NomeDaSubCategoria { get; set; }
       
        public decimal Valor { get; set; }
        
        public string Filtros { get; set; }
        
        public string Tipo { get; set; }
        
        public DateTime Data { get; set; }
      
        public string Mes { get; set; }
        
        public int Ano { get; set; }
        
        public CentralDeDadosDto(){ }

        public CentralDeDadosDto(CentralDeDadosDto centralDeDadosDto)
        {
            Id = centralDeDadosDto.Id;
            NomeDaCategoria = centralDeDadosDto.NomeDaCategoria;
            NomeDaSubCategoria = centralDeDadosDto.NomeDaSubCategoria;
            Valor = centralDeDadosDto.Valor;
            Filtros = centralDeDadosDto.Filtros;
            Tipo = centralDeDadosDto.Tipo;
            Data = centralDeDadosDto.Data;
            Mes = centralDeDadosDto.Mes;
            Ano = centralDeDadosDto.Ano;
        }
    }

    public class ListaDaCentralDeDados : ObservableCollection<CentralDeDadosDto> { }
}
