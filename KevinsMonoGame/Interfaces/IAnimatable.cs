namespace KevinsMonoGame
{
    internal interface IAnimatable : IVisible
    {
        public AnimationManager AnimationManager { get; set; }
        public Animation AnimationIdle { get; set; }
    }
}
