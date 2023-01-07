
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class VoidBlock : Entity
    {
        public int Size { get; set; } = General.BlockSize;
        public int Row { get; set; }
        public int Column { get; set; }

        public VoidBlock(Rectangle rectangle, int column, int row)
        {
            TextureIdle = General.TerrainTexture;
            Row = row;
            Column = column;
            Position = new Vector2(rectangle.X, rectangle.Y);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureIdle, Position, new Rectangle(Row * Size, Column * Size, Size, Size), Color.White, 0f, Vector2.Zero, new Vector2(SpriteDirection * Scale, Scale), new SpriteEffects(), 0f);
        }
    }
}