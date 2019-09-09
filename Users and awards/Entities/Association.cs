using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Association
    {
        int firstID { get; set; }
        int secondID { get; set; }

        public Association(int fr, int sc)
        {
            firstID = fr;
            secondID = sc;
        }
    }
}