using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jaiden.Proof
{
    public static class ForkAlgori
    {

        public static void TForkgori(List<object> array)
        {
            int arraylen = array.Count;
            int mid = arraylen / 2;
            //获取中间位置
            if ((arraylen-- & 1) > 0)
            {
                object mido = array[mid];

                //判断数据
                Console.WriteLine("first:" + mido);
            }
            //左右同时向中间检索
            for (int i = 0; i < mid; i++)
            {
                int j = arraylen - i;
                object left = array[i];
                object right = array[j];

                //判断数据
                Console.WriteLine(left + "-" + right);
            }
        }

        public static void OForkgori(List<object> array)
        {
            int arraylen = array.Count;
            int mid = arraylen / 2;
            //获取中间位置
            if ((arraylen-- & 1) > 0)
            {
                object mido = array[mid];

                //判断数据
                Console.WriteLine("first:" + mido);
            }
            //从中间向两边检索
            for (int i = mid; i > 0; i--)
            {
                int j = mid + i;
                object left = array[i];
                object right = array[j];

                //判断数据
                Console.WriteLine(left + "-" + right);
            }
        }

    }
}
