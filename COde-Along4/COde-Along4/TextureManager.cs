using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace COde_Along4;

public static class TextureManager
{
    public static Texture2D playerTex;
    public static Texture2D enemyTex;
    public static Texture2D platFormTex;
    //public static Texture2D 

    public static void LoadTexture(ContentManager content)
    {
        playerTex = content.Load<Texture2D>("SuperMarioFront");
        enemyTex = content.Load<Texture2D>("enemy");
        platFormTex = content.Load<Texture2D>("wall");

        // Tex = content.Load<Texture2D>(@"");
        // Tex = content.Load<Texture2D>(@"");

    }
}