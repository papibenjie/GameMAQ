using GameMAQ.Lib.Components.Sprites;
using Microsoft.Xna.Framework;

namespace GameMAQ.Lib.Components.Colliders
{
    public class RectangleCollider : Collider<RectangleCollider>
    {
        private bool _display = false;
        public Vector2 Size { get; set; }
        public GameObject SpriteObject { get; set; } = new GameObject();
        public RectangleSprite SpriteComponent { get; set; }
        public bool DisplayDefault { get; set; }

        public bool Display
        {
            get
            {
                return _display;
            }
            set
            {
                if (value != _display)
                {
                    if (value)
                    {
                        GameObject?.Children.Add(SpriteObject);
                    }
                    else
                    {
                        GameObject?.Children.Remove(SpriteObject);
                    }
                    _display = value;
                }
            }
        }

        public RectangleCollider(Vector2 size, bool displayDefault = false)
        {
            Size = size;
            DisplayDefault = displayDefault;
        }

        public override void Start()
        {
            base.Start();
            Display = DisplayDefault;

            SpriteComponent = new RectangleSprite(Size, Color.Green, Color.Transparent, 0, 5);
            SpriteObject.Components.Add(SpriteComponent);
            GameObject.Children.Add(SpriteObject);
        }

        public override void Update()
        {
            base.Update();
            SpriteComponent.Angle += 0.01;
        }

        public override bool IsColliding(RectangleCollider collider)
        {
            return collider.HandleRectangle(this);
        }

        private bool HandleRectangle(RectangleCollider rectangleCollider)
        {
            var pos = GameObject.Transform.AbsolutePosition;
            var r1 = new Rectangle((int)pos.X, (int)pos.Y, (int)Size.X, (int)Size.Y);
            var pos2 = rectangleCollider.GameObject.Transform.AbsolutePosition;
            var size2 = rectangleCollider.Size;
            var r2 = new Rectangle((int)pos2.X, (int)pos2.Y, (int)size2.X, (int)size2.Y);
            return r1.X < r2.X + r2.Width &&
                   r1.X + r1.Width > r2.X &&
                   r1.Y < r2.Y + r2.Height &&
                   r1.Height + r1.Y > r2.Y;
        }
    }
}