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
        public Vector2 Position { get; set; }

        /// <summary>
        /// Скорость снежинки
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Размер снежинки
        /// </summary>
        public float Scale { get; set; }

        private Random random;

        /// <summary>
        /// Снежинка со случайными параметрами
        /// </summary>
        public Snowflake(Random random, int screenWidth)
        {
            this.random = random;
            Position = new Vector2(
                this.random.Next(0, screenWidth),
                this.random.Next(-500, -50)
            );
            Speed = 1 + (float)this.random.NextDouble() * 4;
            Scale = 0.01f + (float)this.random.NextDouble() * 0.04f;
        }

        /// <summary>
        /// Обновление состояния
        /// </summary>
        public void Update(int screenWidth, int screenHeight)
        {
            var newPosition = Position;

            newPosition.Y += Speed;

            if (newPosition.Y > screenHeight)
            {
                newPosition.Y = random.Next(-500, -50);
                newPosition.X = random.Next(0, screenWidth);
            }

            Position = newPosition;
        }
    }
}
