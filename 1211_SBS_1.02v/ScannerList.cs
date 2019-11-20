using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1211_SBS_1._02v
{
    public class Scanner : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //BeaconIcon, BeaconName, BeaconDistance, BeaconBattery, preferences

        //비콘 아이콘

        //비콘 이름
        private string scannername;
        public string ScannerName
        {
            get { return scannername; }
            set
            {
                scannername = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ScannerName"));
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", ScannerName);
        }
    }
    public class ScannerList : List<Scanner>
    {

        public ScannerList()
        {
        }
        public void AddList()
        {
            if (WBServer.Singleton.sclist.Count() == 0)
                return;

            this.Clear();
            foreach (Scanner c in WBServer.Singleton.sclist)
            {

                this.Add(c);
            }
        }
    }
}

