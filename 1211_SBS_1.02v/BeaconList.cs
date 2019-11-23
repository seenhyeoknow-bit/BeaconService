using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace _1211_SBS_1._02v
{
    //비콘정보
    public class Beacon : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //BeaconIcon, BeaconName, BeaconDistance, BeaconBattery, preferences

        //비콘 아이콘
        private BitmapSource beaconicon;
        public BitmapSource BeaconIcon
        {
            get { return beaconicon; }
            set
            {
                beaconicon = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BeaconIcon"));
            }
        }
        //비콘 이름
        private string beaconname;
        public string BeaconName
        {
            get { return beaconname; }
            set
            {
                beaconname = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BeaconName"));
            }
        }
        //사용자로부터의 거리값
        private string beacondistance;
        public string BeaconDistance
        {
            get { return beacondistance; }
            set
            {
                beacondistance = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BeaconDistance"));
            }
        }
        private string distance1;
        public string Distance1
        {
            get { return distance1; }
            set
            {
                distance1 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Distance1"));
            }
        }
        private string distance2;
        public string Distance2
        {
            get { return distance2; }
            set
            {
                distance2 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Distance2"));
            }
        }
        private string distance3;
        public string Distance3
        {
            get { return distance3; }
            set
            {
                distance3 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Distance3"));
            }
        }
 
        

        //환경변수
        public string W1 { get; set; }
        public string Y1 { get; set; }
        public string W2 { get; set; }
        public string Y2 { get; set; }
        public string W3 { get; set; }
        public string Y3 { get; set; }
        //배터리 이미지
        private BitmapSource scannersetting = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.스캐너설정.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        public BitmapSource ScannerSettine
        {
            get
            { return scannersetting; }
            set
            {
                scannersetting = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ScannerSettine"));
            }
        }

        //환경설정
        private BitmapSource preferences = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.설정.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        public BitmapSource Preferences
        {
            get { return preferences; }
            set
            {
                preferences = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Preferences"));
            }
        }

        public override string ToString()
        {
            return string.Format("아이콘:{0}, 이름:{1}, 거리값:{2}, 스캐너설정:{3}, 환경설정:{4}", BeaconIcon, BeaconName, BeaconDistance, ScannerSettine, preferences);
        }
        public Beacon(string bn, string rssi, string rssi1, string rssi2, string icon,string w1,string y1,string w2,string y2,string w3,string y3)
        {
            if (icon.Equals("ring"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__1_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                addbeacon(bicon, bn, rssi, rssi1, rssi2,  w1, y1, w2, y2, w3, y3);
            }
            else if (icon.Equals("person"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__2_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                addbeacon(bicon, bn, rssi, rssi1, rssi2,  w1, y1, w2, y2, w3, y3);
            }
            else if (icon.Equals("book"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__3_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                addbeacon(bicon, bn, rssi, rssi1, rssi2,  w1, y1, w2, y2, w3, y3);
            }
            else if (icon.Equals("remote"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__4_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                addbeacon(bicon, bn, rssi, rssi1, rssi2,  w1, y1, w2, y2, w3, y3);
            }
            else if (icon.Equals("clothes"))
            {
                BitmapSource bicon = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.사물__5_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                addbeacon(bicon, bn, rssi, rssi1, rssi2,  w1, y1, w2, y2, w3, y3);
            }
            else
            {
                BitmapSource beacon = null;
                addbeacon(beacon, bn, rssi, rssi1, rssi2, w1, y1, w2, y2, w3, y3);
            }

        }
        public void addbeacon(BitmapSource icon, string bn, string rssi, string rssi1, string rssi2,  string w1, string y1, string w2, string y2, string w3, string y3)
        {
            BeaconIcon = icon;
            BeaconName = bn;

            List<RssiandWY> rlist = new List<RssiandWY>();
            rlist.Add(new RssiandWY(double.Parse(rssi), double.Parse(w1), double.Parse(y1)));
            rlist.Add(new RssiandWY(double.Parse(rssi1), double.Parse(w2), double.Parse(y2)));
            rlist.Add(new RssiandWY(double.Parse(rssi2), double.Parse(w3), double.Parse(y3)));
            string dis = WBServer.Singleton.RssiToDistance(rlist);
            string[] distances = dis.Split('#');
            BeaconDistance = WBServer.Singleton.sclist[0].ScannerName + ": " + Math.Round(double.Parse(distances[0]), 2) + "M(" + rssi + ")\n" + WBServer.Singleton.sclist[1].ScannerName + ": "
                + (Math.Round(double.Parse(distances[1]), 2)) + "M(" + rssi1 + ")\n" + WBServer.Singleton.sclist[2].ScannerName + ": " + Math.Round(double.Parse(distances[2]), 2) + "M(" + rssi2 + ")";
            Distance1=(Math.Round(double.Parse(distances[0]), 2) + "M(" + rssi + ")");
            Distance2 = (Math.Round(double.Parse(distances[1]), 2) + "M(" + rssi1 + ")");
            Distance3 = (Math.Round(double.Parse(distances[2]), 2) + "M(" + rssi2 + ")");
          
            W1 = w1;
            Y1 = y1;
            W2 = w2;
            Y2 = y2;
            W3 = w3;
            Y3 = y3;
            
        }
    }

    //BeaconIcon, BeaconName, BeaconDistance, BeaconBattery, preferences
    //비콘리스트
    public class BeaconList : List<Beacon>
    {


        public void AddList()
        {
            this.Clear();
            if (WBServer.Singleton.mybeacon.Count() == 0)
                return;

            foreach (Beacon b in WBServer.Singleton.mybeacon)
            {
                
                this.Add(b);
            }
        }
        public BeaconList()
        {


        }

    }


}
