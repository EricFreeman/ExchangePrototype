using System.Collections.Generic;
using Assets.Resources.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Components
{
    public class ItemTile : MonoBehaviour
    {
        private Item _item;

        public Text NameText;
        public Text PriceText;

        public void Setup(Item item)
        {
            _item = item;
            NameText.text = item.Name;
            PriceText.text = item.Price.ToString("C");
        }

        public void AddToCart()
        {
            if(UserModel.CartItems == null) UserModel.CartItems = new List<Item>();
            UserModel.CartItems.Add(_item);
        }
    }
}