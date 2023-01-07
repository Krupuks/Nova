using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal interface ICanJump : ICanDie
    {
        public bool IsJumping { get; set; }
        public Texture2D TextureJump { get; set; }
        public Collider ColliderJump { get; set; }
    }
}
