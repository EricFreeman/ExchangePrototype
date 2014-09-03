using Assets.Resources.Services.EventAggregator;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class CanvasController : MonoBehaviour, 
        IListener<AddToCanvasMessage>,
        IListener<ShowModalMessage>,
        IListener<LogoutMessage>
    {
        public Transform Content;
        public Transform Modal;

        public void Handle(AddToCanvasMessage message)
        {
            AddTo(message.Panel, Content);
        }

        public void Handle(ShowModalMessage message)
        {
            AddTo(message.Modal, Modal);
        }

        private void AddTo(string prefab, Transform parent)
        {
            var p = (GameObject)Instantiate(UnityEngine.Resources.Load(prefab));
            if (p != null) p.transform.SetParent(parent, false);
        }

        public void Handle(LogoutMessage message)
        {
            foreach (Transform child in Content)
                DestroyImmediate(child.gameObject);

            foreach (Transform child in Modal)
                DestroyImmediate(child.gameObject);
        }
    }
}