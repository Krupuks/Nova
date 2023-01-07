using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace KevinsMonoGame
{
    internal abstract class Scene : IGameObject, ICompletable
    {
        public bool completed { get; set; } = false;
        public Song Song { get; set; }
        public virtual void Update(GameTime gameTime){}
        public virtual void Draw(SpriteBatch spriteBatch){}
        public virtual void AddPositionable(IPositionable positionable, Vector2 pos){}
    }
}

