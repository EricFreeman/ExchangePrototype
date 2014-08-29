using Assets.Resources.Services.EventAggregator;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class MainPanelController : MonoBehaviour, IListener<OpenScreenMessage>
    {
        public Transform ContentPanel;

        public void Handle(OpenScreenMessage message)
        {
            // remove current children
            foreach (Transform t in ContentPanel)
                DestroyImmediate(t.gameObject);

            // add new screen to content
            var screen = (GameObject)Instantiate(UnityEngine.Resources.Load("Prefabs/" + message.Screen));
            screen.transform.SetParent(ContentPanel, false);
        }
    }
}