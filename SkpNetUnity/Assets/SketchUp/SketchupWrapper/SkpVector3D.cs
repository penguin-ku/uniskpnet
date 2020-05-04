using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    public static class SkpVector3D
    {
        public static Vector3 ToVector3(this SUVector3D vector)
        {
            return new Vector3((float)vector.x, (float)vector.y, (float)vector.z);
        }

        public static Vector3 ToVector3(this SUPoint3D point)
        {
            return new Vector3((float)point.x, (float)point.y, (float)point.z);
        }
    };
}
