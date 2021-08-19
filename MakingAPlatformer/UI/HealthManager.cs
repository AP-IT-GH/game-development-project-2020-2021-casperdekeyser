using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.UI
{
    public class HealthManager
    {
        public List<Heart> HealthBar;
        private int xOffset = 5;
        private int yOffset = 5;
        private double _spacing = 1.2;

        public HealthManager(int amountOfLives)
        {
            HealthBar = new List<Heart>();
            GenerateHearts(amountOfLives);
        }

        private void GenerateHearts(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                HealthBar.Add(new Heart(new Vector2((float)((i * _spacing * 32) + xOffset), yOffset)));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Heart heart in HealthBar)
            {
                heart.Draw(spriteBatch);
            }
        }
    }
}
