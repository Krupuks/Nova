using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal interface IPositionable : IGameObject
    {
        public Vector2 Position { get; set; }

    }
}

