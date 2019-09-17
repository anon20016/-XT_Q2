using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class lib
    {
        public static int GetId(string s)
        {
            int res = 0;
            foreach(var i in s)
            {
                if (Char.IsDigit(i))
                {
                    res = res * 10 + Convert.ToInt32(i - '0');
                }
                else
                {
                    break;
                }
            }
            return res;
        }
    }
}
