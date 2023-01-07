using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace KevinsMonoGame
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames = new List<AnimationFrame>();
        private int counter;
        private double secondCounter = 0;

        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }
        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    AddFrame(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }
        public bool Done()
        {
            if (counter >= frames.Count - 1)
            {
                counter = 0;
                return true;
            }
            return false;
        }
        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 10;
            
            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
                counter = 0;
        }
    }
}
