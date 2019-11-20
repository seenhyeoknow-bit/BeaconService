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
    /// SignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUp : Window
    {
        public bool isIdCheck { get; private set; }
        public bool isPwCheck { get; private set; }
        public SignUp()
        {
            InitializeComponent();

            idtb.Focus();
            isIdCheck = false;
            isPwCheck = false;

            minibtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.최소.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            closebtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.닫기.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            titleimage.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_07.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            signupbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            idCheck.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.중복확인.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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



        private void signupbtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isIdCheck == false)
            {
                MessageBox.Show("ID중복 체크를 해주세요");
                return;
            }
            if (isPwCheck == false)
            {
                MessageBox.Show("비밀번호를 확인해주세요");
                return;
            }
            if (idtb.Text.Trim() == string.Empty || pwtb.Password.ToString().Trim() == string.Empty
                || nametb.Text.Trim() == string.Empty
                || brithnumtb.Text.Trim() == string.Empty || emailtb.Text.Trim() == string.Empty)
            {
                MessageBox.Show("모든정보를 입력하세요");
                return;
            }

            if (WBServer.Singleton.AddMember(idtb.Text.Trim(), pwtb.Password.ToString().Trim(), nametb.Text.Trim()
                , brithnumtb.Text.Trim(), emailtb.Text.Trim()) == false)
            {
                MessageBox.Show("회원 가입 실패");
                return;
            }

            MessageBox.Show("회원가입 성공");
            this.Close();
        }



        private void pwtb_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pwtb.Password.ToString().Trim().Equals(pwchecktb.Password.ToString().Trim()))
            {
                checkpwlb.Foreground = new SolidColorBrush(Colors.Blue);
                checkpwlb.Content = "pw가 동일합니다";
                isPwCheck = true;
            }
            else
            {
                checkpwlb.Foreground = new SolidColorBrush(Colors.Red);
                checkpwlb.Content = "pw가 다릅니다";
                isPwCheck = false;
            }
        }

        private void idCheck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (idtb.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ID를 입력하세요");
                return;
            }
            if (WBServer.Singleton.IdCheck(idtb.Text.Trim()) == false)
            {
                MessageBox.Show("중복 ID입니다");
                idtb.Text = "";
                idtb.Focus();
                isIdCheck = false;
                return;
            }
            else if (WBServer.Singleton.IdCheck(idtb.Text.Trim()) == true)
            {
                MessageBox.Show("사용 가능합니다");
                isIdCheck = true;
            }
        }

        private void idCheck_MouseEnter(object sender, MouseEventArgs e)
        {
            idCheck.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.중복확인눌린버전.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void idCheck_MouseLeave(object sender, MouseEventArgs e)
        {
            idCheck.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.중복확인.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void signupbtn_MouseEnter(object sender, MouseEventArgs e)
        {
            signupbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04_on.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void signupbtn_MouseLeave(object sender, MouseEventArgs e)
        {
            signupbtn.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.여진2_04.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
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
