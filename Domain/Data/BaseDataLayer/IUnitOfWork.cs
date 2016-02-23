using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDataLayer
{
    public interface IUnitOfWork<T> : IDisposable where T : IContext
    {
        int Save();
        T Context { get; }
    }
}
