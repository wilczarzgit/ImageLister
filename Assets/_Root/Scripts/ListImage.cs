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

        public void UpdateImageData(Texture2D texture, string fileName, DateTime fileDate)
        {
            var timespan = DateTime.Now - fileDate;
            var timeFromCreation = $"Created {timespan.Days} days {timespan.Hours} hours ago";

            Image.texture = texture;
            FilenameLabel.text = fileName;
            DateLabel.text = timeFromCreation;
        }
    }
}