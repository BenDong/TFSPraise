using System.Collections.Generic;
using TFSPraise.Domains;

namespace TFSPraise.Abstract
{
    public interface IPraiseRepository
    {
        IEnumerable<Praise> GetPraises();
    }
}