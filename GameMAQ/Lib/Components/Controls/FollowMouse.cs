using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameMAQ.Lib.Components.Controls
{
    public class FollowMouse : Component
    {
        public Vector2 Offset { get; set; }

        public FollowMouse(Vector2 offset = default(Vector2))
        {
            Offset = offset;
        }

        public override void Update()
        {
            GameObject.Transform.AbsolutePosition = Mouse.GetState().Position.ToVector2() + Offset;
        }
    }
}