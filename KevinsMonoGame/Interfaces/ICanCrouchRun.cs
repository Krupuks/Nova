
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal interface ICanCrouchRun: ICanCrouch, ICanRun
    {
        public Texture2D TextureCrouchRun { get; set; }
        public Collider ColliderCrouchRun { get; set; }

    }
}
