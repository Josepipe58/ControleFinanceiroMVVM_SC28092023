﻿#nullable disable
using System.Windows.Input;

namespace FinancialApp.ManageData.Commands
{
    public class ComandosDeAno : Ano_MD
    {
        #region |=================================| Comandos |==================================================|

        //|=================================| Comando Cadastrar |==================================================|

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

        //|=================================| Comando Alterar |====================================================|

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

        //|=================================| Comando Excluir |====================================================|

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

        //|=================================| Comando Atualizar |==================================================|

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
        #endregion       
    }
}
