#nullable disable
using System.Collections.ObjectModel;

namespace Database.Models
{
    public class NomeDoBancoDeDados : BaseModelo
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

        private string _nomeDoBanco;
        public string NomeDoBanco
        {
            get { return _nomeDoBanco; }
            set
            {
                _nomeDoBanco = value;
                OnPropertyChanged(nameof(NomeDoBanco));
            }
        }

        public NomeDoBancoDeDados(){ }

        public NomeDoBancoDeDados(NomeDoBancoDeDados nomeDeBanco)
        {
            Id = nomeDeBanco.Id;
            NomeDoBanco = nomeDeBanco.NomeDoBanco;
        }
    }

    public class ListaDeNomeDeBancos : ObservableCollection<NomeDoBancoDeDados> { }
}
