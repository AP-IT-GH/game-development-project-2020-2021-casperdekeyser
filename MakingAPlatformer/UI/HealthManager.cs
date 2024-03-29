﻿using MakingAPlatformer.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MakingAPlatformer.UI
{
    public class HealthManager : IHealthManager
    {
        public List<Heart> HealthBar { get; set; }

        private IScreenManager _screenManager;
        private IRespawnable _hero;
        private Vector2 _respawnPosition;

        private int _xOffset = 5;
        private int _yOffset = 5;
        private double _spacing = 1.8;

        public HealthManager(int amountOfLives, IRespawnable hero, Vector2 respawnPosition, IScreenManager screenmng)
        {
            HealthBar = new List<Heart>();
            GenerateHearts(amountOfLives);

            _hero = hero;
            _respawnPosition = respawnPosition;
            _screenManager = screenmng;
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
                HealthBar.RemoveAt(HealthBar.Count - 1);
                Respawn();
            }
        }

        private void GenerateHearts(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                HealthBar.Add(new Heart(new Vector2((float)((i * _spacing * 32) + _xOffset), _yOffset)));
            }
        }

        private void Respawn()
        {
            _hero.Position = _respawnPosition;
            _hero.JumpCommand.CurrentHeight = _respawnPosition.Y;
        }
    }
}
