using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Jaiden.Proof.Reflex
{
    public static class ModelUnit
    {
        /// <summary>
        /// 通过映射创建对象
        /// </summary>
        /// <typeparam name="T">创建的类型</typeparam>
        /// <param name="value">源对象</param>
        /// <returns>结果对象</returns>
        public static T Copy<T>(this object value) where T : class, new()
        {
            if (value == null)
            {
                throw new ArgumentNullException("value is null");
            }
            Type clazz = value.GetType();
            T copy = new T();
            Type t = typeof(T);
            //遍历对象的属性
            foreach (PropertyInfo pi in clazz.GetProperties())
            {
                var pp = t.GetProperty(pi.Name);
                if (pp != null)
                {
                    object o = pi.GetValue(value, null);
                    pp.SetValue(copy, o, null);
                }
            }
            return copy;
        }

    }
}
