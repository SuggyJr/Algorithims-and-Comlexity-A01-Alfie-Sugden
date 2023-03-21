using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1124M___Aclgorithms_and_Complexity___A01
{
    public static class searchAndSort
    {
        public static void searchTrafficData()
        {
            //
        }

        public static void sortTrafficDataAsc(int[] array) 
        {
            Array.Sort(array);
            Console.WriteLine("Sorted Ascending");
        }

        public static void sortTrafficDataDesc(int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
            Console.WriteLine("Sorted Descending");
        }
    }
}
