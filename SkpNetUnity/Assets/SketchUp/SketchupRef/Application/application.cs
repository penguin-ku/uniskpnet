using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;
using SUByte = System.Byte;
using uint32_t = System.UInt32;
using int16_t = System.Int16;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// application
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets a reference to the active model.
        /// </summary>
        /// <param name="model">[out] The model object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if model is NULL
        /// SU_ERROR_NO_DATA if there is no active model
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUApplicationGetActiveModel(ref SUModelRef model);
    }
}
