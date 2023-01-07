using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace KevinsMonoGame
{
    internal class Button : ItemStatic
    {
        public IHasScenes Game { get; set; }
        public string Type { get; set; }

        public Button(string type, Texture2D texture, IHasScenes game) :base(texture)
        {
            Scale = General.Scale;
            Type = type.ToUpper();
            Game = game;
        }

        public bool enterButton()
        {
            MouseState stateM = Mouse.GetState();
            if (stateM.X < Position.X + TextureIdle.Width * Scale &&
                    stateM.X > Position.X &&
                    stateM.Y < Position.Y + TextureIdle.Height * Scale &&
                    stateM.Y > Position.Y)
            {
                return true;
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState stateM = Mouse.GetState();
            if (enterButton() && stateM.LeftButton == ButtonState.Pressed)
            {
                switch (Type)
                {
                    case "NEXT":
                        Game.SceneManager.GoToNextScene(Game);
                        break;
                    case "EXIT":
                        Game.Exit();
                        break;

                    default:
                        break;
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (enterButton())
                spriteBatch.Draw(TextureIdle, new Vector2(Position.X - General.ScreenWidth / 2, Position.Y - General.ScreenHeight / 2), null, Color.White, 0f, Vector2.Zero, Scale * Vector2.One, new SpriteEffects(), 0f);
            else
                spriteBatch.Draw(TextureIdle, new Vector2(Position.X - General.ScreenWidth / 2, Position.Y - General.ScreenHeight / 2), null, Color.White * 0.5f, 0f, Vector2.Zero, Scale * Vector2.One, new SpriteEffects(), 0f);
        }
    }
}
