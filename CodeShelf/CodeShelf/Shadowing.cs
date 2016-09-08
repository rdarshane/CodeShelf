using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShelf
{
    class Book
    {
        public Book()
        {
            ISBN = 134;
        }

        public string GetTypeString()
        {
            return "Book";
        }

        public int ISBN { get; set; }
    }

    class Magazine : Book
    {
        private string _isbn;

        public new string GetTypeString()
        {
            return $"{base.GetTypeString()} : Magazine";
        }

        public new string ISBN
        {
            get
            {
                return $"{_isbn}{base.ISBN.ToString()}";
            }
            set
            {
                _isbn = value;
            }
        }
    }
}
