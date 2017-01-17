using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jaiden.Proof
{

    class Program
    {
        unsafe static void Main(string[] args)
        {
            int via = 100;

            Console.WriteLine(via);
            change(&via);
            Console.WriteLine(via);

            Console.Read();



        }

        unsafe static void change(int* value)
        {
            *value = 300;
        }
    }
}
