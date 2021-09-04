using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MakingAPlatformer.Map.Blocks
{
    public abstract class Block : IMapObject
    {
        public Vector2 Position { get; set; }
        public Texture2D Spritesheet{ get; set; }
        public string SpritesheetPath { get; set; }
        public BoxCollider Collider { get; set; }

        public virtual int RowOnMasterTileset { get; set; }

        protected int size = 62;
        protected int variation = 0;

        public Block(Vector2 position, int variation = 0)
        {
            Position = position;
            SpritesheetPath = "Map/master-tileset";
            Collider = new BoxCollider(Position, "Block-Collider", size, size);

            this.variation = variation;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Spritesheet, Position, new Rectangle(size * (variation * 2), size * RowOnMasterTileset, size, size), Color.White);
        }
    }
}
