using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal abstract class HealthBar : Entity
    {
        public Rectangle FullHealthBar { get; set; }
        public Rectangle CurrentHealthBar { get; set; } = new Rectangle();
        public virtual void Update(Creature creature) { }
        public virtual void Draw(Creature creature, SpriteBatch spriteBatch) { }
    }
}