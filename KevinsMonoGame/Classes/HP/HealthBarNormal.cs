
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class HealthBarNormal : HealthBar
    {
        private int width = 100;
        private int height = 10;
        public override void Update(Creature creature)
        {
            FullHealthBar = new Rectangle((int)creature.Position.X, (int)creature.Position.Y, width, height);
            CurrentHealthBar = new Rectangle((int)creature.Position.X, (int)creature.Position.Y, (int)(creature.CurrentHealth / creature.MaxHealth * width), height);
            creature.DeathManager.Die(creature);
        }
        public override void Draw(Creature creature, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(General.Texture, new Vector2(creature.Position.X - creature.AnimationIdle.CurrentFrame.SourceRectangle.Width / 2, creature.Position.Y), FullHealthBar, Color.Black);
            spriteBatch.Draw(General.Texture, new Vector2(creature.Position.X - creature.AnimationIdle.CurrentFrame.SourceRectangle.Width / 2, creature.Position.Y), CurrentHealthBar, Color.Crimson);
        }

    }
}
