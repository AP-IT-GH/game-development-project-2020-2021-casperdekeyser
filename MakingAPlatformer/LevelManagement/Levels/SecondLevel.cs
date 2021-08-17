using MakingAPlatformer.Management;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer.LevelManagement.Levels
{
    public class SecondLevel : Level
    {
        public override int LevelId { get; set; } = 2;

        public SecondLevel(GraphicsDevice graphicsDevice, ContentManager content, Game1 game) : base(graphicsDevice, content, game)
        {
            Initialize();
            LoadContent();
        }

        protected override void Initialize()
        {
            // Hero
            heroPosition = new Vector2(50, 868 - 96);
            heroAnimator = new HeroAnimator();
            inputReader = new KeyboardReader();
            animateCommand = new AnimateCommand();
            hero = new Hero(heroPosition, heroAnimator, inputReader, animateCommand);

            // Map
            mapMaker = new MapMaker();
            mapMaker.CreateLevel(LevelId);

            endzone = new EndingZone(new Vector2(1500, 0), "Ending zone", 62, 62);

            // Collision
            colliders = new List<BoxCollider>();
            foreach (IMapObject block in mapMaker.Blocks)
            {
                colliders.Add(block.Collider);
            }
            collisionManager = new CollisionManager(colliders, hero);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(_graphics);

            // TODO: use this.Content to load your game content here

            foreach (Animation animation in hero.Animator.Animations)
            {
                animation.SpriteSheet = _content.Load<Texture2D>(animation.SpriteSheetPath);
            }

            foreach (IMapObject block in mapMaker.Blocks)
            {
                block.Spritesheet = _content.Load<Texture2D>(block.SpritesheetPath);
            }
        }

        public override void Update(GameTime gameTime)
        {
            collisionManager.Execute();
            hero.Update(gameTime);

            endzone.CheckEnding(hero);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            mapMaker.DrawLevel(LevelId, _spriteBatch);

            // DRAW COLLIDERS
            //collisionManager.DrawColliders(_spriteBatch, GraphicsDevice);
            //endzone.Draw(_spriteBatch, _graphics);

            _spriteBatch.End();
        }

    }
}
