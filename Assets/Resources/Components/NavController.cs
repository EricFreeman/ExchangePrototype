using UnityEngine;

namespace Assets.Resources.Components
{
    public class NavController : MonoBehaviour
    {
        void Start()
        {
            
        }

        public void NavButtonClicked(Object button)
        {
            Debug.Log(button.name);
        }
    }
}