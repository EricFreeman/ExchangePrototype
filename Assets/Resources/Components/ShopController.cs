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
                new Item {Name = "Item 3", Price = new decimal(10.09)}
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
                var width = rect.rect.xMax;
                var height = rect.rect.yMax;
                rect.anchoredPosition = new Vector2(-width, -height);

                index++;
            });
        }
    }
}