using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib
{
    public class TextSorter : MarshalByRefObject
    {
        public string SortWords(string input)
        {
            return string.Join(" ", input.Split(' ').OrderByDescending(x => x));
        }

        public void Delay(string input)
        {
            Task.Delay(100000);
        }
    }
}
