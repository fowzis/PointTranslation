using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using C3.XNA;

namespace PointTranslation
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Vector2 origin, point;
        double angleDegree = 0;
        double angleRadians;
        double tan;
        float radius = 100;

        Vector2 aim = Vector2.Normalize(new Vector2(30, 30));
        Vector2 orig = new Vector2(100, 100);
        Vector2 end;
        float radius1 = 50;
        double angleRad;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            origin = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            angleRad = aim.ToAngleRad();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Art.Load(GraphicsDevice, Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            #region Point moving in a circular path
            if (angleDegree > 360)
                angleDegree = 0;
            else
                angleDegree += 0.5;

            angleRadians = angleDegree * (Math.PI / 180);   // in radians
            tan = Math.Tan(angleRadians);  // Tan(theta) = Sin(theta)/Cos(therta) = Y/X;

            point.X = origin.X + (float)(Math.Cos(angleRadians) * radius1);
            point.Y = origin.Y + (float)(Math.Sin(angleRadians) * radius1);
            #endregion


            angleRad += 0.01f;
            end = orig + Extention.FromPolar((float)angleRad, radius1);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            #region A Point rotating in circular path
            spriteBatch.DrawPixel(origin, Color.Red, 4);
            spriteBatch.DrawLine(
                origin,
                point,
                Color.Blue);
            spriteBatch.DrawPixel(point, Color.Wheat, 4);
            spriteBatch.DrawCircle(origin, radius, 50, Color.Gray);
            //this.Window.Title = "angle=(" + angleDegree + "), radians=(" + angleRadians + "), result=(" + tan + ")";
            #endregion

            #region Three points rotating in circular path
            spriteBatch.DrawLine(orig, end, Color.Gray);
            spriteBatch.DrawPixel(orig, Color.Yellow, 4);
            spriteBatch.DrawPixel(end, Color.Yellow, 4);
            spriteBatch.DrawCircle(orig, (end - orig).Length(), 50, Color.Blue);

            // Find the two vectors parallel to the Ray emmitting from the circle center in a given direction
            double angleRad1 = angleRad + (Math.PI / 2);
            double angleRad2 = angleRad - (Math.PI / 2);
            Vector2 P1 = new Vector2(orig.X + (float)(Math.Cos(angleRad1) * radius1), orig.Y + (float)(Math.Sin(angleRad1) * radius1));
            Vector2 P2 = new Vector2(orig.X + (float)(Math.Cos(angleRad2) * radius1), orig.Y + (float)(Math.Sin(angleRad2) * radius1));

            spriteBatch.DrawPixel(P1, Color.AliceBlue, 4);
            spriteBatch.DrawLine(P1, P1+Extention.FromPolar((float)angleRad, radius1), Color.LightBlue);

            spriteBatch.DrawPixel(P2, Color.Bisque, 4);
            spriteBatch.DrawLine(P2, P2+ Extention.FromPolar((float)angleRad, radius1), Color.LightBlue);

            this.Window.Title = "aim=(" + aim + "), radians=(" + angleRad + "), result =(" + tan + ")";
            #endregion

            #region C3.XNA
            //spriteBatch.DrawRectangle(new Rectangle(100, 100, 100, 200), Color.Purple, 20);

            //spriteBatch.DrawRectangle(new Rectangle(10, 10, 100, 200), Color.Yellow, 2);
            //spriteBatch.DrawRectangle(new Rectangle(20, 20, 100, 200), Color.Yellow, 1);
            //spriteBatch.DrawRectangle(new Vector2(30, 30), new Vector2(100, 200), Color.Yellow);
            //spriteBatch.DrawRectangle(new Vector2(40, 40), new Vector2(100, 200), Color.Yellow, 5);

            //spriteBatch.DrawCircle(400, 100, 90, 3, Color.White * 0.2f);
            //spriteBatch.DrawCircle(400, 100, 90, 4, Color.White * 0.3f);
            //spriteBatch.DrawCircle(400, 100, 90, 5, Color.White * 0.4f);
            //spriteBatch.DrawCircle(400, 100, 90, 6, Color.White * 0.5f);
            //spriteBatch.DrawCircle(400, 100, 90, 7, Color.White * 0.6f);
            //spriteBatch.DrawCircle(400, 100, 90, 8, Color.White * 0.7f);
            //spriteBatch.DrawCircle(400, 100, 90, 9, Color.White * 0.8f);
            //spriteBatch.DrawCircle(400, 100, 90, 10, Color.White * 0.9f);
            //spriteBatch.DrawCircle(400, 100, 90, 20, Color.Red);

            //spriteBatch.DrawCircle(600, 100, 100, 100, Color.Green, 10);
            //spriteBatch.DrawCircle(new Vector2(600, 100), 40, 30, Color.Green, 30);

            //spriteBatch.FillRectangle(350, 340, 100, 100, Color.Red * 0.4f);
            //spriteBatch.FillRectangle(new Rectangle(350, 340, 100, 100), Color.Red * 0.3f, (float)Math.PI / 4f);
            //spriteBatch.FillRectangle(new Vector2(350, 340), new Vector2(100, 100), Color.Red * 0.2f, (float)Math.PI / 3f);
            //spriteBatch.FillRectangle(350, 340, 100, 100, Color.Red * 0.5f, (float)Math.PI);

            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(180), Color.Navy, 1);
            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(160), Color.Navy * 0.9f, 2);
            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(140), Color.Navy * 0.8f, 4);
            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(120), Color.Navy * 0.7f, 6);
            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(90), Color.Navy * 0.6f, 8);
            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(80), Color.Navy * 0.5f, 10);
            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(65), Color.Navy * 0.4f, 12);
            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(45), Color.Navy * 0.3f, 14);
            //spriteBatch.DrawArc(new Vector2(600, 350), 100, 180, MathHelper.ToRadians(180), MathHelper.ToRadians(12), Color.Navy * 0.2f, 16);

            //spriteBatch.DrawArc(new Vector2(600, 400), 80, 90, MathHelper.ToRadians(90), MathHelper.ToRadians(220), Color.Navy, 10);
            #endregion

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
