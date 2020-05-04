using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// References an entity list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUEntityListRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// entity_list
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates an entity list object.
        /// </summary>
        /// <param name="list">[in] The entity list object to be created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if list is NULL
        /// SU_ERROR_OVERWRITE_VALID if list already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListCreate(out SUEntityListRef list);

        /// <summary>
        /// Releases a list object.
        /// </summary>
        /// <param name="list">[in] The list object to be released.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if list is NULL
        /// SU_ERROR_OVERWRITE_VALID if list already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListRelease(ref SUEntityListRef list);

        /// <summary>
        /// Sets the iterator reference to the beginning of the list. The given
        /// iterator object must have been constructed using \ref
        /// SUEntityListIteratorCreate. The iterator must be released using \ref
        /// SUEntityListIteratorRelease when it is no longer needed.
        /// </summary>
        /// <param name="list">[in] The list.</param>
        /// <param name="iterator">[out] An iterator Ref reference the beginning of the list.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if list is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if iterator is NULL
        /// SU_ERROR_INVALID_OUTPUT if *iterator is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListBegin(SUEntityListRef list, ref SUEntityListIteratorRef iterator);

        /// <summary>
        /// Gets the number of entities in the list.
        /// </summary>
        /// <param name="list">[in] The list object.</param>
        /// <param name="count">[out] The list size.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if list is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListSize(SUEntityListRef list, ref size_t count);
    }
}
