using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal interface ICanCrouch: ICanDie
    {
        public bool IsCrouching { get; set; }
        public Texture2D TextureCrouch { get; set; }
        public Collider ColliderCrouch { get; set; }
    }
}
