using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace KevinsMonoGame
{

    internal class Menu : Scene
    {
        public Texture2D Texture_idle { get; set; }
        public List<IPositionable> positionables { get; set; } = new List<IPositionable>();
        public Menu(Texture2D texture_idle, Song song)
        {
            Song = song;
            Texture_idle = texture_idle;
        }
        public override void AddPositionable(IPositionable positionable, Vector2 pos)
        {
            positionables.Add(positionable);
            positionable.Position = pos;
        }
        public override void Update(GameTime gameTime)
        {
            if (Camera.Position != Matrix.CreateTranslation(0, 0, 0))
                Camera.Reset();
            for (int i = 0; i < positionables.Count; i++)
            {
                positionables[i].Update(gameTime);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture_idle, new Vector2(-General.ScreenWidth / 2, -General.ScreenHeight / 2), null, Color.White, 0f, Vector2.Zero, Vector2.One * General.ScreenWidth / General.MenuWidth, new SpriteEffects(), 0f);

            for (int i = 0; i < positionables.Count; i++)
            {
                positionables[i].Draw(spriteBatch);
            }
        }
    }
}

