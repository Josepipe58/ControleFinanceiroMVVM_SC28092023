﻿using System;
using System.Collections.ObjectModel;

namespace Database.Models
{
    public class Aposentadoria : BaseModelo
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

        private int _anoDoIndice;
        public int AnoDoIndice
        {
            get { return _anoDoIndice; }
            set
            {
                _anoDoIndice = value;
                OnPropertyChanged(nameof(AnoDoIndice));
            }
        }

        private int _anoDoReajuste;
        public int AnoDoReajuste
        {
            get { return _anoDoReajuste; }
            set
            {
                _anoDoReajuste = value;
                OnPropertyChanged(nameof(AnoDoReajuste));
            }
        }

        private decimal _indiceDoAumento;
        public decimal IndiceDoAumento
        {
            get { return _indiceDoAumento; }
            set
            {
                _indiceDoAumento = value;
                OnPropertyChanged(nameof(IndiceDoAumento));
            }
        }

        private decimal _valorDoAumento;
        public decimal ValorDoAumento
        {
            get { return _valorDoAumento; }
            set
            {
                _valorDoAumento = value;
                OnPropertyChanged(nameof(ValorDoAumento));
            }
        }

        private decimal _atualizarValor;
        public decimal AtualizarValor
        {
            get { return _atualizarValor; }
            set
            {
                _atualizarValor = value;
                OnPropertyChanged(nameof(AtualizarValor));
            }
        }

        private decimal _saldoAtual;
        public decimal SaldoAtual
        {
            get { return _saldoAtual; }
            set
            {
                _saldoAtual = value;
                OnPropertyChanged(nameof(SaldoAtual));
            }
        }

        public Aposentadoria(){ }

        public Aposentadoria(Aposentadoria aposentadoria)
        {
            Id = aposentadoria.Id;
            Data = aposentadoria.Data;
            AnoDoIndice = aposentadoria.AnoDoIndice;
            AnoDoReajuste = aposentadoria.AnoDoReajuste;
            IndiceDoAumento = aposentadoria.IndiceDoAumento;
            ValorDoAumento = aposentadoria.ValorDoAumento;
            AtualizarValor = aposentadoria.AtualizarValor;
            SaldoAtual = aposentadoria.SaldoAtual;
        }
    }

    public class ListaDeAposentadoria : ObservableCollection<Aposentadoria> { }
}
