using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Forms;
using System.Drawing;

namespace MSCH
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private System.Windows.Forms.NotifyIcon MyNotifyIcon = new System.Windows.Forms.NotifyIcon();
        private System.Windows.Forms.ContextMenu MyContextMenu = new System.Windows.Forms.ContextMenu();
        private System.Windows.Forms.MenuItem MyMenuItem1 = new System.Windows.Forms.MenuItem();
        private System.Windows.Forms.MenuItem MyMenuItem2 = new System.Windows.Forms.MenuItem();
        public MainWindow()
        {


            InitializeComponent();
            MyNotifyIcon.Icon = new System.Drawing.Icon(@"D:\rocejfi15\MSCH\MSCH\pics\icon.ico");
            MyNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MyNotifyIcon_MouseDoubleClick);
            MyContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { MyMenuItem1 });
            MyContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { MyMenuItem2 });
            MyMenuItem1.Index = 0;
            MyMenuItem1.Text = "Exit";
            MyMenuItem1.Click += new System.EventHandler(this.MyMenuItem1_Click);
            MyMenuItem2.Index = 1;
            MyMenuItem2.Text = "Open";
            MyMenuItem2.Click += new System.EventHandler(this.MyMenuItem2_Click);
            this.DataContext = new MvvmlightCommandViewModel();


        }

        void MyNotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                MyNotifyIcon.ContextMenu = MyContextMenu;
                MyNotifyIcon.BalloonTipTitle = "Minimize Sucessful";
                MyNotifyIcon.BalloonTipText = "Minimized the app ";
                MyNotifyIcon.ShowBalloonTip(400);
                MyNotifyIcon.Visible = true;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                MyNotifyIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        void MyNotifyIcon_Click(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        void MyMenuItem1_Click(object Sender, EventArgs e)
        {
            Close();
        }

        void MyMenuItem2_Click(object Sender, EventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }


    }
}