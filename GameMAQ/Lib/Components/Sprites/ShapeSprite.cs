using Microsoft.Xna.Framework;

namespace GameMAQ.Lib.Components.Sprites
{
    public class ShapeSprite : CustomSprite
    {
        public Color BorderColor { get; set; }
        public Color FillColor { get; set; }
        public float Thickness { get; set; }

        public ShapeSprite(Color borderColor, Color fillColor, float thickness) : base()
        {
            BorderColor = borderColor;
            FillColor = fillColor;
            Thickness = thickness;
        }
    }

    public class RectangleSprite : ShapeSprite
    {
        public Vector2 Size { get; set; }
        public double Angle { get; set; }
        public Vector2 Origin { get; set; }

        public RectangleSprite(Vector2 size, Color borderColor, Color fillColor, float angle, float thickness = 1, Vector2 origin = default) : base(borderColor, fillColor, thickness)
        {
            Size = size;
            Angle = angle;
            Origin = origin;
        }

        public override void Start()
        {
            base.Start();
            Drawer = () => GameObject.Game.SpriteBatch.DrawRectangleMAQ(this);
        }
    }

    public class CircleSprite : ShapeSprite
    {
        public int Radius { get; set; }
        public int Sides { get; set; }

        public CircleSprite(int radius, Color borderColor, Color fillColor, int sides = 25, float thickness = 1) : base(borderColor, fillColor, thickness)
        {
            Radius = radius;
            Sides = sides;
            Drawer = () =>
            {
                //SpriteBatch.DrawCircle(GameObject.Transform.AbsolutePosition, Radius, Sides, BorderColor, Thickness);
            };
        }
    }
}