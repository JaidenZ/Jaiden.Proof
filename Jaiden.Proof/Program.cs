using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jaiden.Proof
{
    class NDateTime
    {
        private DateTime value;

        public static implicit operator DateTime(NDateTime value)
        {
            return value.value;
        }

        public static implicit operator NDateTime(DateTime value)
        {
            return new NDateTime() { value = value };
        }

        public static implicit operator string(NDateTime value)
        {
            return value.value.ToString();
        }

        public static NDateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public static explicit operator long(NDateTime value)
        {
            return value.value.Ticks;
        }
 
    }

    class Program
    {
        static void Main(string[] args)
        {


            string value = NDateTime.Now;
            DateTime dt = NDateTime.Now;

            long c = (long)NDateTime.Now;

            Console.WriteLine(value);

            Console.WriteLine(c);

            //OddEven e = new OddEven();
            //e.ExistNumber(23238);
            Console.Read();
        }
    }
}
