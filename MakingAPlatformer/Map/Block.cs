using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    class Block : IMapObject
    {
        public Vector2 Position { get; set; }
        public int Size = 62;
        public Texture2D Spritesheet{ get; set; }
        public string SpritesheetPath { get; set; }

        public Block(Vector2 position)
        {
            Position = position;
            SpritesheetPath = "Map/master-tileset";
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(0, 0, Size, Size), Color.White);
        }
    }
}
