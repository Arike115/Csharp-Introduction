using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Introduction
{
    internal class QueryFunctions
    {
        //ordering operators
        public static void OrderingMethod()
        {
            List<int> intlist = new List<int>() { 10,45,30, 28,107,76,63,98};
            Console.WriteLine("before sorting");
            foreach(int i in intlist)
            {
                Console.WriteLine(i + " ");
            }
            
            //method syntax
            var data = intlist.Where(x => x > 30).OrderByDescending(x => x).ToList();

            //query syntax
            var datas = (from x in intlist
                         where x > 30
                         orderby x 
                         select x).ToList();
            Console.WriteLine("**********************");
            Console.WriteLine("after sorting .............");
            foreach(int i in datas)
                Console.WriteLine(i + " ");
        }
    }
}
