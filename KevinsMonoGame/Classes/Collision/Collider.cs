using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace KevinsMonoGame
{
    internal class Collider
    {
        //unactive colliders of certain GameObject
        public List<Rectangle> Colliders { get; set; } = new List<Rectangle>();
        public List<bool> Harmful { get; set; } = new List<bool>();

        //active colliders of certain GameObject
        public List<Rectangle> ActiveColliders { get; set; } = new List<Rectangle>();
        public List<bool> ActiveHarmful { get; set; } = new List<bool>();


        public void Add(Rectangle rectangle, bool harmful)
        {
            Colliders.Add(rectangle);
            Harmful.Add(harmful);
        }

        public void Activate(ISolid gameobject)
        {
            ActiveColliders = new List<Rectangle>();
            ActiveHarmful = new List<bool>();

            if (gameobject is IMovable)
            {
                for (int i = 0; i < Colliders.Count; i++)
                {
                    ActiveColliders.Add(new Rectangle((int)gameobject.Position.X + Colliders[i].X, (int)gameobject.Position.Y + Colliders[i].Y, Colliders[i].Width, Colliders[i].Height));
                    ActiveHarmful.Add(Harmful[i]);
                    AllColliders.OverworldCollidersCurrent.Add(ActiveColliders[i]);
                    AllColliders.OverworldHarmfulCurrent.Add(ActiveHarmful[i]);
                    AllColliders.GameObjectsCurrent.Add(gameobject);
                }
            }
            else if (gameobject is IPositionable)
            {
                for (int i = 0; i < Colliders.Count; i++)
                {
                    ActiveColliders.Add(new Rectangle(Colliders[i].X, Colliders[i].Y, Colliders[i].Width, Colliders[i].Height));
                    ActiveHarmful.Add(Harmful[i]);
                    AllColliders.OverworldCollidersCurrent.Add(ActiveColliders[i]);
                    AllColliders.OverworldHarmfulCurrent.Add(ActiveHarmful[i]);
                    AllColliders.GameObjectsCurrent.Add(gameobject);
                }
            }
        }
    }
}
