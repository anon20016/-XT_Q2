using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarking.Interfaces;
//using Accord.Video.FFMPEG;  

namespace Watermarking
{
    public class VideoWatermarkEmbed : IWatermarkEmbed
    {
        public string Mark { get; set; }
        public string VideoIn { get; set; }
        public string VideoOut { get; private set; }
        public int Robustness { get; set; }

        public void Execute()
        {
           
        }
    }
}
