using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FNAScreenServer
{
    public class Village : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _villageBackground;
        private Texture2D _snowflakeTexture;

        private struct Snowflake
        {
            public Vector2 Position;
            public float Speed;
            public float Scale;
        }

        private List<Snowflake> _snowflakes;
        private const int snowflakeCount = 1000;
        private Random random = new Random();

        public Village()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            _snowflakes = new List<Snowflake>();

            for(var i = 0; i < snowflakeCount; i++)
            {
                _snowflakes.Add(new Snowflake 
                { 
                    Position = new Vector2(
                        random.Next(0,_graphics.PreferredBackBufferWidth),
                        random.Next(-500,-50)
                        ),
                Speed = 1 + (float)random.NextDouble() * 4,
                Scale = 0.01f + (float)random.NextDouble() * 0.04f
                });
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
            for (var i = 0; i < snowflakeCount; i++)
            {
                var snowflake = _snowflakes[i];

                snowflake.Position.Y += snowflake.Speed;

                if (snowflake.Position.Y > _graphics.PreferredBackBufferHeight)
                {
                    snowflake.Position.Y = random.Next(-500, -50);
                    snowflake.Position.X = random.Next(0, _graphics.PreferredBackBufferWidth);
                }

                _snowflakes[i] = snowflake;
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
