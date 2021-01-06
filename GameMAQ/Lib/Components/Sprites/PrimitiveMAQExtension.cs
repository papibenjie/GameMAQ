using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameMAQ.Lib.Components.Sprites
{
    public static class PrimitiveMAQExtension
    {
        public static void DrawRectangleMAQ(this SpriteBatch spriteBatch, RectangleSprite sprite)
        {
            var pos = sprite.GameObject.Transform.AbsolutePosition;
            var size = sprite.Size;

            var pix = new Texture2D(spriteBatch.GraphicsDevice, (int)size.X, (int)size.Y, false, SurfaceFormat.Color);
            pix.SetData(Enumerable.Repeat(sprite.FillColor, (int)size.X * (int)size.Y).Select(
                (color, idx) =>
                {
                    int col = idx % (int)size.X;
                    int row = (int)(idx / size.X);
                    float thick = sprite.Thickness;
                    if (col < thick || col > size.X - thick || row < thick || row > size.Y - thick)
                    {
                        return sprite.BorderColor;
                    }

                    return sprite.FillColor;
                }).ToArray());
            var dest = new Rectangle(sprite.GameObject.Transform.AbsolutePosition.ToPoint(), sprite.Size.ToPoint());
            spriteBatch.Draw(pix, dest, new Rectangle(0, 0, (int)size.X, (int)size.Y), Color.White, (float)sprite.Angle,
                sprite.Origin, SpriteEffects.None, 0.0f);
        }
    }
}