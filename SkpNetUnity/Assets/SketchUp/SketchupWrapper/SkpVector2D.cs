using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    public static class SkpVector2D
    {
        public static Vector2 ToVector2(this SUVector2D vertor)
        {
            return new Vector2((float)vertor.x, (float)vertor.y);
        }

        public static Vector2 ToVector2(this SUPoint2D point)
        {
            return new Vector2((float)point.x, (float)point.y);
        }

        public static Vector2 ToVector2(this SUVector3D vertor)
        {
            return new Vector2((float)vertor.x, (float)vertor.y);
        }

        public static Vector2 ToVector2(this SUPoint3D point)
        {
            return new Vector2((float)point.x, (float)point.y);
        }
    }
}
