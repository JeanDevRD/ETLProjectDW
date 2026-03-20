using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETLProjectDW.Core.Application.Interfaces
{
    public interface IExtractor<T>
    {
        Task<IEnumerable<T>> ExtractAsync();
    }
}
