using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;

namespace KevinsMonoGame
{
    internal class LevelBoss : Level
    {
        public EnemyBoss Boss { get; set; } = new EnemyBoss();
        public bool IsTriggered { get; set; } = true;
        public Vector2 TriggerPos { get; set; }
        public LevelBoss(Terrain terrain, Player player, Vector2 startPos, Vector2 triggerPos, Vector2 endPos, Texture2D backgroundTexture, Song song) :base(terrain, player, startPos, endPos, backgroundTexture, song)
        {
            TriggerPos = triggerPos;
        }
        public override void Update(GameTime gameTime)
        {
            if (Player.Position.X > TriggerPos.X && IsTriggered)
            {
                MediaPlayer.Play(General.PrepareForBattle);
                IsTriggered = false;
            }

            try
            {
                if (!Terrain.Enemies[0].IsAlive)
                {
                    CompleteLevel();
                    MediaPlayer.Play(Song);
                }
            }
            catch (Exception) {throw new Exception("Exactly ONE boss is allowed in each bosslevel");}

            Background.Update(gameTime);
            Terrain.Update(gameTime);
            Player.Update(gameTime);
            Camera.Follow(Player);
        }
    }
}
