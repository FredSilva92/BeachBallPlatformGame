using System;
using Microsoft.Xna.Framework;

namespace TDJProj
{
    public static class TileHelper
    {

        public static bool TouchTopOf(this Rectangle r1, Rectangle r2) {
            return (r1.Top >= r2.Bottom - 2 &&
                r1.Top <= r2.Bottom + 2 &&
                r1.Left + 5 <= r2.Right &&
                r1.Right - 5 >= r2.Left);
        }

        public static bool TouchBottomOf(this Rectangle r1, Rectangle r2) {

            return (r1.Bottom >= r2.Top - 2 &&
                r1.Bottom <= r2.Top + 2 &&
                r1.Left + 5 <= r2.Right &&
                r1.Right - 5 >= r2.Left);
        }

        public static bool TouchLeftOf(this Rectangle r1, Rectangle r2) {
            int middleHeight = r1.Top + r1.Height / 2;

            return (r1.Right >= r2.Left &&
                r1.Right <= r2.Right &&
                middleHeight > r2.Top &&
                middleHeight < r2.Bottom);
        }

        public static bool TouchRightOf(this Rectangle r1, Rectangle r2) {
            int middleHeight = r1.Top + r1.Height / 2;

            return (r1.Left >= r2.Left &&
                r1.Left <= r2.Right &&
                middleHeight > r2.Top &&
                middleHeight < r2.Bottom);
        }
    }
}
