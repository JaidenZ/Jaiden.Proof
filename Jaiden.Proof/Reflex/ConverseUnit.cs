using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Jaiden.Proof.Reflex
{
    /// <summary>
    /// 允许字段反转属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class AllowFieldReverseAttribute : Attribute
    {
    }

    /// <summary>
    /// 反转单元
    /// </summary>
    public static class ReserveUnit
    {

        private static IList<int> _typeMapSize = new int[] { 4, 4, 2 };
        private static IList<Type> _typeMapTab = new Type[] { typeof(uint), typeof(int), typeof(ushort) };

        private static int GetTypeSize(Type clazz)
        {
            if (!clazz.IsValueType)
            {
                return 0;
            }
            int ofs = _typeMapTab.IndexOf(clazz);
            if (ofs < 0)
            {
                return 0;
            }
            return _typeMapSize[ofs];
        }

        public static object Reverse(object obj)
        {
            return ReserveUnit.Reverse(obj, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static object Reverse(object obj, BindingFlags flags)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            Type clazz = obj.GetType();
            foreach (FieldInfo fi in clazz.GetFields(flags))
            {
                object[] attrs = fi.GetCustomAttributes(typeof(AllowFieldReverseAttribute), false);
                if (attrs.Length > 0)
                {
                    object value = fi.GetValue(obj);
                    value = ReserveUnit.Reverse(fi.FieldType, value);
                    fi.SetValue(obj, value);
                    
                }
            }
            return obj;
        }


        private static long Reverse(long value, int size)
        {
            byte[] buffer = new byte[sizeof(long)];
            for (int i = size - 1, j = 0; i >= 0; i--, j++)
            {
                buffer[j] = (byte)(value >> (i * 8));
            }
            return BitConverter.ToInt64(buffer, 0);
        }
        
        private static object Reverse(Type clazz, object value)
        {
            int size = ReserveUnit.GetTypeSize(clazz);
            if (size <= 0)
            {
                return value;
            }
            long num = ReserveUnit.Reverse(Convert.ToInt64(value), size);
            if (clazz == typeof(uint))
            {
                return (uint)num;
            }
            if (clazz == typeof(int))
            {
                return (int)num;
            }
            if (clazz == typeof(ulong))
            {
                return (ulong)num;
            }
            if (clazz == typeof(ushort))
            {
                return (ushort)num;
            }
            return num;
        }

        private static byte[] Reverse(byte[] value)
        {
            Array.Reverse(value);
            return value;
        }

        public static float Reverse(float value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            return BitConverter.ToSingle(ReserveUnit.Reverse(buffer), 0);
        }
    }
}
