using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_2D_Project{
    class Tools : GameObject {
        public bool isOnMap;
        public Tools(string text, Vector2f sPosition)
        {
            textur = new Texture(text);
            sprite = new Sprite(textur);
            sprite.Position = sPosition;
            sprite.Scale = new Vector2f(0.1f, 0.1f);
            isOnMap = true;
        }
        public void Update(GameTime gTime, Vector2f positionPlayer){
            if (positionPlayer.X>this.Position.X&&positionPlayer.Y>this.Position.Y&& positionPlayer.X<this.Position.X+this.Size.X&& positionPlayer.Y < this.Position.Y + this.Size.Y)
            {
                isOnMap = false;
            }
        }

        public override void Update(GameTime gTime)
        {
            throw new NotImplementedException();
        }
    }
}
