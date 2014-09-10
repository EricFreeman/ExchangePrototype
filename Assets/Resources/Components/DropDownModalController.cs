using Assets.Resources.Services.EventAggregator;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class DropDownModalController : MonoBehaviour,
        IListener<CloseModalMessage>
    {
        private RectTransform _rectTransform;
        private bool _isClosing;

        void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.anchoredPosition = new Vector2(0, _rectTransform.rect.height);

            this.Register<CloseModalMessage>();
        }

        void OnDestroy()
        {
            this.UnRegister<CloseModalMessage>();
        }

        void Update()
        {
            if (!_isClosing && _rectTransform.anchoredPosition.y > 0)
            {
                _rectTransform.anchoredPosition = Vector2.MoveTowards(_rectTransform.anchoredPosition, Vector2.zero, 3);
            }
            else if (_isClosing)
            {
                _rectTransform.anchoredPosition = Vector2.MoveTowards(_rectTransform.anchoredPosition, new Vector2(0, _rectTransform.rect.height), 3);

                if (_isClosing && _rectTransform.position.y >= _rectTransform.rect.height * 2 + 30)
                {
                    Destroy(gameObject);
                }
            }
        }

        public void Handle(CloseModalMessage message)
        {
            _isClosing = true;
        }
    }
}