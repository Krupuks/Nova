using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class EnemyFactory
    {
        public static Texture2D Texture { get; set; }
        public static Enemy CreateEnemy(int type)
        {
            Enemy newEnemy = null;

            switch (type)
            {
                case -1:// "SMALL"
                    newEnemy = new EnemySmall();
                    break;
                case -2:// "MEDIUM"
                    newEnemy = new EnemyMedium();
                    break;
                case -3:// "BOSS":
                    newEnemy = new EnemyBoss();
                    break;
                default:
                    break;
            }
            return newEnemy;




        }
    }
}
