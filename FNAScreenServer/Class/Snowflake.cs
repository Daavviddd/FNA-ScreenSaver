using System;
using Microsoft.Xna.Framework;

namespace FNAScreenSaver.Class
{
    /// <summary>
    /// Класс снежинки
    /// </summary>
    public class Snowflake
    {
        /// <summary>
        /// Позиция снежинки
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Скорость снежинки
        /// </summary>
        public float Speed;

        /// <summary>
        /// Размер снежинки
        /// </summary>
        public float Scale;

        private Random _random;

        /// <summary>
        /// Снежинка со случайными параметрами
        /// </summary>
        public Snowflake(Random random, int screenWidth)
        {
            _random = random;
            Position = new Vector2(
                _random.Next(0, screenWidth),
                _random.Next(-500, -50)
            );
            Speed = 1 + (float)_random.NextDouble() * 4;
            Scale = 0.01f + (float)_random.NextDouble() * 0.04f;
        }

        /// <summary>
        /// Обновление состояния
        /// </summary>
        public void Update(int screenWidth, int screenHeight)
        {
            Position.Y += Speed;

            if (Position.Y > screenHeight)
            {
                Position.Y = _random.Next(-500, -50);
                Position.X = _random.Next(0, screenWidth);
            }
        }
    }
}
