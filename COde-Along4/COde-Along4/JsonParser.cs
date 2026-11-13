using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace COde_Along4
{
    public class JsonParser
    {
        private static JObject wholeObject;
        private static string currentFileName;

        public static Rectangle GetRectangle(string fileName, string propertyName)
        {
            if (wholeObject == null || currentFileName == null || currentFileName != fileName)
            {
                getObjectFromFile(fileName);
            }


            JObject obj = (JObject)wholeObject.GetValue(propertyName);
            return GetRectangle(obj);
        }

        public static List<Rectangle> HereisSHite(string fileName, string propertyName)
        {
            if (wholeObject == null || currentFileName == null || currentFileName != fileName)
            {
                getObjectFromFile(fileName);
            }

            List<Rectangle> reclist = new List<Rectangle>();
            JArray arrayObject = (JArray)wholeObject.GetValue(propertyName);
            for (int i = 0; i < arrayObject.Count; i++)
            {
                JObject obj = (JObject)arrayObject[i];
                reclist.Add(GetRectangle(obj));
            }
            return reclist;
        }

        private static void getObjectFromFile(string fileName)
        {
            currentFileName = fileName;
            StreamReader file = File.OpenText(fileName);
            JsonTextReader reader = new JsonTextReader(file);// detta funkar för att vi laddade ner "Json Newton grejset..."
            wholeObject = JObject.Load(reader);
            file.Close();
        }

        private static Rectangle GetRectangle(JObject obj)
        {
            int x = Convert.ToInt32(obj.GetValue("positionX"));
            int y = Convert.ToInt32(obj.GetValue("positionY"));
            int height = Convert.ToInt32(obj.GetValue("height"));
            int width = Convert.ToInt32(obj.GetValue("width"));
            return new Rectangle(x, y, width, height);
        }
    }

}

