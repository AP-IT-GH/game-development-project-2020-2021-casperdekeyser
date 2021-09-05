using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework;

namespace MakingAPlatformer.Map.Blocks
{
    public abstract class Trap : Block
    {
        public override int RowOnMasterTileset { get; set; } = 2;
        
        public Trap(Vector2 position) : base(position, 4) { }

        public void CheckCollision(IGameObject hero, IHealthManager healthManager)
        {
            if (hero.Collider.Rectangle.Intersects(new Rectangle(Collider.Rectangle.X, Collider.Rectangle.Y - 3, Collider.Rectangle.Width, Collider.Rectangle.Height + 3))) 
                healthManager.TakeDamage();
        }
    }
}
