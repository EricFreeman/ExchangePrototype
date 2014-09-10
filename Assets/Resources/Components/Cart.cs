using System.Linq;
using Assets.Resources.Models;
using Assets.Resources.Services.EventAggregator;
using Assets.Resources.Util;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class Cart : MonoBehaviour,
        IListener<RemoveItemFromCartMessage>
    {
        public GameObject ItemTile;

        void Start()
        {
            UserModel.CartItems.Each(x =>
            {
                var tile = (GameObject)Instantiate(ItemTile);
                tile.transform.SetParent(transform, false);
                tile.GetComponent<ItemTile>().Setup(x, true);
            });

            this.Register<RemoveItemFromCartMessage>();
        }

        void OnDestroy()
        {
            this.UnRegister<RemoveItemFromCartMessage>();
        }

        public void Handle(RemoveItemFromCartMessage message)
        {
            Destroy(GetComponentsInChildren<ItemTile>().First(x => x.Item == message.Item).gameObject);
        }
    }
}