using System;
using System.Collections.Generic;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OrgPer.Utils
{
    public static class KeyboardManager
    {
        //List to handle per frame key input
        private static List<Keys> keysDown = new List<Keys>();
        private static List<Keys> keysPressed = new List<Keys>();

        //Events for key inputs
        public delegate void KeyEventReturn(Keys key, InputAction action, KeyModifiers mods);
        public delegate void KeyEvent();
        private static Dictionary<Keys, List<KeyEventReturn>> keyEventReturnList = new Dictionary<Keys, List<KeyEventReturn>>();
        private static Dictionary<(Keys, InputAction), List<KeyEvent>> keyEventList = new Dictionary<(Keys, InputAction), List<KeyEvent>>();

        public static void OnKeyEvent(Keys key, InputAction action, KeyModifiers mods)
        {
            Console.WriteLine($"Key: {key} | Action {action} | KeyModifier {mods} | Time {DateTime.Now.Second}.{DateTime.Now.Millisecond}");
            switch (action)
            {
                case InputAction.Press:
                {
                    if (!keysDown.Contains(key)) keysDown.Add(key);
                    if (keysDown.Contains(key) && !keysPressed.Contains(key)) keysPressed.Add(key);
                    break;
                }
                case InputAction.Release:
                {
                    if (keysDown.Contains(key)) keysDown.Remove(key);
                    if (keysPressed.Contains(key)) keysPressed.Remove(key);
                    break;
                }
                case InputAction.Repeat:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }

            if (keyEventReturnList.ContainsKey(key)) keyEventReturnList[key].ForEach(x => x(key, action, mods));
            if (keyEventList.ContainsKey((key, action))) keyEventList[(key, action)].ForEach(x => x());
        }


        public static void AddKeyEvent(Keys key, KeyEventReturn keyEvent)
        {
            if (!keyEventReturnList.ContainsKey(key)) keyEventReturnList.Add(key, new List<KeyEventReturn>());
            keyEventReturnList[key].Add(keyEvent);
        }
        public static void AddKeyEvent(Keys key, InputAction action, KeyEvent keyEvent)
        {
            if (!keyEventList.ContainsKey((key, action))) keyEventList.Add((key, action), new List<KeyEvent>());
            keyEventList[(key, action)].Add(keyEvent);
        }

        public static void RemoveKeyEvent(Keys key, KeyEventReturn keyEvent)
        {
            if (keyEventReturnList.ContainsKey(key)) keyEventReturnList[key].RemoveAll(x => x == keyEvent);
        }
        public static void RemoveKeyEvent(Keys key, InputAction action, KeyEvent keyEvent)
        {
            if (keyEventList.ContainsKey((key, action))) keyEventList[(key, action)].RemoveAll(x => x == keyEvent);
        }

        public static bool IsKeyDown(Keys key)
        {
            return keysDown.Contains(key);
        }
        public static bool IsKeyPressed(Keys key)
        {
            if (!keysPressed.Contains(key)) return false;
            
            keysPressed.Remove(key);
            return true;
        }
    }
}
