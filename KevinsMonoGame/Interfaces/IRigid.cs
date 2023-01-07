using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal interface IRigid : IPositionable
    {
        public Gravity Gravity { get; set; }
        public float Mass { get; set; }
        public bool IsFalling { get; set; }
        public Collider GroundCheck { get; set; }
    }
}
