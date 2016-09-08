using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeShelf
{
    class Animal
    {
        public Animal()
        {
            ISBN = 134;
        }

        public string Speak()
        {
            return "Animal speaking";
        }

        public int ISBN { get; set; }
    }

    class Cat : Animal
    {
        private string _isbn;

        public new string Speak()
        {
            return $"{base.Speak()} Meow";
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
