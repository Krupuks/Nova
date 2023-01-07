namespace KevinsMonoGame
{
    internal class DeathManager
    {
        public void Die(ICanDie canDie)
        {
            if (canDie.CurrentHealth <= 0)
            {
                canDie.CurrentHealth = 0;
                canDie.IsAlive = false;
            }
        }

        public void Resurrect(ICanDie canDie)
        {
            canDie.CurrentHealth = canDie.MaxHealth;
            canDie.IsAlive = true;
        }
    }
}
