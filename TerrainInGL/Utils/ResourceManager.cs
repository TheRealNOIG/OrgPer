using System;
using System.Collections.Generic;
using System.Text;

namespace OrgPer.Utils
{
    public static class ResourceManager
    {
        #region textures
        private static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        private static string texturePath = "OrgPer.Textures.";

        public static Texture getTexture(string textureName)
        {
            if (!textures.ContainsKey(textureName))
                textures.Add(textureName, new Texture($"{texturePath}{textureName}"));
            return textures[textureName];
        }
        public static Texture getTexture(string textureName,int index, int numberOfRows)
        {
            if (!textures.ContainsKey(textureName))
                textures.Add(textureName, new Texture($"{texturePath}{textureName}", index, numberOfRows));
            return textures[textureName];
        }
        #endregion
    }
}
