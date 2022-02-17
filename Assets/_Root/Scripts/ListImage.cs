using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Scripts
{
    public class ListImage : MonoBehaviour
    {
        public TextMeshProUGUI FilenameLabel;
        public TextMeshProUGUI DateLabel;
        public RawImage Image;
        public Image Background;

        private DateTime _creationDate;

        public void UpdateImageData(Texture2D texture, string fileName, DateTime creationDate, bool showBkg)
        {
            Image.texture = texture;
            Image.SizeToParent();
            FilenameLabel.text = fileName;
            Background.gameObject.SetActive(showBkg);
            _creationDate = creationDate;
            RefreshTimespanLabel();
        }

        public void RefreshTimespanLabel()
        {
            var timespan = DateTime.Now - _creationDate;
            var timeFromCreation = $"Time since created: {timespan.Days}d {timespan.Hours}h {timespan.Minutes}min {timespan.Seconds}sec";
            DateLabel.text = timeFromCreation;
        }
    }
}