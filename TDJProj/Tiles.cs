using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TDJProj
{
    public class Tiles
    {
        public Tiles()
        {
        }

        protected Texture2D texture;

        protected bool isEnemy;
        public bool IsEnemy
        {
            get { return isEnemy; }
        }

        private Rectangle rectangle;
        public Rectangle Rectangle {
            get { return rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    public class CollisionTiles : Tiles {
        public CollisionTiles(int i, Rectangle newRectangle) {
            string name = "tile" + i;
            texture = Content.Load<Texture2D>(name);

            if (name.Equals("tile4")) {
                this.isEnemy = true;
            }
      
            this.Rectangle = newRectangle;
        }
    }
}
