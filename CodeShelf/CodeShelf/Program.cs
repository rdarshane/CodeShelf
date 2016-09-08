using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazine a = new Magazine();
            a.ISBN = "New##-456-";
            Console.WriteLine(a.GetTypeString());
            Console.WriteLine(a.ISBN);
            Console.ReadLine();
        }
    }
}
