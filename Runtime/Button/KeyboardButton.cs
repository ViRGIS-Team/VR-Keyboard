using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VrKeyboard.UI
{
/// <summary>
/// Handles a basic button. This is used by other functions that use buttons
/// </summary>
/// <remarks>
/// Keyboard, and dropdown heavily rely on buttons
/// </remarks>
    public class KeyboardButton : MonoBehaviour
    {
        public string UpperCaseCharacter;
        public string LowerCaseCharacter;
        public string OtherCharacter;
        public Keyboard keyboard;
        public Text text;

        private KeyboardStatusTypes m_Status = KeyboardStatusTypes.lower;

        public void onHover() {
            switch(m_Status) {
                case KeyboardStatusTypes.upper:
                    keyboard.onKey(UpperCaseCharacter);
                    break;
                case KeyboardStatusTypes.lower:
                    keyboard.onKey(LowerCaseCharacter);
                    break;
                case KeyboardStatusTypes.other:
                    keyboard.onKey(OtherCharacter);
                    break;
            }
        }

        public void Start()
        {
            keyboard.Status.AddListener(onStatus);
            onStatus(m_Status);
        }

        private void onStatus(KeyboardStatusTypes status) {
            m_Status = status;
            switch (m_Status)
            {
                case KeyboardStatusTypes.upper:
                    text.text = UpperCaseCharacter;
                    break;
                case KeyboardStatusTypes.lower:
                    text.text = LowerCaseCharacter;
                    break;
                case KeyboardStatusTypes.other:
                    text.text = OtherCharacter;
                    break;
            }

        }
    }
}
