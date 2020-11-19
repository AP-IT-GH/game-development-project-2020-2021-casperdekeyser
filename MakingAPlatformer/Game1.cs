using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Xml.Serialization;

namespace MakingAPlatformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        IGameObject hero; // list van alle gameobjects
        IMapObject block;
        //IMapObject anotherBlock;
        CollisionManager collisionManager;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            hero = new Hero();
            block = new Block(new Vector2(300, 280));
            collisionManager = new CollisionManager(hero, block, GraphicsDevice);
            //anotherBlock = new Block(new Vector2(370, 280));

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

            block.Spritesheet = Content.Load<Texture2D>(block.SpritesheetPath);
            //anotherBlock.Spritesheet = Content.Load<Texture2D>(block.SpritesheetPath);
        }


        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            hero.Update(gameTime);
            collisionManager.Execute();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            hero.Draw(_spriteBatch);
            block.Draw(_spriteBatch);
            //anotherBlock.Draw(_spriteBatch);

            //collisionManager.DrawColliders(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
