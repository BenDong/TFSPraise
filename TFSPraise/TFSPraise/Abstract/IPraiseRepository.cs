using System.Collections.Generic;
using TFSPraise.Entities;

namespace TFSPraise.Abstract
{
    public interface IPraiseRepository
    {
        IEnumerable<Praise> GetPraises();
    }
}