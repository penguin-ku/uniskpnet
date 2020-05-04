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
    /// References an entity list iterator object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUEntityListIteratorRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// entity_list_iterator
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates an entity list iterator object.
        /// </summary>
        /// <param name="iterator">[in] The entity list iterator object to be created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if iterator is NULL
        /// SU_ERROR_OVERWRITE_VALID if iterator already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListIteratorCreate(out SUEntityListIteratorRef iterator);

        /// <summary>
        /// Releases a iterator object.
        /// </summary>
        /// <param name="iterator">[in] The iterator object to be released.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if iterator is NULL
        /// SU_ERROR_INVALID_INPUT if iterator does not reference a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListIteratorRelease(ref SUEntityListIteratorRef iterator);

        /// <summary>
        /// Retrieves the specified entity pointer from the given iterator.
        /// </summary>
        /// <param name="iterator">[in] The iterator from which to retrieve the entity.</param>
        /// <param name="entity">[out]  The entity reference retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if iterator is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if entity is NULL
        /// SU_ERROR_NO_DATA if the iterator references an invalid entity
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListIteratorGetEntity(SUEntityListIteratorRef iterator, ref SUEntityRef entity);

        /// <summary>
        /// Increments the provided iterator.
        /// </summary>
        /// <param name="iterator">[in] The iterator to be incremented.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if iterator is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if reached the end of the collection
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListIteratorNext(SUEntityListIteratorRef iterator);

        /// <summary>
        /// Checks if the iterator is still within range of the list.
        /// </summary>
        /// <param name="iterator">[in] The iterator to be queried.</param>
        /// <param name="in_range">[out] A boolean indicating if the iterator is in range.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if iterator is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if in_range is NULL
        /// SU_ERROR_OUT_OF_RANGE if the iterator is at the end of the collection
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityListIteratorIsInRange(SUEntityListIteratorRef iterator, ref bool in_range);
    }
}
