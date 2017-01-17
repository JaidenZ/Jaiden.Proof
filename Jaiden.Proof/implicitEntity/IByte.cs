using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jaiden.Proof.implicitEntity
{
    public partial class IByte
    {
        byte _this;

        public static implicit operator byte(IByte value)
        {


            return value._this;
        }
    }
}
