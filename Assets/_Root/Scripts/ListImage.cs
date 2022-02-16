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

        private const string DATE_FORMAT = "MM/dd/yyyy";

        public void UpdateImageData(Texture2D texture, string fileName, DateTime fileDate)
        {
            Image.texture = texture;
            //Image.SizeToParent();
            FilenameLabel.text = fileName;
            DateLabel.text = fileDate.ToString(DATE_FORMAT);
        }
    }
}