using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class Player : Creature, IControllable
    {
        public IDeviceReader InputReader { get; set; }
        //constructor
        public Player(IDeviceReader inputReader)
        {
            TextureIdle = General.PlayerTexture_idle;
            TextureCrouch = General.PlayerTexture_idle_sneaky;
            TextureRun = General.PlayerTexture_run;
            TextureCrouchRun = General.PlayerTexture_run_sneaky;
            TextureAttack = General.PlayerTexture_attack;
            TextureJump = General.PlayerTexture_jump;

            AnimationJump.GetFramesFromTextureProperties(TextureJump.Width, TextureJump.Height, 1, 1);
            AnimationIdle.GetFramesFromTextureProperties(TextureIdle.Width, TextureIdle.Height, 5, 8);
            AnimationCrouch.GetFramesFromTextureProperties(TextureCrouch.Width, TextureCrouch.Height, 5, 8);
            AnimationRun.GetFramesFromTextureProperties(TextureRun.Width, TextureRun.Height, 4, 2);
            AnimationCrouchRun.GetFramesFromTextureProperties(TextureCrouchRun.Width, TextureCrouchRun.Height, 3, 3); ;
            AnimationAttack.GetFramesFromTextureProperties(TextureAttack.Width, TextureAttack.Height, 2, 3);
            AnimationJump.GetFramesFromTextureProperties(TextureJump.Width, TextureJump.Height, 1, 1);

            GroundCheck.Add(new Rectangle((int)(-2 * Scale), (int)(76 * Scale), (int)(4 * Scale), (int)(5 * Scale)), false);
            GroundCheck.Activate(this);
            ColliderIdle.Add(new Rectangle((int)(-9 * Scale), (int)(13 * Scale), (int)(18 * Scale), (int)(68 * Scale)), false);
            ColliderAttack.Add(new Rectangle((int)(-9 * Scale), (int)(48 * Scale), (int)(18 * Scale), (int)(32 * Scale)), false);
            ColliderCrouch.Add(new Rectangle((int)(-9 * Scale), (int)(48 * Scale), (int)(18 * Scale), (int)(32 * Scale)), false);
            ColliderJump.Add(new Rectangle((int)(-9 * Scale), (int)(30 * Scale), (int)(18 * Scale), (int)(32 * Scale)), false);

            ColliderWeapon.Add(new Rectangle((int)(-65 * Scale), (int)(27 * Scale), (int)(130 * Scale), (int)(50 * Scale)), true);
            Gravity.Add(this);
            InputReader = inputReader;
            CurrentHealth = MaxHealth;
            HealthBar = new HealthBarNormal();
        }

        public override void Update(GameTime gameTime)
        {
            //select the correct animation based on state
            AnimationManager.Update(this, gameTime);
            //select correct collider based on state
            ColliderManager.Update(this);
            //find other colliders
            CollisionDetector.DetectGround(this);
            CollisionDetector.MoveSolid(this);
            //Manage damage and update hp
            HealthManager.ReceiveDamage(this, 5);
            HealthBar.Update(this);
            //read input for movementmanager
            InputReader.ReadInput(this);
            //move to correct location based on state
            Movement.Move(this,gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //draw  animation based on state
            AnimationManager.Draw(this,spriteBatch);
            HealthBar.Draw(this,spriteBatch);

        }
    }
}