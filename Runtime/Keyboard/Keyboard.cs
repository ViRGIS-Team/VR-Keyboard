using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace VrKeyboard
{
    /// <summary>
    /// Class thatcontrols the keyboard
    /// </summary>
    public class Keyboard : MonoBehaviour
    {
        public InputField OutputText;
        public UnityEvent KeyPressed = new UnityEvent();
        public UnityEvent EnterPressed = new UnityEvent();
    }
}
