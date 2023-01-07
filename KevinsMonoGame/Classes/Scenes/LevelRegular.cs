using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace KevinsMonoGame
{
    internal class LevelRegular : Level
    {
        public LevelRegular(Terrain terrain, Player player, Vector2 startPos, Vector2 endPos, Texture2D backgroundTexture, Song song) : base(terrain, player, startPos, endPos, backgroundTexture, song)
        {
            this.EndPos = endPos;
        }
        public override void Update(GameTime gameTime)
        {
            CompleteLevel();
            Background.Update(gameTime);
            Terrain.Update(gameTime);
            Player.Update(gameTime);
            Camera.Follow(Player);
        }
    }
}
