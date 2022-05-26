using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        private Vector2 finalPosition;
        private Rectangle rectangle;
        private bool hasJumped;
        private bool hasCollisionBottom;
        private bool hasCollisionLeft;
        private bool hasCollisionRight;
        private bool hasCollisionTop;
        private float maxJump;
        private float rotation;
        private bool isDeath;
        private bool hasFinished;
        private SoundEffectInstance rollingSoundInstance;
        private SoundEffectInstance explosionInstance;

        public BeachBall()
        {
        }

        public bool IsDeath {
            get { return isDeath; }
        }

        public bool HasFinished {
            get { return hasFinished; }
        }

        public Vector2 Position {
            get { return position; }
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("BeachBall");
            deathSprite = content.Load<Texture2D>("WreckedBall");

            SoundEffect rollingSound = content.Load<SoundEffect>("ballSound");
            rollingSoundInstance = rollingSound.CreateInstance();

            SoundEffect explosionSound = content.Load<SoundEffect>("popped");
            explosionInstance = explosionSound.CreateInstance();

            position = new Vector2(32,32);
        }

        public void Update(GameTime gameTime)
        {
            bool hasCollision = hasCollisionLeft ||
                hasCollisionRight ||
                hasCollisionTop ||
                hasCollisionBottom;

            if (KeyManager.GetKey(Keys.D))
            {
                if (!hasCollisionLeft) {
                    velocity.X = GetVelocity(gameTime);
                    rotation += .2f;

                    if (hasCollision) {
                        rollingSoundInstance.Play();
                    }
                    

                } else {
                    velocity.X = 0f;
                    hasCollisionLeft = false;
                }
            }

            else if (KeyManager.GetKey(Keys.A))
            {
                if (!hasCollisionRight)
                {
                    velocity.X = -GetVelocity(gameTime); ;
                    rotation -= .2f;

                    if (hasCollision)
                    {
                        rollingSoundInstance.Play();
                    }
                }
                else
                {
                    velocity.X = 0f;
                    hasCollisionRight = false;
                }
            }

            else {
                velocity.X = 0f;
                rollingSoundInstance.Stop();

            }

            updateYAxis(gameTime);

            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);


        }

        private void updateYAxis(GameTime gameTime) {

            if (hasJumped) {

                if (hasCollisionTop) {
                    velocity.Y = GetVelocity(gameTime);
                    hasJumped = false;
                    hasCollisionTop = false;
                } else if (position.Y <= maxJump)
                {
                    hasJumped = false;
                }
                else {
                    velocity.Y = -GetVelocity(gameTime);
                }
                
                return;
            }

            if ((KeyManager.GetKey(Keys.Space) || KeyManager.GetKey(Keys.W)) && !hasJumped && hasCollisionBottom)
            {
                maxJump = position.Y - 150f;
                velocity.Y = -GetVelocity(gameTime);
                hasJumped = true;
            }

            if (hasCollisionBottom)
            {
                velocity.Y = 0;
                hasCollisionBottom = false;
            }
            else
            {
                velocity.Y = GetVelocity(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            Vector2 origin = new Vector2(sprite.Width/2, sprite.Height/2);

            if (isDeath) {

                spriteBatch.Draw(deathSprite,
                    finalPosition,
                    Color.White);

                return;
            }

            if (hasFinished)
            {

                spriteBatch.Draw(sprite,
                    finalPosition,
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

        public void HasCollision(GameTime gameTime, Tile tile, int xOffset, int yOffset) {

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
                finalPosition.X = newRectangle.X;
                finalPosition.Y = newRectangle.Y + deathSprite.Height;
                rollingSoundInstance.Stop();
                explosionInstance.Play();
            }
            if (hasCollision && tile.IsFinishFlag)
            {
                hasFinished = true;
                finalPosition.X = newRectangle.X;
                finalPosition.Y = newRectangle.Y;
                rollingSoundInstance.Stop();
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

        private float GetVelocity(GameTime gameTime) {
            return 160 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    }
}
