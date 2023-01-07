using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle sourceRectangle)
        {
            SourceRectangle = sourceRectangle;
        }
    }
}
