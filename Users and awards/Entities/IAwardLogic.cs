using System.Collections.Generic;

namespace Entities
{
    public interface IAwardLogic
    {
        ICollection<Award> GetAll();
    }
}
