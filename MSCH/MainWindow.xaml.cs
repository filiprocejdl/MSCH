using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace MSCH
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            
        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            UInt32 pvParam,
            UInt32 fWinIni);


        public MainWindow()
        {
            InitializeComponent();
        }

        //CHANGE const MOUSESPEED 
        private void Button_Fast(object sender, RoutedEventArgs e)
        {
            const UInt32 SPI_SETMOUSESPEED = 0x0071;
            const UInt32 MOUSESPEED = 10;

            SystemParametersInfo(
                SPI_SETMOUSESPEED,
                0,
                MOUSESPEED,
                0);

        }

        private void Button_Slow(object sender, RoutedEventArgs e)
        {
            const UInt32 SPI_SETMOUSESPEED = 0x0071;
            const UInt32 MOUSESPEED = 1;

            SystemParametersInfo(
                SPI_SETMOUSESPEED,
                0,
                MOUSESPEED,
                0);
        }

        private void Button_Normal(object sender, RoutedEventArgs e)
        {
            const UInt32 SPI_SETMOUSESPEED = 0x0071;
            const UInt32 MOUSESPEED = 5;

            SystemParametersInfo(
                SPI_SETMOUSESPEED,
                0,
                MOUSESPEED,
                0);
        }
    }
}
