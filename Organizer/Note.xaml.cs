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
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Organizer
{
    /// <summary>
    /// Логика взаимодействия для Note.xaml
    /// </summary>
    public partial class Note : Window
    {
        public Note()
        {
            InitializeComponent();
            
        }


        Point old;
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y,
        int cx, int cy, uint uFlags);

        public const int HWND_BOTTOM = 0x1;
        public const uint SWP_NOSIZE = 0x1;
        public const uint SWP_NOMOVE = 0x2;
        public const uint SWP_SHOWWINDOW = 0x40;

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr window, int index, int value);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr window, int index);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public static void HideFromAltTab(IntPtr Handle)
        {
            SetWindowLong(Handle,
                          GWL_EXSTYLE,
                          GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }

        private IntPtr Handle
        {
            get
            {
                return new WindowInteropHelper(this).Handle;
            }
        }

        private void Note_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point cur = e.GetPosition(null);

                this.Left += cur.X - old.X;
                this.Top += cur.Y - old.Y;
            }
        }

        private void Note_MouseDown(object sender, MouseButtonEventArgs e)
        {
            old = e.GetPosition(null);
        }
 
        private void ShoveToBackground()
        {
            SetWindowPos((int)this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE |
                SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShoveToBackground();
            HideFromAltTab(Handle);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
