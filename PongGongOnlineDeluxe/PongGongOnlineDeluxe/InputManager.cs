using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGongOnlineDeluxe
{
    class InputManager
    {
        private NetworkConnection networkConnection;

        public InputManager(NetworkConnection _networkConnection)
        {
            networkConnection = _networkConnection;
        }

        public void Update(double gameTime)
        {
            var state = Keyboard.GetState();
            CheckKeyState(Keys.Down, state);

        }
        private void CheckKeyState(Keys key, KeyboardState state)
        {
            if (state.IsKeyDown(key))
            {
                networkConnection.SendInput(key);
            }
        }
    }
}
