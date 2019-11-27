using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// page_beaconMapControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class page_beaconMapControl : UserControl
    {
        int nowfloor;
        public BeaconList beaconlist;
        public List<WBServer.Point2D> ptlist = new List<WBServer.Point2D>();
        public List<Result> resultlist = new List<Result>();
        string icon = null;
        DispatcherTimer timer = null;
        public page_beaconMapControl()
        {
            InitializeComponent();

            initpage();
            // 윈폼 타이머 사용

            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(5000);
            //timer.Tick += new EventHandler(timer_Tick);
            //timer.Start();

            Searchbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.검색아이콘버튼아닌버전.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.KakaoTalk_20181206_222124769.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            canvas.Background = ib;

        }



        // 쓰레드풀의 작업쓰레드가 지정된 시간 간격으로
        // 아래 이벤트 핸들러 실행



        public void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (WBServer.Singleton.nowchangeid != null)
                {

                    WBServer.Singleton.mybeacon.Clear();
                    WBServer.Singleton.rssilist.Clear();
                    WBServer.Singleton.dislist.Clear();

                    WBServer.Singleton.getData(WBServer.Singleton.nowchangeid);
                    WBServer.Singleton.getDistance();
                    WBServer.Singleton.getBeaconlistName(WBServer.Singleton.nowchangeid);
                    ptlist.Clear();
                    resultlist.Clear();
                    BeaconListfresh();
                    initpage();
                }




            }
            catch
            {
                if (WBServer.Singleton.nowchangeid == null)
                    MessageBox.Show("로그인을 해주세요");
                else
                {

                    if (WBServer.Singleton.mybeacon.Count() == 0)
                        return;
                    MessageBox.Show("비콘등록을 먼저 해주세요");
                }
            }
        }
        public void initpage()
        {
            try
            {
                canvas.Children.Clear();

                leftarrow.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.왼쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                rightarrow.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.오른쪽.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                researchimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.새로_고침.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());


                nowfloor = 8;
                nowfloortext.Text = string.Format("[ {0}F ]", nowfloor);
                nowfloorobjecttext1.Text = string.Format("[ {0}F ]", nowfloor);


                if (WBServer.Singleton.nowchangeid != null)
                {

                    for (int i = 0; i < WBServer.Singleton.dislist.Count; i++)
                    {

                        ptlist.Add(WBServer.Singleton.getPosition(WBServer.Singleton.nowchangeid, "scanner" + (i % 3 + 1), nowfloor, i));
                    }



                    Point s1pt = WBServer.Singleton.getScanner(WBServer.Singleton.nowchangeid, "scanner1", nowfloor.ToString());
                    Point s2pt = WBServer.Singleton.getScanner(WBServer.Singleton.nowchangeid, "scanner2", nowfloor.ToString());

                    for (int j = 0; j < ptlist.Count; j += 3)
                    {

                        Result result = new Result();
                        string str = WBServer.Singleton.TripleResult(ptlist[j], ptlist[j + 1], ptlist[j + 2]);
                        string[] token = str.Split('#');


                        result.Pt = new Point(double.Parse(token[0]), double.Parse(token[1]));
                        result.Bname = token[2];
                        resultlist.Add(result);

                    }
                    double persent = (s2pt.X - s1pt.X) / 5;

                    Image targetrange = new Image();
                    targetrange.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.빨간테두리.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    targetrange.Width = persent * 4.5;
                    targetrange.Height = persent * 4.5;

                    Canvas.SetLeft(targetrange, (s1pt.X + s2pt.X) / 2 - targetrange.Width / 2);
                    Canvas.SetTop(targetrange, (s1pt.Y + s2pt.Y) / 2 - targetrange.Height / 2);
                    canvas.Children.Add(targetrange);

                    foreach (Result pt in resultlist)
                    {

                        icon = WBServer.Singleton.getIcon(WBServer.Singleton.nowchangeid, pt.Bname);

                        changeColor(pt, icon, pt.Bname);


                        if (pt.Pt.X < (s1pt.X + persent / 2) || (s1pt.Y + persent / 2) > pt.Pt.Y || pt.Pt.X > (s2pt.X - persent / 2) || (s2pt.Y - persent / 2) < pt.Pt.Y)
                        {
                            Image target = new Image();
                            target.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.현재_목표물.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            target.Width = 50;
                            target.Height = 50;

                            Canvas.SetLeft(target, pt.Pt.X - 8); //왼쪽에서 200픽셀 떨어진 곳에
                            Canvas.SetTop(target, pt.Pt.Y - 7); //위에서 500픽셀 떨어진 곳에
                            canvas.Children.Add(target);

                        }

                    }
                }
            }
            catch
            {

            }

        }

        public void drawBeacon(BitmapSource icon, Point pt, string bname)
        {
            Image stationImage = new Image();
            stationImage.Source = icon;
            stationImage.Width = 35;
            stationImage.Height = 35;

            Canvas.SetLeft(stationImage, pt.X); //왼쪽에서 200픽셀 떨어진 곳에
            Canvas.SetTop(stationImage, pt.Y); //위에서 500픽셀 떨어진 곳에
            canvas.Children.Add(stationImage);

            TextBlock tb = new TextBlock();
            tb.Text = bname;
            tb.FontSize = 15;
            tb.Foreground = Brushes.White;
            tb.Background = Brushes.Black;

            tb.SetValue(TextBlock.FontWeightProperty, FontWeights.Bold);
            Canvas.SetLeft(tb, pt.X - 14); //왼쪽에서 200픽셀 떨어진 곳에
            Canvas.SetTop(tb, pt.Y + 36); //위에서 500픽셀 떨어진 곳에
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

        private void researchimage_MouseDown(object sender, MouseButtonEventArgs e)
        {

            try
            {
                if (WBServer.Singleton.nowchangeid != null)
                {
                    WBServer.Singleton.mybeacon.Clear();
                    WBServer.Singleton.rssilist.Clear();
                    WBServer.Singleton.dislist.Clear();
                    WBServer.Singleton.myblist.Clear();
                    WBServer.Singleton.getData(WBServer.Singleton.nowchangeid);
                    WBServer.Singleton.getDistance();
                    WBServer.Singleton.getBeaconlistName(WBServer.Singleton.nowchangeid);
                    ptlist.Clear();
                    resultlist.Clear();
                    BeaconListfresh();

                    initpage();
                }





            }
            catch
            {
                if (WBServer.Singleton.nowchangeid == null)
                    MessageBox.Show("로그인을 해주세요");
                else
                    MessageBox.Show("비콘등록을 먼저 해주세요");
            }



        }

        public void BeaconListfresh()
        {


            try
            {
                menuDock.DataContext = null;
                menuDock.DataContext = beaconlist;
                beaconlist.AddList();
            }
            catch { }
           


        }

        private void beaconLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                foreach (Result pt in resultlist)
                {
                    string icon = WBServer.Singleton.getIcon(WBServer.Singleton.nowchangeid, pt.Bname);
                    if (pt.Bname.Equals(((Beacon)beaconLB.SelectedValue).BeaconName))
                    {
                        if (icon.Equals("ring"))
                        {
                            BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1__target.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            drawBeacon(bicon, pt.Pt, pt.Bname);
                            continue;
                        }
                        else if (icon.Equals("person"))
                        {
                            BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2__target.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            drawBeacon(bicon, pt.Pt, pt.Bname);
                            continue;
                        }
                        else if (icon.Equals("book"))
                        {
                            BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3__target.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            drawBeacon(bicon, pt.Pt, pt.Bname);
                            continue;
                        }
                        else if (icon.Equals("remote"))
                        {
                            BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4__target.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            drawBeacon(bicon, pt.Pt, pt.Bname);
                            continue;
                        }
                        else if (icon.Equals("clothes"))
                        {
                            BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5__target.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                            drawBeacon(bicon, pt.Pt, pt.Bname);
                            continue;
                        }
                    }
                    else
                    {
                        //===============================================================================================
                        changeColor(pt, icon, pt.Bname);
                    }
                }
            }
            catch
            {
                MessageBox.Show("아이콘을 먼저 등록해주세요");
            }


        }

        public void changeColor(Result pt, string icon, string bname)
        {
            if (icon.Equals("ring"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                drawBeacon(bicon, pt.Pt, bname);
            }
            else if (icon.Equals("person"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                drawBeacon(bicon, pt.Pt, bname);
            }
            else if (icon.Equals("book"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                drawBeacon(bicon, pt.Pt, bname);
            }
            else if (icon.Equals("remote"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                drawBeacon(bicon, pt.Pt, bname);
            }
            else if (icon.Equals("clothes"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                drawBeacon(bicon, pt.Pt, bname);
            }
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

        private void Searchbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(beaconLB.ItemsSource);
            view.Filter = UserFilter;
            CollectionViewSource.GetDefaultView(beaconLB.ItemsSource).Refresh();
        }
        private bool UserFilter(object item)
        {

            if (String.IsNullOrEmpty(Searchtb.Text))
                return true;
            else
                return ((item as Beacon).BeaconName.IndexOf(Searchtb.Text, StringComparison.OrdinalIgnoreCase) >= 0);

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
            CollectionViewSource.GetDefaultView(beaconLB.ItemsSource).Refresh();
        }
        private void Searchtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(beaconLB.ItemsSource);
                view.Filter = UserFilter;
                CollectionViewSource.GetDefaultView(beaconLB.ItemsSource).Refresh();

            }
        }

    }



    public class Result
    {
        public Point Pt { get; set; }
        public string Bname { get; set; }
    }
}

