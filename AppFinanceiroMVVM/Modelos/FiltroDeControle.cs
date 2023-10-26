#nullable disable
using BancoDeDados.ModelosDto;
using System.Collections.ObjectModel;

namespace AppFinanceiroMVVM.Modelos
{
    public class FiltroDeControle : BaseModelos
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

        public FiltroDeControle(){ }

        public FiltroDeControle(FiltroDeControleDto filtroDeControleDto)
        {
            Id = filtroDeControleDto.Id;
            NomeDoFiltro = filtroDeControleDto.NomeDoFiltro;
        }
    }
}
