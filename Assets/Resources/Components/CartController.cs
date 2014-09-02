using UnityEngine;

namespace Assets.Resources.Components
{
    public class CartController : MonoBehaviour
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
        }
    }
}