using Assets.Resources.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Components
{
    public class LoginScreen : MonoBehaviour
    {
        public Text Username;
        public Text Password;

        public void Login()
        {
            if (LoginService.Login(Username.text, Password.text))
            {
                Destroy(gameObject);
                Instantiate(UnityEngine.Resources.Load("Resources/Panels/MainPanel"));
            }
            else
            {
                // TODO: Let person know their credentials are incorrect
            }
        }
    }
}