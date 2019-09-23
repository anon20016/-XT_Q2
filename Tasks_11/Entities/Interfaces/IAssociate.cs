using System.Collections.Generic;
namespace Entities
{
    public interface IAssociate
    {
        bool Associate(int fr, int sc);
        bool deAssociate(int fr, int sc);
        void RemoveFirstId(int x);
        void RemoveSecondId(int x);

        ICollection<Association> GetAllAssotiations();
    }
}
