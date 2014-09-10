using Assets.Resources.Services.EventAggregator;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class MainPanelController : MonoBehaviour,
        IListener<OpenScreenMessage>,
        IListener<ShowModalMessage>

    {
        public Transform ContentPanel;
        public bool _isModalOpen;

        void Start()
        {
            this.Register<OpenScreenMessage>();
            this.Register<ShowModalMessage>();
        }

        void OnDestroy()
        {
            this.UnRegister<OpenScreenMessage>();
            this.UnRegister<ShowModalMessage>();
        }

        public void Handle(OpenScreenMessage message)
        {
            // remove current children
            foreach (Transform t in ContentPanel)
                DestroyImmediate(t.gameObject);

            // add new screen to content
            var screen = (GameObject)Instantiate(UnityEngine.Resources.Load("Prefabs/" + message.Screen));
            screen.transform.SetParent(ContentPanel, false);
        }

        public void Handle(ShowModalMessage message)
        {
            if (_isModalOpen)
            {
                EventAggregator.SendMessage(new CloseModalMessage());
                _isModalOpen = false;
                return;
            }

            var p = (GameObject)Instantiate(UnityEngine.Resources.Load(message.Modal));
            if (p != null) p.transform.SetParent(ContentPanel, false);
            _isModalOpen = true;
        }
    }
}