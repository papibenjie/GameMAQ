using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace GameMAQ.Lib
{
    public class GameMAQ : Game
    {

        public GameObject Scene { get; set; }
        public GraphicsDeviceManager Graphics { get; set; }
        public Color BackColor { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public GameMAQ(Color backColor, string title = "GameMAQ", Size? size = null)
        {
            BackColor = backColor;
            Graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            IsMouseVisible = true;
            Window.Title = title;
            Scene = new GameObject();
            Scene.Game = this;
            ResizeWindow(size ?? new Size(800, 600));
        }

        protected internal void ResizeWindow(Size size)
        {
            Graphics.PreferredBackBufferWidth = size.Width;
            Graphics.PreferredBackBufferHeight = size.Height;
            Graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            //Scene.Components.Add(new ColliderManager());
        }

        protected override void Initialize()
        {
            base.Initialize();
            Scene.Initialize(this);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(BackColor);
            Scene.Draw();
        }

        protected override void BeginRun()
        {
            base.BeginRun();
            Scene.Start();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Scene.Update();
        }
    }
}