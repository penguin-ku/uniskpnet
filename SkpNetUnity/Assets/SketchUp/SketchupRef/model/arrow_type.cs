using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// Indicates the supported arrow types, currently used by SUDimensionRef and SUTextRef.
    /// </summary>
    public enum SUArrowType
    {
        SUArrowNone = 0,
        SUArrowSlash,
        SUArrowDot,
        SUArrowClosed,
        SUArrowOpen
    };
}
