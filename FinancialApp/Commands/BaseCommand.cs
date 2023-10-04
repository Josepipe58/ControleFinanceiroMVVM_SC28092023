#nullable disable
using System.ComponentModel;

namespace FinancialApp.Commands
{
    public class BaseCommand : RelayCommand, INotifyPropertyChanged
    {
        #region |=================================| Comandos |==================================================|
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
