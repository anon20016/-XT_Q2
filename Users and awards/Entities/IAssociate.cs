namespace Entities
{
    public interface IAssociate
    {
        bool Associate(int fr, int sc);
        bool deAssociate(int fr, int sc);
    }
}
