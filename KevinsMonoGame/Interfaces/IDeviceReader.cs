using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal interface IDeviceReader : IInputReader
    {
        void ReadInput(Creature creature);
    }

}
