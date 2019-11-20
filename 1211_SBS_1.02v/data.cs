using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1211_SBS_1._02v
{
    class data : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public double x;
        public double X
        {
            get { return x; }
            set
            {
                x = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("X"));
            }
        }
              public double y;
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Y"));
            }
        }
        public data(double x, double y)
        {
            
            X = x;
            Y = y;
        }
        }
    class datalist : ObservableCollection<data>
    {
        public datalist()
        {
            
          
        }
    }
    public class RssiandWY
    {
        public double Rssi { get; set; }
        public double W { get; set; }
        public double Y { get; set; }

        public RssiandWY(double r,double w,double y)
        {
            Rssi = r;
            W = w;
            Y = y;
        }
    }
    }

