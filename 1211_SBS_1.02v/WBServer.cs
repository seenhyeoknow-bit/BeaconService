using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;


namespace _1211_SBS_1._02v
{
    public class WBServer
    {
        #region 싱글톤 문법
        static public WBServer Singleton { get; private set; }

        static WBServer()
        {
            Singleton = new WBServer();//단일체 생성 
        }
        private WBServer()
        {

        } //단일체로 구현하기 위하여 private으로 접근 지정 
        #endregion

        public List<Scanner> sclist = new List<Scanner>();
        public List<double> dislist = new List<double>();
        public List<String> blist = new List<string>();
        public List<Beacon> mybeacon = new List<Beacon>();
        public List<RssiandWY> rssilist = new List<RssiandWY>();
        public List<string> myblist = new List<string>();
        public List<string> scannerstate = new List<string>();


        public string enterBname;
        public string nowchangeid;
        public bool scannercheck = false;
        public string enterW1 = "0.33";  //33
        public string enterY1 = "0.5"; // 0.415/5      
        public string enterW2 = "0.33";  //33
        public string enterY2 = "0.5"; // 0.415/5       
        public string enterW3 = "0.33";  //33
        public string enterY3 = "0.5"; // 0.415/5       
        public string enterRssi1 = null;
        public string enterRssi2 = null;
        public string enterRssi3 = null;
        public string enterDistance1 = null;
        public string enterDistance2 = null;
        public string enterDistance3 = null;

