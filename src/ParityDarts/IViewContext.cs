using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts
{
    public interface IViewContext<T>
    {
        T ContextualData { get; set; }
    }
}
