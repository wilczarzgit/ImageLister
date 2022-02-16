using UnityEngine;
using UnityEngine.UI;

namespace _Root.Scripts
{
    public class ScrollContent : MonoBehaviour
    {
        public Transform Container;
        private ScrollRect _scrollRect;

        private void Awake()
        {
            _scrollRect = GetComponent<ScrollRect>();
        }

        public void ClearContent()
        {
            Container.DestroyAllChildren();
        }

        public void MoveToTop()
        {
            _scrollRect.normalizedPosition = Vector2.up;
        }
    }
}