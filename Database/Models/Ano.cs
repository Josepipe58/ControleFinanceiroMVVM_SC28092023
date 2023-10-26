using System.Collections.ObjectModel;

namespace Database.Models
{
    public class Ano : BaseModelo
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

        private int _anoDoCadastro;
        public int AnoDoCadastro
        {
            get { return _anoDoCadastro; }
            set
            {
                _anoDoCadastro = value;
                OnPropertyChanged(nameof(AnoDoCadastro));
            }
        }

        public Ano(){ }

        public Ano(Ano ano)
        {
            Id = ano.Id;
            AnoDoCadastro = ano.AnoDoCadastro;
        }       
    }

    public class ListaDeAnos : ObservableCollection<Ano> { }
}
