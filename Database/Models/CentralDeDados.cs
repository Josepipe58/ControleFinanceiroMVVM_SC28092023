#nullable disable
using System;
using System.Collections.ObjectModel;

namespace Database.Models
{
    public class CentralDeDados : BaseModelo
    {
        #region |=========================| Propriedades da Tabela CentralDeDados |=============================|
        
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

        public CentralDeDados(CentralDeDados centralDeDados)
        {
            Id = centralDeDados.Id;
            NomeDaCategoria = centralDeDados.NomeDaCategoria;
            NomeDaSubCategoria = centralDeDados.NomeDaSubCategoria;
            Valor = centralDeDados.Valor;
            Filtros = centralDeDados.Filtros;
            Tipo = centralDeDados.Tipo;
            Data = centralDeDados.Data;
            Mes = centralDeDados.Mes;
            Ano = centralDeDados.Ano;
        }
        #endregion
    }

    public class ListaDaCentralDeDados : ObservableCollection<CentralDeDados> { }
}
