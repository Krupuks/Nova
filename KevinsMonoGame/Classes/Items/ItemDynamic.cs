using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace KevinsMonoGame
{
    internal class ItemDynamic : Entity, IAnimatable
    {
        public Animation AnimationIdle { get; set; } = new Animation();
        public AnimationManager AnimationManager { get; set; } = new AnimationManager();

        public ItemDynamic(Texture2D texture_idle, int NumberOfWidthSprites, int NumberOfHeightSprites) : this(texture_idle, 3, NumberOfWidthSprites, NumberOfHeightSprites) { }
        public ItemDynamic(Texture2D texture_idle, float scale, int NumberOfWidthSprites, int NumberOfHeightSprites)
        {
            Scale = scale;
            TextureIdle = texture_idle;
            AnimationIdle.GetFramesFromTextureProperties(texture_idle.Width, texture_idle.Height, NumberOfWidthSprites, NumberOfHeightSprites);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            AnimationManager.Draw(this, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            AnimationManager.Update(this, gameTime);
        }
    }
}
