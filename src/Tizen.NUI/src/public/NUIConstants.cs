// Copyright (c) 2018 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// This specifies all the scroll mode type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ScrollModeType
    {
        /// <summary>
        /// Whether the content can be scrolled along the X axis or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        XAxisScrollEnabled,
        /// <summary>
        /// When set, causes scroll view to snap to multiples of the
        /// value of the interval while flicking along the X axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        XAxisSnapToInterval,
        /// <summary>
        /// When set, the scroll view is unable to scroll beyond the
        /// value of the boundary along the X axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        XAxisScrollBoundary,
        /// <summary>
        /// Whether the content can be scrolled along the Y axis or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        YAxisScrollEnabled,
        /// <summary>
        /// When set, causes scroll view to snap to multiples of the
        /// value of the interval while flicking along the Y axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        YAxisSnapToInterval,
        /// <summary>
        /// When set, the scroll view is unable to scroll beyond the
        /// value of the boundary along the Y axis.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        YAxisScrollBoundary
    }

    /// <summary>
    /// This specifies whether the actor uses its own color or inherits.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ColorMode
    {
        /// <summary>
        /// Actor will use its own color.
        /// </summary>
        UseOwnColor,
        /// <summary>
        /// Actor will use its parent color.
        /// </summary>
        UseParentColor,
        /// <summary>
        /// Actor will blend its color with its parents color.
        /// </summary>
        UseOwnMultiplyParentColor,
        /// <summary>
        /// Actor will blend its alpha with its parents alpha. This means when the parent fades in or out, the child does as well. This is the default.
        /// </summary>
        UseOwnMultiplyParentAlpha
    }

    /// <summary>
    /// This specifies the dimension of the width or the height for size negotiation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DimensionType
    {
        /// <summary>
        /// Width dimension.
        /// </summary>
        Width = 0x1,
        /// <summary>
        /// Height dimension.
        /// </summary>
        Height = 0x2,
        /// <summary>
        /// Mask to cover all flags.
        /// </summary>
        AllDimensions = 0x3
    }

    /// <summary>
    /// Enumeration for the instance of how the actor and it's children will be drawn.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DrawModeType
    {
        /// <summary>
        /// The default draw-mode.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Draw the actor and its children as an overlay.
        /// </summary>
        Overlay2D = 1,

        /// <summary>
        /// Will be replaced by separate ClippingMode enum. Draw the actor and its children into the stencil buffer.
        /// </summary>
        /// <remarks>
        /// Deprecated.(API Level 6) Not used.
        /// </remarks>
        [Obsolete("Please do not use this DrawModeType.Stencil(Deprecated). This is replaced by ClippingModeType")]
        Stencil = 3
    }

    /// <summary>
    /// Enumeration for size negotiation resize policies.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ResizePolicyType
    {
        /// <summary>
        /// Size is fixed as set by SetSize.
        /// </summary>
        Fixed,
        /// <summary>
        /// Size is to use the actor's natural size.
        /// </summary>
        /// <see cref="ViewImpl.GetNaturalSize"/>
        UseNaturalSize,
        /// <summary>
        /// Size is to fill up to the actor's parent's bounds. Aspect ratio is not maintained.
        /// </summary>
        FillToParent,
        /// <summary>
        /// The actors size will be ( ParentSize * SizeRelativeToParentFactor ).
        /// </summary>
        SizeRelativeToParent,
        /// <summary>
        /// The actors size will be ( ParentSize + SizeRelativeToParentFactor ).
        /// </summary>
        SizeFixedOffsetFromParent,
        /// <summary>
        /// The size will adjust to wrap around all children.
        /// </summary>
        FitToChildren,
        /// <summary>
        /// One dimension is dependent on the other.
        /// </summary>
        DimensionDependency,
        /// <summary>
        /// The size will be assigned to the actor.
        /// </summary>
        UseAssignedSize
    }

    /// <summary>
    /// Enumeration for policies to determine how an actor should resize itself when having its size set in size negotiation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SizeScalePolicyType
    {
        /// <summary>
        /// Use the size that was set.
        /// </summary>
        UseSizeSet,
        /// <summary>
        /// Fit within the size set maintaining natural size aspect ratio.
        /// </summary>
        FitWithAspectRatio,
        /// <summary>
        /// Fit within the size set maintaining natural size aspect ratio.
        /// </summary>
        FillWithAspectRatio
    }

    /// <summary>
    /// Enumeration for the ClippingMode describing how this actor's children will be clipped against it.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ClippingModeType
    {
        /// <summary>
        /// This actor will not clip its children.
        /// </summary>
        Disabled,
        /// <summary>
        /// This actor will clip all children to within its boundaries (the actor will also be visible itself).
        /// </summary>
        ClipChildren,
        /// <summary>
        /// This Actor will clip all children within a screen-aligned rectangle encompassing its boundaries (the actor will also be visible itself).
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ClipToBoundingBox
    }

    /// <summary>
    /// Enumeration for type determination of how the camera operates.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CameraType
    {
        /// <summary>
        /// Camera orientation is taken from the CameraActor.
        /// </summary>
        FreeLook,
        /// <summary>
        /// Camera is oriented to always look at a target.
        /// </summary>
        LookAtTarget
    }

    /// <summary>
    /// Enumeration for the projection modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProjectionMode
    {
        /// <summary>
        /// Distance causes foreshortening; objects further from the camera appear smaller.
        /// </summary>
        PerspectiveProjection,
        /// <summary>
        /// Relative distance from the camera does not affect the size of objects.
        /// </summary>
        OrthographicProjection
    }

    /// <summary>
    /// This specifies customView behavior types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CustomViewBehaviour
    {
        /// <summary>
        /// Use to provide default behavior (size negotiation is on, event callbacks are not called).
        /// </summary>
        ViewBehaviourDefault = 0,
        /// <summary>
        /// True if the control does not need size negotiation, i.e., it can be skipped in the algorithm.
        /// </summary>
        DisableSizeNegotiation = 1 << 0,
        /// <summary>
        /// True if OnTouch() callback is required.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        RequiresTouchEventsSupport = 1 << 1,
        /// <summary>
        /// True if OnHover() callback is required.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        RequiresHoverEventsSupport = 1 << 2,
        /// <summary>
        /// True if OnWheel() callback is required.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        RequiresWheelEventsSupport = 1 << 3,
        /// <summary>
        /// Use to provide key navigation support.
        /// </summary>
        RequiresKeyboardNavigationSupport = 1 << 5,
        /// <summary>
        /// Use to make style change event disabled.
        /// </summary>
        DisableStyleChangeSignals = 1 << 6,
        /// <summary>
        /// Please do not use! This will be deprecated!
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        LastViewBehaviourFlag
    }

    /// <summary>
    /// An enum of Device Class types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DeviceClassType
    {
        /// <summary>
        /// Not a device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None,
        /// <summary>
        /// The user/seat (the user themselves).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Seat,
        /// <summary>
        /// A regular keyboard, numberpad or attached buttons.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Keyboard,
        /// <summary>
        /// A mouse, trackball or touchpad relative motion device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Mouse,
        /// <summary>
        /// A touchscreen with fingers or stylus.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Touch,
        /// <summary>
        /// A special pen device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Pen,
        /// <summary>
        ///  A pointing device based on laser, infrared or similar technology.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Pointer,
        /// <summary>
        /// A gamepad controller or joystick.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Gamepad
    }

    /// <summary>
    /// An enum of Device Subclass types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum DeviceSubClassType
    {
        /// <summary>
        /// Not a device
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        None,
        /// <summary>
        /// The normal flat of your finger
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Finger,
        /// <summary>
        /// A fingernail
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Fingernail,
        /// <summary>
        /// A Knuckle
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Knuckle,
        /// <summary>
        /// The palm of a users hand
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Palm,
        /// <summary>
        /// The side of your hand
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        HandSide,
        /// <summary>
        /// The flat of your hand
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        HandFlat,
        /// <summary>
        /// The tip of a pen
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        PenTip,
        /// <summary>
        /// A trackpad style mouse
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Trackpad,
        /// <summary>
        /// A trackpoint style mouse
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Trackpoint,
        /// <summary>
        /// A trackball style mouse
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Trackball,
        /// <summary>
        /// A remote controller
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Remocon,
        /// <summary>
        /// A virtual keyboard
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        VirtualKeyboard
    }

    /// <summary>
    /// This specifies all the property types.<br />
    /// Enumeration for the property types supported.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PropertyType
    {
        /// <summary>
        /// No type.
        /// </summary>
        None,
        /// <summary>
        /// A boolean type.
        /// </summary>
        Boolean,
        /// <summary>
        /// A float type.
        /// </summary>
        Float,
        /// <summary>
        /// An integer type.
        /// </summary>
        Integer,
        /// <summary>
        /// A vector array of size=2 with float precision.
        /// </summary>
        Vector2,
        /// <summary>
        /// A vector array of size=3 with float precision.
        /// </summary>
        Vector3,
        /// <summary>
        /// A vector array of size=4 with float precision.
        /// </summary>
        Vector4,
        /// <summary>
        /// A 3x3 matrix.
        /// </summary>
        Matrix3,
        /// <summary>
        /// A 4x4 matrix.
        /// </summary>
        Matrix,
        /// <summary>
        /// An integer array of size=4.
        /// </summary>
        Rectangle,
        /// <summary>
        /// Either a quaternion or an axis angle rotation.
        /// </summary>
        Rotation,
        /// <summary>
        /// A string type.
        /// </summary>
        String,
        /// <summary>
        /// An array of PropertyValue.
        /// </summary>
        Array,
        /// <summary>
        /// A string key to PropertyValue mapping.
        /// </summary>
        Map,
        /// <summary>
        /// An extents type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Extents
    }

    /// <summary>
    /// This specifies the property access mode types.<br />
    /// Enumeration for the access mode for custom properties.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PropertyAccessMode
    {
        /// <summary>
        /// If the property is read-only.
        /// </summary>
        ReadOnly,
        /// <summary>
        /// If the property is read or writeable.
        /// </summary>
        ReadWrite,
        /// <summary>
        /// If the property can be animated or constrained.
        /// </summary>
        Animatable,
        /// <summary>
        /// The number of access modes.
        /// </summary>
        AccessModeCount
    }

    /// <summary>
    /// Types of style change. Enumeration for the StyleChange type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum StyleChangeType
    {
        /// <summary>
        /// Denotes that the default font has changed.
        /// </summary>
        DefaultFontChange,
        /// <summary>
        /// Denotes that the default font size has changed.
        /// </summary>
        DefaultFontSizeChange,
        /// <summary>
        /// Denotes that the theme has changed.
        /// </summary>
        ThemeChange
    }

    /// <summary>
    /// Enumeration for horizontal alignment types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum HorizontalAlignmentType
    {
        /// <summary>
        /// Align horizontally left.
        /// </summary>
        Left,
        /// <summary>
        /// Align horizontally center.
        /// </summary>
        Center,
        /// <summary>
        /// Align horizontally right.
        /// </summary>
        Right
    }

    /// <summary>
    /// Enumeration for vertical alignment types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VerticalAlignmentType
    {
        /// <summary>
        /// Align vertically top.
        /// </summary>
        Top,
        /// <summary>
        /// Align vertically center.
        /// </summary>
        Center,
        /// <summary>
        /// Align vertically bottom.
        /// </summary>
        Bottom
    }

    /// <summary>
    /// Enumeration for point state type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PointStateType
    {
        /// <summary>
        /// Touch or hover started.
        /// </summary>
        Started,
        /// <summary>
        /// Touch or hover finished.
        /// </summary>
        Finished,
        /// <summary>
        /// Screen touched.
        /// </summary>
        Down = Started,
        /// <summary>
        /// Touch stopped.
        /// </summary>
        Up = Finished,
        /// <summary>
        /// Finger dragged or hovered.
        /// </summary>
        Motion,
        /// <summary>
        /// Leave the boundary of an actor.
        /// </summary>
        Leave,
        /// <summary>
        /// No change from last event. <br />
        /// Useful when a multi-point event occurs where all points are sent, but indicates that this particular point has not changed since the last time.
        /// </summary>
        Stationary,
        /// <summary>
        /// A system event has occurred which has interrupted the touch or hover event sequence.
        /// </summary>
        Interrupted
    }

    /// <summary>
    /// Enumeration for the text horizontal aligning.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum HorizontalAlignment
    {
        /// <summary>
        /// Texts place at the begin of horizontal direction.
        /// </summary>
        Begin,
        /// <summary>
        /// Texts place at the center of horizontal direction.
        /// </summary>
        Center,
        /// <summary>
        /// Texts place at the end of horizontal direction.
        /// </summary>
        End
    }

    /// <summary>
    /// Enumeration for the text horizontal aligning.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VerticalAlignment
    {
        /// <summary>
        /// Texts place at the top of vertical direction.
        /// </summary>
        Top,
        /// <summary>
        /// Texts place at the center of vertical direction.
        /// </summary>
        Center,
        /// <summary>
        /// Texts place at the bottom of vertical direction.
        /// </summary>
        Bottom
    }

    /// <summary>
    /// This specifies wrap mode types.<br />
    /// WrapModeU and WrapModeV separately decide how the texture should be sampled when the u and v coordinate exceeds the range of 0.0 to 1.0.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WrapModeType
    {
        /// <summary>
        /// The default value.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Clamp to edge.
        /// </summary>
        ClampToEdge,
        /// <summary>
        /// Repeat.
        /// </summary>
        Repeat,
        /// <summary>
        /// Mirrored repeat.
        /// </summary>
        MirroredRepeat
    }

    /// <summary>
    /// Specifies the release policy types.<br />
    /// Decides if the image should be cached in different conditions.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum ReleasePolicyType
    {
        /// <summary>
        /// Image is released when visual detached from scene.
        /// </summary>
        Detached = 0,
        /// <summary>
        /// Image is only released when visual is destroyed.
        /// </summary>
        Destroyed,
        /// <summary>
        /// Image is not released.
        /// </summary>
        Never
    }

    /// <summary>
    /// Specifies the load policy types.<br />
    /// Decides when the image texture should be loaded.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum LoadPolicyType
    {
        /// <summary>
        /// Load texture once the image source has been provided. Even if not being used yet.
        /// </summary>
        Immediate = 0,
        /// <summary>
        /// Only load texture once the visual is attached, when the image needs to be shown.
        /// </summary>
        Attached
    }

    /// <summary>
    /// The type of coordinate system for certain attributes of the points in a gradient.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum GradientVisualUnitsType
    {
        /// <summary>
        /// Uses the normals for the start, end, and center points, i.e., top-left is (-0.5, -0.5) and bottom-right is (0.5, 0.5).
        /// </summary>
        ObjectBoundingBox,
        /// <summary>
        /// Uses the user coordinates for the start, end, and center points, i.e., in a 200 by 200 control, top-left is (0, 0) and bottom-right is (200, 200).
        /// </summary>
        UserSpace
    }

    /// <summary>
    /// This specifies SpreadMethod types.<br />
    /// SpreadMethod defines what happens if the gradient starts or ends inside the bounds of the target rectangle.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum GradientVisualSpreadMethodType
    {
        /// <summary>
        /// Uses the terminal colors of the gradient to fill the remainder of the quad.
        /// </summary>
        Pad,
        /// <summary>
        /// Reflects the gradient pattern start-to-end, end-to-start, start-to-end, etc. until the quad is filled.
        /// </summary>
        Reflect,
        /// <summary>
        /// Repeats the gradient pattern start-to-end, start-to-end, start-to-end, etc. until the quad is filled.
        /// </summary>
        Repeat
    }

    /// <summary>
    /// The shading mode used by the mesh visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MeshVisualShadingModeValue
    {
        /// <summary>
        /// *Simplest*. One color that is lit by ambient and diffuse lighting.
        /// </summary>
        TexturelessWithDiffuseLighting,
        /// <summary>
        /// Uses only the visual image textures provided with specular lighting in addition to ambient and diffuse lighting.
        /// </summary>
        TexturedWithSpecularLighting,
        /// <summary>
        /// Uses all textures provided including gloss, normal, and texture map along with specular, ambient, and diffuse lighting.
        /// </summary>
        TexturedWithDetailedSpecularLighting
    }

    /// <summary>
    /// The primitive shape to render as a primitive visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum PrimitiveVisualShapeType
    {
        /// <summary>
        /// A perfectly round geometrical object in the three-dimensional space.
        /// </summary>
        Sphere,
        /// <summary>
        /// The area bound between two circles, i.e., a cone with the tip removed.
        /// </summary>
        ConicalFrustrum,
        /// <summary>
        /// Equivalent to a conical frustrum with the top radius of zero.
        /// </summary>Equivalent to a conical frustrum with the top radius of zero.
        Cone,
        /// <summary>
        /// Equivalent to a conical frustrum with the top radius of zero.
        /// </summary>
        Cylinder,
        /// <summary>
        /// Equivalent to a conical frustrum with equal radii for the top and bottom circles.
        /// </summary>
        Cube,
        /// <summary>
        /// Equivalent to a bevelled cube with a bevel percentage of zero.
        /// </summary>
        Octahedron,
        /// <summary>
        /// Equivalent to a bevelled cube with a bevel percentage of one.
        /// </summary>
        BevelledCube
    }

    /// <summary>
    /// This specifies fitting mode types. Fitting options, used when resizing images to fit desired dimensions.<br />
    /// A fitting mode controls the region of a loaded image to be mapped to the desired image rectangle.<br />
    /// All fitting modes preserve the aspect ratio of the image contents.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum FittingModeType
    {
        /// <summary>
        /// Full-screen image display: Limit loaded image resolution to device resolution using the ShrinkToFit mode.
        /// </summary>
        ShrinkToFit,
        /// <summary>
        /// Thumbnail gallery grid: Limit loaded image resolution to screen tile using the ScaleToFill mode.
        /// </summary>
        ScaleToFill,
        /// <summary>
        /// Image columns: Limit loaded image resolution to column width using the FitWidth mode.
        /// </summary>
        FitWidth,
        /// <summary>
        /// Image rows: Limit loaded image resolution to row height using the FitHeight mode.
        /// </summary>
        FitHeight
    }

    /// <summary>
    /// The values of this enum determine how the visual should fit into the view.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum VisualFittingModeType
    {
        /// <summary>
        /// The visual should be scaled to fit, preserving aspect ratio.
        /// </summary>
        FitKeepAspectRatio,
        /// <summary>
        /// The visual should be stretched to fill, not preserving aspect ratio.
        /// </summary>
        Fill
    }

    /// <summary>
    /// This specifies sampling mode types. Filtering options are used when resizing images to sample original pixels.<br />
    /// A SamplingMode controls how pixels in an input image are sampled and combined to generate each pixel of a destination image during scaling.<br />
    /// NoFilter and Box modes do not guarantee that the output pixel array exactly matches the rectangle specified by the desired dimensions and the FittingMode,<br />
    /// but all other filter modes do if the desired dimensions are not more than the raw dimensions of the input image file.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum SamplingModeType
    {
        /// <summary>
        /// Iteratively box filter to generate an image of 1/2, 1/4, 1/8, etc. width and height and approximately the desired size. <br />
        /// This is the default.
        /// </summary>
        Box,
        /// <summary>
        /// For each output pixel, read one input pixel.
        /// </summary>
        Nearest,
        /// <summary>
        /// For each output pixel, read a quad of four input pixels and write a weighted average of them.
        /// </summary>
        Linear,
        /// <summary>
        /// Iteratively box filter to generate an image of 1/2, 1/4, 1/8, etc. width and height and approximately the desired size, <br />
        /// then for each output pixel, read one pixel from the last level of box filtering.<br />
        /// </summary>
        BoxThenNearest,
        /// <summary>
        /// Iteratively box filter to almost the right size, then for each output pixel, read four pixels from the last level of box filtering and write their weighted average.
        /// </summary>
        BoxThenLinear,
        /// <summary>
        /// No filtering is performed. If the SCALE_TO_FILL scaling mode is enabled, the borders of the image may be trimmed to match the aspect ratio of the desired dimensions.
        /// </summary>
        NoFilter,
        /// <summary>
        /// For caching algorithms where a client strongly prefers a cache-hit to reuse a cached image.
        /// </summary>
        DontCare
    }

    /// <summary>
    /// This specifies policy types that could be used by the transform for the offset or size.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VisualTransformPolicyType
    {
        /// <summary>
        /// Relative to the control (percentage [0.0f to 1.0f] of the control).
        /// </summary>
        Relative = 0,
        /// <summary>
        /// Absolute value in world units.
        /// </summary>
        Absolute = 1
    }

    /// <summary>
    /// This specifies all the transform property types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum VisualTransformPropertyType
    {
        /// <summary>
        /// Offset of the visual, which can be either relative (percentage [0.0f to 1.0f] of the parent) or absolute (in world units).
        /// </summary>
        Offset,
        /// <summary>
        /// Size of the visual, which can be either relative (percentage [0.0f to 1.0f] of the parent) or absolute (in world units).
        /// </summary>
        Size,
        /// <summary>
        /// The origin of the visual within its control area.
        /// </summary>
        Origin,
        /// <summary>
        /// The anchor-point of the visual.
        /// </summary>
        AnchorPoint,
        /// <summary>
        /// Whether the x or y offset values are relative (percentage [0.0f to 1.0f] of the control) or absolute (in world units).
        /// </summary>
        OffsetPolicy,
        /// <summary>
        /// Whether the width or the height size values are relative (percentage [0.0f to 1.0f] of the control) or absolute (in world units).
        /// </summary>
        SizePolicy
    }

    /// <summary>
    /// The type for HiddenInput mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum HiddenInputModeType
    {
        /// <summary>
        /// Don't hide text.
        /// </summary>
        HideNone,
        /// <summary>
        /// Hide all the input text.
        /// </summary>
        HideAll,
        /// <summary>
        /// Hide n characters from start.
        /// </summary>
        HideCount,
        /// <summary>
        /// Show n characters from start.
        /// </summary>
        ShowCount,
        /// <summary>
        /// Show last character for the duration(use ShowLastCharacterDuration property to modify duration).
        /// </summary>
        ShowLastCharacter
    }

    /// <summary>
    /// Auto scrolling stop behavior.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AutoScrollStopMode
    {
        /// <summary>
        /// Stop animation after current loop finished.
        /// </summary>
        FinishLoop,
        /// <summary>
        /// Stop animation immediately and reset position.
        /// </summary>
        Immediate
    }

    /// <summary>
    /// An enum of screen mode.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ScreenOffMode
    {
        /// <summary>
        /// The mode which turns the screen off after a timeout.
        /// </summary>
        Timout,
        /// <summary>
        /// The mode which keeps the screen turned on.
        /// </summary>
        Never
    }

    /// <summary>
    /// An enum of notification window's priority level.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum NotificationLevel
    {
        /// <summary>
        /// No notification level.<br />
        /// Default level.<br />
        /// This value makes the notification window place in the layer of the normal window.
        /// </summary>
        None = -1,
        /// <summary>
        /// The base nofitication level.
        /// </summary>
        Base = 10,
        /// <summary>
        /// The medium notification level than base.
        /// </summary>
        Medium = 20,
        /// <summary>
        /// The higher notification level than medium.
        /// </summary>
        High = 30,
        /// <summary>
        /// The highest notification level.
        /// </summary>
        Top = 40
    }

    /// <summary>
    /// An enum of window types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WindowType
    {
        /// <summary>
        /// A default window type.<br />
        /// Indicates a normal or top-level window.
        /// Almost every window will be created with this type.
        /// </summary>
        Normal,
        /// <summary>
        /// A notification window, like a warning about battery life or a new email received.
        /// </summary>
        Notification,
        /// <summary>
        /// A persistent utility window, like a toolbox or a palette.
        /// </summary>
        Utility,
        /// <summary>
        /// Used for simple dialog windows.
        /// </summary>
        Dialog
    }

    /// <since_tizen> 3 </since_tizen>
    public enum DisposeTypes
    {
        /// <summary>
        /// Called By User
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Explicit,
        /// <summary>
        /// Called by DisposeQueue
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Implicit,
    }

    /// <summary>
    /// An enum of the scroll state of the text eidtor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ScrollState
    {
        /// <summary>
        /// Scrolling is started.
        /// </summary>
        Started,

        /// <summary>
        /// Scrolling is finished.
        /// </summary>
        Finished
    }

    /// <summary>
    /// An enum of the line wrap mode of text controls.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum LineWrapMode
    {
        /// <summary>
        /// The word mode will move a word to the next line.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Word,

        /// <summary>
        /// character will move character by character to the next line.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Character
    }

    /// <summary>
    /// An enum of text directions.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum TextDirection
    {
        /// <summary>
        /// Text direction is from left to right.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        LeftToRight,

        /// <summary>
        /// Text direction is from right to left.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        RightToLeft
    }

    /// <summary>
    /// An enum of vertical line alignments.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum VerticalLineAlignment
    {
        /// <summary>
        /// vertical line alignment is from top.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Top,

        /// <summary>
        /// vertical line alignment is from center.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Center,

        /// <summary>
        /// vertical line alignment is from bottom.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Bottom
    }

    /// <summary>
    /// Enumeration type for the font's slant.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum FontSlantType
    {
        /// <summary>
        /// None.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        None,
        /// <summary>
        /// Normal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Normal,
        /// <summary>
        /// Roman.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Roman = Normal,
        /// <summary>
        /// Italic.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Italic,
        /// <summary>
        /// Oblique.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Oblique
    }

    /// <summary>
    /// Enumeration type for the font's weight.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum FontWeightType
    {
        /// <summary>
        /// None.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        None,
        /// <summary>
        /// Thin.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Thin,
        /// <summary>
        /// UltraLight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        UltraLight,
        /// <summary>
        /// ExtraLight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraLight = UltraLight,
        /// <summary>
        /// Light.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Light,
        /// <summary>
        /// DemiLight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DemiLight,
        /// <summary>
        /// SemiLight.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        SemiLight = DemiLight,
        /// <summary>
        /// Book.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Book,
        /// <summary>
        /// Normal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Normal,
        /// <summary>
        /// Regular.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Regular = Normal,
        /// <summary>
        /// Medium.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Medium,
        /// <summary>
        /// DemiBold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DemiBold,
        /// <summary>
        /// SemiBold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        SemiBold = DemiBold,
        /// <summary>
        /// Bold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Bold,
        /// <summary>
        /// UltraBold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        UltraBold,
        /// <summary>
        /// ExtraBold.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraBold = UltraBold,
        /// <summary>
        /// Black.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Black,
        /// <summary>
        /// Heavy.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Heavy = Black,
        /// <summary>
        /// ExtraBlack.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraBlack = Black
    }

    /// <summary>
    /// Enumeration type for the font's width.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum FontWidthType
    {
        /// <summary>
        /// None.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        None,
        /// <summary>
        /// UltraCondensed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        UltraCondensed,
        /// <summary>
        /// ExtraCondensed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraCondensed,
        /// <summary>
        /// Condensed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Condensed,
        /// <summary>
        /// SemiCondensed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        SemiCondensed,
        /// <summary>
        /// Normal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Normal,
        /// <summary>
        /// SemiExpanded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        SemiExpanded,
        /// <summary>
        /// Expanded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Expanded,
        /// <summary>
        /// ExtraExpanded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        ExtraExpanded,
        /// <summary>
        /// UltraExpanded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        UltraExpanded
    }

    /// <summary>
    /// Enumeration type for the glyph type.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum GlyphType
    {
        /// <summary>
        /// Glyph stored as pixels.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        BitmapGlyph,
        /// <summary>
        /// Glyph stored as vectors (scalable). This feature requires highp shader support and is not available on all platforms.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        VectorGlyph
    }

    /// <summary>
    /// Enumeration for Setting the rendering behavior of a Window.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum RenderingBehaviorType
    {
        /// <summary>
        /// Default. Only renders if required.
        /// </summary>
        IfRequired,
        /// <summary>
        /// Renders continuously.
        /// </summary>
        Continuously
    }

    /// <summary>
    /// This specifies visual types.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct Visual
    {
        /// <summary>
        /// The index for the visual type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum Type
        {
            /// <summary>
            /// Renders a solid color as an internal border to the control's quad.
            /// </summary>
            Border,
            /// <summary>
            /// Renders a solid color to the control's quad.
            /// </summary>
            Color,
            /// <summary>
            /// Renders a smooth transition of colors to the control's quad.
            /// </summary>
            Gradient,
            /// <summary>
            /// Renders an image into the control's quad.
            /// </summary>
            Image,
            /// <summary>
            /// Renders a mesh using an "obj" file, optionally with textures provided by an "mtl" file.
            /// </summary>
            Mesh,
            /// <summary>
            /// Renders a simple 3D shape, such as a cube or a sphere.
            /// </summary>
            Primitive,
            /// <summary>
            /// Renders a simple wire-frame outlining a quad.
            /// </summary>
            Wireframe,
            /// <summary>
            /// Renders text.
            /// </summary>
            Text,
            /// <summary>
            /// Renders an NPatch image.
            /// </summary>
            NPatch,
            /// <summary>
            /// Renders an SVG image.
            /// </summary>
            SVG,
            /// <summary>
            /// Renders a animated image (animated GIF).
            /// </summary>
            AnimatedImage
        }

        /// <summary>
        /// This specifies visual properties.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public struct Property
        {
            /// <summary>
            /// Type.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Type = NDalic.VISUAL_PROPERTY_TYPE;
            /// <summary>
            /// Shader.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Shader = NDalic.VISUAL_PROPERTY_SHADER;
            /// <summary>
            /// Transform.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Transform = NDalic.VISUAL_PROPERTY_TRANSFORM;
            /// <summary>
            /// PremultipliedAlpha.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int PremultipliedAlpha = NDalic.VISUAL_PROPERTY_PREMULTIPLIED_ALPHA;
            /// <summary>
            /// MixColor.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int MixColor = NDalic.VISUAL_PROPERTY_MIX_COLOR;
            /// <summary>
            /// Opacity.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int Opacity = NDalic.VISUAL_PROPERTY_MIX_COLOR + 1;
            /// <summary>
            /// The fitting mode of the visual.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public static readonly int VisualFittingMode = NDalic.VISUAL_PROPERTY_MIX_COLOR + 2;
        }

        /// <summary>
        /// This specifies shader properties.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public struct ShaderProperty
        {
            /// <summary>
            /// Vertex shader code
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int VertexShader = NDalic.VISUAL_SHADER_VERTEX;
            /// <summary>
            /// Fragment shader code
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int FragmentShader = NDalic.VISUAL_SHADER_FRAGMENT;
            /// <summary>
            /// How to subdivide the grid along X
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderSubdivideGridX = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_X;
            /// <summary>
            /// How to subdivide the grid along Y
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderSubdivideGridY = NDalic.VISUAL_SHADER_SUBDIVIDE_GRID_Y;
            /// <summary>
            /// Bitmask of hints
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int ShaderHints = NDalic.VISUAL_SHADER_HINTS;
        }

        /// <summary>
        /// This specifies visaul align types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum AlignType
        {
            /// <summary>
            /// TopBegin
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            TopBegin = 0,
            /// <summary>
            /// TopCenter
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            TopCenter,
            /// <summary>
            /// TopEnd
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            TopEnd,
            /// <summary>
            /// CenterBegin
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            CenterBegin,
            /// <summary>
            /// Center
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Center,
            /// <summary>
            /// CenterEnd
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            CenterEnd,
            /// <summary>
            /// BottomBegin
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            BottomBegin,
            /// <summary>
            /// BottomCenter
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            BottomCenter,
            /// <summary>
            /// BottomEnd
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            BottomEnd
        }
    }

    /// <summary>
    /// This specifies properties of the BorderVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct BorderVisualProperty
    {
        /// <summary>
        /// The color of the border.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Color = NDalic.BORDER_VISUAL_COLOR;
        /// <summary>
        /// The width of the border (in pixels).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Size = NDalic.BORDER_VISUAL_SIZE;
        /// <summary>
        /// Whether anti-aliasing of the border is required.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int AntiAliasing = NDalic.BORDER_VISUAL_ANTI_ALIASING;
    }

    /// <summary>
    /// This specifies properties of the ColorVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct ColorVisualProperty
    {
        /// <summary>
        /// The solid color required.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MixColor = NDalic.COLOR_VISUAL_MIX_COLOR;
        /// <summary>
        /// Whether to render if the MixColor is transparent.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int RenderIfTransparent = NDalic.COLOR_VISUAL_MIX_COLOR + 1;
    }

    /// <summary>
    /// This specifies properties of the GradientVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct GradientVisualProperty
    {
        /// <summary>
        /// The start position of a linear gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int StartPosition = NDalic.GRADIENT_VISUAL_START_POSITION;
        /// <summary>
        /// The end position of a linear gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int EndPosition = NDalic.GRADIENT_VISUAL_END_POSITION;
        /// <summary>
        /// The center point of a radial gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Center = NDalic.GRADIENT_VISUAL_CENTER;
        /// <summary>
        /// The size of the radius of a radial gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Radius = NDalic.GRADIENT_VISUAL_RADIUS;
        /// <summary>
        /// All the stop offsets.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int StopOffset = NDalic.GRADIENT_VISUAL_STOP_OFFSET;
        /// <summary>
        /// The color at the stop offsets.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int StopColor = NDalic.GRADIENT_VISUAL_STOP_COLOR;
        /// <summary>
        /// Defines the coordinate system for certain attributes of the points in a gradient.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Units = NDalic.GRADIENT_VISUAL_UNITS;
        /// <summary>
        /// Indicates what happens if the gradient starts or ends inside the bounds of the target rectangle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SpreadMethod = NDalic.GRADIENT_VISUAL_SPREAD_METHOD;
    }

    /// <summary>
    /// This specifies properties of the ImageVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct ImageVisualProperty
    {
        /// <summary>
        /// The URL of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int URL = NDalic.IMAGE_VISUAL_URL;

        /// <summary>
        /// Fitting options, used when resizing images to fit desired dimensions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FittingMode = NDalic.IMAGE_VISUAL_FITTING_MODE;

        /// <summary>
        /// Filtering options, used when resizing images to sample original pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SamplingMode = NDalic.IMAGE_VISUAL_SAMPLING_MODE;

        /// <summary>
        /// The desired image width.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredWidth = NDalic.IMAGE_VISUAL_DESIRED_WIDTH;

        /// <summary>
        /// The desired image height.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredHeight = NDalic.IMAGE_VISUAL_DESIRED_HEIGHT;

        /// <summary>
        /// Whether to load the image synchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SynchronousLoading = NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING;

        /// <summary>
        /// If true, only draws the borders.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BorderOnly = NDalic.IMAGE_VISUAL_BORDER_ONLY;

        /// <summary>
        /// The image area to be displayed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PixelArea = NDalic.IMAGE_VISUAL_PIXEL_AREA;

        /// <summary>
        /// The wrap mode for u coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeU = NDalic.IMAGE_VISUAL_WRAP_MODE_U;

        /// <summary>
        /// The wrap mode for v coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeV = NDalic.IMAGE_VISUAL_WRAP_MODE_V;

        /// <summary>
        /// The border of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Border = NDalic.IMAGE_VISUAL_BORDER;

        /// <summary>
        /// Whether to use the texture atlas.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Atlasing = NDalic.IMAGE_VISUAL_BORDER + 1;

        /// <summary>
        /// The URL of the alpha mask image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int AlphaMaskURL = NDalic.IMAGE_VISUAL_ALPHA_MASK_URL;

        /// <summary>
        /// Defines the batch size for pre-loading images in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int BatchSize = NDalic.IMAGE_VISUAL_BATCH_SIZE;

        /// <summary>
        /// Defines the cache size for loading images in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int CacheSize = NDalic.IMAGE_VISUAL_CACHE_SIZE;

        /// <summary>
        /// The number of milliseconds between each frame in the AnimatedImageVisual
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int FrameDelay = NDalic.IMAGE_VISUAL_FRAME_DELAY;

        /// <summary>
        /// The scale factor to apply to the content image before masking.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int MaskContentScale = NDalic.IMAGE_VISUAL_MASK_CONTENT_SCALE;

        /// <summary>
        /// Whether to crop image to mask or scale mask to fit image
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int CropToMask = NDalic.IMAGE_VISUAL_CROP_TO_MASK;

        /// <summary>
        /// The policy to determine when an image should be loaded.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int LoadPolicy = NDalic.IMAGE_VISUAL_LOAD_POLICY;

        /// <summary>
        /// The policy to determine when an image should no longer be cached.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int ReleasePolicy = NDalic.IMAGE_VISUAL_RELEASE_POLICY;

        /// <summary>
        /// Determines if image orientation should be corrected so that the image displays as it was intended.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int OrientationCorrection = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION;

        /// <summary>
        /// Overlays the auxiliary image on top of an NPatch image.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int AuxiliaryImageURL = NDalic.IMAGE_VISUAL_AUXILIARY_IMAGE_URL;

        /// <summary>
        /// Alpha value for the auxiliary image, without affecting the underlying NPatch image
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int AuxiliaryImageAlpha = NDalic.IMAGE_VISUAL_AUXILIARY_IMAGE_ALPHA;

        /// <summary>
        /// The number of times the AnimatedImageVisual will be looped.
        /// The default is -1. If the value is less than 0, loop unlimited. Otherwise, loop loopCount times.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int LoopCount = NDalic.IMAGE_VISUAL_LOOP_COUNT;

        /// <summary>
        /// @brief The playing range the AnimatedVectorImageVisual will use.
        /// Animation will play between the values specified.The array can only have two values, and more will be ignored.
        /// Both values should be between 0 and the total frame number, otherwise they will be ignored.
        /// If the range provided is not in proper order (minimum, maximum), it will be reordered.
        /// @details Name "playRange", Type Property::ARRAY of Property::INTEGER
        /// @note Default 0 and the total frame number.
        /// </summary>
        /// <remarks>
        /// Hidden API (Inhouse API)
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int PlayRange = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 4;

        /// <summary>
        /// @brief The playing state the AnimatedVectorImageVisual will use.
        /// @details Name "playState", type PlayState (Property::INTEGER)
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Hidden API (Inhouse API)
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int PlayState = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 5;

        /// <summary>
        /// @brief The current frame number the AnimatedVectorImageVisual will use.
        /// @details Name "currentFrameNumber", Type Property::INTEGER, between[0, the maximum frame number] or between the play range if specified
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int CurrentFrameNumber = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 6;

        /// <summary>
        /// @brief The total frame number the AnimatedVectorImageVisual will use.
        /// @details Name "totalFrameNumber", Type Property::INTEGER.
        /// @note This property is read-only.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int TotalFrameNumber = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 7;

        /// <summary>
        /// @brief  The stop behavior the AnimatedVectorImageVisual will use.
        /// @details Name "stopBehavior", Type StopBehavior::Type (Property::INTEGER)
        /// @note Default value is StopBehavior::CURRENT_FRAME.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int StopBehavior = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 8;

        /// <summary>
        /// @brief  The looping mode the AnimatedVectorImageVisual will use.
        /// @details Name "loopingMode", Type LoopingMode::Type (Property::INTEGER) 
        /// @note Default value is LoopingMode::RESTART.
        /// </summary>
        /// <remarks>
        /// Inhouse API
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int LoopingMode = NDalic.IMAGE_VISUAL_ORIENTATION_CORRECTION + 9;
    }

    /// <summary>
    /// This specifies properties of the MeshVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct MeshVisualProperty
    {
        /// <summary>
        /// The location of the ".obj" file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ObjectURL = NDalic.MESH_VISUAL_OBJECT_URL;
        /// <summary>
        /// The location of the ".mtl" file.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MaterialtURL = NDalic.MESH_VISUAL_MATERIAL_URL;
        /// <summary>
        /// Path to the directory the textures (including gloss and normal) are stored in.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int TexturesPath = NDalic.MESH_VISUAL_TEXTURES_PATH;
        /// <summary>
        /// Sets the type of shading mode that the mesh will use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ShadingMode = NDalic.MESH_VISUAL_SHADING_MODE;
        /// <summary>
        /// Whether to use mipmaps for textures or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int UseMipmapping = NDalic.MESH_VISUAL_USE_MIPMAPPING;
        /// <summary>
        /// Whether to average normals at each point to smooth textures or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int UseSoftNormals = NDalic.MESH_VISUAL_USE_SOFT_NORMALS;
        /// <summary>
        /// The position, in stage space, of the point light that applies lighting to the model.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int LightPosition = NDalic.MESH_VISUAL_LIGHT_POSITION;
    }

    /// <summary>
    /// This specifies properties of the PrimitiveVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct PrimitiveVisualProperty
    {
        /// <summary>
        /// The specific shape to render.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Shape = NDalic.PRIMITIVE_VISUAL_SHAPE;
        /// <summary>
        /// The color of the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MixColor = NDalic.PRIMITIVE_VISUAL_MIX_COLOR;
        /// <summary>
        /// The number of slices as you go around the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Slices = NDalic.PRIMITIVE_VISUAL_SLICES;
        /// <summary>
        /// The number of stacks as you go down the shape.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Stacks = NDalic.PRIMITIVE_VISUAL_STACKS;
        /// <summary>
        /// The scale of the radius of the top circle of a conical frustrum.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleTopRadius = NDalic.PRIMITIVE_VISUAL_SCALE_TOP_RADIUS;
        /// <summary>
        /// The scale of the radius of the bottom circle of a conical frustrum.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleBottomRadius = NDalic.PRIMITIVE_VISUAL_SCALE_BOTTOM_RADIUS;
        /// <summary>
        /// The scale of the height of a conic.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleHeight = NDalic.PRIMITIVE_VISUAL_SCALE_HEIGHT;
        /// <summary>
        /// The scale of the radius of a cylinder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleRadius = NDalic.PRIMITIVE_VISUAL_SCALE_RADIUS;
        /// <summary>
        /// The dimensions of a cuboid. Scales in the same fashion as a 9-patch image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int ScaleDimensions = NDalic.PRIMITIVE_VISUAL_SCALE_DIMENSIONS;
        /// <summary>
        /// Determines how bevelled the cuboid should be, based off the smallest dimension.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BevelPercentage = NDalic.PRIMITIVE_VISUAL_BEVEL_PERCENTAGE;
        /// <summary>
        /// Defines how smooth the bevelled edges should be.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BevelSmoothness = NDalic.PRIMITIVE_VISUAL_BEVEL_SMOOTHNESS;
        /// <summary>
        /// The position, in stage space, of the point light that applies lighting to the model.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int LightPosition = NDalic.PRIMITIVE_VISUAL_LIGHT_POSITION;
    }

    /// <summary>
    /// This specifies properties of the TextVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct TextVisualProperty
    {
        /// <summary>
        /// The text to display in UTF-8 format.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Text = NDalic.TEXT_VISUAL_TEXT;
        /// <summary>
        /// The requested font family to use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FontFamily = NDalic.TEXT_VISUAL_FONT_FAMILY;
        /// <summary>
        /// The requested font style to use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FontStyle = NDalic.TEXT_VISUAL_FONT_STYLE;
        /// <summary>
        /// The size of font in points.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PointSize = NDalic.TEXT_VISUAL_POINT_SIZE;
        /// <summary>
        /// The single-line or multi-line layout option.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MultiLine = NDalic.TEXT_VISUAL_MULTI_LINE;
        /// <summary>
        /// The line horizontal alignment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int HorizontalAlignment = NDalic.TEXT_VISUAL_HORIZONTAL_ALIGNMENT;
        /// <summary>
        /// The line vertical alignment.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int VerticalAlignment = NDalic.TEXT_VISUAL_VERTICAL_ALIGNMENT;
        /// <summary>
        /// The color of the text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int TextColor = NDalic.TEXT_VISUAL_TEXT_COLOR;
        /// <summary>
        /// Whether the mark-up processing is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int EnableMarkup = NDalic.TEXT_VISUAL_ENABLE_MARKUP;
        /// <summary>
        /// The shadow parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Shadow = NDalic.TEXT_VISUAL_ENABLE_MARKUP + 1;
        /// <summary>
        /// The default underline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Underline = NDalic.TEXT_VISUAL_ENABLE_MARKUP + 2;
        /// <summary>
        /// The default outline parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Outline = NDalic.TEXT_VISUAL_ENABLE_MARKUP + 3;
        /// <summary>
        /// The default text background parameters.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static readonly int Background = NDalic.TEXT_VISUAL_ENABLE_MARKUP + 4;
    }

    /// <summary>
    /// This specifies properties of the NpatchImageVisual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct NpatchImageVisualProperty
    {
        /// <summary>
        /// The URL of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int URL = NDalic.IMAGE_VISUAL_URL;
        /// <summary>
        /// Fitting options, used when resizing images to fit desired dimensions.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int FittingMode = NDalic.IMAGE_VISUAL_FITTING_MODE;
        /// <summary>
        /// Filtering options, used when resizing images to sample original pixels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SamplingMode = NDalic.IMAGE_VISUAL_SAMPLING_MODE;
        /// <summary>
        /// The desired image width.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredWidth = NDalic.IMAGE_VISUAL_DESIRED_WIDTH;
        /// <summary>
        /// The desired image height.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int DesiredHeight = NDalic.IMAGE_VISUAL_DESIRED_HEIGHT;
        /// <summary>
        /// Whether to load the image synchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SynchronousLoading = NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING;
        /// <summary>
        /// If true, only draws the borders.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int BorderOnly = NDalic.IMAGE_VISUAL_BORDER_ONLY;
        /// <summary>
        /// The image area to be displayed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int PixelArea = NDalic.IMAGE_VISUAL_PIXEL_AREA;
        /// <summary>
        /// The wrap mode for u coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeU = NDalic.IMAGE_VISUAL_WRAP_MODE_U;
        /// <summary>
        /// The wrap mode for v coordinate.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int WrapModeV = NDalic.IMAGE_VISUAL_WRAP_MODE_V;
        /// <summary>
        /// The border of the image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Border = NDalic.IMAGE_VISUAL_WRAP_MODE_V + 1;
    }

    /// <summary>
    /// The HiddenInput property.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct HiddenInputProperty
    {
        /// <summary>
        /// The mode for input text display.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int Mode = NDalicManualPINVOKE.HIDDENINPUT_PROPERTY_MODE_get();
        /// <summary>
        /// All input characters are substituted by this character.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SubstituteCharacter = NDalicManualPINVOKE.HIDDENINPUT_PROPERTY_SUBSTITUTE_CHARACTER_get();
        /// <summary>
        /// Length of text to show or hide, available when HIDE_COUNT/SHOW_COUNT mode is used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int SubstituteCount = NDalicManualPINVOKE.HIDDENINPUT_PROPERTY_SUBSTITUTE_COUNT_get();
        /// <summary>
        /// Hide last character after this duration, available when SHOW_LAST_CHARACTER mode.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public static readonly int ShowLastCharacterDuration = NDalicManualPINVOKE.HIDDENINPUT_PROPERTY_SHOW_LAST_CHARACTER_DURATION_get();
    }

    /// <summary>
    /// ParentOrigin constants.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct ParentOrigin
    {
        /// <summary>
        /// Top
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Top
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle
        {
            get
            {
                float ret = Interop.NDalicParentOrigin.ParentOriginMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginTopRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginCenterRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicParentOrigin.ParentOriginBottomRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }

    /// <summary>
    /// PivotPoint constants.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct PivotPoint
    {
        /// <summary>
        /// Top
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Top
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }
    /// <summary>
    /// PositionAxis constants.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct PositionAxis
    {
        /// <summary>
        /// The X axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position X
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_XAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// The Y axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Y
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_YAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// The Z axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Z
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_ZAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// The Negative X axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeX
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_NEGATIVE_XAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// The Negative Y axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeY
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_NEGATIVE_YAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// The Negative Z axis
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position NegativeZ
        {
            get
            {
                global::System.IntPtr cPtr = Interop.Vector3.Vector3_NEGATIVE_ZAXIS_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }

    /// <summary>
    /// [Obsolete("Please do not use! this will be deprecated")]
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Please do not use! This will be deprecated! Please use PivotPoint instead!")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct AnchorPoint
    {
        /// <summary>
        /// Top
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Top
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointTop_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Bottom
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Bottom
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointBottom_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Left
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Left
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointLeft_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Right
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Right
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointRight_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Middle
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static float Middle
        {
            get
            {
                float ret = Interop.NDalicAnchorPoint.AnchorPointMiddle_get();
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// TopLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// TopCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// TopRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position TopRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointTopRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// CenterLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// Center
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position Center
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// CenterRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position CenterRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointCenterRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// BottomLeft
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomLeft_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// BottomCenter
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomCenter
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomCenter_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
        /// <summary>
        /// BottomRight
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Position BottomRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.NDalicAnchorPoint.AnchorPointBottomRight_get();
                Position ret = (cPtr == global::System.IntPtr.Zero) ? null : new Position(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }

    /// <summary>
    /// Enumeration for setting cache model of a WebView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CacheModel
    {
        /// <summary>
        /// Use the smallest cache capacity.
        /// </summary>
        DocumentViewer,
        /// <summary>
        /// Use the bigger cache capacity than DocumentBrowser.
        /// </summary>
        DocumentBrowser,
        /// <summary>
        /// Use the biggest cache capacity.
        /// </summary>
        PrimaryWebBrowser
    }

    /// <summary>
    /// Enumeration for setting cache model of a WebView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CookieAcceptPolicy
    {
        /// <summary>
        /// Accepts every cookie sent from any page.
        /// </summary>
        Always,
        /// <summary>
        /// Rejects all the cookies.
        /// </summary>
        Never,
        /// <summary>
        /// Accepts only cookies set by the main document that is loaded.
        /// </summary>
        NoThirdParty
    }
}
