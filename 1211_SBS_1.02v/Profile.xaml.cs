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
    /// Profile.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Profile : Window
    {
        page_mainControl maincontrol;
        public page_scannerlistControl scannercontrol;
        public page_beaconlistControl beaconlist;
        public page_beaconMapControl beaconmap;
        public string icon;
        public Profile(page_mainControl mc)
        {
            InitializeComponent();
            maincontrol = mc;
            dogImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.강아지_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            whaleImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고래__프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            catImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고양이_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            selectimagebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.이미지선택.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            logoutbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.logout.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minibtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void dogImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            icon = "dog";
            dogImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.강아지_프로필＿ｏｎ２.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            whaleImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고래__프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            catImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고양이_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        }

        private void whaleImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            icon = "whale";
            dogImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.강아지_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            whaleImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고래__프로필＿ｏｎ２.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            catImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고양이_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void catImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            icon = "cat";
            dogImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.강아지_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            whaleImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고래__프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            catImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고양이_프로필＿ｏｎ２.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void selectimagebtn_Click(object sender, RoutedEventArgs e)
        {
            WBServer.Singleton.setProfileIcon(icon);
            string nowicon = WBServer.Singleton.getProfileIcon();
            if (nowicon == "dog")
            {
                maincontrol.proflieicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.강아지_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            if (nowicon == "whale")
            {
                maincontrol.proflieicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고래__프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            if (nowicon == "cat")
            {
                maincontrol.proflieicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고양이_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }

            this.Close();
        }

        private void logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            WBServer.Singleton.nowchangeid = null;



            WBServer.Singleton.mybeacon.Clear();
            WBServer.Singleton.sclist.Clear();
            scannercontrol.scannerlist.Clear();

            scannercontrol.initpage();
            beaconmap.beaconlist = beaconlist.beaconlist;
            beaconmap.initpage();
            scannercontrol.ScannerListfresh();

            beaconlist.BeaconListfresh();
            beaconmap.BeaconListfresh();

            maincontrol.proflieimage.Width = 0;
            maincontrol.proflieicon.Width = 0;
            maincontrol.preferencesimagebtn.Width = 0;
            maincontrol.tb_loginid.Text = "";
            maincontrol.loginbtn.Height = 100;
            maincontrol.signupbtn.Height = 100;
            this.Close();

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

        private void selectimagebtn_MouseEnter(object sender, MouseEventArgs e)
        {
            selectimagebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.이미지선택＿ｏｎ.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void selectimagebtn_MouseLeave(object sender, MouseEventArgs e)
        {
            selectimagebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.이미지선택.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void logoutbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            logoutbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.logout_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void logoutbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            logoutbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.logout.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }


        private void TitleBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
