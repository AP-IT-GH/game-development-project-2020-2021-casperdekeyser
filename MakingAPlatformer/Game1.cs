using MakingAPlatformer.Management;
using MakingAPlatformer.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MakingAPlatformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Hero
        IGameObject hero;
        Vector2 heroPosition;
        HeroAnimator heroAnimator;
        IInputReader inputReader;
        AnimateCommand animateCommand;

        // Map
        MapMaker mapMaker;
        EndingZone endzone;

        // Collision
        CollisionManager collisionManager;
        List<BoxCollider> colliders;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            // Screen

            _graphics.PreferredBackBufferWidth = 1550;
            _graphics.PreferredBackBufferHeight = 930;
            _graphics.ApplyChanges();


            // Objects
            // Hero
            heroPosition = new Vector2(100, 868-96);
            heroAnimator = new HeroAnimator();
            inputReader = new KeyboardReader();
            animateCommand = new AnimateCommand();
            hero = new Hero(heroPosition, heroAnimator, inputReader, animateCommand);

            // Map
            mapMaker = new MapMaker();
            mapMaker.CreateWorld();

            endzone = new EndingZone(new Vector2(500, 868 - 96), "testendingzone", 100, 100);

            // Collision
            colliders = new List<BoxCollider>();
            foreach (IMapObject block in mapMaker.Blocks)
            {
                colliders.Add(block.Collider);
            }
            collisionManager = new CollisionManager(colliders, hero);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            foreach (Animation animation in hero.Animator.Animations)
            {
                animation.SpriteSheet = Content.Load<Texture2D>(animation.SpriteSheetPath);
            }

            foreach (IMapObject block in mapMaker.Blocks)
            {
                block.Spritesheet = Content.Load<Texture2D>(block.SpritesheetPath);
            }
        }


        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            collisionManager.Execute();
            hero.Update(gameTime);

            endzone.CheckEnding(hero);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);

            mapMaker.DrawWorld(_spriteBatch);

            // DRAW COLLIDERS
            //collisionManager.DrawColliders(_spriteBatch, GraphicsDevice);
            endzone.Draw(_spriteBatch, GraphicsDevice);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
