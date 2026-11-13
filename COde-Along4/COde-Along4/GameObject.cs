using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace COde_Along4;

public abstract class GameObject
{
    protected Rectangle size;
    protected Texture2D tex;
    public Rectangle Size
    {
        get { return size; }
    }

    public GameObject(Rectangle rec)
    {
        this.size = rec;
    }

    public abstract void Draw(SpriteBatch spriteBatch);
}