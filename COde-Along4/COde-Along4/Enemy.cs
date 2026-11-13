using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace COde_Along4
{
    public class Enemy : GameObject
    {
        public Enemy(Rectangle rec) : base(rec)
        {
            this.tex = TextureManager.enemyTex;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, size, Color.White);
        }
    }
}