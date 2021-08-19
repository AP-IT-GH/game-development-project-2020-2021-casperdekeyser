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

        private ScreenManager _screenManager;
        private IGameObject _hero;

        private int xOffset = 5;
        private int yOffset = 5;
        private double _spacing = 1.2;

        public HealthManager(int amountOfLives, IGameObject hero, ScreenManager screenmng)
        {
            HealthBar = new List<Heart>();
            GenerateHearts(amountOfLives);

            _hero = hero;
            _screenManager = screenmng;
        }

        private void GenerateHearts(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                HealthBar.Add(new Heart(new Vector2((float)((i * _spacing * 32) + xOffset), yOffset)));
            }
        }

        private void Respawn(Vector2 respawnPosition)
        {
            _hero.Position = respawnPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Heart heart in HealthBar)
            {
                heart.Draw(spriteBatch);
            }
        }

        public void Execute()
        {
            if (HealthBar.Count == 1) _screenManager.ManageTransitions(2); // when on last live, die
            else
            {
                HealthBar.RemoveAt(HealthBar.Count-1);
                Respawn(new Vector2(50, 868 - 96));
            }
        }
    }
}
