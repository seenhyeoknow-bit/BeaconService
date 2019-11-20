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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1211_SBS_1._02v
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        BeaconList beaconlist;
        public ScannerList scannerlist;

        bool ismenumini = false;

        public MainWindow()
        {
            InitializeComponent();
            scannerlist = new ScannerList();
            beaconlist = new BeaconList();




            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            menuchangebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.메뉴.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            menutitleimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.로고_1.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            homeicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.Home_no_font.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            beaconlisticon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_12_no_font.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            scannerlisticon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_14_no_font.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            beaconmapicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_16_no_font.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            helpicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_19_no_font.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            faqicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_21_no_font.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());


            //메인 페이지에 할당
            mainpage.pagebeaconList = beaconlistpage;
            mainpage.pagescannerList = scannerlistpage;
            mainpage.pagebeaconMap = beaconmappage;

            //비콘 정보 나눠주기
            beaconlistpage.beaconlist = beaconlist;
            beaconlistpage.menuDock.DataContext = beaconlistpage.beaconlist;
            beaconmappage.beaconlist = beaconlist;
            beaconmappage.menuDock.DataContext = beaconmappage.beaconlist;

            //스캐너 정보 나눠주기
            scannerlistpage.scannerlist = scannerlist;
            scannerlistpage.menuDock.DataContext = scannerlistpage.scannerlist;

            //메인 페이지 띄우기
            mainpage.Width = 1100;
            beaconlistpage.Width = 0;
            scannerlistpage.Width = 0;
            beaconmappage.Width = 0;


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

        private void borderGomain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainpage.Width = 1100;
            beaconlistpage.Width = 0;
            scannerlistpage.Width = 0;
            beaconmappage.Width = 0;
        }

        private void borderGoBeaconList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainpage.Width = 0;
            beaconlistpage.Width = 1100;
            scannerlistpage.Width = 0;
            beaconmappage.Width = 0;
        }

        private void borderGoScanner_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainpage.Width = 0;
            beaconlistpage.Width = 0;
            scannerlistpage.Width = 1100;
            beaconmappage.Width = 0;
        }

        private void borderGoBeaconMap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainpage.Width = 0;
            beaconlistpage.Width = 0;
            scannerlistpage.Width = 0;
            beaconmappage.Width = 1100;
        }

        private void helpborder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Help helpform = new Help();
            helpform.ShowDialog();
        }

        private void faqborder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FAQ faqform = new FAQ();
            faqform.ShowDialog();
        }

        private void menuchangebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ismenumini == false)
            {
                menuborder.Width = 80;
                ismenumini = true;


                helpborder.Width = 30;
                helpborder.Height = 30;
                helpborder.Margin = new Thickness(5, 0, 0, 0);
                faqborder.Width = 30;
                faqborder.Height = 30;

                borderGomain.Height = 80;
                borderGoBeaconList.Height = 80;
                borderGoScanner.Height = 80;
                borderGoBeaconMap.Height = 80;

                menutitleimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.로고_2.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            }
            else
            {
                menuborder.Width = 200;
                ismenumini = false;

                helpborder.Width = 80;
                helpborder.Height = 65;
                helpborder.Margin = new Thickness(10, 0, 0, 0);
                faqborder.Width = 80;
                faqborder.Height = 65;

                borderGomain.Height = 65;
                borderGoBeaconList.Height = 65;
                borderGoScanner.Height = 65;
                borderGoBeaconMap.Height = 65;

                menutitleimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.로고_1.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
        }

        private void border_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background = (Brush)(new BrushConverter()).ConvertFrom("#FFE6E6E6");
        }

        private void border_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Border)sender).Background = (Brush)(new BrushConverter()).ConvertFrom("#FF979797");
        }


        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (((Image)sender).Name.Equals("menuchangebtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.메뉴_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("minibtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("closebtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (((Image)sender).Name.Equals("menuchangebtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.메뉴.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("minibtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("closebtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }


    }
}
