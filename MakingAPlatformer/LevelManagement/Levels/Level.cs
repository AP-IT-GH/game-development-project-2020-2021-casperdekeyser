using MakingAPlatformer.Management;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.LevelManagement
{
    public abstract class Level
    {
        public abstract int LevelId { get; set; }

        protected ContentManager _content;
        protected GraphicsDevice _graphics;
        protected SpriteBatch _spriteBatch;
        protected Game1 _game;

        // Hero
        protected IGameObject hero;
        protected Vector2 heroPosition;
        protected HeroAnimator heroAnimator;
        protected IInputReader inputReader;
        protected AnimateCommand animateCommand;

        // Map
        protected MapMaker mapMaker;
        protected EndingZone endzone;

        // Collision
        protected CollisionManager collisionManager;
        protected List<BoxCollider> colliders;

        public Level(GraphicsDevice graphicsDevice, ContentManager content, Game1 game)
        {
            _graphics = graphicsDevice;
            _content = content;
            _game = game;
        }
        protected abstract void Initialize();
        protected abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    }
}
