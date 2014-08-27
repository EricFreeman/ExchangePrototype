using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    public class LoginScreen : MonoBehaviour
    {
        public Text Username;
        public Text Password;

        public void Login()
        {
            // TODO: Validate login info here
            if (Username.text == "eric" && Password.text == "password")
            {
                // TODO: Login functionality here
            }
        }
    }
}