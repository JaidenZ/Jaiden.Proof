using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jaiden.Proof.Entity;
using Jaiden.Proof.Reflex;

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

            //List<object> intarray = new List<object>();
            //for (int i = 0; i < 101; i++)
            //{
            //    intarray.Add(i);
            //}
            //ForkAlgori.TForkgori(intarray);

            //Console.Read();

            ConverseT ct = new ConverseT()
            {
                Converse2 = 1 << 8 | 1 << 16 | 1 << 24 | 0 << 0,
                Converse3 = 1 << 8 | 0 << 0
            };
            
        }




        unsafe static void change(int* value)
        {
            *value = 300;
        }
    }
}
