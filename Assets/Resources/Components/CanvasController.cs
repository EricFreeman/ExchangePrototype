using Assets.Resources.Services.EventAggregator;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class CanvasController : MonoBehaviour, IListener<AddToCanvasMessage>, IListener<LogoutMessage>
    {
        public Transform Content;

        public void Handle(AddToCanvasMessage message)
        {
            var p = (GameObject)Instantiate(UnityEngine.Resources.Load("Panels/" + message.Panel));
;
            if (p != null) p.transform.SetParent(Content, false);
        }

        public void Handle(LogoutMessage message)
        {
            foreach (Transform child in Content)
                DestroyImmediate(child.gameObject);
        }
    }
}