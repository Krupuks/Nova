using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal interface IScriptReader : IInputReader
    {
        void ReadScript(Creature creature, GameTime gameTime, string type);
    }
}
