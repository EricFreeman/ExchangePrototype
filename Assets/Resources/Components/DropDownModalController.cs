using UnityEngine;

namespace Assets.Resources.Components
{
    public class DropDownModalController : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private bool _isClosing;

        void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.anchoredPosition = new Vector2(0, _rectTransform.rect.height);
        }

        void Update()
        {
            if (!_isClosing && _rectTransform.anchoredPosition.y > 0)
            {
                _rectTransform.anchoredPosition = Vector2.MoveTowards(_rectTransform.anchoredPosition, Vector2.zero, 3);
            }
            else if (_isClosing && _rectTransform.anchoredPosition.y <= _rectTransform.rect.height)
            {
                _rectTransform.anchoredPosition = Vector2.MoveTowards(_rectTransform.anchoredPosition, new Vector2(0, _rectTransform.rect.height), 3);
            }
        }
    }
}