using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal interface ICanAttack : ICanDie
    {
        public bool IsAttacking { get; set; }
        public Texture2D TextureAttack { get; set; }
        public Collider ColliderAttack { get; set; }
        public Collider ColliderWeapon { get; set; }
    }
}
