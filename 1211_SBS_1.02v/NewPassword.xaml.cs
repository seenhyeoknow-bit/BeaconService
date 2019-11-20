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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1211_SBS_1._02v
{
    /// <summary>
    /// NewPassword.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewPassword : Window
    {
        public bool isPwCheck { get; private set; }
        public NewPassword()
        {
            InitializeComponent();
            isPwCheck = false;
            tbpw.Focus();
            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            ChangePWbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.changepw.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minibtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ChangePWbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isPwCheck == true)
            {
                if (WBServer.Singleton.ChangePW(tbpw.Password.ToString().Trim()) == true)
                {
                    MessageBox.Show("비밀번호 변경 성공");
                }
            }
            else if (isPwCheck == false)
            {
                MessageBox.Show("비밀번호를 확인하세요");
            }

        }

        private void tbpw_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tbpw.Password.ToString().Trim().Equals(tbpw1.Password.ToString().Trim()))
            {
                checklb.Foreground = new SolidColorBrush(Colors.Blue);
                checklb.Content = "pw가 동일합니다";
                isPwCheck = true;
            }
            else
            {
                checklb.Foreground = new SolidColorBrush(Colors.Red);
                checklb.Content = "pw가 다릅니다";
                isPwCheck = false;
            }
        }

        private void minibtn_MouseEnter(object sender, MouseEventArgs e)
        {
            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void minibtn_MouseLeave(object sender, MouseEventArgs e)
        {
            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void closebtn_MouseEnter(object sender, MouseEventArgs e)
        {
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void closebtn_MouseLeave(object sender, MouseEventArgs e)
        {
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void ChangePWbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangePWbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.changepw_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void ChangePWbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangePWbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.changepw.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

    }
}

