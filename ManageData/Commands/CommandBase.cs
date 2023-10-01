#nullable disable
using System.ComponentModel;

namespace ManageData.Commands
{
    public class CommandBase : RelayCommand, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
