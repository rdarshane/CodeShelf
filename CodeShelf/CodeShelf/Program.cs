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
            Cat a = new Cat();
            a.ISBN = "New##-456-";
            Console.WriteLine(a.Speak());
            Console.WriteLine(a.ISBN);
            Console.ReadLine();
        }
    }
}
