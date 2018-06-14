using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace MSCH
{
    /// <summary>
    /// INotifyPropertyChanged je nutné pro funkčnost eventu PropertyChanged
    /// </summary>
    /// 

    internal class MvvmlightCommandViewModel : INotifyPropertyChanged
    {
        const UInt32 SPI_SETMOUSESPEED = 0x0071;

        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            UInt32 pvParam,
            UInt32 fWinIni);


        private int _SpeedValue;
        public int SpeedValue
        {
            get => _SpeedValue;
            set
            {
                _SpeedValue = value;

                OnPropertyChanged("SpeedValue");
            }
        }

        private void MouseSpeed(int speed)
        {
            UInt32 MOUSESPEED = (uint)speed;

            SystemParametersInfo(
                SPI_SETMOUSESPEED,
                0,
                MOUSESPEED,
                0);

            Console.Write("funguje");

        }

        public RelayCommand<int> ChangeSpeed { get; }

        public MvvmlightCommandViewModel()
        {
            ChangeSpeed = new RelayCommand<int>(MouseSpeed);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }



    }
}