        //DB에서 데이터를 가져옵니다.
        public bool getData(string id)
        {

            try
            {
                string url = "http://61.81.98.207:9001/?flag=wy&var1=" + id;
                string resultGet = Connect(url);

                if (resultGet == "a")
                {

                    return false;
                }

                // 생성한 스트림으로부터 string으로 변환합니다.
                string[] token1 = resultGet.Split('[');
                string[] token2 = token1[1].Split(']');
                string[] token3 = token2[0].Split(',');




                List<int> notchecklist = new List<int>();
                for (int i = 0; i < token3.Count(); i++)
                {
                    if (notchecklist.Contains(i))
                    {

                        continue;
                    }

                    String[] token4 = token3[i].Split('"');
                    String[] token5 = token4[1].Split('#'); // sname, bid, bname, rssi등

                    string now_bname = token5[2];

                    string rssi1 = "정보가없습니다";
                    string rssi2 = "정보가없습니다";
                    string rssi3 = "정보가없습니다";
                    string w1 = "정보가없습니다";
                    string w2 = "정보가없습니다";
                    string w3 = "정보가없습니다";
                    string y1 = "정보가없습니다";
                    string y2 = "정보가없습니다";
                    string y3 = "정보가없습니다";

                    for (int j = 0; j < token3.Count(); j++)
                    {
                        String[] checktoken = token3[j].Split('"');
                        String[] checkbeacon = checktoken[1].Split('#');

                        if (now_bname.Equals(checkbeacon[2]))
                        {

                            notchecklist.Add(j);
                            if ("scanner1".Equals(checkbeacon[0]))
                            {

                                rssi1 = checkbeacon[3];
                                w1 = checkbeacon[6];
                                y1 = checkbeacon[7];
                                rssilist.Add(new RssiandWY(double.Parse(checkbeacon[3]), double.Parse(checkbeacon[6]), double.Parse(checkbeacon[7])));
                            }
                            else if ("scanner2".Equals(checkbeacon[0]))
                            {

                                rssi2 = checkbeacon[3];
                                w2 = checkbeacon[6];
                                y2 = checkbeacon[7];
                                rssilist.Add(new RssiandWY(double.Parse(checkbeacon[3]), double.Parse(checkbeacon[6]), double.Parse(checkbeacon[7])));
                            }
                            else if ("scanner3".Equals(checkbeacon[0]))
                            {

                                rssi3 = checkbeacon[3];
                                w3 = checkbeacon[6];
                                y3 = checkbeacon[7];
                                rssilist.Add(new RssiandWY(double.Parse(checkbeacon[3]), double.Parse(checkbeacon[6]), double.Parse(checkbeacon[7])));
                            }
                            continue;
                        }
                    }

                    Beacon beacon = new Beacon(token5[2], rssi1, rssi2, rssi3, token5[5], w1, y1, w2, y2, w3, y3);

                    mybeacon.Add(beacon);
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public void saveValue(string id, string sname, string bname, string w, string y)
        {
            string url = "http://61.81.98.207:9001/?flag=wyupdate&var1=" + id + "&var2=" + sname + "&var3=" + bname + "&var4=" + w + "&var5=" + y;
            string resultGet = Connect(url);


        }
        public void getRSSI(string id, string bname)
        {
            string url = "http://61.81.98.207:9001/?flag=z&var1=" + id + "&var2=" + bname;
            string resultGet = Connect(url); //-55.15#-68.46#-75.49@0.33(W)#0.5(Y)@0.32#0.49@0.33#0.5

            string[] token = resultGet.Trim().Split('@');
            string[] token1 = token[0].Split('#');
            enterRssi1 = token1[0];
            enterRssi2 = token1[1];
            enterRssi3 = token1[2];

        }
        public bool getScannerName(string id)
        {

            try
            {
                string url = "http://61.81.98.207:9001/?flag=nickreturn&var1=" + id;
                string resultGet = Connect(url);

                if (resultGet == "a")
                {

                    return false;
                }


                string[] token1 = resultGet.Split('[');
                string[] token2 = token1[1].Split(']');
                string[] token3 = token2[0].Split(',');




                for (int i = 0; i < 3; i++)
                {

                    Scanner sc = new Scanner();
                    string[] token4 = token3[i].Split('"');
                    sc.ScannerName = token4[1];
                    sclist.Add(sc);

                }



                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }
        public void getBeaconName()
        {
            try
            {
                string url = "http://61.81.98.207:9001/?flag=k";
                string resultGet = Connect(url);

                if (resultGet == null)
                {
                    return;
                }
                string[] token1 = resultGet.Split('[');
                string[] token2 = token1[1].Split(']');
                string[] token3 = token2[0].Split(',');




                foreach (string s in token3)
                {
                    string[] token4 = s.Split('"');

                    blist.Add(token4[1]);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("테스트");
            }
           

        }
        public void getBeaconlistName(string name)
        {
            try
            {
                string url = "http://61.81.98.207:9001/?flag=p&var1=" + name;
                string resultGet = Connect(url);
                string[] token1 = resultGet.Split('[');
                string[] token2 = token1[1].Split(']');
                string[] token3 = token2[0].Split(',');
                foreach (string s in token3)
                {
                    string[] token4 = s.Split('"');
                    myblist.Add(token4[1]);
                }
            }
            catch (Exception ex)
            {
                
            }


        }
        public void getBeaconlist(string name)
        {
            try
            {
                string url = "http://61.81.98.207:9001/?flag=l&var1=" + name;
                string resultGet = Connect(url);
                String[] temp1 = resultGet.Split('[');
                String[] temp2 = temp1[1].Split(']');
                String[] temp3 = temp2[0].Split(',');

                //=================================================
                List<Beaconinfo> datass = new List<Beaconinfo>();
                Beaconinfo bi = null;
                for (int i = 0; i < temp3.Count(); i++)
                {

                    String[] temp4 = temp3[i].Split('"');
                    String[] temp5 = temp4[1].Split('#');
                    bi = new Beaconinfo(temp5[0], temp5[1], temp5[2], temp5[3]);
                    datass.Add(bi);   //sname

                }
                foreach (Beaconinfo s in datass)
                {

                    string url1 = "http://61.81.98.207:9001/?flag=m&var1=" + nowchangeid + s.ToString();
                    Connect(url1);
                }
            }
            catch
            {
                MessageBox.Show("오류");
            }

        }
        public void setIcon(string name, string icon)
        {
            try
            {
                string url = "http://61.81.98.207:9001/?flag=l&var1=" + name;
                string resultGet = Connect(url);
                String[] temp1 = resultGet.Split('[');
                String[] temp2 = temp1[1].Split(']');
                String[] temp3 = temp2[0].Split(',');


                for (int i = 0; i < temp3.Count(); i++)
                {

                    String[] temp4 = temp3[i].Split('"');
                    String[] temp5 = temp4[1].Split('#');
                    string url1 = "http://61.81.98.207:9001/?flag=o&var1=" + nowchangeid + "&var2=" + temp5[0] + "&var3=" + temp5[1] + "&var4=" + icon;
                    Connect(url1);


                }

            }
            catch
            {
                MessageBox.Show("오류");
            }

        }
        public void setProfileIcon(string icon)
        {
            string url = "http://61.81.98.207:9001/?flag=profile&var1=" + nowchangeid + "&var2=" + icon;
            string resultGet = Connect(url);
        }
        public string getProfileIcon()
        {
            try
            {
                string url = "http://61.81.98.207:9001/?flag=reprofile&var1=" + nowchangeid;
                string resultGet = Connect(url);
                return resultGet;
            }
            catch { return null; }
           
        }
        public string getIcon(string id, string bname)
        {
            string url = "http://61.81.98.207:9001/?flag=q&var1=" + id + "&var2=" + bname;
            string resultGet = Connect(url);
            String[] temp1 = resultGet.Split('[');
            String[] temp2 = temp1[1].Split(']');
            String[] temp3 = temp2[0].Split('"');

            return temp3[1];
        }

        public string RssiToDistance(List<RssiandWY> rlist)
        {
            string dis = string.Empty;
            //===============================================
            double TXpower = -59;

            double n = 2;
            double RSSI;

            foreach (RssiandWY v in rlist)
            {
                RSSI = v.Rssi;
                double a = ((v.W * TXpower - v.Y * RSSI) / (10 * n));
                double d = Math.Pow(10, a);
                double think = Math.Log(-RSSI, 22);
                double hum = Math.Pow(d, 2);
                double nya = Math.Log(d, think);

                if (nya <= 0)
                {

                    dis += hum.ToString() + '#';
                }
                else
                {

                    dis += nya.ToString() + '#';
                }

            }

            return dis;
        }

        public void getDistance()
        {
            try
            {
                //rssi -> 거리값 계산
                string dis = RssiToDistance(rssilist);

                string[] token = dis.Split('#');
                foreach (string d in token)
                {

                    if (d != "")
                        dislist.Add(double.Parse(d));
                }

            }
            catch(Exception ex)
            {

            }



        }
        public void setPosition(string id, string snum, int floor, double x, double y)
        {
            try
            {
                string url = "http://61.81.98.207:9001/?flag=d&var1=" + id + "&var2=" + snum + "&var3=" + floor + "&var4=" + x + "&var5=" + y;
                Connect(url);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void setScannerName(string id, string sname, string nick)
        {
            string url = "http://61.81.98.207:9001/?flag=nick&var1=" + id + "&var2=" + sname + "&var3=" + nick;
            Connect(url);
        }

        public string Connect(string str)
        {
            try
            {
                StringBuilder getParams = new StringBuilder(); ;




                string url = System.Web.HttpUtility.UrlEncode(ErrDesc, System.Text.Encoding.GetEncoding("euc-kr"));
                //http://61.81.98.207:9001/?flag=a
                //http://61.81.98.207:9001/?flag=a
                //http://61.81.98.207:9001/?flag=b&var1=1&var2=2&var3=3&var4=4&var5=5&var6=6
                //주소부분에 다 넣고 객체 생성

                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(str /*+ getParams + url*/);


                //HttpWebResponse 객체 받아옴

                HttpWebResponse wRes = (HttpWebResponse)myReq.GetResponse();



                // Response의 결과를 스트림을 생성합니다.

                Stream respGetStream = wRes.GetResponseStream();

                StreamReader readerGet = new StreamReader(respGetStream, Encoding.UTF8);

                string resultGet = readerGet.ReadToEnd();
                wRes.Close();
                return resultGet;
            }
            catch(Exception ex)
            {
                MessageBox.Show("서버와 연결할수 없습니다");
                return null;
                
            }
            
        }
        #region 로그인기능
        public bool IdCheck(string name)
        {

            string url = "http://61.81.98.207:9001/?flag=f&var1=" + name;
            string resultGet = Connect(url);
            if (resultGet.Equals("true"))
            {
                return true;
            }
            else if (resultGet.Equals("false"))
            {
                return false;
            }
            else
                return false;
        }
        public bool ChangePW(string pw)
        {

            string url = "http://61.81.98.207:9001/?flag=i&var1=" + nowchangeid + "&var2=" + pw;
            string resultGet = Connect(url);
            if (resultGet.Equals("true"))
            {
                return true;
            }
            else if (resultGet.Equals("false"))
            {
                return false;
            }
            else
                return false;
        }
        public bool AddMember(string id, string pw, string name, string birth, string email)
        {
            string url = "http://61.81.98.207:9001/?flag=c&var1=" + id + "&var2=" + pw + "&var3=" + name + "&var4=" + birth + "&var5=" + email;
            string resultGet = Connect(url);

            if (resultGet.Equals("true"))
            {
                return true;
            }
            else if (resultGet.Equals("false"))
            {
                return false;
            }
            else
                return false;
        }
        public bool Login(string id, string pw)
        {
            try
            {
                string url = "http://61.81.98.207:9001/?flag=j&var1=" + id + "&var2=" + pw;
                string resultGet = Connect(url);
                if (resultGet.Equals("true"))
                {
                    return true;
                }
                else if (resultGet.Equals("false"))
                {
                    return false;
                }
                else
                    return false;
            }
            catch { return false; }
           
        }
        public string FindID(string name, string eamil)
        {
            string url = "http://61.81.98.207:9001/?flag=g&var1=" + name + "&var2=" + eamil;

            string resultGet = Connect(url);
            if (resultGet == "[]")
            {

                return "false";
            }
            string[] token1 = resultGet.Split('[');
            string[] token2 = token1[1].Split(']');
            string[] token3 = token2[0].Split('"');


            return token3[1];
        }
        public bool FindPW(string id, string name, string birth)
        {
            string url = "http://61.81.98.207:9001/?flag=h&var1=" + id + "&var2=" + name + "&var3=" + birth;

            string resultGet = Connect(url);
            if (resultGet.Equals("true"))
            {
                return true;
            }
            else if (resultGet.Equals("false"))
            {
                return false;
            }
            else
                return false;


        }
        #endregion
        public string ErrDesc { get; set; }
        public Point2D getPosition(string id, string sname, int floor, int index)
        {

            string url = "http://61.81.98.207:9001/?flag=e&var1=" + id + "&var2=" + sname + "&var3=" + floor;
            string str = Connect(url);

            if (str != null)
            {
                string[] token1 = str.Split('[');
                string[] token2 = token1[1].Split(']');
                string[] token3 = token2[0].Split(',');

                string[] token4 = token3[0].Split('"');
                string[] token5 = token4[1].Split('#'); //name,x,y
                Point2D pt = new Point2D();


                Point2D p1 = pt.getUserPS(double.Parse(token5[0]), double.Parse(token5[1]), dislist[index], myblist[index]);

                return p1;



            }
            return new Point2D(0, 0, 0, "");
        }
        public void ScannerState()
        {
            try
            {
                string url = "http://61.81.98.207:9001/?flag=r";
                string str = Connect(url);
                string[] token = str.Split('#');
                scannerstate.Clear();
                scannerstate.Add(token[0]);
                scannerstate.Add(token[1]);
                scannerstate.Add(token[2]);
            }
            catch
            {

            }



        }
        public bool DeleteBeacon(string id, string bname)
        {
            string url = "http://61.81.98.207:9001/?flag=delete&var1=" + id + "&var2=" + bname;
            string str = Connect(url);


            return false;
        }

        public Point getScanner(string id, string sname, string floor)
        {
            string url = "http://61.81.98.207:9001/?flag=e&var1=" + id + "&var2=" + sname + "&var3=" + floor;
            string str = Connect(url);

            string[] token1 = str.Split('[');
            string[] token2 = token1[1].Split(']');
            string[] token3 = token2[0].Split(',');
            string[] token4 = token3[0].Split('"');
            string[] token5 = token4[1].Split('#');

            Point p = new Point();
            p.X = double.Parse(token5[0]);
            p.Y = double.Parse(token5[1]);
            return p;
        }
        public class Trilateration
        {

            // position = 기준점, 3개의 기준점을 필요로한다 
            public static Point2D getTrilateration(Point2D position1,
            Point2D position2, Point2D position3) // 세 개의 기준점의 x.y 좌표 point.getUserPosition()
            {
                double x1 = position1.getX();
                double y1 = position1.getY();
                double x2 = position2.getX();
                double y2 = position2.getY();
                double x3 = position3.getX();
                double y3 = position3.getY();


                Point spt1 = WBServer.Singleton.getScanner(WBServer.Singleton.nowchangeid, "scanner1", "8");
                Point spt3 = WBServer.Singleton.getScanner(WBServer.Singleton.nowchangeid, "scanner3", "8");

                double persent = (spt3.X - spt1.X) / 5;

                double r1 = position1.getDistance() * persent;
                double r2 = position2.getDistance() * persent;
                double r3 = position3.getDistance() * persent;

                string bname = position1.getBname();

                double S = (Math.Pow(x3, 2.0) - Math.Pow(x2, 2.0) + Math.Pow(y3, 2.0) - Math.Pow(y2, 2.0)

                + Math.Pow(r2, 2.0) - Math.Pow(r3, 2.0)) / 2.0;

                double T = (Math.Pow(x1, 2.0) - Math.Pow(x2, 2.0) + Math.Pow(y1, 2.0) - Math.Pow(y2, 2.0)
                + Math.Pow(r2, 2.0) - Math.Pow(r1, 2.0)) / 2.0;

                // 사용자 위치 
                double y = ((T * (x2 - x3)) - (S * (x2 - x1))) / (((y1 - y2) * (x2 - x3))

                - ((y3 - y2) * (x2 - x1)));

                double x = ((y * (y1 - y2)) - T) / (x2 - x1);

                Point2D userLocation1 = new Point2D(x, y, 0, bname);


                //=================================== 삼변측량식 ===================================================



                //5x5 m^2 정사각형 기준.

                //스캐너 1과 2가 정사각형을 대각선으로 반 자르는 각점에 있음

                //double SX1 = 5;
                //double SY1 = 0;

                //double SX2 = 0;
                //double SY2 = 5;

                //double SX3 = 0;
                //double SY3 = 0;
                double SX1 = x1;
                double SY1 = y1;

                double SX2 = x2;
                double SY2 = y2;

                double SX3 = x3;
                double SY3 = y3;

                double line = SX2 - SX1;
                double diag = Math.Sqrt(Math.Pow(SX2 - SX1, 2.0) + Math.Pow(SY2 - SY1, 2.0));  //스캐너 1과 2 사이의 대각선 길이

                List<double> miters = new List<double>();

                miters.Add(r1);
                miters.Add(r2);
                miters.Add(r3);


                //final x,y 값
                double fx = 999.9;
                double fy = 999.9;
                Point2D userLocation2 = null;

                for (int i = 0; i < miters.Count();)
                {


                    //DB에서 빼온 RSSI값에 기반한 거리값 << 정해지지 않은 값
                    double R1 = miters[i];
                    double R2 = miters[i + 1];
                    double R3 = miters[i + 2];

                    double beta;
                    double arpha;
                    double Xx;


                    //R1+R2가 SX1 * Math.Sqrt(2.0) 미만일 경우도 처리
                    if (R1 + R2 < (line) * Math.Sqrt(2.0)) //같을때는 X
                    {
                        //a와 b가 없어서 R1:R2 비교로 비율 구함.
                        double per = R1 / (R2 + R1);
                        arpha = SX1 + line * per;
                        beta = SY1 + line * per;        //arpha x  / beta  y


                        Xx = 0;
                    }
                    else
                    {

                        double per = 9999;
                        double ij = 1;

                        while (((Math.Sqrt(Math.Pow(R1, 2.0) - ij))
                            + Math.Sqrt(Math.Pow(R2, 2.0) - ij)) > ((line) * Math.Sqrt(2.0)))
                        {
                            ij++;
                            per = Math.Sqrt(Math.Pow(R1, 2.0) - ij) / ((Math.Sqrt(Math.Pow(R1, 2.0) - ij)) + Math.Sqrt(Math.Pow(R2, 2.0) - i));
                        }

                        double b = (((Math.Pow(R2, 2.0) - Math.Pow(R1, 2.0) + Math.Pow(diag, 2.0)) / (2 * diag)) + ((1 - per) * diag)) / 2;
                        double a = diag - b;

                        //a:b 비교로 비율 구함.
                        per = ((a / (a + b)) + per) / 2;
                        arpha = SX1 + line * per;
                        beta = SY1 + line * per;

                        Xx = Math.Sqrt(Math.Pow(R1, 2.0) - Math.Pow(per * diag, 2.0));
                        Xx = Math.Sqrt(Math.Pow(R2, 2.0) - Math.Pow((1 - per) * diag, 2.0));
                    }

                    if (/*대각선위의 점과 S3의 거리*/(Math.Sqrt(Math.Pow(SX3 - arpha, 2.0) + Math.Pow(SY3 - beta, 2.0)) < R3) && (R1 != R2))
                    {

                        fx = arpha - (Xx / Math.Sqrt(2.0));
                        fy = beta + (Xx / Math.Sqrt(2.0));
                    }
                    else if ((Math.Sqrt(Math.Pow(arpha - SX3, 2.0) + Math.Pow(beta - SY3, 2.0)) > R3) && (R1 != R2))
                    {
                        fx = arpha + (Xx / Math.Sqrt(2.0));
                        fy = beta - (Xx / Math.Sqrt(2.0));

                    }
                    else
                    {
                        if (R3 == (line * Math.Sqrt(2.0)) / 2)
                        {

                            fx = arpha;
                            fy = beta;
                        }
                        else if (R3 > (line * Math.Sqrt(2.0)) / 2)
                        {

                            fx = arpha - (R3 - (line * Math.Sqrt(2.0)) / 2) / (Math.Sqrt(2.0));
                            fy = beta + (R3 - (line * Math.Sqrt(2.0)) / 2) / (Math.Sqrt(2.0));
                        }
                        else if (R3 < (line * Math.Sqrt(2.0)) / 2)
                        {

                            fx = arpha + ((line * Math.Sqrt(2.0)) / 2 + R3) / (Math.Sqrt(2.0));
                            fy = beta - ((line * Math.Sqrt(2.0)) / 2 + R3) / (Math.Sqrt(2.0));
                        }


                        //만약 R1과 R2가 작거나 클때의 경우처리...
                        if (R1 * 2 > (line * Math.Sqrt(2.0)))
                        {
                            double withS1S2 = Math.Sqrt(Math.Pow(R1, 2.0) - Math.Pow(line * Math.Sqrt(2.0) / 2, 2.0));

                            if (R3 > (line * Math.Sqrt(2.0)) / 2)
                            {

                                fx = (fx - withS1S2 / Math.Sqrt(2.0)) / 2;
                                fy = (fy + withS1S2 / Math.Sqrt(2.0)) / 2;
                            }
                            else if (R3 < (line * Math.Sqrt(2.0)) / 2)
                            {

                                fx = (fx + withS1S2 / Math.Sqrt(2.0)) / 2;
                                fy = (fy - withS1S2 / Math.Sqrt(2.0)) / 2;
                            }
                        }
                        else if (R1 * 2 < (line * Math.Sqrt(2.0)))
                        {

                            fx = (fx + (SX1 + SX2) / 2) / 2;
                            fy = (fy + (SY1 + SY2) / 2) / 2;
                        }
                        else
                        {

                        }
                    }


                    userLocation2 = new Point2D(fx, fy, 0, bname);

                    i = i + 3;
                }

                Point2D f_userLocation = new Point2D((userLocation1.x * 2 + fx) / 3, (userLocation1.y * 2 + fy) / 3, 0, bname);

                return userLocation1;
            }

        };
        public string TripleResult(Point2D d1, Point2D d2, Point2D d3)
        {
            Point2D userPosition = Trilateration.getTrilateration(d1, d2, d3);
            string str = string.Format("계산결과 ... X : {0}, Y : {1} bname: {2}", userPosition.x, userPosition.y, userPosition.bname);
            string result = userPosition.x.ToString() + "#" + userPosition.y + "#" + userPosition.bname;

            return result;
        }

        public Point fingerprinting()
        {
            //오류값 9999
            double rssi1 = 9999;
            double rssi2 = 9999;
            double rssi3 = 9999;

            double noise = 5;
            List<Point> mypoints = new List<Point>();

            double x1y1_rssi1 = -78.36;
            double x1y1_rssi2 = -74.37;
            double x1y1_rssi3 = -64.4905;

            double x1y2_rssi1 = -75.82;
            double x1y2_rssi2 = -72.14;
            double x1y2_rssi3 = -58.48;

            double x1y3_rssi1 = -76.75;
            double x1y3_rssi2 = -70.3181;
            double x1y3_rssi3 = -66.2174;

            double x1y4_rssi1 = -84;
            double x1y4_rssi2 = -61.2609;
            double x1y4_rssi3 = -68.4680;

            double x1y5_rssi1 = -80.0455;
            double x1y5_rssi2 = -55.6364;
            double x1y5_rssi3 = -78.3182;
            //-------------------------------=============================
            double x2y1_rssi1 = -72.6785;
            double x2y1_rssi2 = -69.3076;
            double x2y1_rssi3 = -68;

            double x2y2_rssi1 = -74.3246;
            double x2y2_rssi2 = -71.625;
            double x2y2_rssi3 = -68.9097;

            double x2y3_rssi1 = -76.238;
            double x2y3_rssi2 = -73.4437;
            double x2y3_rssi3 = -74;

            double x2y4_rssi1 = -74.39;
            double x2y4_rssi2 = -64.76;
            double x2y4_rssi3 = -70.11;

            double x2y5_rssi1 = -77.48;
            double x2y5_rssi2 = -62.54;
            double x2y5_rssi3 = -80.92;
            //-------------------------------=============================
            double x3y1_rssi1 = -68.8461;
            double x3y1_rssi2 = -76.9666;
            double x3y1_rssi3 = -71.3454;

            double x3y2_rssi1 = -71.7;
            double x3y2_rssi2 = -73.2037;
            double x3y2_rssi3 = -70.225;

            double x3y3_rssi1 = -74.73;
            double x3y3_rssi2 = -68.4;
            double x3y3_rssi3 = -74.8;

            double x3y4_rssi1 = -64.56;
            double x3y4_rssi2 = 70.53;
            double x3y4_rssi3 = -76.59;

            double x3y5_rssi1 = -70.5;
            double x3y5_rssi2 = -71.81;
            double x3y5_rssi3 = -78.38;
            //-------------------------------=============================
            double x4y1_rssi1 = -62.26;
            double x4y1_rssi2 = -77.32;
            double x4y1_rssi3 = -71.07;

            double x4y2_rssi1 = -67.71;
            double x4y2_rssi2 = -73.57;
            double x4y2_rssi3 = -74.13;

            double x4y3_rssi1 = -68.62;
            double x4y3_rssi2 = -71.9;
            double x4y3_rssi3 = -77.76;

            double x4y4_rssi1 = -75.14;
            double x4y4_rssi2 = -66.85;
            double x4y4_rssi3 = -73.66;

            double x4y5_rssi1 = -73.21;
            double x4y5_rssi2 = -65.32;
            double x4y5_rssi3 = -67.41;
            //-------------------------------=============================
            double x5y0_rssi1 = -54.57;
            double x5y0_rssi2 = -81.27;
            double x5y0_rssi3 = -81.41;

            double x5y1_rssi1 = -55.5;
            double x5y1_rssi2 = -79.1;
            double x5y1_rssi3 = -76.78;

            double x5y2_rssi1 = -60.35;
            double x5y2_rssi2 = -83.5;
            double x5y2_rssi3 = -81.56;

            double x5y3_rssi1 = -63.27;
            double x5y3_rssi2 = -78.001;
            double x5y3_rssi3 = -83.13;

            double x5y4_rssi1 = -68.39;
            double x5y4_rssi2 = -74.87;
            double x5y4_rssi3 = -79.627;

            double x5y5_rssi1 = -68.42;
            double x5y5_rssi2 = -71.81;
            double x5y5_rssi3 = -82.1;
            //-------------------------------=============================

            //rssi값 대입
            MessageBox.Show("1" + rssilist[0]);



            if (((x1y1_rssi1 - noise <= rssi1) && (rssi1 <= x1y1_rssi1 + noise)) &&
                ((x1y1_rssi2 - noise <= rssi2) && (rssi2 <= x1y1_rssi2 + noise)) &&
                ((x1y1_rssi3 - noise <= rssi3) && (rssi3 <= x1y1_rssi3 + noise)))
            {
                Console.WriteLine("x1y1");
                mypoints.Add(new Point(1, 1));
            }

            if (((x1y2_rssi1 - noise <= rssi1) && (rssi1 <= x1y2_rssi1 + noise)) &&
                ((x1y2_rssi2 - noise <= rssi2) && (rssi2 <= x1y2_rssi2 + noise)) &&
                ((x1y2_rssi3 - noise <= rssi3) && (rssi3 <= x1y2_rssi3 + noise)))
            {
                Console.WriteLine("x1y2");
                mypoints.Add(new Point(1, 2));
            }

            if (((x1y3_rssi1 - noise <= rssi1) && (rssi1 <= x1y3_rssi1 + noise)) &&
                ((x1y3_rssi2 - noise <= rssi2) && (rssi2 <= x1y3_rssi2 + noise)) &&
                ((x1y3_rssi3 - noise <= rssi3) && (rssi3 <= x1y3_rssi3 + noise)))
            {
                Console.WriteLine("x1y3");
                mypoints.Add(new Point(1, 3));
            }

            if (((x1y4_rssi1 - noise <= rssi1) && (rssi1 <= x1y4_rssi1 + noise)) &&
                ((x1y4_rssi2 - noise <= rssi2) && (rssi2 <= x1y4_rssi2 + noise)) &&
                ((x1y4_rssi3 - noise <= rssi3) && (rssi3 <= x1y4_rssi3 + noise)))
            {
                Console.WriteLine("x1y4");
                mypoints.Add(new Point(1, 4));
            }

            if (((x1y5_rssi1 - noise <= rssi1) && (rssi1 <= x1y5_rssi1 + noise)) &&
                ((x1y5_rssi2 - noise <= rssi2) && (rssi2 <= x1y5_rssi2 + noise)) &&
                ((x1y5_rssi3 - noise <= rssi3) && (rssi3 <= x1y5_rssi3 + noise)))
            {
                Console.WriteLine("x1y5");
                mypoints.Add(new Point(1, 5));
            }
            //---------------------------------------------------------------------------------------------=============================

            if (((x2y1_rssi1 - noise <= rssi1) && (rssi1 <= x2y1_rssi1 + noise)) &&
                ((x2y1_rssi2 - noise <= rssi2) && (rssi2 <= x2y1_rssi2 + noise)) &&
                ((x2y1_rssi3 - noise <= rssi3) && (rssi3 <= x2y1_rssi3 + noise)))
            {
                Console.WriteLine("x2y1");
                mypoints.Add(new Point(2, 1));
            }

            if (((x2y2_rssi1 - noise <= rssi1) && (rssi1 <= x2y2_rssi1 + noise)) &&
                ((x2y2_rssi2 - noise <= rssi2) && (rssi2 <= x2y2_rssi2 + noise)) &&
                ((x2y2_rssi3 - noise <= rssi3) && (rssi3 <= x2y2_rssi3 + noise)))
            {
                Console.WriteLine("x2y2");
                mypoints.Add(new Point(2, 2));
            }

            if (((x2y3_rssi1 - noise <= rssi1) && (rssi1 <= x2y3_rssi1 + noise)) &&
                ((x2y3_rssi2 - noise <= rssi2) && (rssi2 <= x2y3_rssi2 + noise)) &&
                ((x2y3_rssi3 - noise <= rssi3) && (rssi3 <= x2y3_rssi3 + noise)))
            {
                Console.WriteLine("x2y3");
                mypoints.Add(new Point(2, 3));
            }

            if (((x2y4_rssi1 - noise <= rssi1) && (rssi1 <= x2y4_rssi1 + noise)) &&
                ((x2y4_rssi2 - noise <= rssi2) && (rssi2 <= x2y4_rssi2 + noise)) &&
                ((x2y4_rssi3 - noise <= rssi3) && (rssi3 <= x2y4_rssi3 + noise)))
            {
                Console.WriteLine("x2y4");
                mypoints.Add(new Point(2, 4));
            }

            if (((x2y5_rssi1 - noise <= rssi1) && (rssi1 <= x2y5_rssi1 + noise)) &&
                ((x2y5_rssi2 - noise <= rssi2) && (rssi2 <= x2y5_rssi2 + noise)) &&
                ((x2y5_rssi3 - noise <= rssi3) && (rssi3 <= x2y5_rssi3 + noise)))
            {
                Console.WriteLine("x2y5");
                mypoints.Add(new Point(2, 5));
            }
            //---------------------------------------------------------------------------------------------=============================

            if (((x3y1_rssi1 - noise <= rssi1) && (rssi1 <= x3y1_rssi1 + noise)) &&
                ((x3y1_rssi2 - noise <= rssi2) && (rssi2 <= x3y1_rssi2 + noise)) &&
                ((x3y1_rssi3 - noise <= rssi3) && (rssi3 <= x3y1_rssi3 + noise)))
            {
                Console.WriteLine("x3y1");
                mypoints.Add(new Point(3, 1));
            }

            if (((x3y2_rssi1 - noise <= rssi1) && (rssi1 <= x3y2_rssi1 + noise)) &&
                ((x3y2_rssi2 - noise <= rssi2) && (rssi2 <= x3y2_rssi2 + noise)) &&
                ((x3y2_rssi3 - noise <= rssi3) && (rssi3 <= x3y2_rssi3 + noise)))
            {
                Console.WriteLine("x3y2");
                mypoints.Add(new Point(3, 2));
            }

            if (((x3y3_rssi1 - noise <= rssi1) && (rssi1 <= x3y3_rssi1 + noise)) &&
                ((x3y3_rssi2 - noise <= rssi2) && (rssi2 <= x3y3_rssi2 + noise)) &&
                ((x3y3_rssi3 - noise <= rssi3) && (rssi3 <= x3y3_rssi3 + noise)))
            {
                Console.WriteLine("x3y3");
                mypoints.Add(new Point(3, 3));
            }

            if (((x3y4_rssi1 - noise <= rssi1) && (rssi1 <= x3y4_rssi1 + noise)) &&
                ((x3y4_rssi2 - noise <= rssi2) && (rssi2 <= x3y4_rssi2 + noise)) &&
                ((x3y4_rssi3 - noise <= rssi3) && (rssi3 <= x3y4_rssi3 + noise)))
            {
                Console.WriteLine("x3y4");
                mypoints.Add(new Point(3, 4));
            }

            if (((x3y5_rssi1 - noise <= rssi1) && (rssi1 <= x3y5_rssi1 + noise)) &&
                ((x3y5_rssi2 - noise <= rssi2) && (rssi2 <= x3y5_rssi2 + noise)) &&
                ((x3y5_rssi3 - noise <= rssi3) && (rssi3 <= x3y5_rssi3 + noise)))
            {
                Console.WriteLine("x3y5");
                mypoints.Add(new Point(3, 5));
            }
            //---------------------------------------------------------------------------------------------=============================

            if (((x4y1_rssi1 - noise <= rssi1) && (rssi1 <= x4y1_rssi1 + noise)) &&
                ((x4y1_rssi2 - noise <= rssi2) && (rssi2 <= x4y1_rssi2 + noise)) &&
                ((x4y1_rssi3 - noise <= rssi3) && (rssi3 <= x4y1_rssi3 + noise)))
            {
                Console.WriteLine("x4y1");
                mypoints.Add(new Point(4, 1));
            }

            if (((x4y2_rssi1 - noise <= rssi1) && (rssi1 <= x4y2_rssi1 + noise)) &&
                ((x4y2_rssi2 - noise <= rssi2) && (rssi2 <= x4y2_rssi2 + noise)) &&
                ((x4y2_rssi3 - noise <= rssi3) && (rssi3 <= x4y2_rssi3 + noise)))
            {
                Console.WriteLine("x4y2");
                mypoints.Add(new Point(4, 2));
            }

            if (((x4y3_rssi1 - noise <= rssi1) && (rssi1 <= x4y3_rssi1 + noise)) &&
                ((x4y3_rssi2 - noise <= rssi2) && (rssi2 <= x4y3_rssi2 + noise)) &&
                ((x4y3_rssi3 - noise <= rssi3) && (rssi3 <= x4y3_rssi3 + noise)))
            {
                Console.WriteLine("x4y3");
                mypoints.Add(new Point(4, 3));
            }

            if (((x4y4_rssi1 - noise <= rssi1) && (rssi1 <= x4y4_rssi1 + noise)) &&
                ((x4y4_rssi2 - noise <= rssi2) && (rssi2 <= x4y4_rssi2 + noise)) &&
                ((x4y4_rssi3 - noise <= rssi3) && (rssi3 <= x4y4_rssi3 + noise)))
            {
                Console.WriteLine("x4y4");
                mypoints.Add(new Point(4, 4));
            }

            if (((x4y5_rssi1 - noise <= rssi1) && (rssi1 <= x4y5_rssi1 + noise)) &&
                ((x4y5_rssi2 - noise <= rssi2) && (rssi2 <= x4y5_rssi2 + noise)) &&
                ((x4y5_rssi3 - noise <= rssi3) && (rssi3 <= x4y5_rssi3 + noise)))
            {
                Console.WriteLine("x4y5");
                mypoints.Add(new Point(4, 5));
            }
            //---------------------------------------------------------------------------------------------=============================

            if (((x5y0_rssi1 - noise <= rssi1) && (rssi1 <= x5y0_rssi1 + noise)) &&
                ((x5y0_rssi2 - noise <= rssi2) && (rssi2 <= x5y0_rssi2 + noise)) &&
                ((x5y0_rssi3 - noise <= rssi3) && (rssi3 <= x5y0_rssi3 + noise)))
            {
                Console.WriteLine("x5y0");
                mypoints.Add(new Point(5, 0));
            }

            if (((x5y1_rssi1 - noise <= rssi1) && (rssi1 <= x5y1_rssi1 + noise)) &&
                ((x5y1_rssi2 - noise <= rssi2) && (rssi2 <= x5y1_rssi2 + noise)) &&
                ((x5y1_rssi3 - noise <= rssi3) && (rssi3 <= x5y1_rssi3 + noise)))
            {
                Console.WriteLine("x5y1");
                mypoints.Add(new Point(5, 1));
            }

            if (((x5y2_rssi1 - noise <= rssi1) && (rssi1 <= x5y2_rssi1 + noise)) &&
                ((x5y2_rssi2 - noise <= rssi2) && (rssi2 <= x5y2_rssi2 + noise)) &&
                ((x5y2_rssi3 - noise <= rssi3) && (rssi3 <= x5y2_rssi3 + noise)))
            {
                Console.WriteLine("x5y2");
                mypoints.Add(new Point(5, 2));
            }

            if (((x5y3_rssi1 - noise <= rssi1) && (rssi1 <= x5y3_rssi1 + noise)) &&
                ((x5y3_rssi2 - noise <= rssi2) && (rssi2 <= x5y3_rssi2 + noise)) &&
                ((x5y3_rssi3 - noise <= rssi3) && (rssi3 <= x5y3_rssi3 + noise)))
            {
                Console.WriteLine("x5y3");
                mypoints.Add(new Point(5, 3));
            }

            if (((x5y4_rssi1 - noise <= rssi1) && (rssi1 <= x5y4_rssi1 + noise)) &&
                ((x5y4_rssi2 - noise <= rssi2) && (rssi2 <= x5y4_rssi2 + noise)) &&
                ((x5y4_rssi3 - noise <= rssi3) && (rssi3 <= x5y4_rssi3 + noise)))
            {
                Console.WriteLine("x5y4");
                mypoints.Add(new Point(5, 2));
            }

            if (((x5y5_rssi1 - noise <= rssi1) && (rssi1 <= x5y5_rssi1 + noise)) &&
                ((x5y5_rssi2 - noise <= rssi2) && (rssi2 <= x5y5_rssi2 + noise)) &&
                ((x5y5_rssi3 - noise <= rssi3) && (rssi3 <= x5y5_rssi3 + noise)))
            {
                Console.WriteLine("x5y5");
                mypoints.Add(new Point(5, 2));
            }
            //---------------------------------------------------------------------------------------------=============================*/
            //======================================================================================-------------------------========================---------------------======================

            if (((x1y1_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x1y1_rssi1 + (noise - 2))) &&
                ((x1y1_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x1y1_rssi2 + (noise - 2))) &&
                ((x1y1_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x1y1_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x1y1");
                mypoints.Add(new Point(1, 1));
                mypoints.Add(new Point(1, 1));
            }

            if (((x1y2_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x1y2_rssi1 + (noise - 2))) &&
                ((x1y2_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x1y2_rssi2 + (noise - 2))) &&
                ((x1y2_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x1y2_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x1y2");
                mypoints.Add(new Point(1, 2));
                mypoints.Add(new Point(1, 2));
            }

            if (((x1y3_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x1y3_rssi1 + (noise - 2))) &&
                ((x1y3_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x1y3_rssi2 + (noise - 2))) &&
                ((x1y3_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x1y3_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x1y3");
                mypoints.Add(new Point(1, 3));
                mypoints.Add(new Point(1, 3));
            }

            if (((x1y4_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x1y4_rssi1 + (noise - 2))) &&
                ((x1y4_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x1y4_rssi2 + (noise - 2))) &&
                ((x1y4_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x1y4_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x1y4");
                mypoints.Add(new Point(1, 4));
                mypoints.Add(new Point(1, 4));
            }

            if (((x1y5_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x1y5_rssi1 + (noise - 2))) &&
                ((x1y5_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x1y5_rssi2 + (noise - 2))) &&
                ((x1y5_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x1y5_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x1y5");
                mypoints.Add(new Point(1, 5));
                mypoints.Add(new Point(1, 5));
            }
            //---------------------------------------------------------------------------------------------=============================

            if (((x2y1_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x2y1_rssi1 + (noise - 2))) &&
                ((x2y1_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x2y1_rssi2 + (noise - 2))) &&
                ((x2y1_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x2y1_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x2y1");
                mypoints.Add(new Point(2, 1));
                mypoints.Add(new Point(2, 1));
            }

            if (((x2y2_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x2y2_rssi1 + (noise - 2))) &&
                ((x2y2_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x2y2_rssi2 + (noise - 2))) &&
                ((x2y2_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x2y2_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x2y2");
                mypoints.Add(new Point(2, 2));
                mypoints.Add(new Point(2, 2));
            }

            if (((x2y3_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x2y3_rssi1 + (noise - 2))) &&
                ((x2y3_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x2y3_rssi2 + (noise - 2))) &&
                ((x2y3_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x2y3_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x2y3");
                mypoints.Add(new Point(2, 3));
                mypoints.Add(new Point(2, 3));
            }

            if (((x2y4_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x2y4_rssi1 + (noise - 2))) &&
                ((x2y4_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x2y4_rssi2 + (noise - 2))) &&
                ((x2y4_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x2y4_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x2y4");
                mypoints.Add(new Point(2, 4));
                mypoints.Add(new Point(2, 4));
            }

            if (((x2y5_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x2y5_rssi1 + (noise - 2))) &&
                ((x2y5_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x2y5_rssi2 + (noise - 2))) &&
                ((x2y5_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x2y5_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x2y5");
                mypoints.Add(new Point(2, 5));
                mypoints.Add(new Point(2, 5));
            }
            //---------------------------------------------------------------------------------------------=============================

            if (((x3y1_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x3y1_rssi1 + (noise - 2))) &&
                ((x3y1_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x3y1_rssi2 + (noise - 2))) &&
                ((x3y1_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x3y1_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x3y1");
                mypoints.Add(new Point(3, 1));
                mypoints.Add(new Point(3, 1));
            }

            if (((x3y2_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x3y2_rssi1 + (noise - 2))) &&
                ((x3y2_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x3y2_rssi2 + (noise - 2))) &&
                ((x3y2_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x3y2_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x3y2");
                mypoints.Add(new Point(3, 2));
                mypoints.Add(new Point(3, 2));
            }

            if (((x3y3_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x3y3_rssi1 + (noise - 2))) &&
                ((x3y3_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x3y3_rssi2 + (noise - 2))) &&
                ((x3y3_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x3y3_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x3y3");
                mypoints.Add(new Point(3, 3));
                mypoints.Add(new Point(3, 3));
            }

            if (((x3y4_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x3y4_rssi1 + (noise - 2))) &&
                ((x3y4_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x3y4_rssi2 + (noise - 2))) &&
                ((x3y4_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x3y4_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x3y4");
                mypoints.Add(new Point(3, 4));
                mypoints.Add(new Point(3, 4));
            }

            if (((x3y5_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x3y5_rssi1 + (noise - 2))) &&
                ((x3y5_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x3y5_rssi2 + (noise - 2))) &&
                ((x3y5_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x3y5_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x3y5");
                mypoints.Add(new Point(3, 5));
                mypoints.Add(new Point(3, 5));
            }
            //---------------------------------------------------------------------------------------------=============================
            if (((x4y1_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x4y1_rssi1 + (noise - 2))) &&
                ((x4y1_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x4y1_rssi2 + (noise - 2))) &&
                ((x4y1_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x4y1_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x4y1");
                mypoints.Add(new Point(4, 1));
                mypoints.Add(new Point(4, 1));
            }

            if (((x4y2_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x4y2_rssi1 + (noise - 2))) &&
                ((x4y2_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x4y2_rssi2 + (noise - 2))) &&
                ((x4y2_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x4y2_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x4y2");
                mypoints.Add(new Point(4, 2));
                mypoints.Add(new Point(4, 2));
            }

            if (((x4y3_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x4y3_rssi1 + (noise - 2))) &&
                ((x4y3_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x4y3_rssi2 + (noise - 2))) &&
                ((x4y3_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x4y3_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x4y3");
                mypoints.Add(new Point(4, 3));
                mypoints.Add(new Point(4, 3));
            }

            if (((x4y4_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x4y4_rssi1 + (noise - 2))) &&
                ((x4y4_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x4y4_rssi2 + (noise - 2))) &&
                ((x4y4_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x4y4_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x4y4");
                mypoints.Add(new Point(4, 4));
                mypoints.Add(new Point(4, 4));
            }

            if (((x4y5_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x4y5_rssi1 + (noise - 2))) &&
                ((x4y5_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x4y5_rssi2 + (noise - 2))) &&
                ((x4y5_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x4y5_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x4y5");
                mypoints.Add(new Point(4, 5));
                mypoints.Add(new Point(4, 5));
            }
            //---------------------------------------------------------------------------------------------=============================
            if (((x5y1_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x5y1_rssi1 + (noise - 2))) &&
                ((x5y1_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x5y1_rssi2 + (noise - 2))) &&
                ((x5y1_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x5y1_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x5y1");
                mypoints.Add(new Point(5, 1));
                mypoints.Add(new Point(5, 1));
            }

            if (((x5y2_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x5y2_rssi1 + (noise - 2))) &&
                ((x5y2_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x5y2_rssi2 + (noise - 2))) &&
                ((x5y2_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x5y2_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x5y2");
                mypoints.Add(new Point(5, 2));
                mypoints.Add(new Point(5, 2));
            }

            if (((x5y3_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x5y3_rssi1 + (noise - 2))) &&
                ((x5y3_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x5y3_rssi2 + (noise - 2))) &&
                ((x5y3_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x5y3_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x5y3");
                mypoints.Add(new Point(5, 3));
                mypoints.Add(new Point(5, 3));
            }

            if (((x5y4_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x5y4_rssi1 + (noise - 2))) &&
                ((x5y4_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x5y4_rssi2 + (noise - 2))) &&
                ((x5y4_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x5y4_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x5y4");
                mypoints.Add(new Point(5, 4));
                mypoints.Add(new Point(5, 4));
            }

            if (((x5y5_rssi1 - (noise - 2) <= rssi1) && (rssi1 <= x5y5_rssi1 + (noise - 2))) &&
                ((x5y5_rssi2 - (noise - 2) <= rssi2) && (rssi2 <= x5y5_rssi2 + (noise - 2))) &&
                ((x5y5_rssi3 - (noise - 2) <= rssi3) && (rssi3 <= x5y5_rssi3 + (noise - 2))))
            {
                Console.WriteLine("세밀버전 : x5y5");
                mypoints.Add(new Point(5, 5));
                mypoints.Add(new Point(5, 5));
            }
            //---------------------------------------------------------------------------------------------=============================
            if (mypoints.Count() <= 0)
            {

                return new Point(0, 0);
            }
            double fx = 0;
            double fy = 0;
            double dcount = 0;

            foreach (Point pt in mypoints)
            {
                dcount++;
                fx += pt.X;
                fy += pt.Y;
            }

            fx = fx / dcount;
            fy = fy / dcount;
            MessageBox.Show("x:" + fx);
            MessageBox.Show("y:" + fy);
            fx = (686 - (fx * 32));
            fy = ((fy * 32) + 256);
            return new Point(fx, fy);

        }
        public class Point2D
        {
            public string bname;
            public double x;
            public double y;
            public double distance;

            public Point2D() { }
            public Point2D(double x, double y, double distance, string bname)
            {
                this.x = x;
                this.y = y;
                this.distance = distance;
                this.bname = bname;

            }
            public double getX()
            {
                return this.x;
            }
            public double getY()
            {
                return this.y;
            }
            public double getDistance()
            {
                return this.distance;
            }
            public string getBname()
            {
                return this.bname;
            }






            public Point2D getUserPS(double d1, double d2, double dis, string bname)
            {

                Point2D position1 = new Point2D(d1, d2, dis, bname);

                return position1;

            }



        };


    }
}
