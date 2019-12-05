using DCTLib;
using System;
using System.Drawing;
using System.Text;
using Watermarking.Interfaces;

namespace Watermarking
{
    public class ImageWatermarkEmbed : IWatermarkEmbed
    {
        public string Mark { get; set; }
        public Bitmap ImgIn { get; set; }
        public Bitmap ImgOut { get; private set; }
        public int Robustness { get; set; }

        public ImageWatermarkEmbed (string mark, Bitmap img, int robastness)
        {
            ImgIn = img;
            Mark = StringToBinary(mark);
            ImgOut = new Bitmap(img.Width, img.Height);
            Robustness = robastness;
        }
        public ImageWatermarkEmbed()
        {
            ImgIn = null;
            Mark = null;
            ImgOut = null;
            Robustness = 0;
        }

        private static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }       

        public void Execute()
        {
            DCT dd = new DCT(ImgIn.Width, ImgIn.Height);
            var t = dd.BitmapToMatrices(ImgIn);
            DCT d = new DCT(8, 8);
            int h = ImgIn.Height - ImgIn.Height % 8;
            int w = ImgIn.Width - ImgIn.Width % 8;
            int c = 0;
            for (int i = 0; i < h; i += 8)
            {
                for (int j = 0; j < w; j += 8)
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

                    r[7, 7] = Robustness;
                    if (Mark[c] == '0')
                    {
                        r[7, 7] = -Robustness;
                    }
                    c = (c + 1) % Mark.Length;

                    r = d.IDCT2D(r);
                    for (int q = 0; q < 8; q++)
                    {
                        for (int e = 0; e < 8; e++)
                        {
                            t[0][j + e, i + q] = r[e, q];
                        }
                    }
                }
            }

            ImgOut = dd.MatricesToBitmap(t);           
        }
    }
}
