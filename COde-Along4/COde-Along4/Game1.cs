using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace COde_Along4;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player player;
    private List<GameObject> listOfGameObjects;
    // private static JObject wholeObject;
    // private static string currentFileName;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        TextureManager.LoadTexture(Content);

        listOfGameObjects = new List<GameObject>();
        // player = new Player(new Rectangle(400, 250, 50, 50));
        // listOfGameObjects.Add(player);
        // listOfGameObjects.Add(new Platform(new Rectangle(400, 300, 150, 50)));
        // listOfGameObjects.Add(new Enemy(new Rectangle(500, 275, 25, 25)));

        ReadFromFile("Level-1.json");

       
    }
     private void ReadFromFile(string fileName)
    {
        Rectangle playerRec = JsonParser.GetRectangle(fileName, "player");
        player = new Player(playerRec);
        listOfGameObjects.Add(player);
        foreach (Rectangle rec in JsonParser.HereisSHite(fileName, "platforms"))
        {
            listOfGameObjects.Add(new Platform(rec));
        }

        foreach(Rectangle rec in JsonParser.HereisSHite(fileName, "enemies"))
        {
            listOfGameObjects.Add(new Enemy(rec));
        }
    }

    
    // public static Rectangle AllInOneRec(string fileName, string propertyName)
    // {
    //     if (wholeObject == null || currentFileName == null || currentFileName != fileName)
    //     {
    //         currentFileName = fileName;
    //         StreamReader file = File.OpenText(fileName);
    //         JsonTextReader reader = new JsonTextReader(file);// detta funkar för att vi laddade ner "Json Newton grejset..."
    //         wholeObject = JObject.Load(reader);
    //         file.Close();
    //     }
    //      // player
    //     JObject obj = (JObject)wholeObject.GetValue(propertyName);
    //     int x = Convert.ToInt32(obj.GetValue("positionX"));
    //     int y = Convert.ToInt32(obj.GetValue("positionY"));
    //     int height = Convert.ToInt32(obj.GetValue("height"));
    //     int width = Convert.ToInt32(obj.GetValue("width"));
    //     return new Rectangle(x,y,width,height);
    // }

    // public static List<Rectangle> AllInOneRecList(string fileName, string propertyName)
    // {
    //     if (wholeObject == null || currentFileName == null || currentFileName != fileName)
    //     {
    //         currentFileName = fileName;
    //         StreamReader file = File.OpenText(fileName);
    //         JsonTextReader reader = new JsonTextReader(file);// detta funkar för att vi laddade ner "Json Newton grejset..."
    //         wholeObject = JObject.Load(reader);
    //         file.Close();
    //     }
    //     List<Rectangle> reclist = new List<Rectangle>();
    //     JArray arrayObject = (JArray)wholeObject.GetValue(propertyName);
    //     for (int i = 0; i <arrayObject.Count; i++)

    //     {
    //     JObject obj = (JObject)(arrayObject)[i]; 
    //     int x = Convert.ToInt32(obj.GetValue("positionX"));
    //     int y = Convert.ToInt32(obj.GetValue("positionY"));
    //     int height = Convert.ToInt32(obj.GetValue("height"));
    //     int width = Convert.ToInt32(obj.GetValue("width"));
    //     reclist.Add(new Rectangle(x,y,width,height));
    //     }
    // return reclist;
    // }

    

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        foreach (GameObject gameobject in listOfGameObjects)
        {
            gameobject.Draw(_spriteBatch);
        }
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
