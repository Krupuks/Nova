using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal interface IMovable : IPositionable
    {
        public Movement Movement { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Acceleration { get; set; }
    }
}