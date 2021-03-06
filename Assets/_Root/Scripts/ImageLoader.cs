using System.IO;
using System.Text;
using _Root.ScriptableObjects;
using UnityEngine;

namespace _Root.Scripts
{
    public class ImageLoader : MonoBehaviour
    {
        public Settings Settings;
        public ScrollContent ScrollContent;
        public BottomBar BottomBar;

        private string _lastFolderHash = "";

        private void Start()
        {
            RefreshList();
            ScrollContent.MoveToTop();
            InvokeRepeating(nameof(AutoRefresh), 1f, 1f);
        }

        private void AutoRefresh()
        {
            var hash = GetHash();
            if (BottomBar.AutoRefreshToggle.isOn && !hash.Equals("") && !hash.Equals(_lastFolderHash))
            {
                RefreshList();
            }
        }

        public void RefreshList()
        {
            var dirInfo = new DirectoryInfo(Settings.FolderPath);
            if (!dirInfo.Exists)
            {
                Debug.LogError($"Could not find the folder {Settings.FolderPath}. Please check your path at Assets/_Root/ScriptableObjects/SettingsObj");
                return;
            }
            var fileInfos = dirInfo.GetFiles(Settings.FilePattern);

            ScrollContent.ClearContent();
            for (var i = 0; i < fileInfos.Length; i++)
            {
                var fileInfo = fileInfos[i];
                var byteArray = File.ReadAllBytes(fileInfo.FullName);
                var texture = new Texture2D(2,2);
                var textureLoaded = texture.LoadImage(byteArray);
                if (textureLoaded)
                {
                    var scrollElement = Instantiate(Settings.ListElementPrefab, ScrollContent.Container);
                    var listImage = scrollElement.GetComponent<ListImage>();
                    listImage.UpdateImageData(texture, fileInfo.Name, fileInfo.CreationTime, i % 2 == 0);
                    ScrollContent.AddListImage(listImage);
                }
                else
                {
                    Debug.LogError($"Unable to load file {fileInfo.Name}");
                }
            }
            _lastFolderHash = GetHash();

            Debug.Log($"List refreshed, image count: {fileInfos.Length}");
        }

        private string GetHash()
        {
            var hash = new StringBuilder();
            var dirInfo = new DirectoryInfo(Settings.FolderPath);
            if (!dirInfo.Exists)
            {
                return "";
            }
            var files = dirInfo.GetFiles(Settings.FilePattern);

            foreach (var fileInfo in files)
            {
                hash.Append(fileInfo.Name);
            }

            return hash.ToString();
        }
    }
}
