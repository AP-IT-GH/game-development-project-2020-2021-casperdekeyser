using MakingAPlatformer.UI;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.Interfaces
{
    public interface IHealthManager
    {
        public List<Heart> HealthBar { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void TakeDamage();
    }
}
