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
using System.Windows.Shapes;

namespace _1211_SBS_1._02v
{
    /// <summary>
    /// InsertBeacon.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class InsertBeacon : Window
    {
        public page_beaconlistControl pagebeaconlist;
         BeaconList beaconlist = new BeaconList();
        public InsertBeacon()
        {
            InitializeComponent();

            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            scaningimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.로딩_중.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            beaconlistLB.ItemsSource = null;
           
            
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

        private void scaningimage_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Thread.Sleep(867);
            beaconlistLB.ItemsSource = WBServer.Singleton.blist;
            scaningimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.완료.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            scaningtext.Text = "스캔 완료!";
        }

        private void beaconlistLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                
                    WBServer.Singleton.mybeacon.Clear();
                   
             
           

                    WBServer.Singleton.getBeaconlist(beaconlistLB.SelectedValue.ToString());
                  
                    WBServer.Singleton.getData(WBServer.Singleton.nowchangeid);

                   
                     pagebeaconlist.BeaconListfresh();
                    
                    this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인을 해주세요");
                this.Close();
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

    }
}

