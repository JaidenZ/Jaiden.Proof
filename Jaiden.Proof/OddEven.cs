using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jaiden.Proof
{
    public class OddEven
    {
        public void ExistNumber(int num)
        {
            if((num & 1) > 0){
                Console.WriteLine("奇数");
            }
            else
            {
                Console.WriteLine("偶数");
            }

        }

    }
}
