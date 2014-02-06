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
        MouseManager mouse;
        #endregion


        #region Accessors
        public KeyboardManager Keyboard
        {
            get { return keyboard; }
        }
        public MouseManager Mouse
        {
            get { return mouse; }
        }
        #endregion


        #region Constructors
        public InputManager(Game game, bool add_services = true, bool add_components = true)
        {
            keyboard = new KeyboardManager(game);
            mouse = new MouseManager(game);

            if (add_services)
            {
                game.Services.AddService(typeof(InputManager), this);
                game.Services.AddService(typeof(KeyboardManager), keyboard);
                game.Services.AddService(typeof(MouseManager), mouse);
            }
            if (add_components)
            {
                game.Components.Add(keyboard);
                game.Components.Add(mouse);
            }
        }
        #endregion
    }
}
