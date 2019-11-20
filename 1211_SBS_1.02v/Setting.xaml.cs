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
    /// Setting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Setting : Window
    {
        public page_beaconlistControl pagebeaconlist;

        public string icon;
        public Setting()
        {
            InitializeComponent();
            ringImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            personImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bookImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            remoteImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            clothesImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            selectimagebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.이미지선택.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            cancelbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.취소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            deletebeacon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.비콘삭제.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void closebtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minibtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void selectimagebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                WBServer.Singleton.setIcon(WBServer.Singleton.enterBname, icon);
                this.Close();
            }
            catch
            {
                MessageBox.Show("비콘을 먼저 선택해주세요");
                this.Close();
            }


        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ringImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            icon = "ring";
            ringImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1__on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            personImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bookImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            remoteImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            clothesImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        }

        private void personImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            icon = "person";
            ringImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            personImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2__on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bookImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            remoteImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            clothesImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void bookImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            icon = "book";
            ringImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            personImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bookImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3__on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            remoteImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            clothesImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void remoteImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            icon = "remote";
            ringImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            personImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bookImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            remoteImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4__on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            clothesImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void clothesImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            icon = "clothes";
            ringImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            personImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            bookImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            remoteImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            clothesImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5__on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void deletebeacon_Click(object sender, RoutedEventArgs e)
        {

            WBServer.Singleton.DeleteBeacon(WBServer.Singleton.nowchangeid, WBServer.Singleton.enterBname);
            WBServer.Singleton.mybeacon.Clear();
            WBServer.Singleton.rssilist.Clear();

            WBServer.Singleton.getData(WBServer.Singleton.nowchangeid);


            pagebeaconlist.BeaconListfresh();
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

        private void cancelbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            cancelbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.취소＿ｏｎ.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void cancelbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            cancelbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.취소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void deletebeacon_MouseEnter(object sender, MouseEventArgs e)
        {
            deletebeacon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.비콘삭제＿ｏｎ.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void deletebeacon_MouseLeave(object sender, MouseEventArgs e)
        {
            deletebeacon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.비콘삭제.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }


        private void TitleBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


    }
}
