namespace Tizen.NUI.CommonUI
{
    public class ViewAttributes : Attributes
    {
        public ViewAttributes() : base() { }

        public ViewAttributes(ViewAttributes attributes)
        {
            if (attributes.Position2D != null)
            {
                Position2D = new Position2D(attributes.Position2D.X, attributes.Position2D.Y);
            }

            if (attributes.Size2D != null)
            {
                Size2D = new Size2D(attributes.Size2D.Width, attributes.Size2D.Height);
            }

            if (attributes.BackgroundColor != null)
            {
                BackgroundColor = attributes.BackgroundColor.Clone() as ColorSelector;
            }

            if (attributes.PositionUsesPivotPoint != null)
            {
                PositionUsesPivotPoint = attributes.PositionUsesPivotPoint;
            }

            if (attributes.ParentOrigin != null)
            {
                ParentOrigin = new Position(attributes.ParentOrigin.X, attributes.ParentOrigin.Y, attributes.ParentOrigin.Z);
            }

            if (attributes.PivotPoint != null)
            {
                PivotPoint = new Position(attributes.PivotPoint.X, attributes.PivotPoint.Y, attributes.PivotPoint.Z);
            }

            if (attributes.WidthResizePolicy != null)
            {
                WidthResizePolicy = attributes.WidthResizePolicy;
            }

            if (attributes.HeightResizePolicy != null)
            {
                HeightResizePolicy = attributes.HeightResizePolicy;
            }

            if (attributes.MinimumSize != null)
            {
                MinimumSize = new Size2D(attributes.MinimumSize.Width, attributes.MinimumSize.Height);
            }

            if (attributes.SizeModeFactor != null)
            {
                SizeModeFactor = new Vector3(attributes.SizeModeFactor.X, attributes.SizeModeFactor.Y, attributes.SizeModeFactor.Z);
            }

            if (attributes.Opacity != null)
            {
                Opacity = attributes.Opacity.Clone() as FloatSelector;
            }

            PaddingLeft = attributes.PaddingLeft;
            PaddingRight = attributes.PaddingRight;
            PaddingTop = attributes.PaddingTop;
            PaddingBottom = attributes.PaddingBottom;
        }

        public Position2D Position2D
        {
            get;
            set;
        }

        public Size2D Size2D
        {
            get;
            set;
        }

        public ColorSelector BackgroundColor
        {
            get;
            set;
        }
        public bool? PositionUsesPivotPoint
        {
            get;
            set;
        }

        public Position ParentOrigin
        {
            get;
            set;
        }

        public Position PivotPoint
        {
            get;
            set;
        }

        public ResizePolicyType? WidthResizePolicy
        {
            get;
            set;
        }

        public ResizePolicyType? HeightResizePolicy
        {
            get;
            set;
        }

        public Size2D MinimumSize
        {
            get;
            set;
        }

        public Vector3 SizeModeFactor
        {
            get;
            set;
        }

        public FloatSelector Opacity
        {
            get;
            set;
        }
        public int PaddingLeft
        {
            get;
            set;
        }

        public int PaddingRight
        {
            get;
            set;
        }

        public int PaddingTop
        {
            get;
            set;
        }

        public int PaddingBottom
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new ViewAttributes(this);
        }

    }
}
