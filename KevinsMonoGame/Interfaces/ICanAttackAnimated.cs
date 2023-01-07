namespace KevinsMonoGame
{
    internal interface ICanAttackAnimated : ICanAttack
    {
        public Animation AnimationAttack { get; set; }
    }
}
