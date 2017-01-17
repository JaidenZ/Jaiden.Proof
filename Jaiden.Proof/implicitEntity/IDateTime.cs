using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jaiden.Proof
{

    public partial class IDateTime
    {
        private DateTime _this;

        #region structure
        
        public static implicit operator DateTime(IDateTime value)
        {
            return value._this;
        }
        public static implicit operator IDateTime(DateTime value)
        {
            return new IDateTime() { _this = value };
        }
        #endregion

        #region expression


        public static implicit operator string(IDateTime value)
        {
            return value._this.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static implicit operator IDateTime(string value)
        {
            IDateTime date = new IDateTime();
            date._this = DateTime.Now;

            if(string.IsNullOrEmpty(value)){
                try
                {
                    date._this = Convert.ToDateTime(value);
                }
                catch { };
            }
            return date;
        }

        #endregion

        public static IDateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

    }
}
