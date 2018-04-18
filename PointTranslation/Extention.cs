using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PointTranslation
{
    public static class Extention
    {
        #region Vector2 extention functions
        /// <summary>
        /// An angle, θ, measured in radians, such that -π≤θ≤π, and tan(θ) = y / x, where(x, y) is a point in the Cartesian plane.Observe the following:
        /// For(x, y) in quadrant 1,    0 < θ < π/2
        /// For(x, y) in quadrant 2,  π/2 < θ ≤ π.
        /// For(x, y) in quadrant 3,   -π < θ < -π/2. 
        /// For(x, y) in quadrant 4, -π/2 < θ < 0. 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>double</returns>
        public static double ToAngleRad(this Vector2 vector)
        {
            // Return 
            return Math.Atan2(vector.Y, vector.X);
        }

        public static double ToAngleDeg(this Vector2 vector)
        {
            // degree = radians × 180° / π
            return ToAngleRad(vector) * (180 / Math.PI);
        }

        public static Vector2 FromPolar(float angle, float magnitude)
        {
            return magnitude * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }
        #endregion

        #region SpriteBatch extention functions
        public static void DrawPixel(this SpriteBatch spriteBatch, float x, float y, Color color, float thickness = 1f)
        {
            spriteBatch.DrawPixel(new Vector2(x, y), color, thickness);
        }

        public static void DrawPixel(this SpriteBatch spriteBatch, Vector2 point, Color color, float thickness = 1f)
        {
            float rotation = 0f;
            Vector2 origin = new Vector2(0.5f, 0.5f);   // Center of the rotation, (0,0) by default.
            Vector2 scale = new Vector2(thickness);     // A scaling of this sprite
            spriteBatch.Draw(Art.Pixel, point, null, color, rotation, origin, scale, SpriteEffects.None, 0);
        }
        #endregion

        //public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        //{
        //    var distance = Vector2.Distance(point1, point2);
        //    var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
        //    DrawLine(spriteBatch, point1, distance, angle, color, thickness);
        //}

        //public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1f)
        //{
        //    var origin = new Vector2(0f, 0.5f);
        //    var scale = new Vector2(length, thickness);
        //    spriteBatch.Draw(Art.Pixel, point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        //}
    }
}
