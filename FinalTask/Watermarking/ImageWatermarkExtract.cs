using DCTLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Watermarking
{
    public class ImageWatermarkExtract
    {
        public string Mark { get; private set; }
        public Bitmap ImgIn { get; set; }
        
        public ImageWatermarkExtract(Bitmap img)
        {
            ImgIn = img;
        }

        private static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length - data.Length % 8; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }
        public void Execute()
        {
            string test = "";
            DCT dd = new DCT(ImgIn.Width, ImgIn.Height);
            var t = dd.BitmapToMatrices(ImgIn);
            DCT d = new DCT(8, 8);
            int height = ImgIn.Height - ImgIn.Height % 8;
            int width = ImgIn.Width - ImgIn.Width % 8;

            for (int i = 0; i < height; i += 8)
            {
                for (int j = 0; j < width; j += 8)
                {
                    double[,] r = new double[8, 8];
                    for (int q = 0; q < 8; q++)
                    {
                        for (int e = 0; e < 8; e++)
                        {
                            r[e, q] = t[0][j + e, i + q];
                        }
                    }
                    r = d.DCT2D(r);

                    if (r[7, 7] < 0)
                    {
                        test += "0";
                    }
                    else{
                        test += "1";
                    }                   
                }
            }

            // Check mark
            for (int i =0; i < 8; i++)
            {
                Mark = BinaryToString(test);
                int count = 0;
                foreach(var item in Mark)
                {
                    if (Char.IsLetterOrDigit(item))
                    {
                        count++;
                    }
                }
                if (count > Mark.Length / 5)
                {
                    break;
                }
                Mark = "None";
            }            
        }
    }
}
