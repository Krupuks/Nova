using Microsoft.Xna.Framework;
using System;

namespace KevinsMonoGame
{
    internal class ScriptReader : IScriptReader
    {
        public bool IsDestinationalInput => false;
        private double ticks;
        public void ReadScript(Creature creature, GameTime gameTime,string type)
        {
            switch (type)
            {
                case "GOTOLEFT":
                    GoToLeft(creature);
                    break;
                case "GOTORIGHT":
                    GoToRight(creature);
                    break;
                case "PACE":
                    Pace(creature, gameTime);
                    break;
                case "BOSSMOVEMENT":
                    if (creature is EnemyBoss)
                    {
                        EnemyBoss enemyBoss = creature as EnemyBoss;
                        BossMovement(enemyBoss, gameTime);
                    }
                    break;
                default:
                    break;
            }
            if (creature.Direction.X == 0 && creature.Direction.Y == 0)
                creature.IsIdle = true;
            else
                creature.IsIdle = false;

        }
        private void GoToLeft(Creature creature)
        {
            creature.SpriteDirection = -1;
            creature.Direction = new Vector2(creature.SpriteDirection, creature.Direction.Y);
        }
        private void GoToRight(Creature creature)
        {
            creature.SpriteDirection = 1;
            creature.Direction = new Vector2(creature.SpriteDirection, creature.Direction.Y);
        }
        private void Stay(Creature creature)
        {
            creature.Direction = new Vector2(0, creature.Direction.Y);
        }
        private void Pace(Creature creature, GameTime gameTime)
        {
            Random random = new Random();
            ticks += gameTime.ElapsedGameTime.TotalSeconds;
            if (ticks >= 6)
                ticks = random.Next(6);

            switch (ticks)
            {
                case < 2:
                    GoToLeft(creature);
                    break;
                case < 3:
                    Stay(creature);
                    break;
                case < 5:
                    GoToRight(creature);
                    break;
                default:
                    Stay(creature);
                    break;
            }
        }

        private void Attack(Creature creature)
        {
            creature.IsAttacking = true;
        }
        private void BossMovement(EnemyBoss enemyBoss, GameTime gameTime)
        {
            ticks += gameTime.ElapsedGameTime.TotalSeconds;
            if (ticks >= 7)
                ticks = 0;

            if (enemyBoss.AnimationAttack.Done())
            {
                enemyBoss.ColliderBossAttack.Activate(enemyBoss);
                enemyBoss.IsAttacking = false;
            }

                switch (ticks)
            {
                case < 2:
                    GoToLeft(enemyBoss);
                    break;
                case < 3.5:
                    Stay(enemyBoss);
                    Attack(enemyBoss);
                    break;
                case < 5.5:
                    GoToRight(enemyBoss);
                    break;
                default:
                    Stay(enemyBoss);
                    Attack(enemyBoss);
                    break;
            }
        }
    }
}
