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
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class variable : Window
    {
        public page_beaconlistControl pagebeaconlist;
        public variable()
        {
            InitializeComponent();

            upbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.위.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            downbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.아래.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            upbtn2.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.위.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            downbtn2.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.아래.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            upbtn3.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.위.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            downbtn3.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.아래.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            upbtn4.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.위.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            downbtn4.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.아래.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            upbtn5.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.위.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            downbtn5.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.아래.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            upbtn6.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.위.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            downbtn6.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.아래.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            resetbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.초기화.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            savebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.저장.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            WBServer.Singleton.getRSSI(WBServer.Singleton.nowchangeid, WBServer.Singleton.enterBname);

            try
            {

                value1.Text = WBServer.Singleton.enterW1;
                value4.Text = WBServer.Singleton.enterY1;
                value2.Text = WBServer.Singleton.enterW2;
                value5.Text = WBServer.Singleton.enterY2;
                value3.Text = WBServer.Singleton.enterW3;
                value6.Text = WBServer.Singleton.enterY3;
                sc1value.Text = WBServer.Singleton.sclist[0] + ": " + WBServer.Singleton.enterDistance1;
                sc2value.Text = WBServer.Singleton.sclist[1] + ": " + WBServer.Singleton.enterDistance2;
                sc3value.Text = WBServer.Singleton.sclist[2] + ": " + WBServer.Singleton.enterDistance3;
            }
            catch
            {

            }

        }

        public string rssitodis_ex(string rssi, double W, double Y)
        {
            string dis = string.Empty;
            //===============================================
            double TXpower = -59;
            double n = 2;

            double RSSI = double.Parse(rssi);
            double a = ((W * TXpower - Y * RSSI) / (10 * n));
            double d = Math.Pow(10, a);
            double think = Math.Log(-RSSI, 22);
            double pow = Math.Pow(d, 2);
            double log = Math.Log(d, think);

            if (log <= 0)
            {

                dis += pow.ToString();
            }
            else
            {

                dis += log.ToString();
            }

            return (Math.Round(double.Parse(dis), 2) + "M(" + RSSI + ")").ToString();
        }

        //=======================Dis1 W1 Y1=======================
        private void upbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterW1);
            num += 0.01;
            WBServer.Singleton.enterW1 = num.ToString();
            value1.Text = WBServer.Singleton.enterW1;

            WBServer.Singleton.enterDistance1 = rssitodis_ex(WBServer.Singleton.enterRssi1,
                double.Parse(WBServer.Singleton.enterW1), double.Parse(WBServer.Singleton.enterY1));

            sc1value.Text = WBServer.Singleton.sclist[0] + ": " + WBServer.Singleton.enterDistance1;
        }
        private void upbtn4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterY1);
            num += 0.01;
            WBServer.Singleton.enterY1 = num.ToString();
            value4.Text = WBServer.Singleton.enterY1;

            WBServer.Singleton.enterDistance1 = rssitodis_ex(WBServer.Singleton.enterRssi1,
                double.Parse(WBServer.Singleton.enterW1), double.Parse(WBServer.Singleton.enterY1));

            sc1value.Text = WBServer.Singleton.sclist[0] + ": " + WBServer.Singleton.enterDistance1;
        }
        //==============================================
        private void upbtn2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterW2);
            num += 0.01;
            WBServer.Singleton.enterW2 = num.ToString();
            value2.Text = WBServer.Singleton.enterW2;

            WBServer.Singleton.enterDistance2 = rssitodis_ex(WBServer.Singleton.enterRssi2,
                double.Parse(WBServer.Singleton.enterW2), double.Parse(WBServer.Singleton.enterY2));

            sc2value.Text = WBServer.Singleton.sclist[1] + ": " + WBServer.Singleton.enterDistance2;
        }
        private void upbtn5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterY2);
            num += 0.01;
            WBServer.Singleton.enterY2 = num.ToString();
            value5.Text = WBServer.Singleton.enterY2;

            WBServer.Singleton.enterDistance2 = rssitodis_ex(WBServer.Singleton.enterRssi2,
                double.Parse(WBServer.Singleton.enterW2), double.Parse(WBServer.Singleton.enterY2));

            sc2value.Text = WBServer.Singleton.sclist[1] + ": " + WBServer.Singleton.enterDistance2;
        }
        //==============================================
        private void upbtn3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterW3);
            num += 0.01;
            WBServer.Singleton.enterW3 = num.ToString();
            value3.Text = WBServer.Singleton.enterW3;

            WBServer.Singleton.enterDistance3 = rssitodis_ex(WBServer.Singleton.enterRssi3,
                double.Parse(WBServer.Singleton.enterW3), double.Parse(WBServer.Singleton.enterY3));

            sc3value.Text = WBServer.Singleton.sclist[2] + ": " + WBServer.Singleton.enterDistance3;
        }
        private void upbtn6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterY3);
            num += 0.01;
            WBServer.Singleton.enterY3 = num.ToString();
            value6.Text = WBServer.Singleton.enterY3;

            WBServer.Singleton.enterDistance3 = rssitodis_ex(WBServer.Singleton.enterRssi3,
                double.Parse(WBServer.Singleton.enterW3), double.Parse(WBServer.Singleton.enterY3));

            sc3value.Text = WBServer.Singleton.sclist[2] + ": " + WBServer.Singleton.enterDistance3;
        }
        //==============================================

        private void upbtn_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void upbtn4_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void upbtn_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void upbtn4_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void upbtn2_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void upbtn5_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void upbtn2_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void upbtn5_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void upbtn3_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void upbtn6_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void upbtn3_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void upbtn6_MouseLeave(object sender, MouseEventArgs e)
        {

        }


        //==============================================
        private void downbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterW1);
            num -= 0.01;
            WBServer.Singleton.enterW1 = num.ToString();
            value1.Text = WBServer.Singleton.enterW1;

            WBServer.Singleton.enterDistance1 = rssitodis_ex(WBServer.Singleton.enterRssi1,
                double.Parse(WBServer.Singleton.enterW1), double.Parse(WBServer.Singleton.enterY1));

            sc1value.Text = WBServer.Singleton.sclist[0] + ": " + WBServer.Singleton.enterDistance1;
        }
        private void downbtn4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterY1);
            num -= 0.01;
            WBServer.Singleton.enterY1 = num.ToString();
            value4.Text = WBServer.Singleton.enterY1;

            WBServer.Singleton.enterDistance1 = rssitodis_ex(WBServer.Singleton.enterRssi1,
                double.Parse(WBServer.Singleton.enterW1), double.Parse(WBServer.Singleton.enterY1));

            sc1value.Text = WBServer.Singleton.sclist[0] + ": " + WBServer.Singleton.enterDistance1;
        }
        //==============================================
        private void downbtn2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterW2);
            num -= 0.01;
            WBServer.Singleton.enterW2 = num.ToString();
            value2.Text = WBServer.Singleton.enterW2;

            WBServer.Singleton.enterDistance2 = rssitodis_ex(WBServer.Singleton.enterRssi2,
                double.Parse(WBServer.Singleton.enterW2), double.Parse(WBServer.Singleton.enterY2));

            sc2value.Text = WBServer.Singleton.sclist[1] + ": " + WBServer.Singleton.enterDistance2;
        }
        private void downbtn5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterY2);
            num -= 0.01;
            WBServer.Singleton.enterY2 = num.ToString();
            value5.Text = WBServer.Singleton.enterY2;

            WBServer.Singleton.enterDistance2 = rssitodis_ex(WBServer.Singleton.enterRssi2,
                double.Parse(WBServer.Singleton.enterW2), double.Parse(WBServer.Singleton.enterY2));

            sc2value.Text = WBServer.Singleton.sclist[1] + ": " + WBServer.Singleton.enterDistance2;
        }
        //==============================================
        private void downbtn3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterW3);
            num -= 0.01;
            WBServer.Singleton.enterW3 = num.ToString();
            value3.Text = WBServer.Singleton.enterW3;

            WBServer.Singleton.enterDistance3 = rssitodis_ex(WBServer.Singleton.enterRssi3,
                double.Parse(WBServer.Singleton.enterW3), double.Parse(WBServer.Singleton.enterY3));

            sc3value.Text = WBServer.Singleton.sclist[2] + ": " + WBServer.Singleton.enterDistance3;
        }
        private void downbtn6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterY3);
            num -= 0.01;
            WBServer.Singleton.enterY3 = num.ToString();
            value6.Text = WBServer.Singleton.enterY3;

            WBServer.Singleton.enterDistance3 = rssitodis_ex(WBServer.Singleton.enterRssi3,
                double.Parse(WBServer.Singleton.enterW3), double.Parse(WBServer.Singleton.enterY3));

            sc3value.Text = WBServer.Singleton.sclist[2] + ": " + WBServer.Singleton.enterDistance3;
        }
        //==============================================


        private void downbtn_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void downbtn4_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void downbtn_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void downbtn4_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void downbtn2_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void downbtn5_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void downbtn2_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void downbtn5_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void downbtn3_MouseEnter(object sender, MouseEventArgs e)
        {

        }
        private void downbtn6_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void downbtn3_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private void downbtn6_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void savebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WBServer.Singleton.saveValue(WBServer.Singleton.nowchangeid, "scanner1", WBServer.Singleton.enterBname, value1.Text, value4.Text);
            WBServer.Singleton.saveValue(WBServer.Singleton.nowchangeid, "scanner2", WBServer.Singleton.enterBname, value2.Text, value5.Text);
            WBServer.Singleton.saveValue(WBServer.Singleton.nowchangeid, "scanner3", WBServer.Singleton.enterBname, value3.Text, value6.Text);
            this.Close();
        }

        private void savebtn_MouseEnter(object sender, MouseEventArgs e)
        {
            savebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.저장＿ｏｎ.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void savebtn_MouseLeave(object sender, MouseEventArgs e)
        {
            savebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.저장.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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
        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minibtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void resetbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double num = double.Parse(WBServer.Singleton.enterW1);
            num = 0.33;
            WBServer.Singleton.enterW1 = num.ToString();
            value1.Text = WBServer.Singleton.enterW1;

            double num2 = double.Parse(WBServer.Singleton.enterY1);
            num2 = 0.5;
            WBServer.Singleton.enterY1 = num2.ToString();
            value4.Text = WBServer.Singleton.enterY1;

            WBServer.Singleton.enterDistance1 = rssitodis_ex(WBServer.Singleton.enterRssi1,
                double.Parse(WBServer.Singleton.enterW1), double.Parse(WBServer.Singleton.enterY1));

            sc1value.Text = WBServer.Singleton.sclist[0] + ": " + WBServer.Singleton.enterDistance1;


            WBServer.Singleton.enterW2 = num.ToString();
            value2.Text = WBServer.Singleton.enterW2;

            WBServer.Singleton.enterY2 = num2.ToString();
            value5.Text = WBServer.Singleton.enterY2;

            WBServer.Singleton.enterDistance2 = rssitodis_ex(WBServer.Singleton.enterRssi2,
                double.Parse(WBServer.Singleton.enterW2), double.Parse(WBServer.Singleton.enterY2));

            sc2value.Text = WBServer.Singleton.sclist[1] + ": " + WBServer.Singleton.enterDistance2;


            WBServer.Singleton.enterW3 = num.ToString();
            value3.Text = WBServer.Singleton.enterW3;



            WBServer.Singleton.enterY3 = num2.ToString();
            value6.Text = WBServer.Singleton.enterY3;

            WBServer.Singleton.enterDistance3 = rssitodis_ex(WBServer.Singleton.enterRssi3,
                double.Parse(WBServer.Singleton.enterW3), double.Parse(WBServer.Singleton.enterY3));

            sc3value.Text = WBServer.Singleton.sclist[2] + ": " + WBServer.Singleton.enterDistance3;
        }

        private void resetbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            resetbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.초기화.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void resetbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            resetbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.초기화＿ｏｎ.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void TitleBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
