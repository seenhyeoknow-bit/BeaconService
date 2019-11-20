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
    /// FindPassword.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindPassword : Window
    {
        public FindPassword()
        {
            InitializeComponent();
            tbid.Focus();
            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            checkmemberbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.인증.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tbid.Text.Trim() == string.Empty || tbname.Text.Trim() == string.Empty||tbbirth.Text.Trim() == string.Empty)
   
            {
                MessageBox.Show("정보를 다 입력해주세요");
                return;
            }
            if(WBServer.Singleton.FindPW(tbid.Text.Trim(),tbname.Text.Trim(),tbbirth.Text.Trim())==false)
            {
                MessageBox.Show("입력하신 정보가 없습니다");
                return;
            }
            else
            {
                MessageBox.Show("인증되었습니다");
                WBServer.Singleton.nowchangeid = tbid.Text.Trim();
                NewPassword newpasswordform = new NewPassword();
                newpasswordform.ShowDialog();
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

        private void checkmemberbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            checkmemberbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.인증_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void checkmemberbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            checkmemberbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.인증.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

    }
}
