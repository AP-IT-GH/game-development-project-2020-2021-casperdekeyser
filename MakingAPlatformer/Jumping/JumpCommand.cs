using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MakingAPlatformer
{
    public class JumpCommand
    {
        private bool rising = false;
        private bool falling = false;
        private bool jumping = false;
        private int jumpSpeed = 5;
        private int jumpHeight = 150;
        private float startY;
        private float currentHeight = 0;

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
            if (keyState.IsKeyDown(Keys.Space) && (!jumping))
            {
                Hero.State = States.Jumping;
                rising = true;
            }

        }

        public void Execute(IGameObject Hero)
        {
            if (!CollisionManager.VerticalColliding)
            {
                if (falling)
                {
                    currentHeight += jumpSpeed; // falling speed
                    Hero.Position = new Vector2(Hero.Position.X, currentHeight);
                    Hero.Direction = new Vector2(Hero.Position.X, currentHeight);
                    if (Hero.Position.Y >= startY)
                    {
                        Hero.Position = new Vector2(Hero.Position.X, startY);
                        falling = false;
                        MakingAPlatformer.Hero.State = States.Idling;
                        jumping = false;
                    }
                }
            }

            if (rising)
            {
                jumping = true;
                Hero.Position = new Vector2(Hero.Position.X, currentHeight);
                if (Hero.Position.Y <= startY - jumpHeight)
                {
                    rising = false;
                    falling = true;
                }
                currentHeight -= jumpSpeed; // rising speed
            }

            if (CollisionManager.VerticalColliding)
            {
                startY = Hero.Position.Y;
            }
        }
    }
}
