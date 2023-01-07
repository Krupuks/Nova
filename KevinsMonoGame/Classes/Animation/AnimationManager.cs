using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal class AnimationManager
    {
        public void Update(IAnimatable animatable, GameTime gametime)
        {

            if (animatable is Creature)
            {
                Creature creature = animatable as Creature;

                if (creature.IsAttacking)
                    creature.AnimationAttack.Update(gametime);
                else if (creature.IsJumping)
                    creature.AnimationJump.Update(gametime);

                else if (creature.IsIdle && creature.IsCrouching)
                    creature.AnimationCrouch.Update(gametime);
                else if (creature.IsIdle && !creature.IsCrouching)
                    creature.AnimationIdle.Update(gametime);
                else if (!creature.IsIdle && creature.IsCrouching)
                    creature.AnimationCrouchRun.Update(gametime);
                else if (!creature.IsIdle && !creature.IsCrouching)
                    creature.AnimationRun.Update(gametime);
            }
            else
                animatable.AnimationIdle.Update(gametime);
        }
        public void Draw(IAnimatable animatable, SpriteBatch spriteBatch)
        {
            if (animatable is Creature)
            {
                Creature creature = animatable as Creature;

                if (creature.IsAttacking)
                    spriteBatch.Draw(creature.TextureAttack, creature.Position, creature.AnimationAttack.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(70, 0), new Vector2(creature.SpriteDirection * creature.Scale, creature.Scale), new SpriteEffects(), 0f);
                else if (creature.IsJumping && !creature.IsAttacking)
                    spriteBatch.Draw(creature.TextureJump, creature.Position, creature.AnimationJump.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(70, 0), new Vector2(creature.SpriteDirection * creature.Scale, creature.Scale), new SpriteEffects(), 0f);
                else if (creature.IsIdle && creature.IsCrouching)
                    spriteBatch.Draw(creature.TextureCrouch, creature.Position, creature.AnimationCrouch.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(70, 0), new Vector2(creature.SpriteDirection * creature.Scale, creature.Scale), new SpriteEffects(), 0f);
                else if (creature.IsIdle && !creature.IsCrouching)
                    spriteBatch.Draw(creature.TextureIdle, creature.Position, creature.AnimationIdle.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(70, 0), new Vector2(creature.SpriteDirection * creature.Scale, creature.Scale), new SpriteEffects(), 0f);
                else if (!creature.IsIdle && creature.IsCrouching)
                    spriteBatch.Draw(creature.TextureCrouchRun, creature.Position, creature.AnimationCrouchRun.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(70, 0), new Vector2(creature.SpriteDirection * creature.Scale, creature.Scale), new SpriteEffects(), 0f);
                else if (!creature.IsIdle && !creature.IsCrouching)
                    spriteBatch.Draw(creature.TextureRun, creature.Position, creature.AnimationRun.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(70, 0), new Vector2(creature.SpriteDirection * creature.Scale, creature.Scale), new SpriteEffects(), 0f);

            }
            else
                spriteBatch.Draw(animatable.TextureIdle, animatable.Position, animatable.AnimationIdle.CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(70, 0), new Vector2(animatable.SpriteDirection * animatable.Scale, animatable.Scale), new SpriteEffects(), 0f);
        }
    }
}
