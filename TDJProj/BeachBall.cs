using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TDJProj.Utils;

namespace TDJProj
{
    public class BeachBall
    {
        private Texture2D sprite;
        private Texture2D deathSprite;
        private Vector2 position;
        private Vector2 velocity;
        private Vector2 deathPosition;
        private Game1 _game;
        private Rectangle rectangle;
        private bool hasJumped;
        private bool hasCollisionBottom;
        private bool hasCollisionLeft;
        private bool hasCollisionRight;
        private bool hasCollisionTop;
        private float maxJump;
        private float rotation;
        private bool isDeath;

        public BeachBall(Game1 game)
        {
            _game = game;
        }

        public bool IsDeath {
            get { return isDeath; }
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("BeachBall");
            deathSprite = content.Load<Texture2D>("WreckedBall");
            position = new Vector2(32,32);

            Console.WriteLine("Loading");
        }

        public void PostUpdate(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            

            if (KeyManager.GetKey(Keys.D))
            {
                if (!hasCollisionLeft) {
                    velocity.X = getVelocity(gameTime); ;
                    rotation += .2f;

                } else {
                    velocity.X = 0f;
                    hasCollisionLeft = false;
                }
            }

            else if (KeyManager.GetKey(Keys.A))
            {
                if (!hasCollisionRight)
                {
                    velocity.X = -getVelocity(gameTime); ;
                    rotation -= .2f;

                }
                else
                {
                    velocity.X = 0f;
                    hasCollisionRight = false;
                }
            }

            else {
                velocity.X = 0f;
            }

            updateYAxis(gameTime);

            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        private void updateYAxis(GameTime gameTime) {

            if (hasJumped) {

                if (hasCollisionTop) {
                    velocity.Y = getVelocity(gameTime);
                    hasJumped = false;
                    hasCollisionTop = false;
                } else if (position.Y <= maxJump)
                {
                    hasJumped = false;
                }
                else {
                    velocity.Y = -getVelocity(gameTime);
                }
                
                return;
            }

            if ((KeyManager.GetKey(Keys.Space) || KeyManager.GetKey(Keys.W)) && !hasJumped && hasCollisionBottom)
            {
                //position.Y -= 5f;
                maxJump = position.Y - 150f;
                velocity.Y = -getVelocity(gameTime);
                hasJumped = true;
            }

            if (hasCollisionBottom)
            {
                velocity.Y = 0;
                hasCollisionBottom = false;
                //hasJumped = false;
            }
            else
            {
                velocity.Y = getVelocity(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            Vector2 origin = new Vector2(sprite.Width/2, sprite.Height/2);

            if (isDeath) {

                spriteBatch.Draw(deathSprite,
                    deathPosition,
                    Color.White);

                return;
            }

            spriteBatch.Draw(sprite,
                 position + origin,
                 null,
                 Color.White,
                 rotation,
                 origin,
                 1f,
                 SpriteEffects.None,
                 0f);

        }

        public void HasCollision(GameTime gameTime, Tiles tile, int xOffset, int yOffset) {

            Rectangle newRectangle = tile.Rectangle;

            bool hasCollision = false;

            if (rectangle.TouchBottomOf(newRectangle)) {
                hasCollision = true;
                hasCollisionBottom = true;
            }

            if (rectangle.TouchLeftOf(newRectangle)) {
                hasCollision = true;
                hasCollisionLeft = true;
            }

            if (rectangle.TouchRightOf(newRectangle))
            {
                hasCollision = true;
                hasCollisionRight = true;
            }

            if (rectangle.TouchTopOf(newRectangle))
            {
                hasCollision = true;
                hasCollisionTop = true;
            }

            if (hasCollision && tile.IsEnemy) {
                isDeath = true;
                deathPosition.X = newRectangle.X;
                deathPosition.Y = newRectangle.Y + deathSprite.Height;
            }

        }

        public bool OnSecondSection(int screenPos) {
            return position.X >= screenPos  &&
                position.X <= screenPos + 10;
        }

        public bool OnFirstSection(int screenPos)
        {
            return position.X > (screenPos - sprite.Width) -10 &&
                position.X < (screenPos - sprite.Width) + 10;
        }

        private float getVelocity(GameTime gameTime) {
            return 120 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    }
}
