using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDJProj
{
    public class Map
    {
        public Map()
        {
        }

        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        public List<CollisionTiles> CollisionTiles {
            get { return collisionTiles; }
        }

        private int width, height;

        public int Width {
            get { return width; }
        }

        public int Height {
            get { return height; }
        }

        public void Generate(int[,] map, int _width, int _height) {
            for (int x = 0; x < map.GetLength(1); x++) {
                for (int y = 0; y < map.GetLength(0); y++) {
                    int number = map[y, x];

                    if (number > 0) {
                        collisionTiles.Add(new CollisionTiles(number,
                            new Rectangle(x * _width, y * _height, _width, _height)));
                    }

                    //width = (x + 1) * _width;
                    //height = (y + 1) * _height;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (CollisionTiles tile in collisionTiles)
                tile.Draw(spriteBatch);
        }
    }
}
