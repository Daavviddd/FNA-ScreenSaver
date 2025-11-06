using System;
using System.Collections.Generic;
using FNAScreenServer.Class;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FNAScreenServer
{
    /// <summary>
    /// Основной класс
    /// </summary>
    public class Village : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _villageBackground;
        private Texture2D _snowflakeTexture;

        private List<Snowflake> _snowflakes;
        private const int snowflakeCount = 1000;
        private Random random = new Random();

        /// <summary>
        /// Основные настройки
        /// </summary>
        public Village()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            _snowflakes = new List<Snowflake>();

            for(var i = 0; i < snowflakeCount; i++)
            {
                _snowflakes.Add(new Snowflake(random, _graphics.PreferredBackBufferWidth));
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _villageBackground = Content.Load<Texture2D>("Shrek");
            _snowflakeTexture = Content.Load<Texture2D>("Snowflake");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().GetPressedKeys().Length > 0 ||
               Mouse.GetState().LeftButton == ButtonState.Pressed ||
               Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                Exit();
            }

            foreach (var snowflake in _snowflakes)
            {
                snowflake.Update(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_villageBackground,
                new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight),
                Color.White);

            foreach(var snowflakes in _snowflakes)
            {
                _spriteBatch.Draw(_snowflakeTexture, snowflakes.Position, null, Color.White, 0f, Vector2.Zero,
                    snowflakes.Scale, SpriteEffects.None, 0f);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
