using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PrintScreen
{
    public abstract class CSprite
    {
        internal static Graphics Graphics;
        public CSprite Parent;

        public string Name;

        public List<CSprite> Childs { get; } = new List<CSprite>();

        public float Alpha = 1;

        public bool Visible = true;

        public int Width
        {
            get => Size.Width;
            set => _size.Width = value;
        }

        public int Height
        {
            get => Size.Height;
            set => _size.Height = value;
        }

        public int X
        {
            get => Location.X;
            set => _location.X = value;
        }

        public int Y
        {
            get => Location.Y;
            set => _location.Y = value;
        }

        private Point _location;

        public virtual Point Location
        {
            get => _location;
            set => _location = value;
        }

        private Size _size;

        public virtual Size Size
        {
            get => _size;
            set => _size = value;
        }

        public virtual int Left
        {
            get => Location.X;
            set => _location.X = value;
        }

        public virtual int Top
        {
            get => Location.Y;
            set => _location.Y = value;
        }

        public virtual int Right
        {
            get => Parent.Width - this.Width - this.Left;
            set => this.Left = Parent.Width - this.Width - value;
        }

        public virtual int Bottom
        {
            get => Parent.Height - this.Height - this.Top;
            set => this.Top = Parent.Height - this.Height - value;
        }

        public virtual int ZIndex { get; set; }

        public virtual void Render()
        {
            // 子节点重绘
            foreach (var child in Childs.OrderBy(p => p.ZIndex))
            {
                if (this.Visible == false)
                    continue;
                child.Render();
            }
        }


        public virtual bool Destroy()
        {
            return this.Parent.Childs.Remove(this);
        }

        public virtual void DestroyChild()
        {
            this.Childs.Clear();
        }

        public virtual void AddChild(params CSprite[] sprites)
        {
            foreach (var sprite in sprites)
            {
                sprite.Parent = this;
              //  sprite.Graphics = this.Graphics;
            }

            this.Childs.AddRange(sprites);
        }
    }
}