using BancoDeDados.ModelosDto;

namespace AppFinanceiroMVVM.Modelos
{
    public class Ano : BaseModelos
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

        public Ano(AnoDto anoDto)
        {
            Id = anoDto.Id;
            AnoDoCadastro = anoDto.AnoDoCadastro;
        }       
    }
}
