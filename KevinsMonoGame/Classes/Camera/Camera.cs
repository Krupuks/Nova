using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal static class Camera
    {
        public static Matrix Transform { get; private set; }
        public static Rectangle Fullzone { get; private set; }
        private static Rectangle deadzone;

        public static Matrix Position { get; private set; } = Matrix.Identity;
        private static Matrix offset = Matrix.Identity;

        internal static void Initialize(IPositionable gameobject, int width, int height)
        {
            deadzone = new Rectangle((int)gameobject.Position.X - width / 2, (int)gameobject.Position.Y - height / 2, width, height);
            Fullzone = new Rectangle(deadzone.X - General.ScreenWidth / 2 + deadzone.Width / 2, deadzone.Y - General.ScreenHeight / 2 + deadzone.Height / 2, General.ScreenWidth, General.ScreenHeight);
            Position = Matrix.CreateTranslation(-gameobject.Position.X, -gameobject.Position.Y, 0);
            offset = Matrix.CreateTranslation(General.ScreenWidth / 2, General.ScreenHeight / 2, 0);
            Transform = Position * offset;
        }
        internal static void Reset()
        {
            Position = Matrix.CreateTranslation(0, 0, 0);
            Transform = Position * offset;
        }
        internal static void Follow(IPositionable positionable)
        {   
            //left of deadzone
            if (positionable.Position.X < deadzone.X)
            {
                deadzone.X = (int)positionable.Position.X;
                Fullzone = new Rectangle(deadzone.X - General.ScreenWidth/2 + deadzone.Width/2, Fullzone.Y, Fullzone.Width, Fullzone.Height) ;
                Position = Matrix.CreateTranslation(-positionable.Position.X - deadzone.Width / 2, -(deadzone.Y + deadzone.Height / 2), 0);
            }
            //right of deadzone
            else if (positionable.Position.X > deadzone.X + deadzone.Width)
            {
                deadzone.X = (int)positionable.Position.X - deadzone.Width;
                Fullzone = new Rectangle(deadzone.X - General.ScreenWidth/2 + deadzone.Width/2, Fullzone.Y, Fullzone.Width, Fullzone.Height);
                Position = Matrix.CreateTranslation(-positionable.Position.X + deadzone.Width / 2, -(deadzone.Y + deadzone.Height / 2), 0);
            }
            //above deadzone
            if (positionable.Position.Y < deadzone.Y)
            {
                deadzone.Y = (int)positionable.Position.Y;
                Fullzone = new Rectangle(Fullzone.X, deadzone.Y - General.ScreenHeight/2 + deadzone.Height/2, Fullzone.Width, Fullzone.Height);
                Position = Matrix.CreateTranslation(-(deadzone.X + deadzone.Width / 2), -positionable.Position.Y - deadzone.Height / 2, 0);
            }
            //under deadzone
            else if (positionable.Position.Y > deadzone.Y + deadzone.Height)
            {
                deadzone.Y = (int)positionable.Position.Y - deadzone.Height;
                Fullzone = new Rectangle(Fullzone.X, deadzone.Y - General.ScreenHeight/2 + deadzone.Height/2, Fullzone.Width, Fullzone.Height);
                Position = Matrix.CreateTranslation(-(deadzone.X + deadzone.Width / 2), -positionable.Position.Y + deadzone.Height / 2, 0);
            }
            offset = Matrix.CreateTranslation(General.ScreenWidth / 2, General.ScreenHeight / 2, 0);
            Transform = Position * offset;
        }

        internal static void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(General.Texture, deadzone, Color.White * 0.1f);
            spritebatch.Draw(General.Texture, Fullzone, Color.White * 0.1f);
        }
    }
}