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
                var panel = Instantiate(UnityEngine.Resources.Load("Panels/MainPanel"));
                EventAggregator.SendMessage(new AddToCanvasMessage { Panel = panel });
                Destroy(gameObject);
            }
            else
            {
                // TODO: Let person know their credentials are incorrect
            }
        }
    }
}