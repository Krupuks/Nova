using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class Enemy : Creature
    {
        public IScriptReader ScriptReader { get; set; } = new ScriptReader();
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
                ScriptReader.ReadScript(this, gameTime, "PACE");
                //move to correct location based on script
                Movement.Move(this, gameTime);
                //select the correct animation based on script
                AnimationManager.Update(this, gameTime);
                //Manage damage and update hp
                HealthManager.ReceiveDamage(this, 5);
                HealthBar.Update(this);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
            {
                //draw selected animation
                AnimationManager.Draw(this, spriteBatch);
                HealthBar.Draw(this, spriteBatch);
            }

        }
    }
}