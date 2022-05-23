using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TDJProj.Utils;

namespace TDJProj
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BeachBall beachBall;
        private Texture2D background;
        private Map map;
        private bool hasDied;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            beachBall = new BeachBall(this);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            new KeyManager();
            map = new Map();
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //_currentState = new MainMenu(this, null);
            //_currentState.LoadContent(Content);
            background = Content.Load<Texture2D>("Background");
            Tiles.Content = Content;
            beachBall.LoadContent(Content);

            int width = this.Window.ClientBounds.Width / 10;
            int height = this.Window.ClientBounds.Height / 10;

            map.Generate(new int[,] {
                {1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1,3,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 2, 1, 1, 1, 1,4,4,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 1,1,1,1,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},


            }, 32, 32);

            GraphicsDevice.Viewport = new Viewport(0, 0, this.Window.ClientBounds.Width * 2, this.Window.ClientBounds.Height);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (hasDied) {
                return;
            }

            // TODO: Add your update logic here

            if (beachBall.OnFirstSection(this.Window.ClientBounds.Width)) {
                GraphicsDevice.Viewport = new Viewport(0, 0, this.Window.ClientBounds.Width * 2, this.Window.ClientBounds.Height);
            } else if (beachBall.OnSecondSection(this.Window.ClientBounds.Width)) {
                GraphicsDevice.Viewport = new Viewport(-this.Window.ClientBounds.Width, 0, this.Window.ClientBounds.Width * 2, this.Window.ClientBounds.Height);
            }

            KeyManager.Update();
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                beachBall.HasCollision(gameTime, tile, map.Width, map.Height);

                if (beachBall.IsDeath) {
                    return;
                }
                /*if (beachBall.HasCollision(gameTime, tile, map.Width, map.Height) == 'd')
                {
                    //hasDied = true;
                };*/
            }
            beachBall.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            //_currentState.Draw(gameTime, _spriteBatch);
            _spriteBatch.Draw(background,
                new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height),
                Color.White);
            _spriteBatch.Draw(background,
                new Rectangle(this.Window.ClientBounds.Width, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height),
                Color.White);
            map.Draw(_spriteBatch);
            beachBall.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
