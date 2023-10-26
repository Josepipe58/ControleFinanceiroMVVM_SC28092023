#nullable disable
using AppFinanceiroMVVM.Commandos;
using System.Windows.Input;

namespace AppFinanceiroMVVM.ViewModels.AnosVM
{
    public partial class AnoViewModel//Comandos
    {
        //Cadastrar
        private ICommand _comandoDeCadastrarAno;
        public ICommand ComandoDeCadastrarAno
        {
            get
            {
                _comandoDeCadastrarAno ??=
                    new RelayCommand(param => Cadastrar(Ano));
                return _comandoDeCadastrarAno;
            }
        }
        
        //Alterar
        private ICommand _comandoDeAlterarAno;
        public ICommand ComandoDeDeAlterarAno
        {
            get
            {
                _comandoDeAlterarAno ??= new RelayCommand(param =>
                    Alterar(Ano));
                return _comandoDeAlterarAno;
            }
        }
       
        //Comando Excluir
        private ICommand _comandoDeExcluirAno;
        public ICommand ComandoDeDeExcluirAno
        {
            get
            {
                _comandoDeExcluirAno ??= new RelayCommand(param =>
                    Excluir(Ano));
                return _comandoDeExcluirAno;
            }
        }

        //Limpar e atualizar dados
        private ICommand _comandoDeAtualizarAno;
        public ICommand ComandoDeDeAtualizarAno
        {
            get
            {
                _comandoDeAtualizarAno ??= new RelayCommand(param =>
                LimparEAtualizarDados());
                return _comandoDeAtualizarAno;
            }
        }
    }
}
