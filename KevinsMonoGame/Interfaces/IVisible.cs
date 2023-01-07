using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal interface IVisible : IPositionable
    {
        public Texture2D TextureIdle { get; set; }
        public int SpriteDirection { get; set; }
        public float Scale { get; set; }
    }
}
