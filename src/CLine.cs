using System.Linq;
using System.Drawing;

namespace PrintScreen
{
    public class CLine : CSprite
    {
        public Color Color = Color.Black;

        public Point Point1;
        public Point Point2;

        public int Thickness = 5;

        public override void Render()
        {
            using (var pen = new Pen(Color.FromArgb((int)(255 * base.Alpha), this.Color), Thickness))
            {
                Graphics.DrawLine(pen,
                    new Point(Parent.X + this.Point1.X, Parent.Y + this.Point1.Y),
                    new Point(Parent.X + this.Point2.X, Parent.Y + this.Point2.Y)
                );
                
               
            }

            base.Render();
        }
    }
}