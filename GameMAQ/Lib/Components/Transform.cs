using Microsoft.Xna.Framework;

namespace GameMAQ.Lib.Components
{
    public class Transform : Component
    {
        public Vector2 RelativePosition { get; set; } = Vector2.Zero;

        public Vector2 AbsolutePosition
        {
            get
            {
                return RelativePosition + (GameObject.Parent?.Transform.AbsolutePosition ?? Vector2.Zero);
            }
            set
            {
                RelativePosition = value - (GameObject.Parent?.Transform.AbsolutePosition ?? Vector2.Zero);
            }
        }
    }
}