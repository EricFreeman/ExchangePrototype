using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Resources.Models.Navigation;
using Assets.Resources.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Components
{
    public class NavController : MonoBehaviour
    {
        private readonly Dictionary<string, Action> _buttonClick = new Dictionary<string, Action>();

        void Start()
        {
            LoadNavButtons();
        }

        private void LoadNavButtons()
        {
            var buttons = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x.GetInterfaces().Contains(typeof(INavigationButton)))
                .OrderBy(x => ((INavigationButton)Activator.CreateInstance(x)).Order);

            var index = 0;

            buttons.Each(b =>
            {
                var t = (INavigationButton)Activator.CreateInstance(b);
                var prefab = (GameObject) Instantiate(UnityEngine.Resources.Load("Prefabs/NavButton"));
                prefab.GetComponentInChildren<Text>().text = t.ButtonText;
                prefab.name = t.Name;
                prefab.transform.SetParent(transform, false);

                var buttonClicked = new Button.ButtonClickedEvent();
                buttonClicked.AddListener(() => _buttonClick[prefab.name]());
                prefab.GetComponent<Button>().onClick = buttonClicked;
                _buttonClick.Add(t.Name, t.OnClick);

                var rect = prefab.GetComponent<RectTransform>();
                var width = rect.rect.xMax;
                var height = rect.rect.yMax;

                rect.anchoredPosition = new Vector2(width * index * 2 + width, -height);
                index++;
            });
        }
    }
}