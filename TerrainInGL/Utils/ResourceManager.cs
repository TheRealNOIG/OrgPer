using System;
using System.Collections.Generic;
using System.Text;

namespace OrgPer.Utils
{
    public static class ResourceManager
    {
        #region textures
        private static Dictionary<string, int> textures = new Dictionary<string, int>();
        private static string texturePath = "OrgPer.Textures.";

        public static Texture getTexture(string textureName)
        {
            if (!textures.ContainsKey(textureName))
            {
                Texture texture = new Texture($"{texturePath}{textureName}");
                textures.Add(textureName, texture.Handle);
            }
            return new Texture(textures[textureName]);
        }
        public static Texture getTexture(string textureName,int index, int numberOfRows)
        {
            if (!textures.ContainsKey(textureName))
            {
                Texture texture = new Texture($"{texturePath}{textureName}");
                textures.Add(textureName, texture.Handle);
            }
            return new Texture(textures[textureName], index, numberOfRows);
        }
        #endregion
    }
}
