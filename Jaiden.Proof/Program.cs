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
            //int via = 100;

            //Console.WriteLine(via);
            //change(&via);
            //Console.WriteLine(via);
            //Console.WriteLine(IDateTime.Now);

            List<object> intarray = new List<object>();
            for (int i = 0; i < 101; i++)
            {
                intarray.Add(i);
            }
            ForkAlgori.TForkgori(intarray);

            Console.Read();



        }

        


        unsafe static void change(int* value)
        {
            *value = 300;
        }
    }
}
