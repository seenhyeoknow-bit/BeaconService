using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace _1211_SBS_1._02v
{
    /// <summary>
    /// page_scannerlistControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class page_scannerlistControl : UserControl
    {
        public ScannerList scannerlist;
        int nowfloor;
        datalist datas = new datalist();
        DispatcherTimer timer = null;
        public Point pt;
        WBServer.Point2D wb = new WBServer.Point2D();
        bool state = false;
        int i = 1;
        public object sender;
        public RoutedEventArgs e;
        public page_scannerlistControl()
        {
            InitializeComponent();



            initpage();
            ImageBrush ib = new ImageBrush();
            canvas.Background = ib;
            ib.ImageSource = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.KakaoTalk_20181206_222124769.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                WBServer.Singleton.ScannerState();
                initpage();
            }
            catch { }

        }
        public void initpage()
        {
            try
            {



                leftarrow.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.왼쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rightarrow.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.오른쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                researchimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.새로_고침.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                setButton.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.addscanner.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                renamebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.이름변경.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                Searchbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.검색아이콘버튼아닌버전.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                nowfloor = 8;
                nowfloortext.Text = string.Format("[ {0}F ]", nowfloor);
                nowfloorobjecttext1.Text = string.Format("[ {0}F ]", nowfloor);
                if (WBServer.Singleton.nowchangeid != null)
                {

                    Point pos = WBServer.Singleton.getScanner(WBServer.Singleton.nowchangeid, "scanner1", nowfloor.ToString());

                    Point pos1 = WBServer.Singleton.getScanner(WBServer.Singleton.nowchangeid, "scanner2", nowfloor.ToString());

                    Point pos2 = WBServer.Singleton.getScanner(WBServer.Singleton.nowchangeid, "scanner3", nowfloor.ToString());

                    if (WBServer.Singleton.scannerstate[0] == "true")
                    {
                        drawScannerOn(pos, 0);

                    }
                    else if (WBServer.Singleton.scannerstate[0] == "false")
                    {
                        drawScanner(pos, 0);

                    }
                    if (WBServer.Singleton.scannerstate[1] == "true")
                    {
                        drawScannerOn(pos1, 1);
                    }
                    else if (WBServer.Singleton.scannerstate[1] == "false")
                    {
                        drawScanner(pos1, 1);
                    }
                    if (WBServer.Singleton.scannerstate[2] == "true")
                    {
                        drawScannerOn(pos2, 2);
                    }
                    else if (WBServer.Singleton.scannerstate[2] == "false")
                    {
                        drawScanner(pos2, 2);
                    }
                }



            }
            catch
            {

            }



        }
        public void drawScanner(Point pos, int i)
        {
            Image stationImage = new Image();
            stationImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.스캐너.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            stationImage.Width = 35;
            stationImage.Height = 35;

            Canvas.SetLeft(stationImage, pos.X); //왼쪽에서 200픽셀 떨어진 곳에
            Canvas.SetTop(stationImage, pos.Y); //위에서 500픽셀 떨어진 곳에
            canvas.Children.Add(stationImage);

            TextBlock tb = new TextBlock();
            tb.Text = WBServer.Singleton.sclist[i].ScannerName;
            tb.FontSize = 15;
            tb.Foreground = Brushes.White;
            tb.Background = Brushes.Black;

            tb.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            Canvas.SetLeft(tb, pos.X - 14); //왼쪽에서 200픽셀 떨어진 곳에
            Canvas.SetTop(tb, pos.Y + 36); //위에서 500픽셀 떨어진 곳에
            canvas.Children.Add(tb);
        }
        public void drawScannerOn(Point pos, int i)
        {
            Image stationImage = new Image();
            stationImage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.스캐너_target.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            stationImage.Width = 35;
            stationImage.Height = 35;

            Canvas.SetLeft(stationImage, pos.X); //왼쪽에서 200픽셀 떨어진 곳에
            Canvas.SetTop(stationImage, pos.Y); //위에서 500픽셀 떨어진 곳에
            canvas.Children.Add(stationImage);

            Canvas.SetLeft(stationImage, pos.X); //왼쪽에서 200픽셀 떨어진 곳에
            Canvas.SetTop(stationImage, pos.Y); //위에서 500픽셀 떨어진 곳에
            canvas.Children.Add(stationImage);

            TextBlock tb = new TextBlock();
            tb.Text = WBServer.Singleton.sclist[i].ScannerName;
            tb.FontSize = 15;
            tb.Foreground = Brushes.White;
            tb.Background = Brushes.Black;

            tb.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            Canvas.SetLeft(tb, pos.X - 14); //왼쪽에서 200픽셀 떨어진 곳에
            Canvas.SetTop(tb, pos.Y + 36); //위에서 500픽셀 떨어진 곳에
            canvas.Children.Add(tb);
        }


        private void leftarrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (nowfloor <= 1)
                return;

            nowfloor--;
            //층수에 따라 정보를 새로 로딩해야함.
            nowfloortext.Text = string.Format("[ {0}F ]", nowfloor);
            nowfloorobjecttext1.Text = string.Format("[ {0}F ]", nowfloor);
        }

        private void rightarrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (nowfloor >= 8)
                return;

            nowfloor++;
            //층수에 따라 정보를 새로 로딩해야함.
            nowfloortext.Text = string.Format("[ {0}F ]", nowfloor);
            nowfloorobjecttext1.Text = string.Format("[ {0}F ]", nowfloor);
        }

        public Point g_pt1 = new Point();
        public Point g_pt3 = new Point();

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {


                if (state == true)
                {

                    if (WBServer.Singleton.nowchangeid != null)
                    {
                        if (i == 1)
                        {
                            g_pt1.X = e.GetPosition(canvas).X;
                            g_pt1.Y = e.GetPosition(canvas).Y;
                            MessageBox.Show("스캐너1 설정 완료!\n스캐너3의 위치를 눌러주세요!");
                        }
                        else if (i == 2)
                        {
                            g_pt3.X = e.GetPosition(canvas).X;
                            g_pt3.Y = e.GetPosition(canvas).Y;

                            g_pt1.Y = (g_pt1.Y + g_pt3.Y) / 2;
                            g_pt3.Y = g_pt1.Y;


                            WBServer.Singleton.setPosition(WBServer.Singleton.nowchangeid, "scanner1", nowfloor, g_pt1.X, g_pt1.Y);
                            MessageBox.Show("스캐너3 설정 완료!");
                            WBServer.Singleton.setPosition(WBServer.Singleton.nowchangeid, "scanner2", nowfloor, g_pt3.X, g_pt3.Y + (g_pt3.X - g_pt1.X));
                            WBServer.Singleton.setPosition(WBServer.Singleton.nowchangeid, "scanner3", nowfloor, g_pt3.X, g_pt3.Y);
                            canvas.Children.Clear();
                            MessageBox.Show("스캐너가 설정 되었습니다.");
                        }
                    }

                }

                if (i == 2)
                {
                    state = false;
                    WBServer.Singleton.scannercheck = true;
                }
                i++;
                if (i == 3)
                {
                    i = 1;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        private void researchimage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                if (WBServer.Singleton.nowchangeid != null)
                {
                    WBServer.Singleton.sclist.Clear();
                    WBServer.Singleton.getScannerName(WBServer.Singleton.nowchangeid);
                    canvas.Children.Clear();
                    ScannerListfresh();
                    initpage();
                }




            }
            catch { }

        }
        public void ScannerListfresh()
        {

            canvas.Children.Clear();
            menuDock.DataContext = null;
            menuDock.DataContext = scannerlist;
            scannerlist.AddList();


        }







        private void setButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WBServer.Singleton.nowchangeid == null)
            {
                MessageBox.Show("먼저 로그인을 해주세요");
                return;
            }

            state = true;
            MessageBox.Show("스캐너1의 위치를 지정해주세요");
        }

        private void setButton_MouseEnter(object sender, MouseEventArgs e)
        {
            setButton.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.addscanner_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void setButton_MouseLeave(object sender, MouseEventArgs e)
        {
            setButton.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.addscanner.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void researchimage_MouseEnter(object sender, MouseEventArgs e)
        {
            researchimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.새로_고침_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void researchimage_MouseLeave(object sender, MouseEventArgs e)
        {
            researchimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.새로_고침.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void leftarrow_MouseEnter(object sender, MouseEventArgs e)
        {
            leftarrow.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.왼쪽_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void leftarrow_MouseLeave(object sender, MouseEventArgs e)
        {
            leftarrow.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.왼쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void rightarrow_MouseEnter(object sender, MouseEventArgs e)
        {
            rightarrow.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.오른쪽_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void rightarrow_MouseLeave(object sender, MouseEventArgs e)
        {
            rightarrow.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.오른쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void renamebtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WBServer.Singleton.nowchangeid == null)
            {
                MessageBox.Show("먼저 로그인 해주세요");
                return;
            }
            if (SClistview.SelectedValue == null)
            {
                MessageBox.Show("변경할 스캐너를 선택해주세요");
                return;
            }

            ScannerRename screnameform = new ScannerRename();
            screnameform.pagescanner = this;
            screnameform.ShowDialog();
        }

        private void renamebtn_MouseEnter(object sender, MouseEventArgs e)
        {
            renamebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.이름변경＿ｏｎ.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void renamebtn_MouseLeave(object sender, MouseEventArgs e)
        {
            renamebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.이름변경.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void Searchbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(SClistview.ItemsSource);
            view.Filter = UserFilter;
            CollectionViewSource.GetDefaultView(SClistview.ItemsSource).Refresh();
        }
        private bool UserFilter(object item)
        {

            if (String.IsNullOrEmpty(Searchtb.Text))
                return true;
            else
                return ((item as Scanner).ScannerName.IndexOf(Searchtb.Text, StringComparison.OrdinalIgnoreCase) >= 0);

        }

        private void Searchbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            Searchbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.검색아이콘버튼아닌버전_3.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void Searchbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            Searchbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.검색아이콘버튼아닌버전.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void Searchtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(SClistview.ItemsSource).Refresh();
        }

        private void Searchtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(SClistview.ItemsSource);
                view.Filter = UserFilter;
                CollectionViewSource.GetDefaultView(SClistview.ItemsSource).Refresh();

            }
        }






    }

}
