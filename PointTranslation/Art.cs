using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointTranslation
{
    static class Art
    {
        public static Texture2D Pixel { get; private set; }

        public static void Load(GraphicsDevice graphicsDevice, ContentManager content)
        {
            Pixel = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            Pixel.SetData<Color>(new[] { Color.White });
            //Pixel.SetData(new[] { Color.White });
        }
    }
}
