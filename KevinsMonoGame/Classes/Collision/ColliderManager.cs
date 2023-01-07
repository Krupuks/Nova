using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal class ColliderManager
    {
        public void Update(Creature creature)
        {
            creature.GroundCheck.Activate(creature);
            if (creature.IsAttacking)
            {
                creature.ColliderAttack.Activate(creature);
                creature.ActiveCollider = creature.ColliderAttack;
                creature.ColliderWeapon.Activate(creature);
            }
            else if (creature.IsJumping && !creature.IsAttacking)
            {
                creature.ColliderJump.Activate(creature);
                creature.ActiveCollider = creature.ColliderJump;
            }
            else if (creature.IsIdle && creature.IsCrouching)
            {
                creature.ColliderCrouch.Activate(creature);
                creature.ActiveCollider = creature.ColliderCrouch;
            }
            else if (creature.IsIdle && !creature.IsCrouching)
            {
                creature.ColliderIdle.Activate(creature);
                creature.ActiveCollider = creature.ColliderIdle;
            }
            else if (!creature.IsIdle && creature.IsCrouching)
            {
                creature.ColliderCrouch.Activate(creature);
                creature.ActiveCollider = creature.ColliderCrouch;

            }
            else if (!creature.IsIdle && !creature.IsCrouching)
            {
                creature.ColliderIdle.Activate(creature);
                creature.ActiveCollider = creature.ColliderIdle;
            }
        }
    }
}
