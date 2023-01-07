using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class EnemySmall : Enemy
    {
        public EnemySmall()
        {
            TextureIdle = General.PebbleTexture_idle;
            TextureCrouch = General.PebbleTexture_idle;
            TextureRun = General.PebbleTexture_idle;
            TextureCrouchRun = General.PebbleTexture_idle;
            TextureAttack = General.PebbleTexture_idle;

            AnimationIdle.GetFramesFromTextureProperties(TextureIdle.Width, TextureIdle.Height, 5, 4);
            AnimationCrouch.GetFramesFromTextureProperties(TextureCrouch.Width, TextureCrouch.Height, 5, 4);
            AnimationRun.GetFramesFromTextureProperties(TextureRun.Width, TextureRun.Height, 5, 4);
            AnimationCrouchRun.GetFramesFromTextureProperties(TextureCrouchRun.Width, TextureCrouchRun.Height, 5, 4); ;
            AnimationAttack.GetFramesFromTextureProperties(TextureAttack.Width, TextureAttack.Height, 5, 4);

            Gravity.Add(this);
            GroundCheck.Add(new Rectangle((int)(-2 * Scale), (int)(28 * Scale), (int)(4 * Scale), (int)(5 * Scale)), false);

            ColliderIdle.Add(new Rectangle((int)(-16 * Scale), (int)(10 * Scale), (int)(32 * Scale), (int)(23 * Scale)), true);
            Speed = new Vector2(3, 0);
            Mass = 30f;

            MaxHealth = 200;
            CurrentHealth = MaxHealth;
            HealthBar = new HealthBarNormal();
        }


    }
}
