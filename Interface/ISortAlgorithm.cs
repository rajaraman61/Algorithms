using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Interface
{
    public interface ISortAlgorithm
    {
        void Run();
		int[] Sort(int[] arr);
        string GetDescription();
    }
}
