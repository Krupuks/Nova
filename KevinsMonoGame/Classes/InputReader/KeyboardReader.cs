using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KevinsMonoGame
{
    internal class KeyboardReader : IDeviceReader
    {

        public void ReadInput(Creature player) //can this be an interface?
        {

            KeyboardState state = Keyboard.GetState();
            MouseState stateM = Mouse.GetState();
            
            //get Direction
            if ((state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q)) && !(state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)))
            {
                player.SpriteDirection = -1;
                player.Direction = new Vector2(player.SpriteDirection, player.Direction.Y);
            }
            else if ((state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D)) && !(state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q)))
            {
                player.SpriteDirection = 1;
                player.Direction = new Vector2(player.SpriteDirection, player.Direction.Y);
            }
            else
                player.Direction = new Vector2(0, player.Direction.Y);

            //get JumpStatus
            if ((state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Z) || state.IsKeyDown(Keys.Space)))
                player.IsJumping = true;

            //get CrouchStatus
            if ((state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S)) && !player.IsJumping)
            {
                player.IsCrouching = true;
                player.Speed = new Vector2(5, player.Speed.Y);
            }
            else
            {
                player.IsCrouching = false;
                player.Speed = new Vector2(20, player.Speed.Y);
            }

            //get IdleStatus
            if (player.Direction.X == 0 && player.Direction.Y == 0)
                player.IsIdle = true;
            else
                player.IsIdle = false;

            //get AttackStatus
            if (stateM.LeftButton == ButtonState.Pressed || state.IsKeyDown(Keys.E))
                player.IsAttacking = true;
            if (player.AnimationAttack.Done())
                player.IsAttacking = false;

            //get JumpStatus
            if (player.IsJumping)
            {
                player.Direction = new Vector2(player.Direction.X, -1);
                player.Speed = new Vector2(player.Speed.X, 25);
                player.IsCrouching = false;
            }
            //get FallStatus
            else if (!player.IsFalling)
                player.Direction = new Vector2(player.Direction.X, 0);

        }
        public bool IsDestinationalInput => false;
    }
}
