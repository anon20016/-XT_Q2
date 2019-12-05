using DCTLib;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarking;
using Watermarks.Common;

namespace Watermarks.ConsolePL
{
    class Program
    {       
        static void Main(string[] args)
        {
           
          Bitmap img = new Bitmap("57bdb61578ab8156bd0f43f6.png");

           ImageWatermarkEmbed w = new ImageWatermarkEmbed("My name Anton", img, 50);
           w.Execute();
           w.ImgOut.Save("57bdb61578ab8156bd0f43f61.png");



           Bitmap img2 = new Bitmap("57bdb61578ab8156bd0f43f6.png");
            ImageWatermarkExtract ww = new ImageWatermarkExtract(img2);
           ww.Execute();
          Console.WriteLine(ww.Mark);
           

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
