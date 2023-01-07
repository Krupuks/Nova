using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace KevinsMonoGame
{
    internal class Terrain : Entity
    {
        //BlockSolid list is separated in a static list to be detectable as ground
        public static List<SolidBlock> BlocksSolid = new List<SolidBlock>();

        public List<VoidBlock> Blocks = new List<VoidBlock>();
        public int BlockSize { get; set; } = General.BlockSize;
        public int[,] Gameboard { get; set; }
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public List<Vector2> EnemyPos { get; set; } = new List<Vector2>();
        public void AddEnemy(Enemy enemy, Vector2 enemyPos)
        {
            Enemies.Add(enemy);
            EnemyPos.Add(enemyPos);
            enemy.Position = enemyPos;
        }

        public Terrain(int[,] gameboard)
        {
            Gameboard = gameboard;

            for (int y = 0; y < Gameboard.GetLength(0); y++)
            {
                for (int x = 0; x < Gameboard.GetLength(1); x++)
                {
                    //negative numbers are reserved for enemies
                    if (Gameboard[y, x] < 0)
                        AddEnemy(EnemyFactory.CreateEnemy(Gameboard[y, x]), new Vector2((x + 1) * BlockSize * Scale, General.ScreenHeight - (Gameboard.GetLength(0) - (y + 1) * BlockSize * Scale)));
                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            BlocksSolid.Clear();
            Blocks.Clear();
            for (int y = 0; y < Gameboard.GetLength(0); y++)
            {
                for (int x = 0; x < Gameboard.GetLength(1); x++)
                {
                    //positive numbers are reserved for blocks
                    if (Gameboard[y, x] > 0 && Gameboard[y, x] < 100 )
                    {
                        BlocksSolid.Add(BlockFactory.CreateSolidBlock(Gameboard[y, x], new Rectangle((int)((x + 1) * BlockSize * Scale), (int)(General.ScreenHeight - (Gameboard.GetLength(0) - (y + 1) * BlockSize * Scale)), (int)(BlockSize * Scale), (int)(BlockSize * Scale))));
                    }
                    if (Gameboard[y, x] > 100)
                    { 
                        Blocks.Add(BlockFactory.CreateBlock(Gameboard[y, x], new Rectangle((int)((x + 1) * BlockSize * Scale), (int)(General.ScreenHeight - (Gameboard.GetLength(0) - (y + 1) * BlockSize * Scale)), (int)(BlockSize * Scale), (int)(BlockSize * Scale))));
                    }
                }
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Update(gameTime);
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            //for (int y = 0; y < Gameboard.GetLength(0); y++)
            //{
            //for (int x = 0; x < Gameboard.GetLength(1); x++)
            //{
            //renders only within camera
            //if (x * size * scale >= (Camera.Fullzone.X - 6 * size * scale) && x * size * scale <= (Camera.Fullzone.X + Camera.Fullzone.Width + 6 * size * scale) &&
            //    y * size * scale >= (Camera.Fullzone.Y - 6 * size * scale) && y * size * scale <= (Camera.Fullzone.Y + Camera.Fullzone.Height + 6 * size * scale))
            //{

            for (int i = 0; i < BlocksSolid.Count; i++)
            {
                BlocksSolid[i].Draw(spriteBatch);
            }
            for (int i = 0; i < Blocks.Count; i++)
            {
                Blocks[i].Draw(spriteBatch);
            }
            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies[i].Draw(spriteBatch);
            }
            //}
            //}
            //}
        }
    }
}
