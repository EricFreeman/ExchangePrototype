using System.Collections.Generic;
using Assets.Resources.Models;
using Assets.Resources.Util;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class ShopController : MonoBehaviour
    {
        public Transform ItemList;
        public GameObject ItemTile;

        private List<Item> _items;

        // Use this for initialization
        void Start()
        {
            // TODO: Load the plans in from db instead of faking them
            _items = new List<Item>
            {
                new Item {Name = "Item 1", Price = new decimal(5.55)},
                new Item {Name = "Item 2", Price = new decimal(8.75)},
                new Item {Name = "Item 3", Price = new decimal(10.09)},
                new Item {Name = "Item 4", Price = new decimal(2.22)},
                new Item {Name = "Item 5", Price = new decimal(86.75)},
                new Item {Name = "Item 6", Price = new decimal(3.09)}
            };

            UpdateItemList();
        }

        private void UpdateItemList()
        {
            var index = 0;

            _items.Each(x =>
            {
                var prefab = (GameObject)Instantiate(UnityEngine.Resources.Load("Prefabs/ItemTile"));
                prefab.GetComponent<ItemTile>().Setup(x);
                prefab.transform.SetParent(ItemList, false);

                var rect = prefab.GetComponent<RectTransform>();
                var height = rect.rect.yMin;
                rect.anchoredPosition = new Vector2(0, index * height);

                index++;
            });

            var r = ItemList.GetComponent<RectTransform>();
            r.sizeDelta = new Vector2(0, index * 64);
            r.position = new Vector2(r.position.x, 0);
        }
    }
}