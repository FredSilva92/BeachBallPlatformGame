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
        private LevelMap map;
        private ScreenMessage screenMessage;
        private int viewportWidth;
        private int viewportHeight;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            beachBall = new BeachBall();
            screenMessage = new ScreenMessage();
        }

        protected override void Initialize()
        {
            new KeyManager();
            map = new LevelMap();
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("Background");
            viewportWidth = this.Window.ClientBounds.Width;
            viewportHeight = this.Window.ClientBounds.Height;
            Tile.Content = Content;
            beachBall.LoadContent(Content);
            screenMessage.LoadContent(Content);

            map.Generate(new int[,] {
                {1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1,1,1,1,1,1,1,3,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,4,4,1,1,1,1,1,0,0,0,1,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 2, 1, 1, 1, 1,4,4,1,1,1,1,1,4,4,1,1,1,1,1,1,1,1,0,0,4,4,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 1,1,1,1,0,0,0,1,1,1,1,0,0,0,0,0,0,1,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,5,1,0,0,0,0,0,0,0,0,0,4,4,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 0, 1, 1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {1, 0, 0, 0, 0, 1, 1, 1,4,4,1,1,4,4,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,4,4,4,4,1,},
                {1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,},
            }, 32, 32);

            GraphicsDevice.Viewport = new Viewport(0, 0, viewportWidth * 2, viewportHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (beachBall.IsDeath || beachBall.HasFinished)
            {
                return;
            }


            if (beachBall.OnFirstSection(viewportWidth)) {
                GraphicsDevice.Viewport = new Viewport(0, 0, viewportWidth * 2, viewportHeight);
            } else if (beachBall.OnSecondSection(viewportWidth)) {
                GraphicsDevice.Viewport = new Viewport(-viewportWidth, 0, viewportWidth * 2, viewportHeight);
            }

            KeyManager.Update();
            foreach (Tile tile in map.CollisionTiles)
            {
                beachBall.HasCollision(gameTime, tile, map.Width, map.Height);

                if (beachBall.IsDeath || beachBall.HasFinished) {
                    return;
                }
            }
            beachBall.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(background,
                new Rectangle(0, 0, viewportWidth, viewportHeight),
                Color.White);
            _spriteBatch.Draw(background,
                new Rectangle(viewportWidth, 0, viewportWidth, viewportHeight),
                Color.White);
            map.Draw(_spriteBatch);
            beachBall.Draw(gameTime, _spriteBatch);

            if (beachBall.IsDeath) {

                if (beachBall.Position.X <= viewportWidth)
                {
                    screenMessage.Draw(_spriteBatch, 0, viewportWidth / 2, viewportHeight / 3);
                }
                else {
                    screenMessage.Draw(_spriteBatch, 0, viewportWidth + viewportWidth / 2, viewportHeight / 2);
                }
                
            }

            if (beachBall.HasFinished) {
                int width = viewportWidth + viewportWidth/2;
                screenMessage.Draw(_spriteBatch, 1, width, viewportHeight / 2);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
