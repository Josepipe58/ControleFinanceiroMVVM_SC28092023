#nullable disable
using AppFinanceiroMVVM.Commandos;
using System.Windows.Input;

namespace AppFinanceiroMVVM.ViewModels.AposentadoriaVM
{
    public partial class AposentadoriaViewModel//Comandos
    {
        //Cadastrar
        private ICommand _comandoDeCadastrarAposentadoria;
        public ICommand ComandoDeCadastrarAposentadoria
        {
            get
            {
                _comandoDeCadastrarAposentadoria ??=
                    new RelayCommand(param => Cadastrar(Aposentadoria));
                return _comandoDeCadastrarAposentadoria;
            }
        }
        
        //Alterar
        private ICommand _comandoDeAlterarAposentadoria;
        public ICommand ComandoDeDeAlterarAposentadoria
        {
            get
            {
                _comandoDeAlterarAposentadoria ??= new RelayCommand(param =>
                    Alterar(Aposentadoria));
                return _comandoDeAlterarAposentadoria;
            }
        }
       
        //Comando Excluir
        private ICommand _comandoDeExcluirAposentadoria;
        public ICommand ComandoDeDeExcluirAposentadoria
        {
            get
            {
                _comandoDeExcluirAposentadoria ??= new RelayCommand(param =>
                    Excluir(Aposentadoria));
                return _comandoDeExcluirAposentadoria;
            }
        }

        //Calcular Aposentadoria
        private ICommand _comandoDeCalcularAposentadoria;
        public ICommand ComandoDeDeCalcularAposentadoria
        {
            get
            {
                _comandoDeCalcularAposentadoria ??= new RelayCommand(param =>
                CalcularReajusteDaAposentadoria());
                return _comandoDeCalcularAposentadoria;
            }
        }

        //Limpar e atualizar dados
        private ICommand _comandoDeAtualizarAposentadoria;
        public ICommand ComandoDeDeAtualizarAposentadoria
        {
            get
            {
                _comandoDeAtualizarAposentadoria ??= new RelayCommand(param =>
                AtualizarDados());
                return _comandoDeAtualizarAposentadoria;
            }
        }
    }
}
