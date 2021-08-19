using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.UI
{
    public class HealthManager
    {
        public List<Heart> HealthBar;

        private ScreenManager _screenManager;
        private IGameObject _hero;
        private Vector2 _startPosition;

        private int xOffset = 5;
        private int yOffset = 5;
        private double _spacing = 1.2;

        public HealthManager(int amountOfLives, IGameObject hero, Vector2 startpos, ScreenManager screenmng)
        {
            HealthBar = new List<Heart>();
            GenerateHearts(amountOfLives);

            _hero = hero;
            _startPosition = startpos;
            _screenManager = screenmng;
        }

        private void GenerateHearts(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                HealthBar.Add(new Heart(new Vector2((float)((i * _spacing * 32) + xOffset), yOffset)));
            }
        }

        private void Respawn()
        {
            _hero.Position = _startPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Heart heart in HealthBar)
            {
                heart.Draw(spriteBatch);
            }
        }

        public void TakeDamage()
        {
            if (HealthBar.Count == 1) _screenManager.ManageTransitions(2); // when on last life, die
            else
            {
                HealthBar.RemoveAt(HealthBar.Count-1);
                Respawn();
            }
        }
    }
}
