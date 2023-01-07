using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal interface ICanRun : ICanDie
    {
        public bool IsIdle { get; set; }
        public Texture2D TextureRun { get; set; }
        public Collider ColliderRun { get; set; }
    }
}
