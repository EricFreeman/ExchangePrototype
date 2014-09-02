using Assets.Resources.Services;
using Assets.Resources.Services.EventAggregator;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Components
{
    public class LoginController : MonoBehaviour
    {
        public Text Username;
        public Text Password;

        public void Login()
        {
            if (LoginService.Login(Username.text, Password.text))
            {
                EventAggregator.SendMessage(new AddToCanvasMessage { Panel = "MainPanel" });
                Destroy(gameObject);
            }
            else
            {
                // TODO: Let person know their credentials are incorrect
            }
        }
    }
}