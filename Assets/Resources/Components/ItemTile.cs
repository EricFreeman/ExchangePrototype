using System.Collections.Generic;
using Assets.Resources.Models;
using Assets.Resources.Services.EventAggregator;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Components
{
    public class ItemTile : MonoBehaviour
    {
        public Item Item;

        public Text NameText;
        public Text PriceText;
        public Text ButtonText;

        private bool _isInCart;

        public void Setup(Item item, bool isInCart = false)
        {
            Item = item;
            NameText.text = item.Name;
            PriceText.text = item.Price.ToString("C");
            ButtonText.text = isInCart ? "Remove" : "Buy";
            _isInCart = isInCart;
        }

        public void ButtonClicked()
        {
            if (_isInCart)
            {
                UserModel.CartItems.Remove(Item);
                EventAggregator.SendMessage(new RemoveItemFromCartMessage { Item = Item });
            }
            else
            {
                if (UserModel.CartItems == null) UserModel.CartItems = new List<Item>();
                UserModel.CartItems.Add(Item);
            }
        }
    }
}