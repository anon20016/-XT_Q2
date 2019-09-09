using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IAssociate
    {
        bool Associate(int fr, int sc);
        bool deAssociate(int fr, int sc);
    }
}
