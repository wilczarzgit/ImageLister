using System.IO;
using System.Text;
using UnityEngine;

namespace _Root.Scripts
{
    public class ImageLoader : MonoBehaviour
    {
        public GameObject ListElementPrefab;
        public ScrollContent ScrollContent;
        public BottomBar BottomBar;

        private string _lastFolderHash = "";

        private const string FILE_EXTENSION = "*.png";
        private const string RESOURCES_PATH = "Assets/Resources/";
        private const string FOLDER_PATH = "ListImages/";
        private const string FULL_PATH = RESOURCES_PATH + FOLDER_PATH;

        private void Start()
        {
            RefreshList();
            ScrollContent.MoveToTop();
            InvokeRepeating(nameof(AutoRefresh), 1f, 1f);
        }

        private void AutoRefresh()
        {
            var hash = GetHash();
            if (BottomBar.AutoRefreshToggle.isOn && !hash.Equals(_lastFolderHash))
            {
                RefreshList();
            }
        }

        public void RefreshList()
        {
            var info = new DirectoryInfo(FULL_PATH);
            var fileInfos = info.GetFiles(FILE_EXTENSION);

            ScrollContent.ClearContent();
            foreach (var fileInfo in fileInfos)
            {
                var scrollElement = Instantiate(ListElementPrefab, ScrollContent.Container);
                var listImage = scrollElement.GetComponent<ListImage>();

                var texture = Resources.Load(FOLDER_PATH + Path.GetFileNameWithoutExtension(fileInfo.Name)) as Texture2D;
                listImage.UpdateImageData(texture, fileInfo.Name, fileInfo.CreationTime);
            }
            _lastFolderHash = GetHash();

            Debug.Log($"List refreshed, image count: {fileInfos.Length}");
        }

        private string GetHash()
        {
            var hash = new StringBuilder();
            var info = new DirectoryInfo(FULL_PATH);
            var files = info.GetFiles(FILE_EXTENSION);

            foreach (var fileInfo in files)
            {
                hash.Append(fileInfo.Name);
            }

            return hash.ToString();
        }
    }
}
