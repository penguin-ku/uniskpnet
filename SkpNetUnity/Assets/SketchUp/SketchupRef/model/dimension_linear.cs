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
    /// A linear dimension entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUDimensionLinearRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// Indicates the different supported horizontal text position types
    /// </summary>
    public enum SUHorizontalTextPositionType
    {
        SUHorizontalTextPositionCenter = 0,
        SUHorizontalTextPositionOutsideStart,
        SUHorizontalTextPositionOutsideEnd
    }

    /// <summary>
    /// Indicates the different supported horizontal text position types
    /// </summary>
    public enum SUVerticalTextPositionType
    {
        SUVerticalTextPositionCenter = 0,
        SUVerticalTextPositionAbove,
        SUVerticalTextPositionBelow
    }

    /// <summary>
    /// Indicates the different supported horizontal text position types
    /// </summary>
    public enum SUDimensionLinearAlignmentType
    {
        SUDimensionLinearAlignmentAligned = 0,
        SUDimensionLinearAlignmentVertical,
        SUDimensionLinearAlignmentHorizontal
    }

    /// <summary>
    /// dimension_linear
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUDimensionLinearRef to an SUDimensionRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="dimension">[in] The given dimension reference.</param>
        /// <returns>
        /// The converted SUDimensionRef if dimension is a valid object
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDimensionRef SUDimensionLinearToDimension(SUDimensionLinearRef dimension);

        /// <summary>
        /// Converts from an SUDimensionRef to an SUDimensionLinearRef.
        /// This is essentially a downcast operation so the given \ref
        /// SUDimensionRef must be convertible to an SUDimensionLinearRef.
        /// </summary>
        /// <param name="dimension">[in] The given dimension reference.</param>
        /// <returns>
        /// The converted SUDimensionLinearRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDimensionLinearRef SUDimensionLinearFromDimension(SUDimensionRef dimension);

        /// <summary>
        /// Creates a new linear dimension object with default data. Refer to the documentation for SUDimensionLinearSetStartPoint for more
        /// information about the various supported ways for setting connection points.
        /// </summary>
        /// <param name="dimension">[out] The dimension object created.</param>
        /// <param name="start_point">[in] The 3d point used to set the start location.</param>
        /// <param name="start_path">[in] The instance path used to specify the entity connected to the dimension's start.</param>
        /// <param name="end_point">[in] The 3d point used to set the end location.</param>
        /// <param name="end_path">[in] The instance path used to specify the entity connected to the dimension's end.</param>
        /// <param name="offset">[in] The offset distance from the measured entities to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if dimension is NULL
        /// SU_ERROR_OVERWRITE_VALID if dimension already references a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if {start,end}_path is invalid and {start,end}_point is NULL
        /// SU_ERROR_INVALID_ARGUMENT {start,end}_path is valid but refers to an invalid instance path
        /// SU_ERROR_GENERIC if {start,end}_point is NULL and {start,end}_path doesn't have a vertex or guide point for its leaf
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearCreate(ref SUDimensionLinearRef dimension, ref SUPoint3D start_point, SUInstancePathRef start_path, ref SUPoint3D end_point, SUInstancePathRef end_path,  double offset);

        /// <summary>
        /// Releases a dimension object.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if dimension is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearRelease(ref SUDimensionLinearRef dimension);

        /// <summary>
        /// Retrieves the start point of a dimension object. The given instance path object either must have been constructed using one of the
        /// SUInstancePathCreate* functions or it will be generated on the fly if it is invalid. It must be released using \ref SUInstancePathRelease when
        /// it is no longer needed.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="point">[out] The 3d point retrieved.</param>
        /// <param name="path">[out] The instance path retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if point or path are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetStartPoint(SUDimensionLinearRef dimension, ref SUPoint3D point, ref SUInstancePathRef path);

        /// <summary>
        /// Sets the start connection point of a dimension object. A dimension's
        /// connection point can be set in a few different ways.In the simplest
        /// form a connection point can be set to an arbitrary point in space by
        /// providing a non-null \ref SUPoint3D and an invalid
        /// \ref SUInstancePathRef.The more complex forms connect the point to a
        /// position on an entity in the model by providing a valid \ref
        /// SUInstancePathRef which refers to an existing model entity. In the more
        /// complex forms the the input SUPoint3D must be non-null for all
        /// connectable entity types except for vertices and guide points, in which
        /// case the \ref SUPoint3D argument may be null as it will be ignored. It
        /// should be noted that when changing a dimension's connection point the
        /// other point may need to be adjusted as well.Users may want to verify
        /// the other connection point after setting this one.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="point">[in] The 3d point to be set.</param>
        /// <param name="path">[in] The instance path to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if path is invalid and point is NULL
        /// SU_ERROR_INVALID_ARGUMENT path is valid but refers to an invalid instance path
        /// SU_ERROR_GENERIC if point is NULL and path doesn't have a vertex or guide point for its leaf
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearSetStartPoint(SUDimensionLinearRef dimension, ref SUPoint3D point, SUInstancePathRef path);

        /// <summary>
        /// Retrieves the end point of a dimension object. The given instance path object either must have been constructed using one of the
        /// SUInstancePathCreate* functions or it will be generated on the fly if it is invalid. It must be released using \ref SUInstancePathRelease when
        /// it is no longer needed.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="point">[out] The 3d point retrieved.</param>
        /// <param name="path">[out] The instance path retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if point or path are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetEndPoint(SUDimensionLinearRef dimension, ref SUPoint3D point, ref SUInstancePathRef path);

        /// <summary>
        /// Sets the end connection point of a dimension object. A dimension's
        /// connection point can be set in a few different ways.In the simplest
        /// form a connection point can be set to an arbitrary point in space by
        /// providing a non-null \ref SUPoint3D and an invalid
        /// \ref SUInstancePathRef.The more complex forms connect the point to a
        /// position on an entity in the model by providing a valid \ref
        /// SUInstancePathRef which refers to an existing model entity. In the more
        /// complex forms the the input SUPoint3D must be non-null for all
        /// connectable entity types except for vertices and guide points, in which
        /// case the \ref SUPoint3D argument may be null as it will be ignored. It
        /// should be noted that when changing a dimension's connection point the
        /// other point may need to be adjusted as well.Users may want to verify
        /// the other connection point after setting this one.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="point">[in] The 3d point to be set.</param>
        /// <param name="path">[in] The instance path to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if path is invalid and point is NULL
        /// SU_ERROR_INVALID_ARGUMENT path is valid but refers to an invalid instance path
        /// SU_ERROR_GENERIC if point is NULL and path doesn't have a vertex or guide point for its leaf
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearSetEndPoint(SUDimensionLinearRef dimension, ref SUPoint3D point, SUInstancePathRef path);

        /// <summary>
        /// Retrieves the x-axis of a dimension object. The x-axis is the axis along the length of the dimension.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="axis">[out] axis The 3d vector retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetXAxis(SUDimensionLinearRef dimension, ref SUVector3D axis);

        /// <summary>
        /// Sets the x-axis of a dimension object.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="axis">[in] The 3d vector to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearSetXAxis(SUDimensionLinearRef dimension, ref SUVector3D axis);

        /// <summary>
        /// Retrieves the normal vector of a dimension object. The normal vector is
        /// a unit vector pointing out of the plane of the linear dimension.A
        /// linear dimension's plane is the plane defined by the x-axis and the
        /// leader lines' direction vector.  
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="normal">[out] The 3d vector retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if normal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetNormal(SUDimensionLinearRef dimension, ref SUVector3D normal);

        /// <summary>
        /// Sets the x-axis of a dimension object.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="normal">[in] The 3d vector to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if normal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearSetNormal(SUDimensionLinearRef dimension, ref SUVector3D normal);

        /// <summary>
        /// Retrieves the position of a dimension object. The position is a 2D point
        /// in the dimension's plane indicating where the dimension text is located.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="position">[out] The position retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetPosition(SUDimensionLinearRef dimension, ref SUPoint2D position);

        /// <summary>
        /// Sets the position of a dimension object.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="position">[in] The position to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearSetPosition(SUDimensionLinearRef dimension, ref SUPoint2D position);

        /// <summary>
        /// Retrieves an enum value indicating the dimension's vertical alignment type.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="alignment">[out] The dimension alignment enum value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if alignment is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetVerticalAlignment(SUDimensionLinearRef dimension, ref SUVerticalTextPositionType alignment);

        /// <summary>
        /// Sets the dimension's vertical alignment type.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="alignment">[in] The dimension alignment type to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if alignment is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearSetVerticalAlignment(SUDimensionLinearRef dimension, SUVerticalTextPositionType alignment);

        /// <summary>
        /// Retrieves an enum value indicating the dimension's horizontal alignment type.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="alignment">[out] The dimension alignment enum value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if alignment is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetHorizontalAlignment(SUDimensionLinearRef dimension, ref SUHorizontalTextPositionType alignment);

        /// <summary>
        /// Sets the dimension's horizontal alignment type.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="alignment">[in] The dimension alignment type to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if alignment is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearSetHorizontalAlignment(SUDimensionLinearRef dimension, SUHorizontalTextPositionType alignment);

        /// <summary>
        /// Retrieves an enum value indicating the linear dimension's alignment
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="alignment">[out] The dimension alignment enum value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if alignment is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetAlignment(SUDimensionLinearRef dimension, ref SUDimensionLinearAlignmentType alignment);

        /// <summary>
        /// Retrieves the position of the text location attachment point of the
        /// dimension text.Note that depending on the TextPosition enumerator, this
        /// can be the center or side of a text element.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="position">[out] The position of the text element.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_OUT_OF_RANGE if the dimension text relation is invalid
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionLinearGetTextPosition(SUDimensionLinearRef dimension, ref SUPoint3D position);
    }
}
