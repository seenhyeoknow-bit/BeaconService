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
    /// FindID.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindID : Window
    {
        public FindID()
        {
            InitializeComponent();
            tbname.Focus();
            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            findidbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findid.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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
            if (tbname.Text.Trim() == string.Empty || tbemail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("이름과 이메일을 입력하세요");
                return;
            }
            if (WBServer.Singleton.FindID(tbname.Text.Trim(), tbemail.Text.Trim())=="false")//Trim 공백제거
            {
                MessageBox.Show("회원정보가 없습니다.");
                return;
               
            }
            if (youridtext.Text.Equals("고객님의 ID : "))
                youridtext.Text += WBServer.Singleton.FindID(tbname.Text.Trim(), tbemail.Text.Trim());
            else
                return;
           
          

        }

        private void findidbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            findidbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findid_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void findidbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            findidbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findid.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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

    }
}
