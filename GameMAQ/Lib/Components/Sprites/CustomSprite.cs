using System;

namespace GameMAQ.Lib.Components.Sprites
{
    public class CustomSprite : Component
    {
        public Action Drawer { get; set; } = () => { };

        public override void Draw()
        {
            base.Draw();
            GameObject.Game.SpriteBatch.Begin();
            Drawer();
            GameObject.Game.SpriteBatch.End();
        }
    }
}