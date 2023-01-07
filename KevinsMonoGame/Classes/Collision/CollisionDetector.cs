using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal class CollisionDetector
    {
        private bool IntersectsFromTop(Rectangle target1, Rectangle target2)
        {
            var intersection = Rectangle.Intersect(target1, target2);
            return target1.Intersects(target2) && intersection.Y == target2.Y && intersection.Width >= intersection.Height;
        }
        private bool IntersectsFromBottom(Rectangle target1, Rectangle target2)
        {
            var intersection = Rectangle.Intersect(target1, target2);
            return target1.Intersects(target2) && intersection.Y + intersection.Height == target2.Y + target2.Height && intersection.Width >= intersection.Height;
        }
        private bool IntersectsFromLeft(Rectangle target1, Rectangle target2)
        {
            var intersection = Rectangle.Intersect(target1, target2);
            return target1.Intersects(target2) && intersection.X == target2.X && intersection.Width <= intersection.Height;
        }
        private bool IntersectsFromRight(Rectangle target1, Rectangle target2)
        {
            var intersection = Rectangle.Intersect(target1, target2);
            return target1.Intersects(target2) && intersection.X + intersection.Width == target2.X + target2.Width && intersection.Width <= intersection.Height;
        }

        private bool IntersectsGround(Rectangle target1, Rectangle ground)
        {
            var intersection = Rectangle.Intersect(target1, ground);
            return target1.Intersects(ground) && target1.Y <= ground.Y + ground.Height;
        }

        public void DetectGround(Creature creature)
        {
            //loop through blocks
            for (int i = 0; i < Terrain.BlocksSolid.Count; i++)
            {
                //don't check colliders that are from the same gameobject
                if (AllColliders.GameObjectsCurrent[i].GetHashCode != creature.GetHashCode)
                {
                    Rectangle target = creature.GroundCheck.ActiveColliders[0];
                    Rectangle ground = Terrain.BlocksSolid[i].ColliderIdle.ActiveColliders[0];
                    if (IntersectsGround(target, ground))
                    {
                        creature.IsFalling = false;
                        creature.IsJumping = false;
                        i = Terrain.BlocksSolid.Count;
                    }
                    else
                        creature.IsFalling = true;
                }
            }
        }
        public void MoveSolid(Creature creature)
        {
            ISolid detected = null;
            int knockback = 15;
            //loop through every other hitbox
            for (int i = 0; i < AllColliders.OverworldColliders.Count; i++)
            {
                for (int j = 0; j < creature.ActiveCollider.ActiveColliders.Count; j++)
                {
                    bool FromTop = IntersectsFromTop(creature.ActiveCollider.ActiveColliders[j], AllColliders.OverworldColliders[i]);
                    bool FromBottom = IntersectsFromBottom(creature.ActiveCollider.ActiveColliders[j], AllColliders.OverworldColliders[i]);
                    bool FromRight = IntersectsFromRight(creature.ActiveCollider.ActiveColliders[j], AllColliders.OverworldColliders[i]);
                    bool FromLeft = IntersectsFromLeft(creature.ActiveCollider.ActiveColliders[j], AllColliders.OverworldColliders[i]);

                    if (AllColliders.GameObjects[i].GetHashCode != creature.GetHashCode)
                    {
                        detected = AllColliders.GameObjects[i];
                        if (creature.ActiveCollider.ActiveColliders[j].Intersects(AllColliders.OverworldColliders[i]) && AllColliders.OverworldHarmful[i])
                        {
                            //push away when harmful
                            if (FromTop)
                                creature.Position = new Vector2(creature.Position.X, creature.Position.Y - knockback);
                            else if (FromBottom)
                                creature.Position = new Vector2(creature.Position.X, creature.Position.Y + knockback);
                            else if (FromRight)
                                creature.Position = new Vector2(creature.Position.X + knockback, creature.Position.Y);
                            else if (FromLeft)
                                creature.Position = new Vector2(creature.Position.X - knockback, creature.Position.Y);
                        }
                        if (creature.ActiveCollider.ActiveColliders[j].Intersects(AllColliders.OverworldColliders[i]) && !AllColliders.OverworldHarmful[i])
                        {

                            if (FromTop)
                                creature.Position = new Vector2(creature.Position.X, AllColliders.OverworldColliders[i].Y - creature.ActiveCollider.Colliders[j].Height - creature.ActiveCollider.Colliders[j].Y + 1 * creature.Scale);
                            else if (FromBottom)
                                creature.Position = new Vector2(creature.Position.X, AllColliders.OverworldColliders[i].Y + AllColliders.OverworldColliders[i].Height - creature.ActiveCollider.Colliders[j].Y + 1 * creature.Scale);
                            else if (FromRight)
                                creature.Position = new Vector2(AllColliders.OverworldColliders[i].X + AllColliders.OverworldColliders[i].Width - creature.ActiveCollider.Colliders[j].X, creature.Position.Y);
                            else if (FromLeft)
                                creature.Position = new Vector2(AllColliders.OverworldColliders[i].X + creature.ActiveCollider.Colliders[j].X, creature.Position.Y);
                        }
                    }
                }
            }
        }
        public ISolid DetectSolid(Creature creature)
        {
            ISolid detected = null;
            //loop through every other hitbox
            for (int i = 0; i < AllColliders.OverworldColliders.Count; i++)
            {
                for (int j = 0; j < creature.ActiveCollider.ActiveColliders.Count; j++)
                {
                    bool FromTop = IntersectsFromTop(creature.ActiveCollider.ActiveColliders[j], AllColliders.OverworldColliders[i]);
                    bool FromBottom = IntersectsFromBottom(creature.ActiveCollider.ActiveColliders[j], AllColliders.OverworldColliders[i]);
                    bool FromRight = IntersectsFromRight(creature.ActiveCollider.ActiveColliders[j], AllColliders.OverworldColliders[i]);
                    bool FromLeft = IntersectsFromLeft(creature.ActiveCollider.ActiveColliders[j], AllColliders.OverworldColliders[i]);

                    if (AllColliders.GameObjects[i].GetHashCode != creature.GetHashCode)
                    {
                        detected = AllColliders.GameObjects[i];
                    }
                }
            }
            return detected;
        }

        public bool DetectHarmful(Creature creature)
        {
            //loop through every other hitbox
            for (int i = 0; i < AllColliders.OverworldColliders.Count; i++)
            {
                if (AllColliders.GameObjects[i].GetHashCode != creature.GetHashCode)
                {
                    for (int j = 0; j < creature.ActiveCollider.ActiveColliders.Count; j++)
                    {
                        if (creature.ActiveCollider.ActiveColliders[j].Intersects(AllColliders.OverworldColliders[i]) && AllColliders.OverworldHarmful[i])
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
