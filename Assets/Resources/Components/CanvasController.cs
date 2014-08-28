using Assets.Resources.Services.EventAggregator;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class CanvasController : MonoBehaviour, IListener<AddToCanvasMessage>
    {
        public Transform Content;

        public void Handle(AddToCanvasMessage message)
        {
            var p = message.Panel as GameObject;
            if (p != null) p.transform.SetParent(Content, false);
        }
    }
}