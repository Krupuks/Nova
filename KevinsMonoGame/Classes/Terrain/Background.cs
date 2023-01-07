using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace KevinsMonoGame
{
    internal class Background : Entity
    {
        public List<List<Texture2D>> Textures { get; set; } = new List<List<Texture2D>>();
        public List<List<Vector2>> Positions { get; set; } = new List<List<Vector2>>();
        public List<float> Speeds { get; set; } = new List<float>();

        public IPositionable Positionable { get; set;}

        public Background(IPositionable positionable)
        {
            Positionable = positionable;
        }
        public void Add(Texture2D texture, float speed)
        {
            Textures.Add(new List<Texture2D>());
            Positions.Add(new List<Vector2>());
            Speeds.Add(speed);
            for (int i = 0; i < 4; i++)
            {
                Textures[0].Add(texture);
                Positions[0].Add(Vector2.Zero);
            }
        }
        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < Textures.Count; i++)
            {
                for (int j = 0; j < Textures[i].Count; j++)
                {
                    Positions[i][j] = new Vector2((j-1) * Textures[i][j].Width * Scale - Speeds[i] * Camera.Position.M41, General.ScreenHeight - Textures[i][j].Height * Scale / 2 - Speeds[i] * Camera.Position.M42);
                }
            }


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Textures.Count; i++)
            {
                for (int j = 0; j < Textures[i].Count; j++)
                {
                    spriteBatch.Draw(Textures[i][j], Positions[i][j], null, Color.White, 0f, Vector2.Zero, Scale * Vector2.One, new SpriteEffects(), 0f);
                }
            }

        }
    }
}
