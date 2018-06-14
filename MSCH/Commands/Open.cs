using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MSCH
{
    class Open : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainWindow window;
        public Open(MainWindow window)
        {
            this.window = window;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {


            if (window.WindowState == WindowState.Minimized)
            {
                window.WindowState = WindowState.Normal;
            }

        }
        public override string ToString()
        {
            return "Open";
        }
    }
}