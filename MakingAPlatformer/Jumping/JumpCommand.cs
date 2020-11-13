using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class JumpCommand : IGameCommand
    {
        bool rising = false;
        bool falling = false;
        private int jumpSpeed = 5;
        private int jumpHeight = 150;
        float startY;
        float currentHeight = 0;

        public JumpCommand(int speed, int height, float ground)
        {
            jumpSpeed = speed;
            jumpHeight = height;
            startY = ground;
            currentHeight = ground;
        }

        public void CheckJumping()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space))
            {
                rising = true;
            }

        }

        public void Execute(ITransform Hero, Movement MoveDirection)
        {

            if (falling)
            {
                currentHeight += jumpSpeed; // falling speed
                Hero.Position = new Vector2(Hero.Position.X, currentHeight);
                if (Hero.Position.Y >= startY)
                {
                    Hero.Position = new Vector2(Hero.Position.X, startY);
                    falling = false;
                }
            }

            if (rising)
            {
                Hero.Position = new Vector2(Hero.Position.X, currentHeight);
                if (Hero.Position.Y <= startY - jumpHeight)
                {
                    rising = false;
                    falling = true;
                }
                currentHeight -= jumpSpeed; // rising speed
            }
        }
    }
}
