using Microsoft.Xna.Framework;
using System;

namespace KevinsMonoGame
{

    internal class Movement
    {
        private double ticks;

        public void Move(Creature gameobject, GameTime gameTime)
        {
            Vector2 velocity = Vector2.Zero;
            //don't move if input not correct
            if (gameobject is Player)
            {
                Player player = gameobject as Player;
                if (player.InputReader != null)
                {
                    if (player.InputReader.IsDestinationalInput)
                        player.Direction -= player.Position;
                }
            }

            ticks += gameTime.ElapsedGameTime.TotalSeconds;
            if (!gameobject.IsFalling)
                ticks = 0;

            //add speed
            velocity += gameobject.Direction * gameobject.Speed;

            //add acceleration
            velocity += gameobject.Mass * new Vector2((float)(gameobject.Acceleration.X * Math.Pow(ticks, 2d)), (float)(gameobject.Acceleration.Y * Math.Pow(ticks, 2d)));
            gameobject.Position += velocity;
        }
    }
}