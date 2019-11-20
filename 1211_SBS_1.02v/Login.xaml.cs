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
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Window
    {
        page_mainControl maincontrol;
        public page_scannerlistControl scannercontrol;
        public page_beaconlistControl beaconlist;
        public page_beaconMapControl beaconmap;

        public Login(page_mainControl mc)
        {
            InitializeComponent();

            maincontrol = mc;

            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            titleimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_07.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            loginbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.로그인.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            SignUpbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            Loginbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_03.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            findidbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findid.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            findpwbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findpw.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            idtb.Focus();
        }
        private void btn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (((Image)sender).Name.Equals("minibtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("closebtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("Loginbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_03_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("SignUpbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("findidbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findid_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("findpwbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findpw_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void btn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (((Image)sender).Name.Equals("minibtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("closebtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("Loginbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_03.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("SignUpbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("findidbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findid.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            else if (((Image)sender).Name.Equals("findpwbtn"))
                ((Image)sender).Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.findpw.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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

        private void findidbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FindID findidform = new FindID();
            findidform.ShowDialog();
        }

        private void findpwbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FindPassword findpwform = new FindPassword();
            findpwform.ShowDialog();
        }

        private void SignUpbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignUp signupform = new SignUp();
            signupform.ShowDialog();
        }

        private void Loginbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginEvent();
        }

        private void pwtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                LoginEvent();

            }


        }
        public void LoginEvent()
        {
            if (idtb.Text.Trim() == string.Empty || pwtb.Password.ToString().Trim() == string.Empty)
            {
                MessageBox.Show("ID 패스워드를 입력하세요");
                return;
            }
            if (WBServer.Singleton.Login(idtb.Text.Trim(), pwtb.Password.ToString().Trim()))//Trim 공백제거
            {
                this.Close();


                WBServer.Singleton.nowchangeid = idtb.Text.Trim();
                WBServer.Singleton.getBeaconName();
                maincontrol.loginbtn.Height = 0;
                maincontrol.signupbtn.Height = 0;
                maincontrol.proflieimage.Width = 265;
                maincontrol.proflieicon.Width = 65;
                maincontrol.preferencesimagebtn.Width = 65;
                maincontrol.tb_loginid.Text = WBServer.Singleton.nowchangeid;
                string icon = WBServer.Singleton.getProfileIcon();
                if (icon == "dog")
                {
                    maincontrol.proflieicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.강아지_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
                if (icon == "whale")
                {
                    maincontrol.proflieicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고래__프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
                if (icon == "cat")
                {
                    maincontrol.proflieicon.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.고양이_프로필.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                }
                WBServer.Singleton.getScannerName(idtb.Text.Trim());
                if (WBServer.Singleton.getData(idtb.Text.Trim()))
                {


                    WBServer.Singleton.getBeaconlistName(WBServer.Singleton.nowchangeid);
                    scannercontrol.initpage();
                    beaconmap.beaconlist = beaconlist.beaconlist;
                    WBServer.Singleton.getDistance();
                    beaconmap.initpage();
                    scannercontrol.ScannerListfresh();
                    beaconlist.BeaconListfresh();
                    beaconmap.BeaconListfresh();
                    WBServer.Singleton.ScannerState();



                }


            }
            else
            {
                MessageBox.Show("아이디 비밀번호를 확인하세요");
            }

        }
    }

}

