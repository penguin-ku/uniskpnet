using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;
using SUByte = System.Byte;
using uint32_t = System.UInt32;
using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    public class SkpTexture:IDisposable
    {
        #region private members

        private string m_name;
        private bool m_exist;
        private Texture2D m_texture2D;
        private double m_scalex;
        private double m_scaley;
        private long m_width;
        private long m_height;
        private byte[] m_data;

        #endregion

        #region public properties

        /// <summary>
        /// 设置或获取名称
        /// </summary>
        public string Name
        {
            set
            {
                m_name = value;
            }
            get
            {
                return m_name;
            }
        }

        public Texture2D UnityTexture
        {
            get
            {
                if (string.IsNullOrEmpty(m_name))
                {
                    return null;
                }
                if (m_data == null)
                {
                    return null;
                }
                if (m_texture2D != null)
                {
                    return m_texture2D;
                }

                Texture2D texture2D = new Texture2D(1, 1);
                texture2D.LoadImage(m_data);
                m_texture2D = texture2D;
                return m_texture2D;
            }
        }

        public double ScaleX
        {
            set
            {
                m_scalex = value;
            }
            get
            {
                return m_scalex;
            }
        }

        public double ScaleY
        {
            set
            {
                m_scaley = value;
            }
            get
            {
                return m_scaley;
            }
        }

        #endregion

        #region constructors


        /// <summary>
        /// 构造函数
        /// </summary>
        public SkpTexture()
        {
            this.m_name = "";
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="texture"></param>
        internal SkpTexture(SUTextureRef texture)
        {
            m_name = Guid.NewGuid().ToString();

            if (texture.ptr == IntPtr.Zero)
            {
                return;
            }

            SKPCExport.SUTextureGetDimensions(texture, ref m_width, ref m_height, ref m_scalex, ref m_scaley);
            if (m_width == 0 || m_height == 0)// 莫名的存在0，如果继续后续，直接崩溃，天知道发生了什么
            {
                return;
            }

            try
            {
                //Debug.Log($"图片 {m_name} 开始保存");
                string guid = Guid.NewGuid().ToString();
                string fileName = $"./{guid}-su.png";
                SKPCExport.SUTextureWriteToFile(texture, fileName);
                if (System.IO.File.Exists(fileName))// 判断是否存在
                {
                    m_data = System.IO.File.ReadAllBytes(fileName);
                    //Debug.Log($"图片 {m_name} 保存成功");
                    System.IO.File.Delete(fileName);// 清除临时文件
                }
                else
                {
                    Debug.LogWarning($"图片 {m_name} 保存失败 {texture.ptr}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }

        #endregion

        public void Dispose()
        {
            m_data = null;
        }
    }

}
