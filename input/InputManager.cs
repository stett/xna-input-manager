using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace input
{
    public class InputManager
    {
        #region Members
        KeyboardManager keyboard;
        #endregion


        #region Accessors
        public KeyboardManager Keyboard
        {
            get { return keyboard; }
        }
        #endregion


        #region Constructors
        public InputManager(Game game, bool add_services=true, bool add_components=true)
        {
            keyboard = new KeyboardManager(game);

            if (add_services)
            {
                game.Services.AddService(typeof(InputManager), this);
                game.Services.AddService(typeof(KeyboardManager), keyboard);
            }
            if (add_components)
            {
                game.Components.Add(keyboard);
            }
        }
        #endregion
    }
}
