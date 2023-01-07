
using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal class Gravity
    {
        public void Add(IMovable gameobject, float gravitationalConstant)
        {
            gameobject.Acceleration += new Vector2(0, gravitationalConstant);
        }
        public void Add(IMovable gameobject)
        {
            Add(gameobject, 9.81f);
        }
    }
}
