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
    /// Help.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Help : Window
    {
        int nowpagenum;
        public Help()
        {
            InitializeComponent();

            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            prevbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.왼쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            nowpageimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.help1.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            nextbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.오른쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            nowpagenum = 1;
            NowPageNumCheck();
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

        private void prevbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (nowpagenum <= 1)
                return;

            nowpagenum -= 1;

            NowPageNumCheck();
        }

        private void nextbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (nowpagenum >= 5)
                return;

            nowpagenum += 1;

            NowPageNumCheck();
        }

        private void NowPageNumCheck()
        {
            setImage(nowpagenum);
        }

        private void setImage(int now)
        {
            page1image.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.notnowpage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            page2image.Source = page1image.Source;
            page3image.Source = page1image.Source;
            page4image.Source = page1image.Source;
            page5image.Source = page1image.Source;

            BitmapSource NewSource = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.nowpage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

           switch(now)
           {
               case 1: page1image.Source = NewSource; nowsteptext.Text = "[ STEP 1 ]";
                   break;
               case 2: page2image.Source = NewSource; nowsteptext.Text = "[ STEP 2 ]";
                   break;
               case 3: page3image.Source = NewSource; nowsteptext.Text = "[ STEP 3 ]";
                   break;
               case 4: page4image.Source = NewSource; nowsteptext.Text = "[ STEP 4 ]";
                   break;
               case 5: page5image.Source = NewSource; nowsteptext.Text = "[ STEP 5 ]";
                   break;
               default: break;
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

        private void prevbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            prevbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.왼쪽_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void prevbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            prevbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.왼쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void nextbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            nextbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.오른쪽_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void nextbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            nextbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.오른쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}

