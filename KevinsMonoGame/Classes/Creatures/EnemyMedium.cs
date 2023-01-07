using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class EnemyMedium : Enemy
    {
        public EnemyMedium()
        {
            TextureIdle = General.LevirockTexture_idle;
            TextureCrouch = General.LevirockTexture_idle;
            TextureRun = General.LevirockTexture_idle;
            TextureCrouchRun = General.LevirockTexture_idle;
            TextureAttack = General.LevirockTexture_idle;

            AnimationIdle.GetFramesFromTextureProperties(TextureIdle.Width, TextureIdle.Height, 5, 8);
            AnimationCrouch.GetFramesFromTextureProperties(TextureCrouch.Width, TextureCrouch.Height, 5, 8);
            AnimationRun.GetFramesFromTextureProperties(TextureRun.Width, TextureRun.Height, 5, 8);
            AnimationCrouchRun.GetFramesFromTextureProperties(TextureCrouchRun.Width, TextureCrouchRun.Height, 5, 8); ;
            AnimationAttack.GetFramesFromTextureProperties(TextureAttack.Width, TextureAttack.Height, 5, 8);

            GroundCheck.Add(new Rectangle((int)(-2 * Scale), (int)(76 * Scale), (int)(2 * Scale), (int)(5 * Scale)), false);
            ColliderIdle.Add(new Rectangle((int)(-17 * Scale), (int)(13 * Scale), (int)(34 * Scale), (int)(68 * Scale)), true);
            Speed = new Vector2(6, 0);
            Mass = 10f;

            MaxHealth = 300;
            CurrentHealth = MaxHealth;
            HealthBar = new HealthBarNormal();
        }


    }
}
