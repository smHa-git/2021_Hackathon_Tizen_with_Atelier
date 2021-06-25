using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using System.IO;


namespace Topic1SampleCode
{
    class Program
    {
        String m_url = "http://xxx.xxx.xxx.xxx:53001";
                
        String m_postData = "";
        String m_nowString = "";
        int m_deviceID = 9001;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Send Data Start!!!");
            Console.WriteLine("");

            var p = new Program();
        
            string[] readString = File.ReadAllLines(@"sensor_data_temp.txt");

            foreach (string show in readString)
            {
                p.m_nowString = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                p.m_postData = "{\"DEVICE_ID\" : " + p.m_deviceID + ", \"SENSOR_INPUT_TIME\" : \"" + p.m_nowString + "\", "   + show +  "\"}";
                Console.WriteLine(p.m_postData);

                try
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] data = Encoding.GetEncoding("UTF-8").GetBytes(p.m_postData);

                    WebRequest request = WebRequest.Create(p.m_url);

                    request.Method = "POST";           
                    request.ContentType = "application/json; charset=UTF-8";
                    request.ContentLength = data.Length;

                    Stream stream = request.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();

                    WebResponse response = request.GetResponse();
                    stream = response.GetResponseStream();

                    StreamReader sr = new StreamReader(stream);
                    string responseFromServer = sr.ReadToEnd();
                    Console.WriteLine(responseFromServer);

                    sr.Close();
                    stream.Close();
                    response.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : " + ex.Message);
                }

                Thread.Sleep(1000);
            }
        }
    }
}
