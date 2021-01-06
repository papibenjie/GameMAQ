using System;
using GameMAQ.Lib;
using GameMAQ.Lib.Components.Colliders;
using GameMAQ.Lib.Components.Controls;
using GameMAQ.Lib.Components.Sprites;
using Microsoft.Xna.Framework;
using Color = Microsoft.Xna.Framework.Color;

namespace GameMAQ
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            var game = new Lib.GameMAQ(Color.Aqua);
            var obj = new GameObject();
            obj.Game = game;
            var vec = new Vector2(100, 100);

            obj.Components.Add(new RectangleSprite(vec, Color.Black, Color.Transparent, 0, 5));
            obj.Components.Add(new FollowMouse(-vec / 2));
            game.Scene.Components.Add(new RectangleSprite(vec, Color.Purple, Color.Transparent, 0, 25));
            game.Scene.Children.Add(obj);

            obj.Transform.RelativePosition = new Vector2(100, 100);
            game.Scene.Transform.RelativePosition = new Vector2(100, 100);

            RectangleCollider col1 = new RectangleCollider(new Vector2(50, 50), true);
            RectangleCollider col2 = new RectangleCollider(new Vector2(50, 50), true);

            obj.Components.Add(col1);
            game.Scene.Components.Add(col2);

            game.Run();
        }
    }
}