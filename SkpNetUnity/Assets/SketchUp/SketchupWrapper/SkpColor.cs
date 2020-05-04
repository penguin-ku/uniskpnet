using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    /// <summary>
    /// 颜色
    /// </summary>
    public static class SkpColor
    {
        public static Color32 ToUnityColor(this SUColor color)
        {
            return new Color32(color.red, color.green, color.blue, color.alpha);
        }
    }

}
