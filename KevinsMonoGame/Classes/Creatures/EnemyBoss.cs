using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal class EnemyBoss : Enemy
    {
        public Collider ColliderBossAttack { get; set; } = new Collider();
        public EnemyBoss()
        {
            TextureIdle = General.NovadonTexture_idle;
            TextureCrouch = General.NovadonTexture_idle;
            TextureRun = General.NovadonTexture_run;
            TextureCrouchRun = General.NovadonTexture_idle;
            TextureAttack = General.NovadonTexture_attack;

            AnimationIdle.GetFramesFromTextureProperties(TextureIdle.Width, TextureIdle.Height, 4, 5);
            AnimationCrouch.GetFramesFromTextureProperties(TextureCrouch.Width, TextureCrouch.Height, 4, 5);
            AnimationRun.GetFramesFromTextureProperties(TextureRun.Width, TextureRun.Height, 4, 5);
            AnimationCrouchRun.GetFramesFromTextureProperties(TextureCrouchRun.Width, TextureCrouchRun.Height, 4, 5); ;
            AnimationAttack.GetFramesFromTextureProperties(TextureAttack.Width, TextureAttack.Height, 4, 4);

            GroundCheck.Add(new Rectangle((int)(-2 * Scale), (int)(124 * Scale), (int)(4 * Scale), (int)(5 * Scale)), false);
            ColliderIdle.Add(new Rectangle((int)(-67 * Scale), (int)(10 * Scale), (int)(124 * Scale), (int)(119 * Scale)), true);
            ColliderAttack.Add(new Rectangle((int)(-67 * Scale), (int)(10 * Scale), (int)(124 * Scale), (int)(119 * Scale)), true);
            ColliderBossAttack.Add(new Rectangle((int)(-1000 * Scale), (int)(124 * Scale), (int)(2000 * Scale), (int)(5 * Scale)), true);
            Gravity.Add(this);
            Speed = new Vector2(3f, 0);
            Mass = 50f;

            MaxHealth = 5000;
            CurrentHealth = MaxHealth;
            HealthBar = new HealthBarBoss();
        }
        public override void Update(GameTime gameTime)
        {
            if (IsAlive)
            {
                //select correct collider based on state
                ColliderManager.Update(this);
                //find other colliders
                CollisionDetector.DetectGround(this);
                CollisionDetector.MoveSolid(this);
                //read script for movementmanager
                ScriptReader.ReadScript(this, gameTime, "BOSSMOVEMENT");
                //move to correct location based on script
                Movement.Move(this, gameTime);
                //select the correct animation based on script
                AnimationManager.Update(this, gameTime);

                //Manage damage and update hp
                HealthManager.ReceiveDamage(this, 5);
                HealthBar.Update(this);
            }

        }
    }
}
