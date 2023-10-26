#nullable disable
using BancoDeDados.ModelosDto;
using System.Collections.ObjectModel;

namespace AppFinanceiroMVVM.Modelos
{
    public class NomeDeBanco : BaseModelos
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

        public NomeDeBanco() { }

        public NomeDeBanco(NomeDeBancoDto nomeDeBancoDto)
        {
            Id = nomeDeBancoDto.Id;
            NomeDoBanco = nomeDeBancoDto.NomeDoBanco;

        }
    }
}
