namespace KevinsMonoGame
{
    internal interface ISolid : IPositionable
    {
        public CollisionDetector CollisionDetector { get; set; }
        public Collider ColliderIdle { get; set; }
    }
}

