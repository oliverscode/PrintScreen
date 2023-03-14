using System.Drawing;

namespace PrintScreen
{
    public class CString : CSprite
    {
        private Font _font = new Font("微软雅黑", 12);

        public Font Font
        {
            get => _font;
            set
            {
                _font = value;

                var size = Graphics.MeasureString(this.Text, this.Font);
                Size = new Size((int)size.Width, (int)size.Height);
            }
        }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                var size = Graphics.MeasureString(this.Text, this.Font);
                Size = new Size((int)size.Width, (int)size.Height);
            }
        }

        public Color Color = Color.Black;


        public CString()
        {
        }

        public CString(string text)
        {
            this.Text= text;
        }

        public CString(string text, Color color)
        {
            this.Text = text;
            this.Color = color;
        }

        public CString(string text, Color color, Font font)
        {
            this.Text = text;
            this.Color = color;
            this.Font = font;
        }


        public override void Render()
        {
            using (var brush = new SolidBrush(Color.FromArgb((int)(255 * base.Alpha), this.Color)))
            {
                if (string.IsNullOrEmpty(_text))
                    return;

                Graphics.DrawString(this.Text, this.Font, brush,
                    this.Location.X + base.Parent.Location.X,
                    this.Location.Y + base.Parent.Location.Y
                );
            }

            base.Render();
        }
    }
}