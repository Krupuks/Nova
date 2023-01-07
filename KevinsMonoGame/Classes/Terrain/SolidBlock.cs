using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KevinsMonoGame
{
    internal class SolidBlock : VoidBlock, ISolid

    {
        public CollisionDetector CollisionDetector { get; set; } = new CollisionDetector();
        public Collider ColliderIdle { get; set; } = new Collider();

        public SolidBlock(Rectangle rectangle, int column, int row) : base(rectangle, column, row)
        {
            //lowered block colliders with 5px to create a '3D' effect
            ColliderIdle.Add(new Rectangle(rectangle.X, (int)(rectangle.Y + 5 * Scale), rectangle.Width, rectangle.Height) , false);
            ColliderIdle.Activate(this);
        }
    }
}
