using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2DEngine.Source.Classes
{
    internal class InputAction
    {
        public string name { get; set; }
        public Keyboard.Key Key { get; set; }
        public Keyboard.Key SecKey { get; set; }

        public bool Pressing = false;
        public bool Pressed = false;


        public InputAction(string name, Keyboard.Key key)
        {
            this.name = name;
            Key = key;
            SecKey = Keyboard.Key.Unknown;
            Input.AllInputActions.Add(this.name, this);
        }

        public InputAction(string name, Keyboard.Key key, Keyboard.Key secKey)
        {
            this.name = name;
            Key = key;
            SecKey = secKey;
            Input.AllInputActions.Add(this.name, this);
        }

    }
}
