using Assets.Resources.Models;
using Assets.Resources.Util;
using UnityEngine;

namespace Assets.Resources.Components
{
    public class Cart : MonoBehaviour
    {
        public GameObject ItemTile;

        void Start()
        {
            UserModel.CartItems.Each(x =>
            {
                var tile = (GameObject)Instantiate(ItemTile);
                tile.transform.SetParent(transform, false);
                tile.GetComponent<ItemTile>().Setup(x);
            });
        }
    }
}