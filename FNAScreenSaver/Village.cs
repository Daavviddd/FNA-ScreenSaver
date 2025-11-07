using System;
using System.Collections.Generic;
using FNAScreenSaver.Class;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FNAScreenSaver
{
    /// <summary>
    /// Основной класс
    /// </summary>
    public class Village : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D villageBackground;
        private Texture2D snowflakeTexture;

        private List<Snowflake> snowflakes;
        private const int snowflakeCount = 1000;
        private Random random = new Random();

        /// <summary>
        /// Основные настройки
        /// </summary>
        public Village()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            snowflakes = new List<Snowflake>();

            for(var i = 0; i < snowflakeCount; i++)
            {
                snowflakes.Add(new Snowflake(random, graphics.PreferredBackBufferWidth));
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            villageBackground = Content.Load<Texture2D>("Shrek");
            snowflakeTexture = Content.Load<Texture2D>("Snowflake");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0 ||
               Mouse.GetState().LeftButton == ButtonState.Pressed ||
               Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                Exit();
            }

            foreach (var snowflake in snowflakes)
            {
                snowflake.Update(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(villageBackground,
                new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                Color.White);

            foreach(var snowflakes in snowflakes)
            {
                spriteBatch.Draw(snowflakeTexture, snowflakes.Position, null, Color.White, 0f, Vector2.Zero,
                    snowflakes.Scale, SpriteEffects.None, 0f);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
