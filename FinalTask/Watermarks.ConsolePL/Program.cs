using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermarks.Common;

namespace Watermarks.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var userlogic = DependencyResolver.UserLogic;
            var authlogic = DependencyResolver.AuthLogic;
            var rolelogic = DependencyResolver.RoleLogic;

            
            Console.ReadLine();
        }
    }
}
