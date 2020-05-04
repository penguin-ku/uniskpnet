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
    /// References the camera object of a SketchUp model.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUCameraRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// camera
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a default camera object.
        /// </summary>
        /// <param name="camera">[out] The camera object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if camera is NULL
        /// SU_ERROR_OVERWRITE_VALID if camera already refers to a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraCreate(ref SUCameraRef camera);

        /// <summary>
        /// Releases a camera object created by SUCameraCreate.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if camera is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraRelease(ref SUCameraRef camera);

        /// <summary>
        /// Retrieves the orientation of a camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="position">[out] The position retrieved.</param>
        /// <param name="target">[out] The target retrieved.</param>
        /// <param name="up_vector">[out] The up direction retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if position, target, or up_vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetOrientation(SUCameraRef camera, ref SUPoint3D position, ref SUPoint3D target, ref SUVector3D up_vector);

        /// <summary>
        /// Sets the position of a camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="position">[in] The new eye position.</param>
        /// <param name="target">[in] The new target position.</param>
        /// <param name="up_vector">[in] The new up direction.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if position, target or up_vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetOrientation(SUCameraRef camera, ref SUPoint3D position, ref SUPoint3D target, ref SUVector3D up_vector);

        /// <summary>
        /// Retrieves the look at matrix of the camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="transformation">[out] The look at matrix retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success.
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if transformation is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetViewTransformation(SUCameraRef camera, ref SUTransformation transformation);

        /// <summary>
        /// Sets the field of view angle of a camera object. If the camera object is
        /// an orthographic camera, the camera object subsequently becomes a
        /// perspective camera. The field of view is measured along the vertical
        /// direction of the camera.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="fov">[in] The field of view angle in degrees.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetPerspectiveFrustumFOV(SUCameraRef camera, double fov);

        /// <summary>
        /// Retrieves the field of view in degrees of a camera object. The field of
        /// view is measured along the vertical direction of the camera.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="fov">[out] The field of view retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NO_DATA if camera is not a perspective camera (orthographic camera)
        /// SU_ERROR_NULL_POINTER_OUTPUT if fov is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetPerspectiveFrustumFOV(SUCameraRef camera, ref double fov);

        /// <summary>
        /// Sets the aspect ratio of a camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="aspect_ratio">[in] The aspect ratio to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_OUT_OF_RANGE is aspect_ratio < 0.0
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetAspectRatio(SUCameraRef camera, double aspect_ratio);

        /// <summary>
        /// Retrieves the aspect ratio of a camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="aspect_ratio">[out] The aspect ratio retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NO_DATA if the camera uses the screen aspect ratio
        /// SU_ERROR_NULL_POINTER_OUTPUT if aspect_ratio is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetAspectRatio(SUCameraRef camera, ref double aspect_ratio);

        /// <summary>
        /// Sets the height of a camera object which is used to calculate the
        /// orthographic projection of a camera object. If the camera object is a
        /// perspective camera, the camera subsequently becomes an orthographic
        /// camera.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="height">[in] The height of the camera view.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetOrthographicFrustumHeight(SUCameraRef camera, double height);

        /// <summary>
        /// Retrieves the height of an orthographic camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="height">[out] The height retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NO_DATA if camera is not an orthographic camera (perspective camera)
        /// SU_ERROR_NULL_POINTER_OUTPUT if height is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetOrthographicFrustumHeight(SUCameraRef camera, ref double height);

        /// <summary>
        /// Sets a camera object perspective or orthographic.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="perspective">[in] The perspective flag.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetPerspective(SUCameraRef camera, bool perspective);

        /// <summary>
        /// Retrieves whether a camera object is a perspective camera or not (i.e. orthographic).
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="perspective">[out] The perspective flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT perspective is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetPerspective(SUCameraRef camera, ref bool perspective);

        /// <summary>
        /// Retrieves the near and far clipping distances of the camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="znear">[out] The near clipping distance.</param>
        /// <param name="zfar">[out] The far clipping distance.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if znear or zfar is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetClippingDistances(SUCameraRef camera, ref double znear, ref double zfar);

        /// <summary>
        /// Sets whether the field of view value represents the camera view height.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="is_fov_ceight">[in] The field of view flag set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetFOVIsHeight(SUCameraRef camera, bool is_fov_ceight);

        /// <summary>
        /// Retrieves whether the field of view value represents the camera view height.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="is_fov_ceight">[out] The field of view flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT is_fov_ceight is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetFOVIsHeight(SUCameraRef camera, ref bool is_fov_ceight);

        /// <summary>
        /// Sets the size of the image on the "film" for a perspective camera. The
        /// value is given in millimeters. It is used in the conversions between
        /// field of view and focal length.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="width">[in] The width set in millimeters.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetImageWidth(SUCameraRef camera, double width);

        /// <summary>
        /// Retrieves the size of the image on the image plane of the Camera. By
        /// default, this value is not set. If it is set, it is used in the
        /// calculation of the focal length from the field of view. Unlike most
        /// length values in SketchUp, this width is specified in millimeters rather
        /// than in inches.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="width">[out] The image width retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT width is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetImageWidth(SUCameraRef camera, ref double width);

        /// <summary>
        /// Sets the description of a camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="desc">[in] The description to be set. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if desc is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetDescription(SUCameraRef camera, byte[] desc);

        /// <summary>
        /// Retrieves the description of a camera object.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="desc">[out] The description retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if desc is NULL
        /// SU_ERROR_INVALID_OUTPUT if desc does not point to a valid \ref
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetDescription(SUCameraRef camera, ref SUStringRef desc);

        /// <summary>
        /// Retrieves the camera's direction vector.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="direction">[out] The direction vector retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if direction is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetDirection(SUCameraRef camera, ref SUVector3D direction);

        /// <summary>
        /// Sets whether a camera is two dimensional. 2 point perspective mode and PhotoMatch mode are 2d cameras.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="make_2d">[out] The flag for specifying if the camera should be 2D.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSet2D(SUCameraRef camera, bool make_2d);

        /// <summary>
        /// Retrieves whether a camera object is two dimensional.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="is_2d">[out] The boolean retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT is_2d is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGet2D(SUCameraRef camera, ref bool is_2d);

        /// <summary>
        /// Retrieves the camera's 2D scale factor.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="scale">[out] The scale factor retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if scale is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetScale2D(SUCameraRef camera, ref double scale);

        /// <summary>
        /// Sets the camera's 2D center point. The point coordinates are in screen
        /// space.  Since this is setting the 2D center point the z component of the
        /// provided point is ignored.
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="center">[in] The center point retrieved.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraSetCenter2D(SUCameraRef camera, ref SUPoint3D center);

        /// <summary>
        /// Retrieves the camera's 2D center point. Since this is accessing a 2D
        /// point with a 3D point structure the z coordinate is always set to 0.0. 
        /// </summary>
        /// <param name="camera">[in] The camera object.</param>
        /// <param name="center">[out] The center point retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if center is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCameraGetCenter2D(SUCameraRef camera, ref SUPoint3D center);
    }
}
