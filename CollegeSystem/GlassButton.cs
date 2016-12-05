using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Glass
{
    // Token: 0x02000010 RID: 16
    [Description("Raises an event when the user clicks it."), ToolboxItem(true), ToolboxItemFilter("System.Windows.Forms"), ToolboxBitmap(typeof(GlassButton))]
    public class GlassButton : Button
    {
        // Token: 0x06000051 RID: 81 RVA: 0x00003FF0 File Offset: 0x000021F0
        public GlassButton()
        {
            this.InitializeComponent();
            this.timer.Interval = 30;
            base.BackColor = Color.Transparent;
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.OuterBorderColor = Color.White;
            this.InnerBorderColor = Color.Black;
            this.ShineColor = Color.White;
            this.GlowColor = Color.FromArgb(-7488001);
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.Opaque, false);
        }

        // Token: 0x0600007D RID: 125 RVA: 0x00004788 File Offset: 0x00002988
        private Image CreateBackgroundFrame(bool pressed, bool hovered, bool animating, bool enabled, float glowOpacity)
        {
            Rectangle clientRectangle = base.ClientRectangle;
            if (clientRectangle.Width <= 0)
            {
                clientRectangle.Width = 1;
            }
            if (clientRectangle.Height <= 0)
            {
                clientRectangle.Height = 1;
            }
            Image image = new Bitmap(clientRectangle.Width, clientRectangle.Height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.Clear(Color.Transparent);
                GlassButton.DrawButtonBackground(graphics, clientRectangle, pressed, hovered, animating, enabled, this._outerBorderColor, this._backColor, this._glowColor, this._shineColor, this._innerBorderColor, glowOpacity);
            }
            return image;
        }

        // Token: 0x06000083 RID: 131 RVA: 0x00005118 File Offset: 0x00003318
        private static GraphicsPath CreateBottomRadialPath(Rectangle rectangle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            RectangleF rect = rectangle;
            rect.X -= rect.Width * 0.35f;
            rect.Y -= rect.Height * 0.15f;
            rect.Width *= 1.7f;
            rect.Height *= 2.3f;
            graphicsPath.AddEllipse(rect);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        // Token: 0x0600008A RID: 138 RVA: 0x000051E8 File Offset: 0x000033E8
        private void CreateFrames()
        {
            this.CreateFrames(false);
        }

        // Token: 0x0600008B RID: 139 RVA: 0x000051F4 File Offset: 0x000033F4
        private void CreateFrames(bool withAnimationFrames)
        {
            this.DestroyFrames();
            if (!base.IsHandleCreated)
            {
                return;
            }
            if (this._frames == null)
            {
                this._frames = new List<Image>();
            }
            this._frames.Add(this.CreateBackgroundFrame(false, false, false, false, 0f));
            this._frames.Add(this.CreateBackgroundFrame(true, true, false, true, 0f));
            this._frames.Add(this.CreateBackgroundFrame(false, false, false, true, 0f));
            if (!withAnimationFrames)
            {
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                this._frames.Add(this.CreateBackgroundFrame(false, true, true, true, (float)i / 9f));
            }
        }

        // Token: 0x06000081 RID: 129 RVA: 0x00004F64 File Offset: 0x00003164
        private static GraphicsPath CreateRoundRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int left = rectangle.Left;
            int top = rectangle.Top;
            int width = rectangle.Width;
            int height = rectangle.Height;
            int num = radius << 1;
            graphicsPath.AddArc(left, top, num, num, 180f, 90f);
            graphicsPath.AddLine(left + radius, top, left + width - radius, top);
            graphicsPath.AddArc(left + width - num, top, num, num, 270f, 90f);
            graphicsPath.AddLine(left + width, top + radius, left + width, top + height - radius);
            graphicsPath.AddArc(left + width - num, top + height - num, num, num, 0f, 90f);
            graphicsPath.AddLine(left + width - radius, top + height, left + radius, top + height);
            graphicsPath.AddArc(left, top + height - num, num, num, 90f, 90f);
            graphicsPath.AddLine(left, top + height - radius, left, top + radius);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        // Token: 0x06000082 RID: 130 RVA: 0x00005060 File Offset: 0x00003260
        private static GraphicsPath CreateTopRoundRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            int left = rectangle.Left;
            int top = rectangle.Top;
            int width = rectangle.Width;
            int height = rectangle.Height;
            int num = radius << 1;
            graphicsPath.AddArc(left, top, num, num, 180f, 90f);
            graphicsPath.AddLine(left + radius, top, left + width - radius, top);
            graphicsPath.AddArc(left + width - num, top, num, num, 270f, 90f);
            graphicsPath.AddLine(left + width, top + radius, left + width, top + height);
            graphicsPath.AddLine(left + width, top + height, left, top + height);
            graphicsPath.AddLine(left, top + height, left, top + radius);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        // Token: 0x0600008C RID: 140 RVA: 0x000052A0 File Offset: 0x000034A0
        private void DestroyFrames()
        {
            if (this._frames != null)
            {
                while (this._frames.Count > 0)
                {
                    this._frames[this._frames.Count - 1].Dispose();
                    this._frames.RemoveAt(this._frames.Count - 1);
                }
            }
        }

        // Token: 0x06000091 RID: 145 RVA: 0x000053BC File Offset: 0x000035BC
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (this._imageButton != null)
                    {
                        this._imageButton.Parent.Dispose();
                        this._imageButton.Parent = null;
                        this._imageButton.Dispose();
                        this._imageButton = null;
                    }
                    this.DestroyFrames();
                    if (this.components != null)
                    {
                        this.components.Dispose();
                    }
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Token: 0x0600007E RID: 126 RVA: 0x00004830 File Offset: 0x00002A30
        private static void DrawButtonBackground(Graphics g, Rectangle rectangle, bool pressed, bool hovered, bool animating, bool enabled, Color outerBorderColor, Color backColor, Color glowColor, Color shineColor, Color innerBorderColor, float glowOpacity)
        {
            SmoothingMode smoothingMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectangle2 = rectangle;
            rectangle2.Width--;
            rectangle2.Height--;
            using (GraphicsPath graphicsPath = GlassButton.CreateRoundRectangle(rectangle2, 4))
            {
                using (Pen pen = new Pen(outerBorderColor))
                {
                    g.DrawPath(pen, graphicsPath);
                }
            }
            rectangle2.X++;
            rectangle2.Y++;
            rectangle2.Width -= 2;
            rectangle2.Height -= 2;
            Rectangle rectangle3 = rectangle2;
            rectangle3.Height >>= 1;
            using (GraphicsPath graphicsPath2 = GlassButton.CreateRoundRectangle(rectangle2, 2))
            {
                int alpha = pressed ? 204 : 127;
                using (Brush brush = new SolidBrush(Color.FromArgb(alpha, backColor)))
                {
                    g.FillPath(brush, graphicsPath2);
                }
            }
            if ((hovered || animating) && !pressed)
            {
                using (GraphicsPath graphicsPath3 = GlassButton.CreateRoundRectangle(rectangle2, 2))
                {
                    g.SetClip(graphicsPath3, CombineMode.Intersect);
                    using (GraphicsPath graphicsPath4 = GlassButton.CreateBottomRadialPath(rectangle2))
                    {
                        using (PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath4))
                        {
                            int alpha2 = (int)(178f * glowOpacity + 0.5f);
                            RectangleF bounds = graphicsPath4.GetBounds();
                            pathGradientBrush.CenterPoint = new PointF((bounds.Left + bounds.Right) / 2f, (bounds.Top + bounds.Bottom) / 2f);
                            pathGradientBrush.CenterColor = Color.FromArgb(alpha2, glowColor);
                            pathGradientBrush.SurroundColors = new Color[]
							{
								Color.FromArgb(0, glowColor)
							};
                            g.FillPath(pathGradientBrush, graphicsPath4);
                        }
                    }
                    g.ResetClip();
                }
            }
            if (rectangle3.Width > 0 && rectangle3.Height > 0)
            {
                rectangle3.Height++;
                using (GraphicsPath graphicsPath5 = GlassButton.CreateTopRoundRectangle(rectangle3, 2))
                {
                    rectangle3.Height++;
                    int num = 153;
                    if (pressed | !enabled)
                    {
                        num = (int)(0.4f * (float)num + 0.5f);
                    }
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle3, Color.FromArgb(num, shineColor), Color.FromArgb(num / 3, shineColor), LinearGradientMode.Vertical))
                    {
                        g.FillPath(linearGradientBrush, graphicsPath5);
                    }
                }
                rectangle3.Height -= 2;
            }
            using (GraphicsPath graphicsPath6 = GlassButton.CreateRoundRectangle(rectangle2, 3))
            {
                using (Pen pen2 = new Pen(innerBorderColor))
                {
                    g.DrawPath(pen2, graphicsPath6);
                }
            }
            g.SmoothingMode = smoothingMode;
        }

        // Token: 0x0600007C RID: 124 RVA: 0x00004704 File Offset: 0x00002904
        private void DrawButtonBackgroundFromBuffer(Graphics graphics)
        {
            int index;
            if (!base.Enabled)
            {
                index = 0;
            }
            else if (this.IsPressed)
            {
                index = 1;
            }
            else if (!this.IsAnimating && this._currentFrame == 0)
            {
                index = 2;
            }
            else
            {
                if (!this.HasAnimationFrames)
                {
                    this.CreateFrames(true);
                }
                index = 3 + this._currentFrame;
            }
            if (this._frames == null || this._frames.Count == 0)
            {
                this.CreateFrames();
            }
            graphics.DrawImage(this._frames[index], Point.Empty);
        }

        // Token: 0x0600007F RID: 127 RVA: 0x00004BA8 File Offset: 0x00002DA8
        private void DrawButtonForeground(Graphics g)
        {
            if (this.Focused && this.ShowFocusCues)
            {
                Rectangle clientRectangle = base.ClientRectangle;
                clientRectangle.Inflate(-4, -4);
                ControlPaint.DrawFocusRectangle(g, clientRectangle);
            }
        }

        // Token: 0x06000080 RID: 128 RVA: 0x00004BE0 File Offset: 0x00002DE0
        private void DrawForegroundFromButton(PaintEventArgs pevent)
        {
            if (this._imageButton == null)
            {
                this._imageButton = new Button();
                this._imageButton.Parent = new GlassButton.TransparentControl();
                this._imageButton.SuspendLayout();
                this._imageButton.BackColor = Color.Transparent;
                this._imageButton.FlatAppearance.BorderSize = 0;
                this._imageButton.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                this._imageButton.SuspendLayout();
            }
            this._imageButton.AutoEllipsis = base.AutoEllipsis;
            if (base.Enabled)
            {
                this._imageButton.ForeColor = this.ForeColor;
            }
            else
            {
                this._imageButton.ForeColor = Color.FromArgb(3 * this.ForeColor.R + this._backColor.R >> 2, 3 * this.ForeColor.G + this._backColor.G >> 2, 3 * this.ForeColor.B + this._backColor.B >> 2);
            }
            this._imageButton.Font = this.Font;
            this._imageButton.RightToLeft = this.RightToLeft;
            this._imageButton.Image = base.Image;
            if (base.Image != null && !base.Enabled)
            {
                Size size = base.Image.Size;
                float[][] array = new float[5][];
                array[0] = new float[]
				{
					0.2125f,
					0.2125f,
					0.2125f,
					0f,
					0f
				};
                array[1] = new float[]
				{
					0.2577f,
					0.2577f,
					0.2577f,
					0f,
					0f
				};
                array[2] = new float[]
				{
					0.0361f,
					0.0361f,
					0.0361f,
					0f,
					0f
				};
                float[] array2 = new float[5];
                array2[3] = 1f;
                array[3] = array2;
                array[4] = new float[]
				{
					0.38f,
					0.38f,
					0.38f,
					0f,
					1f
				};
                ColorMatrix colorMatrix = new ColorMatrix(array);
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.ClearColorKey();
                imageAttributes.SetColorMatrix(colorMatrix);
                this._imageButton.Image = new Bitmap(base.Image.Width, base.Image.Height);
                using (Graphics graphics = Graphics.FromImage(this._imageButton.Image))
                {
                    graphics.DrawImage(base.Image, new Rectangle(0, 0, size.Width, size.Height), 0, 0, size.Width, size.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }
            this._imageButton.ImageAlign = base.ImageAlign;
            this._imageButton.ImageIndex = base.ImageIndex;
            this._imageButton.ImageKey = base.ImageKey;
            this._imageButton.ImageList = base.ImageList;
            this._imageButton.Padding = base.Padding;
            this._imageButton.Size = base.Size;
            this._imageButton.Text = this.Text;
            this._imageButton.TextAlign = this.TextAlign;
            this._imageButton.TextImageRelation = base.TextImageRelation;
            this._imageButton.UseCompatibleTextRendering = base.UseCompatibleTextRendering;
            this._imageButton.UseMnemonic = base.UseMnemonic;
            this._imageButton.ResumeLayout();
            base.InvokePaint(this._imageButton, pevent);
            if (this._imageButton.Image != null && this._imageButton.Image != base.Image)
            {
                this._imageButton.Image.Dispose();
                this._imageButton.Image = null;
            }
        }

        // Token: 0x0600008E RID: 142 RVA: 0x0000530C File Offset: 0x0000350C
        private void FadeIn()
        {
            this._direction = 1;
            this.timer.Enabled = true;
        }

        // Token: 0x0600008F RID: 143 RVA: 0x00005324 File Offset: 0x00003524
        private void FadeOut()
        {
            this._direction = -1;
            this.timer.Enabled = true;
        }

        // Token: 0x06000092 RID: 146 RVA: 0x00005438 File Offset: 0x00003638
        private void InitializeComponent()
        {
            this.components = new Container();
            this.timer = new Timer(this.components);
            base.SuspendLayout();
            this.timer.Tick += new EventHandler(this.timer_Tick);
            base.ResumeLayout(false);
        }

        // Token: 0x0600006F RID: 111 RVA: 0x00004470 File Offset: 0x00002670
        protected override void OnClick(EventArgs e)
        {
            this._isKeyDown = (this._isMouseDown = false);
            base.OnClick(e);
        }

        // Token: 0x06000070 RID: 112 RVA: 0x00004494 File Offset: 0x00002694
        protected override void OnEnter(EventArgs e)
        {
            this._isFocused = (this._isFocusedByKey = true);
            base.OnEnter(e);
            if (this._fadeOnFocus)
            {
                this.FadeIn();
            }
        }

        // Token: 0x0600006D RID: 109 RVA: 0x00004448 File Offset: 0x00002648
        protected virtual void OnGlowColorChanged(EventArgs e)
        {
            if (this.GlowColorChanged != null)
            {
                this.GlowColorChanged(this, e);
            }
        }

        // Token: 0x06000064 RID: 100 RVA: 0x000042B0 File Offset: 0x000024B0
        protected virtual void OnInnerBorderColorChanged(EventArgs e)
        {
            if (this.InnerBorderColorChanged != null)
            {
                this.InnerBorderColorChanged(this, e);
            }
        }

        // Token: 0x06000072 RID: 114 RVA: 0x00004514 File Offset: 0x00002714
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this._isKeyDown = true;
                base.Invalidate();
            }
            base.OnKeyDown(e);
        }

        // Token: 0x06000073 RID: 115 RVA: 0x00004534 File Offset: 0x00002734
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (this._isKeyDown && e.KeyCode == Keys.Space)
            {
                this._isKeyDown = false;
                base.Invalidate();
            }
            base.OnKeyUp(e);
        }

        // Token: 0x06000071 RID: 113 RVA: 0x000044C8 File Offset: 0x000026C8
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this._isFocused = (this._isFocusedByKey = (this._isKeyDown = (this._isMouseDown = false)));
            base.Invalidate();
            if (this._fadeOnFocus)
            {
                this.FadeOut();
            }
        }

        // Token: 0x06000074 RID: 116 RVA: 0x0000455C File Offset: 0x0000275C
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!this._isMouseDown && e.Button == MouseButtons.Left)
            {
                this._isMouseDown = true;
                this._isFocusedByKey = false;
                base.Invalidate();
            }
            base.OnMouseDown(e);
        }

        // Token: 0x06000077 RID: 119 RVA: 0x00004614 File Offset: 0x00002814
        protected override void OnMouseEnter(EventArgs e)
        {
            this._isHovered = true;
            this.FadeIn();
            base.Invalidate();
            base.OnMouseEnter(e);
        }

        // Token: 0x06000078 RID: 120 RVA: 0x00004630 File Offset: 0x00002830
        protected override void OnMouseLeave(EventArgs e)
        {
            this._isHovered = false;
            if (!this.FadeOnFocus || !this._isFocusedByKey)
            {
                this.FadeOut();
            }
            base.Invalidate();
            base.OnMouseLeave(e);
        }

        // Token: 0x06000076 RID: 118 RVA: 0x000045B0 File Offset: 0x000027B0
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != MouseButtons.None)
            {
                if (!base.ClientRectangle.Contains(e.X, e.Y))
                {
                    if (this._isHovered)
                    {
                        this._isHovered = false;
                        base.Invalidate();
                        return;
                    }
                }
                else if (!this._isHovered)
                {
                    this._isHovered = true;
                    base.Invalidate();
                }
            }
        }

        // Token: 0x06000075 RID: 117 RVA: 0x00004590 File Offset: 0x00002790
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this._isMouseDown)
            {
                this._isMouseDown = false;
                base.Invalidate();
            }
            base.OnMouseUp(e);
        }

        // Token: 0x06000067 RID: 103 RVA: 0x00004338 File Offset: 0x00002538
        protected virtual void OnOuterBorderColorChanged(EventArgs e)
        {
            if (this.OuterBorderColorChanged != null)
            {
                this.OuterBorderColorChanged(this, e);
            }
        }

        // Token: 0x06000079 RID: 121 RVA: 0x0000465C File Offset: 0x0000285C
        protected override void OnPaint(PaintEventArgs e)
        {
            this.DrawButtonBackgroundFromBuffer(e.Graphics);
            this.DrawForegroundFromButton(e);
            this.DrawButtonForeground(e.Graphics);
            if (this.Paint != null)
            {
                this.Paint(this, e);
            }
        }

        // Token: 0x0600006A RID: 106 RVA: 0x000043C0 File Offset: 0x000025C0
        protected virtual void OnShineColorChanged(EventArgs e)
        {
            if (this.ShineColorChanged != null)
            {
                this.ShineColorChanged(this, e);
            }
        }

        // Token: 0x0600006E RID: 110 RVA: 0x00004460 File Offset: 0x00002660
        protected override void OnSizeChanged(EventArgs e)
        {
            this.CreateFrames();
            base.OnSizeChanged(e);
        }

        // Token: 0x06000090 RID: 144 RVA: 0x0000533C File Offset: 0x0000353C
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!this.timer.Enabled)
            {
                return;
            }
            this.Refresh();
            this._currentFrame += this._direction;
            if (this._currentFrame == -1)
            {
                this._currentFrame = 0;
                this.timer.Enabled = false;
                this._direction = 0;
                return;
            }
            if (this._currentFrame == 10)
            {
                this._currentFrame = 9;
                this.timer.Enabled = false;
                this._direction = 0;
            }
        }

        // Token: 0x17000019 RID: 25
        [DefaultValue(typeof(Color), "Black")]
        public new virtual Color BackColor
        {
            // Token: 0x06000052 RID: 82 RVA: 0x0000407C File Offset: 0x0000227C
            get
            {
                return this._backColor;
            }
            // Token: 0x06000053 RID: 83 RVA: 0x00004084 File Offset: 0x00002284
            set
            {
                if (!this._backColor.Equals(value))
                {
                    this._backColor = value;
                    this.UseVisualStyleBackColor = false;
                    this.CreateFrames();
                    this.OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        // Token: 0x1700001F RID: 31
        [Category("Appearance"), DefaultValue(false), Description("Indicates whether the button should fade in and fade out when it is getting and loosing the focus.")]
        public virtual bool FadeOnFocus
        {
            // Token: 0x0600005E RID: 94 RVA: 0x000041D4 File Offset: 0x000023D4
            get
            {
                return this._fadeOnFocus;
            }
            // Token: 0x0600005F RID: 95 RVA: 0x000041DC File Offset: 0x000023DC
            set
            {
                if (this._fadeOnFocus != value)
                {
                    this._fadeOnFocus = value;
                }
            }
        }

        // Token: 0x17000022 RID: 34
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatButtonAppearance FlatAppearance
        {
            // Token: 0x06000084 RID: 132 RVA: 0x0000519C File Offset: 0x0000339C
            get
            {
                return base.FlatAppearance;
            }
        }

        // Token: 0x17000023 RID: 35
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new FlatStyle FlatStyle
        {
            // Token: 0x06000085 RID: 133 RVA: 0x000051A4 File Offset: 0x000033A4
            get
            {
                return base.FlatStyle;
            }
            // Token: 0x06000086 RID: 134 RVA: 0x000051AC File Offset: 0x000033AC
            set
            {
                base.FlatStyle = value;
            }
        }

        // Token: 0x1700001A RID: 26
        [DefaultValue(typeof(Color), "White")]
        public new virtual Color ForeColor
        {
            // Token: 0x06000054 RID: 84 RVA: 0x000040C0 File Offset: 0x000022C0
            get
            {
                return base.ForeColor;
            }
            // Token: 0x06000055 RID: 85 RVA: 0x000040C8 File Offset: 0x000022C8
            set
            {
                base.ForeColor = value;
            }
        }

        // Token: 0x1700001E RID: 30
        [Category("Appearance"), DefaultValue(typeof(Color), "255,141,189,255"), Description("The glow color of the control.")]
        public virtual Color GlowColor
        {
            // Token: 0x0600005C RID: 92 RVA: 0x00004194 File Offset: 0x00002394
            get
            {
                return this._glowColor;
            }
            // Token: 0x0600005D RID: 93 RVA: 0x0000419C File Offset: 0x0000239C
            set
            {
                if (this._glowColor != value)
                {
                    this._glowColor = value;
                    this.CreateFrames();
                    if (base.IsHandleCreated)
                    {
                        base.Invalidate();
                    }
                    this.OnGlowColorChanged(EventArgs.Empty);
                }
            }
        }

        // Token: 0x17000025 RID: 37
        private bool HasAnimationFrames
        {
            // Token: 0x06000089 RID: 137 RVA: 0x000051CC File Offset: 0x000033CC
            get
            {
                return this._frames != null && this._frames.Count > 3;
            }
        }

        // Token: 0x1700001B RID: 27
        [Category("Appearance"), DefaultValue(typeof(Color), "Black"), Description("The inner border color of the control.")]
        public virtual Color InnerBorderColor
        {
            // Token: 0x06000056 RID: 86 RVA: 0x000040D4 File Offset: 0x000022D4
            get
            {
                return this._innerBorderColor;
            }
            // Token: 0x06000057 RID: 87 RVA: 0x000040DC File Offset: 0x000022DC
            set
            {
                if (this._innerBorderColor != value)
                {
                    this._innerBorderColor = value;
                    this.CreateFrames();
                    if (base.IsHandleCreated)
                    {
                        base.Invalidate();
                    }
                    this.OnInnerBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        // Token: 0x17000026 RID: 38
        private bool IsAnimating
        {
            // Token: 0x0600008D RID: 141 RVA: 0x000052FC File Offset: 0x000034FC
            get
            {
                return this._direction != 0;
            }
        }

        // Token: 0x17000020 RID: 32
        private bool IsPressed
        {
            // Token: 0x06000060 RID: 96 RVA: 0x000041F0 File Offset: 0x000023F0
            get
            {
                return this._isKeyDown || (this._isMouseDown && this._isHovered);
            }
        }

        // Token: 0x1700001C RID: 28
        [Category("Appearance"), DefaultValue(typeof(Color), "White"), Description("The outer border color of the control.")]
        public virtual Color OuterBorderColor
        {
            // Token: 0x06000058 RID: 88 RVA: 0x00004114 File Offset: 0x00002314
            get
            {
                return this._outerBorderColor;
            }
            // Token: 0x06000059 RID: 89 RVA: 0x0000411C File Offset: 0x0000231C
            set
            {
                if (this._outerBorderColor != value)
                {
                    this._outerBorderColor = value;
                    this.CreateFrames();
                    if (base.IsHandleCreated)
                    {
                        base.Invalidate();
                    }
                    this.OnOuterBorderColorChanged(EventArgs.Empty);
                }
            }
        }

        // Token: 0x1700001D RID: 29
        [Category("Appearance"), DefaultValue(typeof(Color), "White"), Description("The shine color of the control.")]
        public virtual Color ShineColor
        {
            // Token: 0x0600005A RID: 90 RVA: 0x00004154 File Offset: 0x00002354
            get
            {
                return this._shineColor;
            }
            // Token: 0x0600005B RID: 91 RVA: 0x0000415C File Offset: 0x0000235C
            set
            {
                if (this._shineColor != value)
                {
                    this._shineColor = value;
                    this.CreateFrames();
                    if (base.IsHandleCreated)
                    {
                        base.Invalidate();
                    }
                    this.OnShineColorChanged(EventArgs.Empty);
                }
            }
        }

        // Token: 0x17000021 RID: 33
        [Browsable(false)]
        public PushButtonState State
        {
            // Token: 0x06000061 RID: 97 RVA: 0x0000420C File Offset: 0x0000240C
            get
            {
                if (!base.Enabled)
                {
                    return PushButtonState.Disabled;
                }
                if (this.IsPressed)
                {
                    return PushButtonState.Pressed;
                }
                if (this._isHovered)
                {
                    return PushButtonState.Hot;
                }
                if (this._isFocused || base.IsDefault)
                {
                    return PushButtonState.Default;
                }
                return PushButtonState.Normal;
            }
        }

        // Token: 0x17000024 RID: 36
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
        public new bool UseVisualStyleBackColor
        {
            // Token: 0x06000087 RID: 135 RVA: 0x000051B8 File Offset: 0x000033B8
            get
            {
                return base.UseVisualStyleBackColor;
            }
            // Token: 0x06000088 RID: 136 RVA: 0x000051C0 File Offset: 0x000033C0
            set
            {
                base.UseVisualStyleBackColor = value;
            }
        }

        // Token: 0x14000004 RID: 4
        // Token: 0x0600006B RID: 107 RVA: 0x000043D8 File Offset: 0x000025D8
        // Token: 0x0600006C RID: 108 RVA: 0x00004410 File Offset: 0x00002610
        [Category("Property Changed"), Description("Event raised when the value of the GlowColor property is changed.")]
        public event EventHandler GlowColorChanged;

        // Token: 0x14000001 RID: 1
        // Token: 0x06000062 RID: 98 RVA: 0x00004240 File Offset: 0x00002440
        // Token: 0x06000063 RID: 99 RVA: 0x00004278 File Offset: 0x00002478
        [Category("Property Changed"), Description("Event raised when the value of the InnerBorderColor property is changed.")]
        public event EventHandler InnerBorderColorChanged;

        // Token: 0x14000002 RID: 2
        // Token: 0x06000065 RID: 101 RVA: 0x000042C8 File Offset: 0x000024C8
        // Token: 0x06000066 RID: 102 RVA: 0x00004300 File Offset: 0x00002500
        [Category("Property Changed"), Description("Event raised when the value of the OuterBorderColor property is changed.")]
        public event EventHandler OuterBorderColorChanged;

        // Token: 0x14000005 RID: 5
        // Token: 0x0600007A RID: 122 RVA: 0x00004694 File Offset: 0x00002894
        // Token: 0x0600007B RID: 123 RVA: 0x000046CC File Offset: 0x000028CC
        public new event PaintEventHandler Paint;

        // Token: 0x14000003 RID: 3
        // Token: 0x06000068 RID: 104 RVA: 0x00004350 File Offset: 0x00002550
        // Token: 0x06000069 RID: 105 RVA: 0x00004388 File Offset: 0x00002588
        [Category("Property Changed"), Description("Event raised when the value of the ShineColor property is changed.")]
        public event EventHandler ShineColorChanged;

        // Token: 0x04000030 RID: 48
        private const int animationLength = 300;

        // Token: 0x04000046 RID: 70
        private IContainer components;

        // Token: 0x04000031 RID: 49
        private const int framesCount = 10;

        // Token: 0x0400002F RID: 47
        private const int FRAME_ANIMATED = 3;

        // Token: 0x0400002C RID: 44
        private const int FRAME_DISABLED = 0;

        // Token: 0x0400002E RID: 46
        private const int FRAME_NORMAL = 2;

        // Token: 0x0400002D RID: 45
        private const int FRAME_PRESSED = 1;

        // Token: 0x04000047 RID: 71
        private Timer timer;

        // Token: 0x04000032 RID: 50
        private Color _backColor;

        // Token: 0x04000044 RID: 68
        private int _currentFrame;

        // Token: 0x04000045 RID: 69
        private int _direction;

        // Token: 0x04000037 RID: 55
        private bool _fadeOnFocus;

        // Token: 0x04000043 RID: 67
        private List<Image> _frames;

        // Token: 0x04000036 RID: 54
        private Color _glowColor;

        // Token: 0x04000042 RID: 66
        private Button _imageButton;

        // Token: 0x04000033 RID: 51
        private Color _innerBorderColor;

        // Token: 0x04000039 RID: 57
        private bool _isFocused;

        // Token: 0x0400003A RID: 58
        private bool _isFocusedByKey;

        // Token: 0x04000038 RID: 56
        private bool _isHovered;

        // Token: 0x0400003B RID: 59
        private bool _isKeyDown;

        // Token: 0x0400003C RID: 60
        private bool _isMouseDown;

        // Token: 0x04000034 RID: 52
        private Color _outerBorderColor;

        // Token: 0x04000035 RID: 53
        private Color _shineColor;

        // Token: 0x02000011 RID: 17
        private class TransparentControl : Control
        {
            // Token: 0x06000094 RID: 148 RVA: 0x0000548C File Offset: 0x0000368C
            protected override void OnPaint(PaintEventArgs e)
            {
            }

            // Token: 0x06000093 RID: 147 RVA: 0x00005488 File Offset: 0x00003688
            protected override void OnPaintBackground(PaintEventArgs pevent)
            {
            }
        }
    }
}
