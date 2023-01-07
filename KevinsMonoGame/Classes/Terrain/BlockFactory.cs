using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace KevinsMonoGame
{
    internal class BlockFactory
    {
        public static Texture2D Texture { get; set; }
        public static SolidBlock CreateSolidBlock(int type, Rectangle rectangle)
        {
            SolidBlock newBlock = null;

            switch (type)
            {
                case 1:// "GRASS"
                    newBlock = new SolidBlock(rectangle, 0, 0);
                    break;
                case 2:// "GRASSTODIRT"
                    newBlock = new SolidBlock(rectangle, 0, 1);
                    break;
                case 3:// "DIRT":
                    newBlock = new SolidBlock(rectangle, 0, 2);
                    break;
                case 4://"DIRTTOGRASS":
                    newBlock = new SolidBlock(rectangle, 1, 0);
                    break;
                case 5://"ROCK":
                    newBlock = new SolidBlock(rectangle, 1, 1);
                    break;
                case 6://"MOSSYROCK":
                    newBlock = new SolidBlock(rectangle, 1, 2);
                    break;
                case 7://"BLACK":
                    newBlock = new SolidBlock(rectangle, 2, 0);
                    break;
                default:
                    break;
            }
            return newBlock;


        }
        public static VoidBlock CreateBlock(int type, Rectangle rectangle)
        {
            VoidBlock newBlock = null;

            switch (type)
            {
                case 101://"ROCK BG":
                    newBlock = new VoidBlock(rectangle, 2, 1);
                    break;
                case 102://"PLANTS BG":
                    newBlock = new VoidBlock(rectangle, 2, 2);
                    break;
                case 103://"GRASS BG":
                    newBlock = new VoidBlock(rectangle, 3, 0);
                    break;
            }
            return newBlock;


        }
    }
}
