using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1211_SBS_1._02v
{
    public class Beaconinfo
    {
        public string Sname { get; set; }
        public string Bname { get; set; }
        public string Rssi { get; set; }
        public string Bid { get; set; }
        
      
        public Beaconinfo(string sn,string bn,string rs,string bi)
        {
            Sname = sn;
            Bname = bn;
            Rssi = rs;
            Bid = bi;
          
         
        }
        public override string ToString()
        {
            return string.Format("&var2={0}&var3={1}&var4={2}&var5={3}", Sname, Bname, Rssi, Bid);
        }
    }

}
