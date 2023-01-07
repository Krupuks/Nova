using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal abstract class Entity : IVisible
    {
        public Texture2D TextureIdle { get; set; }
        public int SpriteDirection { get; set; } = 1;
        public float Scale { get; set; } = General.Scale;
        public Vector2 Position { get; set; } = Vector2.Zero;
        public virtual void Draw(SpriteBatch spriteBatch) { }
        public virtual void Update(GameTime gameTime) { }
        
    }
}
