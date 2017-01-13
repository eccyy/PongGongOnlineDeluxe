using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGongOnlineDeluxe
{
    class Ball
    {
        public Texture2D sprite;
        public Rectangle hitbox;
        public Vector2 position;
        public int width, height;
        public float speed;
        
        public void BallConstructor(Texture2D spr, Vector2 pos, int w, int h, float sp)
        {
            this.sprite = spr;
            this.position = pos;
            this.width = w;
            this.height = h;
            this.speed = sp;
        }

        public void Update()
        {
            hitbox = new Rectangle((int)position.X,(int)position.Y,width,height);
            position.X += speed;
        }
    }
}
