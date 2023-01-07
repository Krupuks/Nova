using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace KevinsMonoGame
{
    internal static class AllColliders
    {
        // ALL colliders in the game (except ground)
        public static List<ISolid> GameObjectsCurrent = new List<ISolid>();
        public static List<Rectangle> OverworldCollidersCurrent = new List<Rectangle>();
        public static List<bool> OverworldHarmfulCurrent = new List<bool>();

        //memory in case an object hasn't updated in time
        public static List<Rectangle> OverworldColliders = new List<Rectangle>();
        public static List<bool> OverworldHarmful = new List<bool>();
        public static List<ISolid> GameObjects = new List<ISolid>();

        public static void Clear()
        {
            OverworldColliders = OverworldCollidersCurrent;
            OverworldHarmful = OverworldHarmfulCurrent;
            GameObjects = GameObjectsCurrent;

            OverworldCollidersCurrent = new List<Rectangle>();
            OverworldHarmfulCurrent = new List<bool>();
            GameObjectsCurrent = new List<ISolid>();
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < OverworldCollidersCurrent.Count; i++)
            {
                spriteBatch.Draw(General.Texture, new Vector2(OverworldCollidersCurrent[i].X, OverworldCollidersCurrent[i].Y), OverworldCollidersCurrent[i], Color.White * 0.25f, 0f, Vector2.Zero, Vector2.One, new SpriteEffects(), 0f);
            }
        }
    }
}