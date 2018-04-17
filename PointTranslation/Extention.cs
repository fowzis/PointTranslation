using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace PointTranslation
{
    public static class Extention
    {
        public static void DrawPixel(this SpriteBatch spriteBatch, Vector2 point, Color color, float thickness = 1f)
        {

            spriteBatch.Draw(Art.Pixel, point, null, color, 0f, new Vector2(0.5f, 0.5f), new Vector2(thickness), SpriteEffects.None, 0);
        }

        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point1, Vector2 point2, Color color, float thickness = 1f)
        {
            var distance = Vector2.Distance(point1, point2);
            var angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            DrawLine(spriteBatch, point1, distance, angle, color, thickness);
        }

        public static void DrawLine(this SpriteBatch spriteBatch, Vector2 point, float length, float angle, Color color, float thickness = 1f)
        {
            var origin = new Vector2(0f, 0.5f);
            var scale = new Vector2(length, thickness);
            spriteBatch.Draw(Art.Pixel, point, null, color, angle, origin, scale, SpriteEffects.None, 0);
        }
    }
}
