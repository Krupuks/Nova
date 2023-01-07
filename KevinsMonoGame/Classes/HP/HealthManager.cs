namespace KevinsMonoGame
{
    internal class HealthManager
    {
        public void ReceiveDamage(Creature creature, int damage)
        {
            //receive damage when contact with harmful collider
            if (creature.CollisionDetector.DetectSolid(creature) is EnemyBoss)
                damage *= 5;
            if (creature.CollisionDetector.DetectHarmful(creature))
            {
                creature.CurrentHealth -= damage;
                if (creature.CurrentHealth < 0)
                    creature.CurrentHealth = 0;
            }
        }

        //public void ReceiveHealth() could be added
    }
}
