using UnityEngine;
using UnityEngine.UI;

namespace _Root.Scripts
{
    public class BottomBar : MonoBehaviour
    {
        public Toggle AutoRefreshToggle;

        private void Awake()
        {
            AutoRefreshToggle.isOn = false;
        }
    }
}
