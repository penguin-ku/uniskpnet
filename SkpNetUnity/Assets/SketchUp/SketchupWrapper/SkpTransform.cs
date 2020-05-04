using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    public class SkpTransform
    {
        public static SUTransformation Identity
        {
            get
            {
                return new SUTransformation()
                {
                    values = new double[16]
                     {
                         1,0,0,0,
                         0,1,0,0,
                         0,0,1,0,
                         0,0,0,1
                     }
                };
            }
        }

        public static SUTransformation Inverse(SUTransformation p_transform)
        {
            SUTransformation resTransform = new SUTransformation();
            SKPCExport.SUTransformationGetInverse(ref p_transform, ref resTransform);
            return resTransform;
        }

        public static SUTransformation Multily(SUTransformation p_transform0, SUTransformation p_transform1)
        {
            SUTransformation resTransform = new SUTransformation();
            SKPCExport.SUTransformationMultiply(ref p_transform0, ref p_transform1, ref resTransform);
            return resTransform;
        }

        #region private members

        private SUTransformation m_suTransform;

        #endregion

        #region public properties

        /// <summary>
        /// 获取SU原始transform
        /// </summary>
        public SUTransformation SUTransform
        {
            set
            {
                m_suTransform = value;
            }
            get
            {
                return m_suTransform;
            }
        }

        #endregion

        #region contructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="transformation"></param>
        internal SkpTransform(SUTransformation transformation)
        {
            m_suTransform = transformation;
        }

        #endregion

        #region public functions

        public Transform ToTransform(Transform transform)
        {
            Matrix4x4 materix = Matrix4x4.identity;
            materix.m00 = (float)m_suTransform.values[0];
            materix.m01 = (float)m_suTransform.values[8];
            materix.m02 = (float)m_suTransform.values[4];
            materix.m03 = (float)m_suTransform.values[12] * 0.0254f;
            materix.m10 = (float)m_suTransform.values[2];
            materix.m11 = (float)m_suTransform.values[10];
            materix.m12 = (float)m_suTransform.values[6];
            materix.m13 = (float)m_suTransform.values[14] * 0.0254f;
            materix.m20 = (float)m_suTransform.values[1];
            materix.m21 = (float)m_suTransform.values[9];
            materix.m22 = (float)m_suTransform.values[5];
            materix.m23 = (float)m_suTransform.values[13] * 0.0254f;
            materix.m30 = (float)m_suTransform.values[3];
            materix.m31 = (float)m_suTransform.values[11];
            materix.m32 = (float)m_suTransform.values[7];
            materix.m33 = (float)m_suTransform.values[15];
            try
            {
                transform.FromMatrix(materix);
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
            return transform;
        }

        #endregion
    };

}
