using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TDJProj
{
    public class ScreenMessage
    {
        private Texture2D congratulations;
        private Texture2D gameOver;
        private Vector2 congratzPosition;
        private Vector2 gameOverPosition;

        public ScreenMessage()
        {
        }

        public void LoadContent(ContentManager content, int xCenter, int yCenter) {
            congratulations = content.Load<Texture2D>("Congratulations");
            gameOver = content.Load<Texture2D>("GameOver");
        }

        public void Draw(SpriteBatch spriteBatch, int index, int xCenter, int yCenter) {
            Vector2 position;

            switch (index) {
                case 0:
                    position = new Vector2(xCenter - gameOver.Width / 2,
                yCenter - gameOver.Height / 2);

                    spriteBatch.Draw(gameOver, position, Color.White);
                    break;

                case 1:
                    position = new Vector2(xCenter - congratulations.Width / 2,
                yCenter - congratulations.Height / 2);

                    spriteBatch.Draw(congratulations, position, Color.White);
                    break;
            }
        }


    }
}
