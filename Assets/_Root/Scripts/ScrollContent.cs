using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Scripts
{
    public class ScrollContent : MonoBehaviour
    {
        public Transform Container;
        private ScrollRect _scrollRect;
        private List<ListImage> _listImages;

        private void Awake()
        {
            _scrollRect = GetComponent<ScrollRect>();
            _listImages = new List<ListImage>();
            InvokeRepeating(nameof(Tick), 0f, 1f);
        }

        public void AddListImage(ListImage listImage)
        {
            _listImages.Add(listImage);
        }

        public void ClearContent()
        {
            Container.DestroyAllChildren();
            _listImages.Clear();
        }

        public void MoveToTop()
        {
            _scrollRect.normalizedPosition = Vector2.up;
        }

        public void Tick()
        {
            foreach (var listImage in _listImages)
            {
                listImage.RefreshTimespanLabel();
            }
        }

    }
}