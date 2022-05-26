using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TDJProj
{
    public class Tile {

        protected bool isEnemy;
        private bool isFinishFlag;
        protected Texture2D texture;
        private Rectangle rectangle;
        private static ContentManager content;

        public Tile(int i, Rectangle newRectangle)
        {
            string name = "tile" + i;
            texture = Content.Load<Texture2D>(name);

            if (name.Equals("tile4"))
            {
                this.isEnemy = true;
            } else if (name.Equals("tile5")) {
                this.isFinishFlag = true;
            }

            this.Rectangle = newRectangle;
        }
        
        public bool IsEnemy
        {
            get { return isEnemy; }
        }

        public bool IsFinishFlag {
            get { return isFinishFlag; }
        }

        
        public Rectangle Rectangle {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        
        public static ContentManager Content {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
