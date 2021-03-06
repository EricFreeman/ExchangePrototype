﻿using Assets.Resources.Services.EventAggregator;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class CanvasController : MonoBehaviour, 
        IListener<AddToCanvasMessage>,
        IListener<LogoutMessage>
    {
        public Transform Content;
        private bool _isModalOpen;

        void Start()
        {
            this.Register<AddToCanvasMessage>();
            this.Register<LogoutMessage>();
        }

        void OnDestroy()
        {
            this.UnRegister<AddToCanvasMessage>();
            this.UnRegister<LogoutMessage>();
        }

        public void Handle(AddToCanvasMessage message)
        {
            AddTo(message.Panel, Content);
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
        }
    }
}