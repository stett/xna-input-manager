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
    public class MouseManager : Microsoft.Xna.Framework.GameComponent
    {
        #region Types
        public enum ButtonState { Up, Released, Pressed, Down };
        public enum Buttons { Left, Middle, Right };
        #endregion


        #region Members
        Dictionary<Buttons, ButtonState> button_state;
        Vector2 screen_pos;
        Vector2 screen_diff;
        int scroll_pos;
        int scroll_diff;
        #endregion


        #region Constructors
        public MouseManager(Game game)
            : base(game)
        {
            button_state = new Dictionary<Buttons, ButtonState>();
            button_state[Buttons.Left] = ButtonState.Up;
            button_state[Buttons.Middle] = ButtonState.Up;
            button_state[Buttons.Right] = ButtonState.Up;
            screen_pos = new Vector2();
            screen_diff = new Vector2();
            scroll_pos = 0;
            scroll_diff = 0;
        }
        #endregion


        #region Accessors
        public Vector2 ScreenPos
        {
            get { return screen_pos; }
        }
        public Vector2 ScreenDiff
        {
            get { return screen_diff; }
        }
        public int ScrollPos
        {
            get { return scroll_pos; }
        }
        public int ScrollDiff
        {
            get { return scroll_diff; }
        }
        #endregion


        #region Overrides
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize() { base.Initialize(); }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gt">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gt)
        {
            Vector2 new_screen_pos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            screen_diff = new_screen_pos - screen_pos;
            screen_pos = new_screen_pos;

            int new_scroll_pos = Mouse.GetState().ScrollWheelValue;
            scroll_diff = new_scroll_pos - scroll_pos;
            scroll_pos = new_scroll_pos;

            update_button(Buttons.Left, Mouse.GetState().LeftButton);
            update_button(Buttons.Right, Mouse.GetState().RightButton);
            update_button(Buttons.Middle, Mouse.GetState().MiddleButton);

            base.Update(gt);
        }
        #endregion


        #region Methods
        private void update_button(Buttons button, Microsoft.Xna.Framework.Input.ButtonState xna_button)
        {
            if (xna_button == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                if (get_button_state(button) != ButtonState.Down)
                    button_state[button] = ButtonState.Pressed;
                else
                    button_state[button] = ButtonState.Down;
            }
            else
            {
                if (get_button_state(button) != ButtonState.Up)
                    button_state[button] = ButtonState.Released;
                else
                    button_state[button] = ButtonState.Up;
            }
        }
        public ButtonState get_button_state(Buttons button)
        {
            if (button_state.ContainsKey(button)) return button_state[button];
            else return ButtonState.Up;
        }

        public bool button_pressed(Buttons button) { return get_button_state(button) == ButtonState.Pressed; }
        public bool button_released(Buttons button) { return get_button_state(button) == ButtonState.Released; }
        public bool button_up(Buttons button) { return button_pressed(button) || get_button_state(button) == ButtonState.Up; }
        public bool button_down(Buttons button) { return button_released(button) || get_button_state(button) == ButtonState.Down; }
        #endregion
    }
}
