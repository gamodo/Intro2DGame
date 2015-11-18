
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_2D_Project{
    class Monster01 : GameObject{
        Texture textur2;
        public Monster01(string direction, Vector2f sPosition){
            textur = new Texture(direction);
            sprite = new Sprite(textur);
            baseMovementSpeed = 0.05f;
            sprite.Position = sPosition;
            sprite.Scale = new Vector2f(0.1f, 0.1f);
        }
        public Monster01(string direction, Vector2f sPos, string direction2) : this(direction, sPos){
            textur2 = new Texture(direction2);
        }
        protected void Animate(GameTime gTime){
            if (gTime.Total.Milliseconds % 1000 < 500)
                sprite.Texture = textur;
            else
                sprite.Texture = textur2;
        }
        public override void Update(GameTime gTime){
            movementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            MovingDirection = Game.Player.Position - sprite.Position;
            Move();
            if (isMoving)
                Animate(gTime);
        }
    }
}