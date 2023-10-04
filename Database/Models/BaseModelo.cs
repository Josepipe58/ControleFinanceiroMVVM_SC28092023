using System.ComponentModel;

namespace Database.Models
{
    public class BaseModelo : INotifyPropertyChanged
    {
        #region |===========================| Interface INotifyPropertyChanged |================================|
       
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void Dispose() { }
        #endregion
    }
}
