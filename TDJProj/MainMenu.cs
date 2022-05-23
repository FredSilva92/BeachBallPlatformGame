using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TDJProj
{
    public class MainMenu : State
    {
        private Texture2D background;

        public MainMenu()
        {
        }

        public MainMenu(Game1 game, GraphicsDevice graphicsDevice) : base(game, graphicsDevice)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>("MenuBackground");
        }

        public override void PostUpdate(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background,
                new Rectangle(0, 0, _game.Window.ClientBounds.Width, _game.Window.ClientBounds.Height),
                Color.White);
        }
    }
}
