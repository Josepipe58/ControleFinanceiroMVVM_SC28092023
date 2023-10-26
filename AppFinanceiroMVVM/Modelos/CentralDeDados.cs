#nullable disable
using BancoDeDados.ModelosDto;
using System;
using System.Collections.ObjectModel;

namespace AppFinanceiroMVVM.Modelos
{
    public class CentralDeDados : BaseModelos
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

        private decimal _valor;
        public decimal Valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                OnPropertyChanged(nameof(Valor));
            }
        }

        private string _filtros;
        public string Filtros
        {
            get { return _filtros; }
            set
            {
                _filtros = value;
                OnPropertyChanged(nameof(Filtros));
            }
        }

        private string _tipo;
        public string Tipo
        {
            get { return _tipo; }
            set
            {
                _tipo = value;
                OnPropertyChanged(nameof(Tipo));
            }
        }

        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private string _mes;
        public string Mes
        {
            get { return _mes; }
            set
            {
                _mes = value;
                OnPropertyChanged(nameof(Mes));
            }
        }

        private int _ano;
        public int Ano
        {
            get { return _ano; }
            set
            {
                _ano = value;
                OnPropertyChanged(nameof(Ano));
            }
        }

        public CentralDeDados(){ }

        public CentralDeDados(CentralDeDadosDto centralDeDadosDto)
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
}
