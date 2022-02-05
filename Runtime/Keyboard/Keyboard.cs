using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace VrKeyboard
{

    public enum KeyboardStatusTypes
    {
        upper,
        lower,
        other
    }

    /// <summary>
    /// Class thatcontrols the keyboard
    /// </summary>
    public class Keyboard : MonoBehaviour
    {
        public UnityEvent<string> KeyPressed = new UnityEvent<string>();
        public UnityEvent EnterPressed = new UnityEvent();
        public UnityEvent BackspacePressed = new UnityEvent();

        public UnityEvent<KeyboardStatusTypes> Status = new UnityEvent<KeyboardStatusTypes>();

        public void onKey(string text) {
            switch(text)
            {
                case "Enter":
                    onEnter();
                    break;
                case "Backspace":
                    onBackspace();
                    break;
                case "%#":
                    Status.Invoke(KeyboardStatusTypes.other);
                    break;
                case "Ab":
                    Status.Invoke(KeyboardStatusTypes.lower);
                    break;
                case "Caps":
                    Status.Invoke(KeyboardStatusTypes.upper);
                    break;
                case "Norm":
                    Status.Invoke(KeyboardStatusTypes.lower);
                    break;
                case "Space":
                    KeyPressed.Invoke(" ");
                    break;
                default:
                    KeyPressed.Invoke(text);
                    break;
            }
            
        }

        public void onEnter() {
            EnterPressed.Invoke();
        }

        public void onBackspace() {
            BackspacePressed.Invoke();
        }

    }
}
