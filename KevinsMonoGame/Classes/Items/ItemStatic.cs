using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal class ItemStatic : Entity
    {
        public ItemStatic(Texture2D texture_idle)
        {
            TextureIdle = texture_idle;
        }
        public ItemStatic(Texture2D texture_idle, int scale)
        {
            Scale = scale;
            TextureIdle = texture_idle;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureIdle, new Vector2(Position.X - General.ScreenWidth / 2, Position.Y - General.ScreenHeight / 2), null, Color.White, 0f, Vector2.Zero, Scale * Vector2.One, new SpriteEffects(), 0f);
        }
        public override void Update(GameTime gameTime) { }

    }
}
