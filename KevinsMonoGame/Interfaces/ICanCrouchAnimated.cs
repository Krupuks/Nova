namespace KevinsMonoGame
{
    internal interface ICanCrouchAnimated: ICanCrouch
    {
        public Animation AnimationCrouch { get; set; }
    }
}
