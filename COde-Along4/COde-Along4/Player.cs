using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace COde_Along4
{
    public class Player : GameObject
    {
        public Player(Rectangle rec) : base(rec)
        {
            this.tex = TextureManager.playerTex;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, size, Color.White);
        }
    }
}