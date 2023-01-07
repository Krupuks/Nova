using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class HealthBarBoss : HealthBar
    {
        private int offset = 20;
        private int height = 50;
        public override void Update(Creature creature)
        {
            FullHealthBar = new Rectangle((int)(offset - Camera.Position.M41 - General.ScreenWidth / 2), (int)(offset - Camera.Position.M42 - General.ScreenHeight / 2), General.ScreenWidth - offset * 2, height);
            CurrentHealthBar = new Rectangle((int)(offset - Camera.Position.M41 - General.ScreenWidth / 2), (int)(offset - Camera.Position.M42 - General.ScreenHeight / 2), (int)(creature.CurrentHealth / creature.MaxHealth * General.ScreenWidth - offset * 2), height);
            creature.DeathManager.Die(creature);
        }
        public override void Draw(Creature creature, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(General.Texture, new Vector2(FullHealthBar.X, FullHealthBar.Y), FullHealthBar, Color.Black);
            spriteBatch.Draw(General.Texture, new Vector2(CurrentHealthBar.X, CurrentHealthBar.Y), CurrentHealthBar, Color.Crimson);
        }
    }
}
