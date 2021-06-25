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
using System.Net.Http.Headers;


namespace Topic2SampleCode
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            string imageFileName = "giantPanda.jpeg";
            Uri url = new Uri("http://xxx.xxx.xxx.xxx:8002/model/predict_images/images");

            byte[] fileBytes;
            FileStream fs = new FileStream(imageFileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            fileBytes = br.ReadBytes((int)fs.Length);

            

            WebRequest request = WebRequest.Create(url);

            request.Method = "POST";

            request.ContentType = "image/jpeg";
            request.ContentLength = fileBytes.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(fileBytes, 0, fileBytes.Length);

            dataStream.Close();
            WebResponse response = request.GetResponse();
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();
        }

    }
}
