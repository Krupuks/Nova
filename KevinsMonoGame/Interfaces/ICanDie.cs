namespace KevinsMonoGame
{
    internal interface ICanDie
    {
        public DeathManager DeathManager { get; set; }
        public HealthManager HealthManager { get; set; }
        public HealthBar HealthBar { get; set; }
        public bool IsAlive { get; set; }
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }


    }
}
