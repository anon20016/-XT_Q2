using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tasks10.Control
{
    public class Action
    {
        public static int counter {get;set;}
        public static void add()
        {
            counter++;
        }
    }
}