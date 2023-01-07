namespace KevinsMonoGame
{
    internal interface IControllable : IMovable
    {
        public IDeviceReader InputReader { get; set; }
    }
}
