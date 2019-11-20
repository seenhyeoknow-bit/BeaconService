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
    /// page_mainControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class page_mainControl : UserControl
    {
        public page_beaconlistControl pagebeaconList;
        public page_scannerlistControl pagescannerList;
        public page_beaconMapControl pagebeaconMap;

        public page_mainControl()
        {
            InitializeComponent();

            backgroundimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.SolBeaconServiceUI_1.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            tb_loginid.Text = "";
            proflieicon.Width = 0;
            proflieicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.프로필_추가.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            preferencesimagebtn.Width = 0;
            preferencesimagebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.설정.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            proflieimage.Width = 0;
            proflieimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            loginbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_03.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            signupbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            beaconlistbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_12.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            scannerlistbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_14.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            beaconmapbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_16.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            helpbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_19.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            fapbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_21.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            infobtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_30.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        }

        private void beaconlistbtn_Click(object sender, RoutedEventArgs e)
        {
            pagebeaconList.Width = 1100;
            pagescannerList.Width = 0;
            pagebeaconMap.Width = 0;
            this.Width = 0;
        }

        private void scannerlistbtn_Click(object sender, RoutedEventArgs e)
        {
            pagebeaconList.Width = 0;
            pagescannerList.Width = 1100;
            pagebeaconMap.Width = 0;
            this.Width = 0;
        }

        private void beaconmapbtn_Click(object sender, RoutedEventArgs e)
        {
            pagebeaconList.Width = 0;
            pagescannerList.Width = 0;
            pagebeaconMap.Width = 1100;
            this.Width = 0;
        }

        private void helpbtn_Click(object sender, RoutedEventArgs e)
        {
            Help helpform = new Help();
            helpform.ShowDialog();
        }

        private void fapbtn_Click(object sender, RoutedEventArgs e)
        {
            FAQ faqform = new FAQ();
            faqform.ShowDialog();
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            Login loginform = new Login(this);
            loginform.scannercontrol = pagescannerList;
            loginform.beaconlist = pagebeaconList;
            loginform.beaconmap = pagebeaconMap;
            loginform.ShowDialog();
        }

        private void signupbtn_Click(object sender, RoutedEventArgs e)
        {
            SignUp signupform = new SignUp();
            signupform.ShowDialog();
        }

        private void infobtn_Click(object sender, RoutedEventArgs e)
        {
            Info infoform = new Info();
            infoform.ShowDialog();
        }

        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (((Image)sender).Name.Equals("loginbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_03_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("signupbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("beaconlistbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_12_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("scannerlistbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_14_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("beaconmapbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_16_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("helpbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_19_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("fapbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_21_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("infobtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_30_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (((Image)sender).Name.Equals("loginbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_03.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("signupbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("beaconlistbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_12.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("scannerlistbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_14.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("beaconmapbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_16.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("helpbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_19.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("fapbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_21.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("infobtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_30.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }



        private void preferencesimagebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Profile profileform = new Profile(this);
            profileform.scannercontrol = pagescannerList;
            profileform.beaconlist = pagebeaconList;
            profileform.beaconmap = pagebeaconMap;
            profileform.ShowDialog();
        }

        private void preferencesimagebtn_MouseEnter(object sender, MouseEventArgs e)
        {
            preferencesimagebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.설정_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void preferencesimagebtn_MouseLeave(object sender, MouseEventArgs e)
        {
            preferencesimagebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.설정.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
