using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;


namespace TDJProj
{
    public abstract class State
    {
        public State()
        {
        }

        #region Fields

        protected GraphicsDevice _graphicsDevice;

        protected Game1 _game;

        #endregion

        #region Methods
        public abstract void LoadContent(ContentManager content);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public State(Game1 game, GraphicsDevice graphicsDevice)
        {
            _game = game;

            _graphicsDevice = graphicsDevice;

        }

        public abstract void Update(GameTime gameTime);

        #endregion
    }
}
