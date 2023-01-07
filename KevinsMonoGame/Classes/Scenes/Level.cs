using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace KevinsMonoGame
{

    internal abstract class Level : Scene
    {

        public Background Background { get; set; }
        public Terrain Terrain { get; set; }
        public Player Player { get; set; }
        public Vector2 StartPos { get; set; }
        public Vector2 EndPos { get; set; }

        public Level(Terrain terrain, Player player, Vector2 startPos, Vector2 endPos, Texture2D backgroundTexture, Song song)
        {
            Song = song;
            Terrain = terrain;
            Player = player;
            StartPos = startPos;
            EndPos = endPos;
            player.Position = startPos;
            Background = new Background(player);
            Background.Add(backgroundTexture, 0.5f);
        }
        public void CompleteLevel()
        {
            if (Player.Position.X >= EndPos.X && Player.Position.Y >= EndPos.Y)
                completed = true;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            Background.Draw(spriteBatch);
            Terrain.Draw(spriteBatch);
            Player.Draw(spriteBatch);

        }
    }
}


