using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Intro_2D_Project{
    class Player : GameObject{
        public Player(Vector2f startPosition){
            textur = new Texture("Bilder/Player.png");
            sprite = new Sprite(textur);
            sprite.Position = startPosition;
            baseMovementSpeed = 0.1f;
            sprite.Scale = new Vector2f(0.5f, 0.5f);
        }
        void KeyboardInput(){
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                MovingDirection = new Vector2f(0, -1);
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                MovingDirection = new Vector2f(0, 1);
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                MovingDirection = new Vector2f(-1, 0);
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                MovingDirection = new Vector2f(1, 0);
            else
                MovingDirection = new Vector2f(0, 0);
        }
        public override void Update(GameTime gTime){
            movementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            KeyboardInput();
            Move();
        }
    }
}