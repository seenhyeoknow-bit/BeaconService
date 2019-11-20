using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace _1211_SBS_1._02v
{
    /// <summary>
    /// page_beaconlistControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class page_beaconlistControl : UserControl
    {
        DispatcherTimer timer = null;
        public BeaconList beaconlist;
        public page_beaconlistControl()
        {
            InitializeComponent();
            BeaconInsertbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.비콘_추가.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Beaconrefreshbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.새로_고침.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();


        }


        public void timer_Tick(object sender, EventArgs e)
        {
            timerBeacon();

        }

        private void preferencesImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.설정_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void preferencesImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.설정.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void preferencesImage_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Setting settingform = new Setting();
            settingform.pagebeaconlist = this;
            settingform.ShowDialog();
        }

        private void BeaconInsertbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            InsertBeacon insertbeaconform = new InsertBeacon();
            insertbeaconform.pagebeaconlist = this;
            insertbeaconform.ShowDialog();
        }

        private void Beaconrefreshbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                ininbeacon();

            }
            catch
            {
                MessageBox.Show("오류");
            }


        }
        public void ininbeacon()
        {
            if (WBServer.Singleton.nowchangeid != null)
            {
                WBServer.Singleton.mybeacon.Clear();
                WBServer.Singleton.rssilist.Clear();

                for (int i = 0; i < beaconlistLB.Items.Count; i++)
                {
                    
                    beaconlistLB.SelectedIndex = i;

                    WBServer.Singleton.getBeaconlist(((Beacon)beaconlistLB.SelectedValue).BeaconName);
                }


                WBServer.Singleton.getData(WBServer.Singleton.nowchangeid);
                BeaconListfresh();
            }
        }

        public void timerBeacon()
        {
            ininbeacon();

        }
        public void BeaconListfresh()
        {

            try
            {

                menuDock.DataContext = null;    

                menuDock.DataContext = beaconlist;
                beaconlist.AddList();
                beaconlistLB.Items.Refresh();
            }
            catch (Exception ex)
            {

            }




        }



        private void ListBoxItem_MouseEnter(object s, MouseEventArgs e)
        {
            if (WBServer.Singleton.nowchangeid != null)
            {

                var item = e.OriginalSource as ListBoxItem;

                WBServer.Singleton.enterBname = ((Beacon)item.Content).BeaconName;
                WBServer.Singleton.enterW1 = ((Beacon)item.Content).W1;
                WBServer.Singleton.enterY1 = ((Beacon)item.Content).Y1;
                WBServer.Singleton.enterW2 = ((Beacon)item.Content).W2;
                WBServer.Singleton.enterY2 = ((Beacon)item.Content).Y2;
                WBServer.Singleton.enterW3 = ((Beacon)item.Content).W3;
                WBServer.Singleton.enterY3 = ((Beacon)item.Content).Y3;
                WBServer.Singleton.enterDistance1 = ((Beacon)item.Content).Distance1;
                WBServer.Singleton.enterDistance2 = ((Beacon)item.Content).Distance2;
                WBServer.Singleton.enterDistance3 = ((Beacon)item.Content).Distance3;

            }

        }

        private void BeaconInsertbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            BeaconInsertbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.비콘_추가_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void BeaconInsertbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            BeaconInsertbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.비콘_추가.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void Beaconrefreshbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Beaconrefreshbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.새로_고침_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void Beaconrefreshbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Beaconrefreshbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.새로_고침.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }



        private void batteryImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            variable variableform = new variable();
            variableform.pagebeaconlist = this;
            variableform.ShowDialog();
        }


        private void batteryImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.스캐너설정＿ｏｎ.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void batteryImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.스캐너설정.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }








    }
}
