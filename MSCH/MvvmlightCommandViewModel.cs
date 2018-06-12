using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace MSCH
{
    /// <summary>
    /// INotifyPropertyChanged je nutné pro funkčnost eventu PropertyChanged
    /// </summary>
    internal class MvvmlightCommandViewModel : INotifyPropertyChanged
    {
        private int _numberOfClicks;
        /// <summary>
        ///     Veřejné přístupové rozhraní pro proměnnou, která je iterována pomocí Buttonu
        /// </summary>
        public int NumberOfClicks
        {
            get => _numberOfClicks;
            set
            {
                _numberOfClicks = value;
                // Po změně hodnoty proměnné je nutné oznámit View tuto změnu, aby se mohlo View obnovit (refresh)
                OnPropertyChanged("NumberOfClicks");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Metoda volaná Commandem, který je Bindovaný na Button
        /// </summary>
        private void ClickMethod()
        {
            NumberOfClicks++;
        }


        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}